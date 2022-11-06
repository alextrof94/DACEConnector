using Newtonsoft.Json;
using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using System.Windows.Threading;

namespace DACEConnector
{
	public partial class Form1 : Form
	{
        string code = "";

        string address = "https://www.donationalerts.com/";
        string addressAuth = "oauth/authorize";
        string addressToken = "oauth/token";
        string addressDonations = "api/v1/alerts/donations";

        string scope = "oauth-user-show oauth-donation-index oauth-donation-subscribe oauth-custom_alert-store oauth-goal-subscribe oauth-poll-subscribe";
        string redirectUrl = "https://turnlive.ru/da/dace.php";


        string tokenType = "";
        string expiresIn = "";
        string tokenAccess = "";
        string tokenRefresh = "";

        List<int> processedIds = new List<int>();
        List<UserDonate> userDonates = new List<UserDonate>();
        List<DonateAction> actions = new List<DonateAction>();

        string simpleKeys = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-=[];',./\\`";

        bool authorised = false;

        bool needUpdateUserList = true;

        Timer testTimer = new Timer();

        public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
            Start();
        }
        private void Start()
        {
            WriteToLog("START");
            WriteToLog("Creator: twitch.tv/GoodVrGames");

            foreach (var a in simpleKeys)
                cbButton.Items.Add(a);

            if (!string.IsNullOrEmpty(Properties.Settings.Default.userDonates))
                userDonates = JsonConvert.DeserializeObject<List<UserDonate>>(Properties.Settings.Default.userDonates);
            if (!string.IsNullOrEmpty(Properties.Settings.Default.processedIds))
                processedIds = JsonConvert.DeserializeObject<List<int>>(Properties.Settings.Default.processedIds);
            if (!string.IsNullOrEmpty(Properties.Settings.Default.actions))
                actions = JsonConvert.DeserializeObject<List<DonateAction>>(Properties.Settings.Default.actions);
            /*foreach (var a in actions) {
                if (a.ActionWindow == null)
                    a.ActionWindow = new DonateActionWindow();
                a.form = new FormForAction(); 
            }*/
            ReloadActionList();
            UpdateForms();

            if (!string.IsNullOrEmpty(Properties.Settings.Default.tokenRefresh))
            {
                tokenAccess = Properties.Settings.Default.tokenAccess;
                tokenRefresh = Properties.Settings.Default.tokenRefresh;
                tokenType = Properties.Settings.Default.tokenType;
                expiresIn = Properties.Settings.Default.expiresIn;

                WriteToLog("Exists refresh token: " + tokenRefresh);
                string url = address + addressToken;
                string bodyJson = string.Format("client_id={0}&redirect_uri={1}&client_secret={2}&code={3}&refresh_token={4}&grant_type=refresh_token",
                    HttpUtility.UrlEncode(Secret.appId), HttpUtility.UrlEncode(redirectUrl), HttpUtility.UrlEncode(Secret.appApiKey), HttpUtility.UrlEncode(code), HttpUtility.UrlEncode(tokenRefresh));
                string tokens = DoPostRequest(url, bodyJson);
                if (string.IsNullOrEmpty(tokens))
                    return;
                if (cbLogAllRequests.Checked)
                    WriteToLog(tokens);
                AuthResp resp = AuthResp.Deserialize(tokens);
                tokenAccess = resp.access_token;
                tokenRefresh = resp.refresh_token;
                tokenType = resp.token_type;
                expiresIn = resp.expires_in;

                Properties.Settings.Default.tokenAccess = tokenAccess;
                Properties.Settings.Default.tokenRefresh = tokenRefresh;
                Properties.Settings.Default.tokenType = tokenType;
                Properties.Settings.Default.expiresIn = expiresIn;
                Properties.Settings.Default.Save();

                timer1.Enabled = true;
            }
        }

		#region LOG

		private void WriteToLog(string str, bool error = false)
        {
            lbLog.Invoke(new Action(() =>
            {
                string l = DateTime.Now.ToShortTimeString() + " ";
                if (error)
                    l += "ERROR: ";
                l += str;
                lbLog.Items.Insert(0, l);
            }));
        }

        private void ClearLog()
        {
            lbLog.Invoke(new Action(() => { lbLog.Items.Clear(); }));
        }

        private void lbLog_Click(object sender, EventArgs e)
        {
            if (lbLog.SelectedIndex > -1)
            {
                rtbLog.Text = lbLog.Items[lbLog.SelectedIndex].ToString();
            }
        }

        #endregion // LOG

        #region HTTP

        private string DoPostRequest(string url, string body)
        {
            string res = "";
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(body);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    res = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                WriteToLog(ex.Message, true);
            }
            return res;
        }

        private string DoDonateRequest(string url, string bearer)
        {
            string res = "";
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + bearer);


                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    res = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                WriteToLog(ex.Message, true);
            }
            return res;
        }

        #endregion //HTTP

        private void OpenBrowser(string url)
		{
            System.Diagnostics.Process.Start(url);
		}



        /*
		private void button2_Click(object sender, EventArgs e)
		{
            string url = address + addressAuth + "?" + string.Format("client_id={0}&redirect_uri={1}&scope={2}&response_type=code",
                HttpUtility.UrlEncode(Secret.appId), HttpUtility.UrlEncode(redirectUrl), HttpUtility.UrlEncode(scope));
            if (cbLogAllRequests.Checked)
                WriteToLog(url);
            OpenBrowser(url);
        }

		private void button1_Click(object sender, EventArgs e)
		{
            try
			{
                code = tbCode.Text;
                string url = address + addressToken;
                string bodyJson = string.Format("client_id={0}&redirect_uri={1}&client_secret={2}&code={3}&grant_type=authorization_code",
                    HttpUtility.UrlEncode(Secret.appId), HttpUtility.UrlEncode(redirectUrl), HttpUtility.UrlEncode(Secret.appApiKey), HttpUtility.UrlEncode(code));
                if (cbLogAllRequests.Checked)
                    WriteToLog(url);
                if (cbLogAllRequests.Checked)
                    WriteToLog(bodyJson);
                string tokens = DoPostRequest(url, bodyJson);
                if (string.IsNullOrEmpty(tokens))
                    return;
                if (cbLogAllRequests.Checked)
                    WriteToLog(tokens);
                AuthResp resp = AuthResp.Deserialize(tokens);
                tokenAccess = resp.access_token;
                tokenRefresh = resp.refresh_token;
                tokenType = resp.token_type;
                expiresIn = resp.expires_in;

                Properties.Settings.Default.tokenAccess = tokenAccess;
                Properties.Settings.Default.tokenRefresh = tokenRefresh;
                Properties.Settings.Default.tokenType = tokenType;
                Properties.Settings.Default.expiresIn = expiresIn;
                Properties.Settings.Default.Save();

                timer1.Enabled = true;
            }
            catch (Exception ex)
			{
                WriteToLog(ex.Message, true);
			}
        }
        */

        private void timer1_Tick(object sender, EventArgs e)
		{
            try 
            {
                gbLog.Text = (gbLog.Text == "Лог Х") ? "Лог О" : "Лог Х";
                string url = address + addressDonations + "?to=20";
                string donates = DoDonateRequest(url, tokenAccess);
                donates = ConvertUnicodeEscapeSequencetoUTF8Characters(donates);
                if (cbLogAllRequests.Checked)
                    WriteToLog(donates);
                JsonSerializerSettings sett = new JsonSerializerSettings();
                sett.StringEscapeHandling = StringEscapeHandling.EscapeNonAscii;
                var resp = JsonConvert.DeserializeObject<DonateResp>(donates, sett);
                authorised = true;
                UpdateAuthorisedSection();
                foreach (var donate in resp.data)
			    {
                    if (!processedIds.Contains(donate.id))
				    {
                        DoDonate(donate);
                        needUpdateUserList = true;
				    }
                }

                if (needUpdateUserList)
                {
                    lbUsers.Items.Clear();
                    foreach (var u in userDonates)
                    {
                        lbUsers.Items.Add(u.ToString());
                    }
                    needUpdateUserList = false;
                }
            }
            catch (Exception ex)
            {
                WriteToLog(ex.Message, true);
                authorised = false;
                UpdateAuthorisedSection();
                timer1.Enabled = false;
            }
        }

		private void UpdateAuthorisedSection()
		{
			if (authorised)
			{
                buAuthorise.Text = "Авторизовано!";
			}
            else
            {
                buAuthorise.Text = "Авторизоваться";
            }
		}

		private void DoDonate(Donate donate)
		{
            processedIds.Add(donate.id);
            var ud = userDonates.Find(x => x.Username == donate.username);
            if (ud == null)
            {
                ud = new UserDonate() { Username = donate.username };
                userDonates.Add(ud);
            }
            ud.DonatedAll += donate.amount;

            foreach (var action in actions)
			{
                if (donate.amount == action.Summ)
                {
                    if (action.Enabled)
                    {
                        PressKey(action.Button);
                        if (action.DisableAfterAction)
                            action.Enabled = false;
                    }
                }

			}

            Properties.Settings.Default.userDonates = JsonConvert.SerializeObject(userDonates);
            Properties.Settings.Default.processedIds = JsonConvert.SerializeObject(processedIds);
            Properties.Settings.Default.Save();
            ReloadActionList();
        }

        private void PressKey(string key)
        {
            SendKeys.Send(key);
        }

		private static Regex _regex = new Regex(@"(\\u(?<Value>[a-zA-Z0-9]{4}))+", RegexOptions.Compiled);
        private static string ConvertUnicodeEscapeSequencetoUTF8Characters(string sourceContent)
        {
            return _regex.Replace(
                sourceContent, m =>
                {
                    var urlEncoded = m.Groups[0].Value.Replace(@"\u00", "%");
                    var urlDecoded = Regex.Unescape(urlEncoded);
                    return urlDecoded;
                }
            );
        }

        private void buTestAction_Click(object sender, EventArgs e)
        {
            if (cbButton.SelectedIndex < 0)
                return;
            if (testTimer.Enabled)
                return;
            testTimer.Interval = 10000;
            testTimer.Tick += testKeyPressTick;
            testTimer.Tag = cbButton.SelectedItem.ToString();
            testTimer.Start();
        }

        private void testKeyPressTick(object sender, EventArgs e)
		{
            if (!string.IsNullOrEmpty((string)testTimer.Tag))
                PressKey((string)testTimer.Tag);
            ((Timer)sender).Stop();
        }

        private void UpdateForms()
		{
            foreach (var a in actions)
            {
                //a.form.Show();
                a.form.MyUpdate();
            }
		}

		#region AUTHORIZATION

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
            OpenBrowser("https://turnlive.ru/da/");
        }

		private void buAuthorise_Click(object sender, EventArgs e)
		{
            if (string.IsNullOrEmpty(tbLogin.Text) || string.IsNullOrEmpty(tbPass.Text))
			{
                MessageBox.Show("Введите логин и пароль!");
                WriteToLog("Введите логин и пароль!");
                return;
			}
            string body = "app_id=0&login=" + HttpUtility.UrlEncode(tbLogin.Text) + "&pass=" + HttpUtility.UrlEncode(tbPass.Text);
            string tokens = DoPostRequest("https://turnlive.ru/da/appauth.php", body);
            tokens = HttpUtility.UrlDecode(tokens);
            WriteToLog(tokens);
            AuthResp resp = AuthResp.Deserialize(tokens);
            tokenAccess = resp.access_token;
            tokenRefresh = resp.refresh_token;
            tokenType = resp.token_type;
            expiresIn = resp.expires_in;

            Properties.Settings.Default.tokenAccess = tokenAccess;
            Properties.Settings.Default.tokenRefresh = tokenRefresh;
            Properties.Settings.Default.tokenType = tokenType;
            Properties.Settings.Default.expiresIn = expiresIn;
            Properties.Settings.Default.Save();

            timer1.Enabled = true;
        }

        private void buClearDonations_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить все записи о донатах?\r\nНесколько последних донатов заново вызовут действия.", "DACEConnector", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                userDonates = new List<UserDonate>();
                processedIds = new List<int>();
                Properties.Settings.Default.userDonates = JsonConvert.SerializeObject(userDonates);
                Properties.Settings.Default.processedIds = JsonConvert.SerializeObject(processedIds);
                Properties.Settings.Default.Save();
                ReloadActionList();
            }
        }

        #endregion // AUTHORIZATION

        #region UI

        bool shunted = false;
        private void ReloadActionList()
        {
            var ind = lbActions.SelectedIndex;
            lbActions.Items.Clear();
            foreach (var a in actions)
            {
                lbActions.Items.Add(a.ToString());
            }
            if (ind < lbActions.Items.Count)
                lbActions.SelectedIndex = ind;
            else
                lbActions.SelectedIndex = -1;
            cbEnabled.Enabled = (lbActions.SelectedIndex > -1);
            cbDisableAfter.Enabled = (lbActions.SelectedIndex > -1);
            tbName.Enabled = (lbActions.SelectedIndex > -1);
            tbSumm.Enabled = (lbActions.SelectedIndex > -1);
            cbButton.Enabled = (lbActions.SelectedIndex > -1);
        }
        private void buAddAction_Click(object sender, EventArgs e)
        {
            actions.Add(new DonateAction() { Name = "new", Summ = 127, Button = "F" });
            Properties.Settings.Default.actions = JsonConvert.SerializeObject(actions);
            Properties.Settings.Default.Save();
            ReloadActionList();
        }

        private void buDeleteAction_Click(object sender, EventArgs e)
        {
            if (lbActions.SelectedIndex < 0)
                return;
            actions.RemoveAt(lbActions.SelectedIndex);
            ReloadActionList();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (lbActions.SelectedIndex < 0)
                return;
            actions[lbActions.SelectedIndex].Name = tbName.Text;
            shunted = true;
            lbActions.Items[lbActions.SelectedIndex] = actions[lbActions.SelectedIndex].ToString();
            shunted = false;
            Properties.Settings.Default.actions = JsonConvert.SerializeObject(actions);
            Properties.Settings.Default.Save();
        }

        private void nudSumm_ValueChanged(object sender, EventArgs e)
        {
            if (lbActions.SelectedIndex < 0)
                return;
            try
            {
                actions[lbActions.SelectedIndex].Summ = decimal.Parse(tbSumm.Text);
                shunted = true;
                lbActions.Items[lbActions.SelectedIndex] = actions[lbActions.SelectedIndex].ToString();
                shunted = false;
                Properties.Settings.Default.actions = JsonConvert.SerializeObject(actions);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                WriteToLog(ex.Message);
            }
        }

        private void cbButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbActions.SelectedIndex < 0)
                return;
            actions[lbActions.SelectedIndex].Button = cbButton.SelectedItem.ToString();
            shunted = true;
            lbActions.Items[lbActions.SelectedIndex] = actions[lbActions.SelectedIndex].ToString();
            shunted = false;
            Properties.Settings.Default.actions = JsonConvert.SerializeObject(actions);
            Properties.Settings.Default.Save();
        }

        private void lbActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (shunted)
                return;
            cbEnabled.Enabled = (lbActions.SelectedIndex > -1);
            cbDisableAfter.Enabled = (lbActions.SelectedIndex > -1);
            tbName.Enabled = (lbActions.SelectedIndex > -1);
            tbSumm.Enabled = (lbActions.SelectedIndex > -1);
            cbButton.Enabled = (lbActions.SelectedIndex > -1);
            if (lbActions.SelectedIndex < 0)
                return;

            cbEnabled.Checked = actions[lbActions.SelectedIndex].Enabled;
            cbDisableAfter.Checked = actions[lbActions.SelectedIndex].DisableAfterAction;
            tbName.Text = actions[lbActions.SelectedIndex].Name;
            tbSumm.Text = actions[lbActions.SelectedIndex].Summ.ToString();
            foreach (var item in cbButton.Items)
            {
                if (item.ToString() == actions[lbActions.SelectedIndex].Button)
                    cbButton.SelectedItem = item;
            }
        }

        private void buColorTextActive_Click(object sender, EventArgs e)
        {
            if (lbActions.SelectedIndex < 0)
                return;
            colorDialog1.Color = actions[lbActions.SelectedIndex].ActionWindow.LabelActive.ColorText;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                actions[lbActions.SelectedIndex].ActionWindow.LabelActive.ColorText = colorDialog1.Color;
            }
        }

        private void cbEnabled_CheckedChanged(object sender, EventArgs e)
		{
            if (lbActions.SelectedIndex < 0)
                return;
            actions[lbActions.SelectedIndex].Enabled = cbEnabled.Checked;
            shunted = true;
            lbActions.Items[lbActions.SelectedIndex] = actions[lbActions.SelectedIndex].ToString();
            shunted = false;
            Properties.Settings.Default.actions = JsonConvert.SerializeObject(actions);
            Properties.Settings.Default.Save();
        }

		private void cbDisableAfter_CheckedChanged(object sender, EventArgs e)
        {
            if (lbActions.SelectedIndex < 0)
                return;
            actions[lbActions.SelectedIndex].DisableAfterAction = cbDisableAfter.Checked;
            shunted = true;
            lbActions.Items[lbActions.SelectedIndex] = actions[lbActions.SelectedIndex].ToString();
            shunted = false;
            Properties.Settings.Default.actions = JsonConvert.SerializeObject(actions);
            Properties.Settings.Default.Save();
        }

		#endregion // UI

	}

	public enum HttpMethod
	{
        GET, POST
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class DonateAction
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("summ")]
        public decimal Summ { get; set; }

        [JsonProperty("button")]
        public string Button { get; set; }

        [JsonProperty("disableAfterAction")]
        public bool DisableAfterAction { get; set; }

        [JsonProperty("secondActionEnabled")]
        public bool SecondActionEnabled { get; set; }

        [JsonProperty("secondActionDelay")]
        public double SecondActionDelay { get; set; }

        [JsonProperty("secondActionButton")]
        public string SecondActionButton { get; set; }

        [JsonProperty("actionWindow")]
        public DonateActionWindow ActionWindow { get; set; }

        public FormForAction form;

        public DonateAction()
		{
            ActionWindow = new DonateActionWindow();
            form = new FormForAction();
            form.parentAction = this;
        }

        public override string ToString()
        {
            return ((Enabled) ? (DisableAfterAction?"O   ":"   ") : "X   ") + Name + " " + Summ + " [" + Button + "]";
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class DonateActionWindow
    {
        [JsonProperty("labelActive")]
        public DonateActionWindowText LabelActive { get; set; }

        [JsonProperty("labelInactive")]
        public DonateActionWindowText LabelInactive { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }


        public DonateActionWindow()
        {
            LabelActive = new DonateActionWindowText();
            LabelInactive = new DonateActionWindowText();
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class DonateActionWindowText
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("colorText")]
        public Color ColorText { get; set; }

        [JsonProperty("colorBack")]
        public Color ColorBack { get; set; } 

        public DonateActionWindowText()
		{
            Text = "NO TEXT";
            ColorText = Color.Black;
            ColorBack = Color.White;
        }
    }




    [JsonObject(MemberSerialization.OptIn)]
    public class AuthResp
    {
        [JsonProperty("token_type")]
        public string token_type { get; set; }

        [JsonProperty("expires_in")]
        public string expires_in { get; set; }

        [JsonProperty("access_token")]
        public string access_token { get; set; }

        [JsonProperty("refresh_token")]
        public string refresh_token { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static AuthResp Deserialize(string jsonString)
        {
            return JsonConvert.DeserializeObject<AuthResp>(jsonString);
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class UserDonate
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("donated_all")]
        public decimal DonatedAll { get; set; }

        [JsonProperty("processed_donates")]
        public int ProcessedDonates { get; set; }

        public override string ToString()
        {
            return Username + ": [" + DonatedAll + "] [" + ProcessedDonates + "]";
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class DonateResp
    {
        [JsonProperty("data")]
        public List<Donate> data { get; set; }

        [JsonProperty("meta")]
        public Metadata meta { get; set; }

    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Metadata
    {
        [JsonProperty("title")]
        public string title { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Donate
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("message_type")]
        public string message_type { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }

        [JsonProperty("amount")]
        public decimal amount { get; set; }

        [JsonProperty("currency")]
        public string currency { get; set; }

        [JsonProperty("is_shown")]
        public int is_shown { get; set; }

        [JsonProperty("created_at")]
        public string created_at { get; set; }

        [JsonProperty("shown_at")]
        public string shown_at { get; set; }

        [JsonProperty("payin_system")]
        public PaySystem payin_system { get; set; }

        [JsonProperty("recipient")]
        public Recipient recipient { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class PaySystem
    {
        [JsonProperty("title")]
        public string title { get; set; }
    }


    [JsonObject(MemberSerialization.OptIn)]
    public class Recipient
    {
        [JsonProperty("user_id")]
        public int user_id { get; set; }

        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("avatar")]
        public string avatar { get; set; }
    }
}

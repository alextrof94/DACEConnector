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
        string redirectUrl = "http://localhost";


        string tokenType = "";
        string expiresIn = "";
        string tokenAccess = "";
        string tokenRefresh = "";

        List<int> processedIds = new List<int>();
        List<UserDonate> userDonates = new List<UserDonate>();
        List<DonateAction> actions = new List<DonateAction>();

        string simpleKeys = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-=[];',./\\`";

        public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
            Start();
        }

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

        private string DoPostRequest(string url, string body)
        {
            string res = "";
            try
            {
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

        private void OpenBrowser(string url)
		{
            System.Diagnostics.Process.Start(url);
		}


		private void Start()
        {
            WriteToLog("START");
            WriteToLog("Creator: twitch.tv/GoodVrGames");

            foreach (var a in simpleKeys)
                cbButton.Items.Add(a);

            if (!string.IsNullOrEmpty(Properties.Settings.Default.userDonates))
                userDonates = JsonConvert.DeserializeObject<List<UserDonate>>(Properties.Settings.Default.userDonates);
            if (!string.IsNullOrEmpty(Properties.Settings.Default.userDonates))
                processedIds = JsonConvert.DeserializeObject<List<int>>(Properties.Settings.Default.processedIds);
            if (!string.IsNullOrEmpty(Properties.Settings.Default.actions))
                actions = JsonConvert.DeserializeObject<List<DonateAction>>(Properties.Settings.Default.actions);
            ReloadActionList();

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

		private void lbLog_Click(object sender, EventArgs e)
		{
            if (lbLog.SelectedIndex > -1)
			{
                rtbLog.Text = lbLog.Items[lbLog.SelectedIndex].ToString();
			}
        }

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


        bool needUpdateUserList = true;

        private void timer1_Tick(object sender, EventArgs e)
		{
            try 
            { 
                string url = address + addressDonations + "?to=2";
                string donates = DoDonateRequest(url, tokenAccess);
                donates = ConvertUnicodeEscapeSequencetoUTF8Characters(donates);
                if (cbLogAllRequests.Checked)
                    WriteToLog(donates);
                JsonSerializerSettings sett = new JsonSerializerSettings();
                sett.StringEscapeHandling = StringEscapeHandling.EscapeNonAscii;
                var resp = JsonConvert.DeserializeObject<DonateResp>(donates, sett);
                foreach(var donate in resp.data)
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
                    PressKey(action.Button);
                }

			}

            Properties.Settings.Default.userDonates = JsonConvert.SerializeObject(userDonates);
            Properties.Settings.Default.processedIds = JsonConvert.SerializeObject(processedIds);
            Properties.Settings.Default.Save();
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

        Timer t = new Timer();
        private void button5_Click(object sender, EventArgs e)
        {
            if (cbButton.SelectedIndex < 0)
                return;
            if (t.Enabled)
                return;
            t.Interval = 10000;
            t.Tick += testKeyPressTick;
            t.Tag = cbButton.SelectedItem.ToString();
            t.Start();
		}

		private void testKeyPressTick(object sender, EventArgs e)
		{
            if (!string.IsNullOrEmpty((string)t.Tag))
                PressKey((string)t.Tag);
            ((Timer)sender).Stop();
        }

		private void button3_Click(object sender, EventArgs e)
		{
            actions.Add(new DonateAction() { Name="new", Summ=127, Button="F" });
            Properties.Settings.Default.actions = JsonConvert.SerializeObject(actions);
            Properties.Settings.Default.Save();
            ReloadActionList();
		}

		private void ReloadActionList()
		{
            lbActions.Items.Clear();
            foreach (var a in actions)
			{
                lbActions.Items.Add(a.ToString());
			}
            lbActions.SelectedIndex = -1;
		}

		private void button4_Click(object sender, EventArgs e)
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
            lbActions.Items[lbActions.SelectedIndex] = actions[lbActions.SelectedIndex].ToString();
            Properties.Settings.Default.actions = JsonConvert.SerializeObject(actions);
            Properties.Settings.Default.Save();
        }

		private void nudSumm_ValueChanged(object sender, EventArgs e)
        {
            if (lbActions.SelectedIndex < 0)
                return;
            try
            {
                actions[lbActions.SelectedIndex].Summ = double.Parse(tbSumm.Text);
                lbActions.Items[lbActions.SelectedIndex] = actions[lbActions.SelectedIndex].ToString();
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
            lbActions.Items[lbActions.SelectedIndex] = actions[lbActions.SelectedIndex].ToString();
            Properties.Settings.Default.actions = JsonConvert.SerializeObject(actions);
            Properties.Settings.Default.Save();
        }

		private void lbActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbActions.SelectedIndex < 0)
                return;
            tbName.Text = actions[lbActions.SelectedIndex].Name;
            tbSumm.Text = actions[lbActions.SelectedIndex].Summ.ToString();
            foreach (var item in cbButton.Items)
			{
                if (item.ToString() == actions[lbActions.SelectedIndex].Button)
                    cbButton.SelectedItem = item;
            }
        }
	}

	public enum HttpMethod
	{
        GET, POST
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
        public double DonatedAll { get; set; }

        [JsonProperty("processed_donates")]
        public int ProcessedDonates { get; set; }

        public override string ToString()
        {
            return Username + ": [" + DonatedAll + "] [" + ProcessedDonates + "]";
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class DonateAction
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("summ")]
        public double Summ { get; set; }

        [JsonProperty("button")]
        public string Button { get; set; }

        public override string ToString()
        {
            return Name + " " + Summ + " [" + Button + "]";
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
        public double amount { get; set; }

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

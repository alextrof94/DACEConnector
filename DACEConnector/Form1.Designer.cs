
namespace DACEConnector
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.lbLog = new System.Windows.Forms.ListBox();
			this.rtbLog = new System.Windows.Forms.RichTextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.lbUsers = new System.Windows.Forms.ListBox();
			this.cbLogAllRequests = new System.Windows.Forms.CheckBox();
			this.lbActions = new System.Windows.Forms.ListBox();
			this.buAddAction = new System.Windows.Forms.Button();
			this.buDeleteAction = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.buAuthorise = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.tbPass = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbLogin = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.buClearDonations = new System.Windows.Forms.Button();
			this.gbLog = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cbEnabled = new System.Windows.Forms.CheckBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.buColorBackInactive = new System.Windows.Forms.Button();
			this.buColorTextInactive = new System.Windows.Forms.Button();
			this.tbWindowTextInactive = new System.Windows.Forms.TextBox();
			this.buColorBackActive = new System.Windows.Forms.Button();
			this.buColorTextActive = new System.Windows.Forms.Button();
			this.cbWindow = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tbWindowTextActive = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.cbDisableAfter = new System.Windows.Forms.CheckBox();
			this.cbButton2 = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbSecondActionDelay = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbAddAction = new System.Windows.Forms.CheckBox();
			this.tbSumm = new System.Windows.Forms.TextBox();
			this.tbName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.buTestAction = new System.Windows.Forms.Button();
			this.cbButton = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.gbLog.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbLog
			// 
			this.lbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbLog.FormattingEnabled = true;
			this.lbLog.Location = new System.Drawing.Point(6, 42);
			this.lbLog.Name = "lbLog";
			this.lbLog.Size = new System.Drawing.Size(158, 56);
			this.lbLog.TabIndex = 0;
			this.lbLog.Click += new System.EventHandler(this.lbLog_Click);
			// 
			// rtbLog
			// 
			this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbLog.Location = new System.Drawing.Point(6, 104);
			this.rtbLog.Name = "rtbLog";
			this.rtbLog.Size = new System.Drawing.Size(158, 403);
			this.rtbLog.TabIndex = 1;
			this.rtbLog.Text = "";
			// 
			// timer1
			// 
			this.timer1.Interval = 2000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// lbUsers
			// 
			this.lbUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbUsers.FormattingEnabled = true;
			this.lbUsers.Location = new System.Drawing.Point(6, 19);
			this.lbUsers.Name = "lbUsers";
			this.lbUsers.Size = new System.Drawing.Size(206, 342);
			this.lbUsers.TabIndex = 10;
			// 
			// cbLogAllRequests
			// 
			this.cbLogAllRequests.AutoSize = true;
			this.cbLogAllRequests.Location = new System.Drawing.Point(6, 19);
			this.cbLogAllRequests.Name = "cbLogAllRequests";
			this.cbLogAllRequests.Size = new System.Drawing.Size(159, 17);
			this.cbLogAllRequests.TabIndex = 11;
			this.cbLogAllRequests.Text = "Логгировать все запросы";
			this.cbLogAllRequests.UseVisualStyleBackColor = true;
			// 
			// lbActions
			// 
			this.lbActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbActions.FormattingEnabled = true;
			this.lbActions.Location = new System.Drawing.Point(6, 19);
			this.lbActions.Name = "lbActions";
			this.lbActions.Size = new System.Drawing.Size(476, 82);
			this.lbActions.TabIndex = 12;
			this.lbActions.SelectedIndexChanged += new System.EventHandler(this.lbActions_SelectedIndexChanged);
			// 
			// buAddAction
			// 
			this.buAddAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buAddAction.Location = new System.Drawing.Point(488, 19);
			this.buAddAction.Name = "buAddAction";
			this.buAddAction.Size = new System.Drawing.Size(23, 23);
			this.buAddAction.TabIndex = 13;
			this.buAddAction.Text = "+";
			this.buAddAction.UseVisualStyleBackColor = true;
			this.buAddAction.Click += new System.EventHandler(this.buAddAction_Click);
			// 
			// buDeleteAction
			// 
			this.buDeleteAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buDeleteAction.Location = new System.Drawing.Point(488, 48);
			this.buDeleteAction.Name = "buDeleteAction";
			this.buDeleteAction.Size = new System.Drawing.Size(23, 23);
			this.buDeleteAction.TabIndex = 14;
			this.buDeleteAction.Text = "-";
			this.buDeleteAction.UseVisualStyleBackColor = true;
			this.buDeleteAction.Click += new System.EventHandler(this.buDeleteAction_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.linkLabel1);
			this.groupBox1.Controls.Add(this.buAuthorise);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.tbPass);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tbLogin);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(220, 112);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Авторизация через TurnLive.ru";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(6, 91);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(167, 13);
			this.linkLabel1.TabIndex = 5;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Открыть страницу регистрации";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// buAuthorise
			// 
			this.buAuthorise.Location = new System.Drawing.Point(9, 65);
			this.buAuthorise.Name = "buAuthorise";
			this.buAuthorise.Size = new System.Drawing.Size(203, 23);
			this.buAuthorise.TabIndex = 4;
			this.buAuthorise.Text = "Авторизоваться";
			this.buAuthorise.UseVisualStyleBackColor = true;
			this.buAuthorise.Click += new System.EventHandler(this.buAuthorise_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(6, 42);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(45, 13);
			this.label11.TabIndex = 3;
			this.label11.Text = "Пароль";
			// 
			// tbPass
			// 
			this.tbPass.Location = new System.Drawing.Point(57, 39);
			this.tbPass.Name = "tbPass";
			this.tbPass.PasswordChar = '*';
			this.tbPass.Size = new System.Drawing.Size(155, 20);
			this.tbPass.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Логин";
			// 
			// tbLogin
			// 
			this.tbLogin.Location = new System.Drawing.Point(57, 19);
			this.tbLogin.Name = "tbLogin";
			this.tbLogin.Size = new System.Drawing.Size(155, 20);
			this.tbLogin.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox2.Controls.Add(this.buClearDonations);
			this.groupBox2.Controls.Add(this.lbUsers);
			this.groupBox2.Location = new System.Drawing.Point(12, 130);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(220, 395);
			this.groupBox2.TabIndex = 16;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Пользователи - Донаты";
			// 
			// buClearDonations
			// 
			this.buClearDonations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buClearDonations.Location = new System.Drawing.Point(6, 366);
			this.buClearDonations.Name = "buClearDonations";
			this.buClearDonations.Size = new System.Drawing.Size(206, 23);
			this.buClearDonations.TabIndex = 11;
			this.buClearDonations.Text = "Очистить список донатов";
			this.buClearDonations.UseVisualStyleBackColor = true;
			this.buClearDonations.Click += new System.EventHandler(this.buClearDonations_Click);
			// 
			// gbLog
			// 
			this.gbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.gbLog.Controls.Add(this.cbLogAllRequests);
			this.gbLog.Controls.Add(this.lbLog);
			this.gbLog.Controls.Add(this.rtbLog);
			this.gbLog.Location = new System.Drawing.Point(238, 12);
			this.gbLog.Name = "gbLog";
			this.gbLog.Size = new System.Drawing.Size(170, 513);
			this.gbLog.TabIndex = 17;
			this.gbLog.TabStop = false;
			this.gbLog.Text = "Лог";
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.cbEnabled);
			this.groupBox4.Controls.Add(this.groupBox6);
			this.groupBox4.Controls.Add(this.groupBox5);
			this.groupBox4.Controls.Add(this.tbSumm);
			this.groupBox4.Controls.Add(this.tbName);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.buTestAction);
			this.groupBox4.Controls.Add(this.cbButton);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this.lbActions);
			this.groupBox4.Controls.Add(this.buAddAction);
			this.groupBox4.Controls.Add(this.buDeleteAction);
			this.groupBox4.Location = new System.Drawing.Point(414, 12);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(517, 513);
			this.groupBox4.TabIndex = 18;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Действия";
			// 
			// cbEnabled
			// 
			this.cbEnabled.AutoSize = true;
			this.cbEnabled.Enabled = false;
			this.cbEnabled.Location = new System.Drawing.Point(6, 106);
			this.cbEnabled.Name = "cbEnabled";
			this.cbEnabled.Size = new System.Drawing.Size(107, 17);
			this.cbEnabled.TabIndex = 25;
			this.cbEnabled.Text = "Кнопка активна";
			this.cbEnabled.UseVisualStyleBackColor = true;
			this.cbEnabled.CheckedChanged += new System.EventHandler(this.cbEnabled_CheckedChanged);
			// 
			// groupBox6
			// 
			this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox6.Controls.Add(this.label10);
			this.groupBox6.Controls.Add(this.label9);
			this.groupBox6.Controls.Add(this.buColorBackInactive);
			this.groupBox6.Controls.Add(this.buColorTextInactive);
			this.groupBox6.Controls.Add(this.tbWindowTextInactive);
			this.groupBox6.Controls.Add(this.buColorBackActive);
			this.groupBox6.Controls.Add(this.buColorTextActive);
			this.groupBox6.Controls.Add(this.cbWindow);
			this.groupBox6.Controls.Add(this.label7);
			this.groupBox6.Controls.Add(this.tbWindowTextActive);
			this.groupBox6.Controls.Add(this.label8);
			this.groupBox6.Location = new System.Drawing.Point(6, 334);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(505, 97);
			this.groupBox6.TabIndex = 24;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Отобразить окно об активности действия";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(442, 23);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(32, 13);
			this.label10.TabIndex = 28;
			this.label10.Text = "Цвет";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(102, 23);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(37, 13);
			this.label9.TabIndex = 27;
			this.label9.Text = "Текст";
			// 
			// buColorBackInactive
			// 
			this.buColorBackInactive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buColorBackInactive.Enabled = false;
			this.buColorBackInactive.Location = new System.Drawing.Point(475, 68);
			this.buColorBackInactive.Name = "buColorBackInactive";
			this.buColorBackInactive.Size = new System.Drawing.Size(24, 20);
			this.buColorBackInactive.TabIndex = 26;
			this.buColorBackInactive.Text = "Ф";
			this.buColorBackInactive.UseVisualStyleBackColor = true;
			// 
			// buColorTextInactive
			// 
			this.buColorTextInactive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buColorTextInactive.Enabled = false;
			this.buColorTextInactive.Location = new System.Drawing.Point(445, 68);
			this.buColorTextInactive.Name = "buColorTextInactive";
			this.buColorTextInactive.Size = new System.Drawing.Size(24, 20);
			this.buColorTextInactive.TabIndex = 25;
			this.buColorTextInactive.Text = "Т";
			this.buColorTextInactive.UseVisualStyleBackColor = true;
			// 
			// tbWindowTextInactive
			// 
			this.tbWindowTextInactive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbWindowTextInactive.Enabled = false;
			this.tbWindowTextInactive.Location = new System.Drawing.Point(105, 68);
			this.tbWindowTextInactive.Name = "tbWindowTextInactive";
			this.tbWindowTextInactive.Size = new System.Drawing.Size(334, 20);
			this.tbWindowTextInactive.TabIndex = 24;
			// 
			// buColorBackActive
			// 
			this.buColorBackActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buColorBackActive.Enabled = false;
			this.buColorBackActive.Location = new System.Drawing.Point(475, 42);
			this.buColorBackActive.Name = "buColorBackActive";
			this.buColorBackActive.Size = new System.Drawing.Size(24, 20);
			this.buColorBackActive.TabIndex = 23;
			this.buColorBackActive.Text = "Ф";
			this.buColorBackActive.UseVisualStyleBackColor = true;
			// 
			// buColorTextActive
			// 
			this.buColorTextActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buColorTextActive.Enabled = false;
			this.buColorTextActive.Location = new System.Drawing.Point(445, 42);
			this.buColorTextActive.Name = "buColorTextActive";
			this.buColorTextActive.Size = new System.Drawing.Size(24, 20);
			this.buColorTextActive.TabIndex = 22;
			this.buColorTextActive.Text = "Т";
			this.buColorTextActive.UseVisualStyleBackColor = true;
			this.buColorTextActive.Click += new System.EventHandler(this.buColorTextActive_Click);
			// 
			// cbWindow
			// 
			this.cbWindow.AutoSize = true;
			this.cbWindow.Enabled = false;
			this.cbWindow.Location = new System.Drawing.Point(6, 19);
			this.cbWindow.Name = "cbWindow";
			this.cbWindow.Size = new System.Drawing.Size(41, 17);
			this.cbWindow.TabIndex = 21;
			this.cbWindow.Text = "Да";
			this.cbWindow.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 71);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(93, 13);
			this.label7.TabIndex = 19;
			this.label7.Text = "Деактивировано";
			// 
			// tbWindowTextActive
			// 
			this.tbWindowTextActive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbWindowTextActive.Enabled = false;
			this.tbWindowTextActive.Location = new System.Drawing.Point(105, 42);
			this.tbWindowTextActive.Name = "tbWindowTextActive";
			this.tbWindowTextActive.Size = new System.Drawing.Size(334, 20);
			this.tbWindowTextActive.TabIndex = 2;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 45);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(79, 13);
			this.label8.TabIndex = 1;
			this.label8.Text = "Активировано";
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.cbDisableAfter);
			this.groupBox5.Controls.Add(this.cbButton2);
			this.groupBox5.Controls.Add(this.label6);
			this.groupBox5.Controls.Add(this.tbSecondActionDelay);
			this.groupBox5.Controls.Add(this.label5);
			this.groupBox5.Controls.Add(this.cbAddAction);
			this.groupBox5.Location = new System.Drawing.Point(6, 216);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(505, 112);
			this.groupBox5.TabIndex = 23;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Действие после";
			// 
			// cbDisableAfter
			// 
			this.cbDisableAfter.AutoSize = true;
			this.cbDisableAfter.Enabled = false;
			this.cbDisableAfter.Location = new System.Drawing.Point(6, 19);
			this.cbDisableAfter.Name = "cbDisableAfter";
			this.cbDisableAfter.Size = new System.Drawing.Size(190, 17);
			this.cbDisableAfter.TabIndex = 21;
			this.cbDisableAfter.Text = "Деактивировать после нажатия";
			this.cbDisableAfter.UseVisualStyleBackColor = true;
			this.cbDisableAfter.CheckedChanged += new System.EventHandler(this.cbDisableAfter_CheckedChanged);
			// 
			// cbButton2
			// 
			this.cbButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbButton2.Enabled = false;
			this.cbButton2.FormattingEnabled = true;
			this.cbButton2.Location = new System.Drawing.Point(63, 85);
			this.cbButton2.Name = "cbButton2";
			this.cbButton2.Size = new System.Drawing.Size(436, 21);
			this.cbButton2.TabIndex = 20;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 88);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 13);
			this.label6.TabIndex = 19;
			this.label6.Text = "Кнопка";
			// 
			// tbSecondActionDelay
			// 
			this.tbSecondActionDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSecondActionDelay.Enabled = false;
			this.tbSecondActionDelay.Location = new System.Drawing.Point(63, 59);
			this.tbSecondActionDelay.Name = "tbSecondActionDelay";
			this.tbSecondActionDelay.Size = new System.Drawing.Size(436, 20);
			this.tbSecondActionDelay.TabIndex = 2;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 62);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(58, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "Задержка";
			// 
			// cbAddAction
			// 
			this.cbAddAction.AutoSize = true;
			this.cbAddAction.Enabled = false;
			this.cbAddAction.Location = new System.Drawing.Point(6, 42);
			this.cbAddAction.Name = "cbAddAction";
			this.cbAddAction.Size = new System.Drawing.Size(242, 17);
			this.cbAddAction.TabIndex = 0;
			this.cbAddAction.Text = "Нажать ещё одну кнопку после активации";
			this.cbAddAction.UseVisualStyleBackColor = true;
			// 
			// tbSumm
			// 
			this.tbSumm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSumm.Enabled = false;
			this.tbSumm.Location = new System.Drawing.Point(69, 163);
			this.tbSumm.Name = "tbSumm";
			this.tbSumm.Size = new System.Drawing.Size(442, 20);
			this.tbSumm.TabIndex = 22;
			this.tbSumm.TextChanged += new System.EventHandler(this.nudSumm_ValueChanged);
			// 
			// tbName
			// 
			this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbName.Enabled = false;
			this.tbName.Location = new System.Drawing.Point(69, 137);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(442, 20);
			this.tbName.TabIndex = 21;
			this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 140);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 13);
			this.label4.TabIndex = 20;
			this.label4.Text = "Название";
			// 
			// buTestAction
			// 
			this.buTestAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buTestAction.Location = new System.Drawing.Point(6, 484);
			this.buTestAction.Name = "buTestAction";
			this.buTestAction.Size = new System.Drawing.Size(502, 23);
			this.buTestAction.TabIndex = 19;
			this.buTestAction.Text = "Тест через 10 секунд";
			this.buTestAction.UseVisualStyleBackColor = true;
			this.buTestAction.Click += new System.EventHandler(this.buTestAction_Click);
			// 
			// cbButton
			// 
			this.cbButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbButton.Enabled = false;
			this.cbButton.FormattingEnabled = true;
			this.cbButton.Location = new System.Drawing.Point(69, 189);
			this.cbButton.Name = "cbButton";
			this.cbButton.Size = new System.Drawing.Size(442, 21);
			this.cbButton.TabIndex = 18;
			this.cbButton.SelectedIndexChanged += new System.EventHandler(this.cbButton_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 192);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 17;
			this.label2.Text = "Кнопка";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 165);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Сумма";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(941, 537);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.gbLog);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "DACEConnector by GoodVrGames";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.gbLog.ResumeLayout(false);
			this.gbLog.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lbLog;
		private System.Windows.Forms.RichTextBox rtbLog;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ListBox lbUsers;
		private System.Windows.Forms.CheckBox cbLogAllRequests;
		private System.Windows.Forms.ListBox lbActions;
		private System.Windows.Forms.Button buAddAction;
		private System.Windows.Forms.Button buDeleteAction;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox gbLog;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox cbButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buTestAction;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbSumm;
		private System.Windows.Forms.CheckBox cbEnabled;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button buColorBackInactive;
		private System.Windows.Forms.Button buColorTextInactive;
		private System.Windows.Forms.TextBox tbWindowTextInactive;
		private System.Windows.Forms.Button buColorBackActive;
		private System.Windows.Forms.Button buColorTextActive;
		private System.Windows.Forms.CheckBox cbWindow;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbWindowTextActive;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.CheckBox cbDisableAfter;
		private System.Windows.Forms.ComboBox cbButton2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbSecondActionDelay;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox cbAddAction;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbLogin;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Button buAuthorise;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tbPass;
		private System.Windows.Forms.Button buClearDonations;
	}
}


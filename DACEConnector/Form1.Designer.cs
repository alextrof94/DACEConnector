
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
			this.label3 = new System.Windows.Forms.Label();
			this.tbCode = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.lbUsers = new System.Windows.Forms.ListBox();
			this.cbLogAllRequests = new System.Windows.Forms.CheckBox();
			this.lbActions = new System.Windows.Forms.ListBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.tbName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.cbButton = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbSumm = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbLog
			// 
			this.lbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbLog.FormattingEnabled = true;
			this.lbLog.Location = new System.Drawing.Point(6, 42);
			this.lbLog.Name = "lbLog";
			this.lbLog.Size = new System.Drawing.Size(393, 56);
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
			this.rtbLog.Size = new System.Drawing.Size(393, 88);
			this.rtbLog.TabIndex = 1;
			this.rtbLog.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 45);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "2. Code";
			// 
			// tbCode
			// 
			this.tbCode.Location = new System.Drawing.Point(6, 61);
			this.tbCode.Name = "tbCode";
			this.tbCode.PasswordChar = '*';
			this.tbCode.Size = new System.Drawing.Size(100, 20);
			this.tbCode.TabIndex = 6;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(112, 45);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 36);
			this.button1.TabIndex = 8;
			this.button1.Text = "3. Получить токен";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(6, 19);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(206, 23);
			this.button2.TabIndex = 9;
			this.button2.Text = "1. Авторизоваться в приложении";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
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
			this.lbUsers.Size = new System.Drawing.Size(206, 303);
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
			this.lbActions.Size = new System.Drawing.Size(364, 82);
			this.lbActions.TabIndex = 12;
			this.lbActions.SelectedIndexChanged += new System.EventHandler(this.lbActions_SelectedIndexChanged);
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(376, 19);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(23, 23);
			this.button3.TabIndex = 13;
			this.button3.Text = "+";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.Location = new System.Drawing.Point(376, 48);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(23, 23);
			this.button4.TabIndex = 14;
			this.button4.Text = "-";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.tbCode);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(220, 90);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Первоначальная настройка";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox2.Controls.Add(this.lbUsers);
			this.groupBox2.Location = new System.Drawing.Point(12, 108);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(220, 330);
			this.groupBox2.TabIndex = 16;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Пользователи - Донаты";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.cbLogAllRequests);
			this.groupBox3.Controls.Add(this.lbLog);
			this.groupBox3.Controls.Add(this.rtbLog);
			this.groupBox3.Location = new System.Drawing.Point(238, 240);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(405, 198);
			this.groupBox3.TabIndex = 17;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Лог";
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.tbSumm);
			this.groupBox4.Controls.Add(this.tbName);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.button5);
			this.groupBox4.Controls.Add(this.cbButton);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this.lbActions);
			this.groupBox4.Controls.Add(this.button3);
			this.groupBox4.Controls.Add(this.button4);
			this.groupBox4.Location = new System.Drawing.Point(238, 12);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(405, 222);
			this.groupBox4.TabIndex = 18;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Действия";
			// 
			// tbName
			// 
			this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbName.Location = new System.Drawing.Point(69, 108);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(330, 20);
			this.tbName.TabIndex = 21;
			this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 111);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 13);
			this.label4.TabIndex = 20;
			this.label4.Text = "Название";
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button5.Location = new System.Drawing.Point(9, 193);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(390, 23);
			this.button5.TabIndex = 19;
			this.button5.Text = "Тест через 10 секунд";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// cbButton
			// 
			this.cbButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbButton.FormattingEnabled = true;
			this.cbButton.Location = new System.Drawing.Point(53, 160);
			this.cbButton.Name = "cbButton";
			this.cbButton.Size = new System.Drawing.Size(346, 21);
			this.cbButton.TabIndex = 18;
			this.cbButton.SelectedIndexChanged += new System.EventHandler(this.cbButton_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 163);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 17;
			this.label2.Text = "Кнопка";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 136);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Сумма";
			// 
			// tbSumm
			// 
			this.tbSumm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSumm.Location = new System.Drawing.Point(69, 134);
			this.tbSumm.Name = "tbSumm";
			this.tbSumm.Size = new System.Drawing.Size(330, 20);
			this.tbSumm.TabIndex = 22;
			this.tbSumm.TextChanged += new System.EventHandler(this.nudSumm_ValueChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(653, 450);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "DACEConnector by GoodVrGames";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lbLog;
		private System.Windows.Forms.RichTextBox rtbLog;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbCode;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ListBox lbUsers;
		private System.Windows.Forms.CheckBox cbLogAllRequests;
		private System.Windows.Forms.ListBox lbActions;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox cbButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbSumm;
	}
}


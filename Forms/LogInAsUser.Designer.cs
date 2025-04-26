namespace EcoCalc_Plus
{
    partial class LogInAsUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInAsUser));
            visibleBtn = new PictureBox();
            invisibleBtn = new PictureBox();
            passwordTbx = new TextBox();
            usernameTbx = new TextBox();
            logInBtn = new Panel();
            logInBtnpic = new PictureBox();
            returnTTBtn = new PictureBox();
            loginPanel = new Panel();
            forgotPasswordLink = new Krypton.Toolkit.KryptonLinkLabel();
            customLogInMessageBox1 = new CustomLogInMessageBox();
            usernameLbl = new Label();
            passLbl = new Label();
            panelCreate = new Panel();
            returnTTpanel = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            createAccBtn = new Panel();
            createAccBtnpic = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)visibleBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)invisibleBtn).BeginInit();
            logInBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logInBtnpic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)returnTTBtn).BeginInit();
            loginPanel.SuspendLayout();
            returnTTpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            createAccBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)createAccBtnpic).BeginInit();
            SuspendLayout();
            // 
            // visibleBtn
            // 
            visibleBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            visibleBtn.BackColor = Color.DarkSeaGreen;
            visibleBtn.Image = Properties.Resources.sprite_visible;
            visibleBtn.Location = new Point(864, 332);
            visibleBtn.Name = "visibleBtn";
            visibleBtn.Size = new Size(47, 48);
            visibleBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            visibleBtn.TabIndex = 14;
            visibleBtn.TabStop = false;
            visibleBtn.Click += visibleBtn_Click;
            visibleBtn.MouseEnter += visibleBtn_MouseEnter;
            visibleBtn.MouseLeave += visibleBtn_MouseLeave;
            // 
            // invisibleBtn
            // 
            invisibleBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            invisibleBtn.BackColor = Color.DarkSeaGreen;
            invisibleBtn.Image = Properties.Resources.sprite_invisible;
            invisibleBtn.Location = new Point(864, 332);
            invisibleBtn.Name = "invisibleBtn";
            invisibleBtn.Size = new Size(47, 48);
            invisibleBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            invisibleBtn.TabIndex = 13;
            invisibleBtn.TabStop = false;
            invisibleBtn.Click += invisibleBtn_Click;
            invisibleBtn.MouseEnter += invisibleBtn_MouseEnter;
            invisibleBtn.MouseLeave += invisibleBtn_MouseLeave;
            // 
            // passwordTbx
            // 
            passwordTbx.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            passwordTbx.BackColor = Color.LightGreen;
            passwordTbx.Font = new Font("Minecraft", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordTbx.Location = new Point(164, 332);
            passwordTbx.Name = "passwordTbx";
            passwordTbx.PasswordChar = '*';
            passwordTbx.PlaceholderText = "Password";
            passwordTbx.Size = new Size(694, 48);
            passwordTbx.TabIndex = 2;
            // 
            // usernameTbx
            // 
            usernameTbx.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            usernameTbx.BackColor = Color.LightGreen;
            usernameTbx.Font = new Font("Minecraft", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameTbx.Location = new Point(165, 211);
            usernameTbx.Name = "usernameTbx";
            usernameTbx.PlaceholderText = "Username";
            usernameTbx.Size = new Size(694, 48);
            usernameTbx.TabIndex = 1;
            // 
            // logInBtn
            // 
            logInBtn.Anchor = AnchorStyles.Bottom;
            logInBtn.BackColor = Color.Transparent;
            logInBtn.Controls.Add(logInBtnpic);
            logInBtn.Location = new Point(295, 497);
            logInBtn.Name = "logInBtn";
            logInBtn.Size = new Size(447, 81);
            logInBtn.TabIndex = 5;
            // 
            // logInBtnpic
            // 
            logInBtnpic.Dock = DockStyle.Fill;
            logInBtnpic.Image = Properties.Resources.sprite_logIn;
            logInBtnpic.Location = new Point(0, 0);
            logInBtnpic.Name = "logInBtnpic";
            logInBtnpic.Size = new Size(447, 81);
            logInBtnpic.SizeMode = PictureBoxSizeMode.StretchImage;
            logInBtnpic.TabIndex = 0;
            logInBtnpic.TabStop = false;
            logInBtnpic.Click += logInBtnpic_Click;
            logInBtnpic.MouseEnter += logInBtnpic_MouseEnter;
            logInBtnpic.MouseLeave += logInBtnpic_MouseLeave;
            // 
            // returnTTBtn
            // 
            returnTTBtn.BackColor = Color.Transparent;
            returnTTBtn.Dock = DockStyle.Fill;
            returnTTBtn.Image = Properties.Resources.sprite_returnTitleOrig;
            returnTTBtn.Location = new Point(0, 0);
            returnTTBtn.Name = "returnTTBtn";
            returnTTBtn.Size = new Size(147, 145);
            returnTTBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            returnTTBtn.TabIndex = 0;
            returnTTBtn.TabStop = false;
            returnTTBtn.Click += returnTTBtn_Click;
            returnTTBtn.MouseEnter += returnTTBtn_MouseEnter;
            returnTTBtn.MouseLeave += returnTTBtn_MouseLeave;
            // 
            // loginPanel
            // 
            loginPanel.BackColor = Color.DarkGreen;
            loginPanel.Controls.Add(forgotPasswordLink);
            loginPanel.Controls.Add(customLogInMessageBox1);
            loginPanel.Controls.Add(usernameLbl);
            loginPanel.Controls.Add(passLbl);
            loginPanel.Controls.Add(panelCreate);
            loginPanel.Controls.Add(returnTTpanel);
            loginPanel.Controls.Add(pictureBox2);
            loginPanel.Controls.Add(pictureBox1);
            loginPanel.Controls.Add(visibleBtn);
            loginPanel.Controls.Add(invisibleBtn);
            loginPanel.Controls.Add(passwordTbx);
            loginPanel.Controls.Add(usernameTbx);
            loginPanel.Controls.Add(createAccBtn);
            loginPanel.Controls.Add(logInBtn);
            loginPanel.Dock = DockStyle.Fill;
            loginPanel.Location = new Point(0, 0);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(1025, 742);
            loginPanel.TabIndex = 4;
            // 
            // forgotPasswordLink
            // 
            forgotPasswordLink.Location = new Point(347, 408);
            forgotPasswordLink.Name = "forgotPasswordLink";
            forgotPasswordLink.Size = new Size(312, 33);
            forgotPasswordLink.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            forgotPasswordLink.TabIndex = 21;
            forgotPasswordLink.Values.Text = "FORGOT PASSWORD";
            forgotPasswordLink.Click += forgotPasswordLink_Click;
            forgotPasswordLink.MouseEnter += forgotPasswordLink_MouseEnter;
            forgotPasswordLink.MouseLeave += forgotPasswordLink_MouseLeave;
            // 
            // customLogInMessageBox1
            // 
            customLogInMessageBox1.Location = new Point(805, 423);
            customLogInMessageBox1.Name = "customLogInMessageBox1";
            customLogInMessageBox1.Size = new Size(1281, 928);
            customLogInMessageBox1.TabIndex = 20;
            // 
            // usernameLbl
            // 
            usernameLbl.AutoSize = true;
            usernameLbl.Font = new Font("Minecraft", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameLbl.Location = new Point(165, 171);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Size = new Size(211, 37);
            usernameLbl.TabIndex = 19;
            usernameLbl.Text = "Username";
            // 
            // passLbl
            // 
            passLbl.AutoSize = true;
            passLbl.Font = new Font("Minecraft", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passLbl.Location = new Point(165, 292);
            passLbl.Name = "passLbl";
            passLbl.Size = new Size(200, 37);
            passLbl.TabIndex = 18;
            passLbl.Text = "Password";
            // 
            // panelCreate
            // 
            panelCreate.Location = new Point(48, 500);
            panelCreate.Name = "panelCreate";
            panelCreate.Size = new Size(111, 90);
            panelCreate.TabIndex = 17;
            // 
            // returnTTpanel
            // 
            returnTTpanel.BackColor = Color.Transparent;
            returnTTpanel.Controls.Add(returnTTBtn);
            returnTTpanel.Location = new Point(3, 3);
            returnTTpanel.Name = "returnTTpanel";
            returnTTpanel.Size = new Size(147, 145);
            returnTTpanel.TabIndex = 5;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Image = Properties.Resources.sprite_lockLogo;
            pictureBox2.Location = new Point(108, 332);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(51, 48);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.sprite_userLogo;
            pictureBox1.Location = new Point(108, 211);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // createAccBtn
            // 
            createAccBtn.Anchor = AnchorStyles.Bottom;
            createAccBtn.BackColor = Color.Transparent;
            createAccBtn.Controls.Add(createAccBtnpic);
            createAccBtn.Location = new Point(295, 603);
            createAccBtn.Name = "createAccBtn";
            createAccBtn.Size = new Size(447, 81);
            createAccBtn.TabIndex = 6;
            // 
            // createAccBtnpic
            // 
            createAccBtnpic.Dock = DockStyle.Fill;
            createAccBtnpic.Image = Properties.Resources.sprite_createBtn;
            createAccBtnpic.Location = new Point(0, 0);
            createAccBtnpic.Name = "createAccBtnpic";
            createAccBtnpic.Size = new Size(447, 81);
            createAccBtnpic.SizeMode = PictureBoxSizeMode.StretchImage;
            createAccBtnpic.TabIndex = 1;
            createAccBtnpic.TabStop = false;
            createAccBtnpic.Click += createAccBtnpic_Click;
            createAccBtnpic.MouseEnter += createAccBtnpic_MouseEnter;
            createAccBtnpic.MouseLeave += createAccBtnpic_MouseLeave;
            // 
            // LogInAsUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1025, 742);
            Controls.Add(loginPanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LogInAsUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EcoCalc Plus - Log In As User";
            WindowState = FormWindowState.Maximized;
            FormClosing += LogInAsUser_FormClosing;
            Load += LogInAsUser_Load;
            ((System.ComponentModel.ISupportInitialize)visibleBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)invisibleBtn).EndInit();
            logInBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logInBtnpic).EndInit();
            ((System.ComponentModel.ISupportInitialize)returnTTBtn).EndInit();
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            returnTTpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            createAccBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)createAccBtnpic).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel logInBtn;
        private PictureBox returnTTBtn;
        private TextBox usernameTbx;
        private TextBox passwordTbx;
        private PictureBox visibleBtn;
        private PictureBox invisibleBtn;
        private PictureBox logInBtnpic;
        private Panel loginPanel;
        private Panel returnTTpanel;
        private Panel createAccBtn;
        private PictureBox createAccBtnpic;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel panelCreate;
        private Label usernameLbl;
        private Label passLbl;
        private CustomLogInMessageBox customLogInMessageBox1;
        private Krypton.Toolkit.KryptonLinkLabel forgotPasswordLink;
    }
}
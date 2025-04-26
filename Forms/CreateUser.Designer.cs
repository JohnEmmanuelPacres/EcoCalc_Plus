namespace EcoCalc_Plus
{
    partial class CreateUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateUser));
            loginPanel = new Panel();
            femaleRadioBtn = new Krypton.Toolkit.KryptonRadioButton();
            maleRadioBtn = new Krypton.Toolkit.KryptonRadioButton();
            sexLbl = new Label();
            returnTTpanel = new Panel();
            returnTTBtn = new PictureBox();
            usernameLbl = new Label();
            emailLbl = new Label();
            passLbl = new Label();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            passwordTbx = new TextBox();
            emailTbx = new TextBox();
            visibleBtn = new PictureBox();
            invisibleBtn = new PictureBox();
            usernameTbx = new TextBox();
            createAccBtn = new Panel();
            signUpBtn = new PictureBox();
            loginPanel.SuspendLayout();
            returnTTpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)returnTTBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)visibleBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)invisibleBtn).BeginInit();
            createAccBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)signUpBtn).BeginInit();
            SuspendLayout();
            // 
            // loginPanel
            // 
            loginPanel.BackColor = Color.DarkGreen;
            loginPanel.Controls.Add(femaleRadioBtn);
            loginPanel.Controls.Add(maleRadioBtn);
            loginPanel.Controls.Add(sexLbl);
            loginPanel.Controls.Add(returnTTpanel);
            loginPanel.Controls.Add(usernameLbl);
            loginPanel.Controls.Add(emailLbl);
            loginPanel.Controls.Add(passLbl);
            loginPanel.Controls.Add(pictureBox3);
            loginPanel.Controls.Add(pictureBox2);
            loginPanel.Controls.Add(pictureBox1);
            loginPanel.Controls.Add(passwordTbx);
            loginPanel.Controls.Add(emailTbx);
            loginPanel.Controls.Add(visibleBtn);
            loginPanel.Controls.Add(invisibleBtn);
            loginPanel.Controls.Add(usernameTbx);
            loginPanel.Controls.Add(createAccBtn);
            loginPanel.Dock = DockStyle.Fill;
            loginPanel.Location = new Point(0, 0);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(1025, 742);
            loginPanel.TabIndex = 6;
            // 
            // femaleRadioBtn
            // 
            femaleRadioBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            femaleRadioBtn.Location = new Point(293, 586);
            femaleRadioBtn.Name = "femaleRadioBtn";
            femaleRadioBtn.Size = new Size(131, 33);
            femaleRadioBtn.StateCommon.ShortText.Color1 = Color.Black;
            femaleRadioBtn.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            femaleRadioBtn.TabIndex = 24;
            femaleRadioBtn.Values.Text = "Female";
            // 
            // maleRadioBtn
            // 
            maleRadioBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            maleRadioBtn.Location = new Point(293, 547);
            maleRadioBtn.Name = "maleRadioBtn";
            maleRadioBtn.Size = new Size(90, 33);
            maleRadioBtn.StateCommon.ShortText.Color1 = Color.Black;
            maleRadioBtn.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            maleRadioBtn.TabIndex = 23;
            maleRadioBtn.Values.Text = "Male";
            // 
            // sexLbl
            // 
            sexLbl.AutoSize = true;
            sexLbl.Font = new Font("Minecraft", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sexLbl.Location = new Point(165, 547);
            sexLbl.Name = "sexLbl";
            sexLbl.Size = new Size(89, 37);
            sexLbl.TabIndex = 22;
            sexLbl.Text = "Sex";
            // 
            // returnTTpanel
            // 
            returnTTpanel.BackColor = Color.Transparent;
            returnTTpanel.Controls.Add(returnTTBtn);
            returnTTpanel.Location = new Point(3, 3);
            returnTTpanel.Name = "returnTTpanel";
            returnTTpanel.Size = new Size(147, 145);
            returnTTpanel.TabIndex = 7;
            // 
            // returnTTBtn
            // 
            returnTTBtn.BackColor = Color.Transparent;
            returnTTBtn.Dock = DockStyle.Fill;
            returnTTBtn.Image = Properties.Resources.sprite_returnOrig;
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
            // usernameLbl
            // 
            usernameLbl.AutoSize = true;
            usernameLbl.Font = new Font("Minecraft", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameLbl.Location = new Point(165, 171);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Size = new Size(211, 37);
            usernameLbl.TabIndex = 21;
            usernameLbl.Text = "Username";
            // 
            // emailLbl
            // 
            emailLbl.AutoSize = true;
            emailLbl.Font = new Font("Minecraft", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            emailLbl.Location = new Point(164, 292);
            emailLbl.Name = "emailLbl";
            emailLbl.Size = new Size(119, 37);
            emailLbl.TabIndex = 20;
            emailLbl.Text = "Email";
            // 
            // passLbl
            // 
            passLbl.AutoSize = true;
            passLbl.Font = new Font("Minecraft", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passLbl.Location = new Point(165, 418);
            passLbl.Name = "passLbl";
            passLbl.Size = new Size(200, 37);
            passLbl.TabIndex = 19;
            passLbl.Text = "Password";
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox3.Image = Properties.Resources.sprite_lockLogo;
            pictureBox3.Location = new Point(108, 458);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(51, 48);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 18;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Image = Properties.Resources.sprite_emailLogo;
            pictureBox2.Location = new Point(108, 332);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(51, 48);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.sprite_userLogo;
            pictureBox1.Location = new Point(108, 211);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // passwordTbx
            // 
            passwordTbx.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            passwordTbx.BackColor = Color.LightGreen;
            passwordTbx.Font = new Font("Minecraft", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordTbx.Location = new Point(165, 458);
            passwordTbx.Name = "passwordTbx";
            passwordTbx.PasswordChar = '*';
            passwordTbx.PlaceholderText = "Password";
            passwordTbx.Size = new Size(694, 48);
            passwordTbx.TabIndex = 4;
            passwordTbx.WordWrap = false;
            // 
            // emailTbx
            // 
            emailTbx.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            emailTbx.BackColor = Color.LightGreen;
            emailTbx.Font = new Font("Minecraft", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            emailTbx.Location = new Point(164, 332);
            emailTbx.Name = "emailTbx";
            emailTbx.PlaceholderText = "Email";
            emailTbx.Size = new Size(694, 48);
            emailTbx.TabIndex = 3;
            // 
            // visibleBtn
            // 
            visibleBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            visibleBtn.BackColor = Color.DarkSeaGreen;
            visibleBtn.Image = Properties.Resources.sprite_visible;
            visibleBtn.Location = new Point(864, 458);
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
            invisibleBtn.Location = new Point(865, 458);
            invisibleBtn.Name = "invisibleBtn";
            invisibleBtn.Size = new Size(47, 48);
            invisibleBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            invisibleBtn.TabIndex = 13;
            invisibleBtn.TabStop = false;
            invisibleBtn.Click += invisibleBtn_Click;
            invisibleBtn.MouseEnter += invisibleBtn_MouseEnter;
            invisibleBtn.MouseLeave += invisibleBtn_MouseLeave;
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
            usernameTbx.TabIndex = 2;
            // 
            // createAccBtn
            // 
            createAccBtn.Anchor = AnchorStyles.Bottom;
            createAccBtn.BackColor = Color.Transparent;
            createAccBtn.Controls.Add(signUpBtn);
            createAccBtn.Location = new Point(293, 649);
            createAccBtn.Name = "createAccBtn";
            createAccBtn.Size = new Size(447, 81);
            createAccBtn.TabIndex = 6;
            // 
            // signUpBtn
            // 
            signUpBtn.Dock = DockStyle.Fill;
            signUpBtn.Image = Properties.Resources.sprite_signUp;
            signUpBtn.Location = new Point(0, 0);
            signUpBtn.Name = "signUpBtn";
            signUpBtn.Size = new Size(447, 81);
            signUpBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            signUpBtn.TabIndex = 1;
            signUpBtn.TabStop = false;
            signUpBtn.Click += signUpBtnpic_Click;
            signUpBtn.MouseEnter += signUpBtn_MouseEnter;
            signUpBtn.MouseLeave += signUpBtn_MouseLeave;
            // 
            // CreateUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1025, 742);
            Controls.Add(loginPanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create an Account";
            WindowState = FormWindowState.Maximized;
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            returnTTpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)returnTTBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)visibleBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)invisibleBtn).EndInit();
            createAccBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)signUpBtn).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel loginPanel;
        private TextBox passwordTbx;
        private TextBox emailTbx;
        private PictureBox visibleBtn;
        private PictureBox invisibleBtn;
        private TextBox usernameTbx;
        private Panel createAccBtn;
        private PictureBox signUpBtn;
        private Panel returnTTpanel;
        private PictureBox returnTTBtn;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label emailLbl;
        private Label passLbl;
        private Label usernameLbl;
        private Krypton.Toolkit.KryptonRadioButton femaleRadioBtn;
        private Krypton.Toolkit.KryptonRadioButton maleRadioBtn;
        private Label sexLbl;
    }
}
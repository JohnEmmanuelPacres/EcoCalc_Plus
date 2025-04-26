namespace EcoCalc_Plus
{
    partial class TitleScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TitleScreen));
            panel1 = new Panel();
            versionLbl = new Krypton.Toolkit.KryptonLabel();
            enterLbl = new Label();
            exitPanel = new Panel();
            btn_exit = new PictureBox();
            guestPanel = new Panel();
            btn_logInAsGuest = new PictureBox();
            userPanel = new Panel();
            btn_logInAsUser = new PictureBox();
            titlePanel = new Panel();
            title = new PictureBox();
            backdrop1 = new PictureBox();
            panelLogIn = new Panel();
            panel1.SuspendLayout();
            exitPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_exit).BeginInit();
            guestPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_logInAsGuest).BeginInit();
            userPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_logInAsUser).BeginInit();
            titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)title).BeginInit();
            ((System.ComponentModel.ISupportInitialize)backdrop1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(versionLbl);
            panel1.Controls.Add(enterLbl);
            panel1.Controls.Add(exitPanel);
            panel1.Controls.Add(guestPanel);
            panel1.Controls.Add(userPanel);
            panel1.Controls.Add(titlePanel);
            panel1.Controls.Add(backdrop1);
            panel1.Controls.Add(panelLogIn);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1924, 973);
            panel1.TabIndex = 0;
            // 
            // versionLbl
            // 
            versionLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            versionLbl.Location = new Point(1683, 915);
            versionLbl.Name = "versionLbl";
            versionLbl.Size = new Size(238, 55);
            versionLbl.StateCommon.ShortText.Color1 = Color.Black;
            versionLbl.StateCommon.ShortText.Font = new Font("Minecraft", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            versionLbl.TabIndex = 19;
            versionLbl.Values.Text = "BETA 0.2";
            // 
            // enterLbl
            // 
            enterLbl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            enterLbl.AutoSize = true;
            enterLbl.Font = new Font("Minecraft", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            enterLbl.ForeColor = Color.Gray;
            enterLbl.Location = new Point(440, 508);
            enterLbl.Name = "enterLbl";
            enterLbl.Size = new Size(1078, 60);
            enterLbl.TabIndex = 4;
            enterLbl.Text = "<PRESS ANY KEYS TO CONTINUE>";
            // 
            // exitPanel
            // 
            exitPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            exitPanel.Controls.Add(btn_exit);
            exitPanel.Location = new Point(1433, 629);
            exitPanel.Name = "exitPanel";
            exitPanel.Size = new Size(437, 221);
            exitPanel.TabIndex = 4;
            // 
            // btn_exit
            // 
            btn_exit.Dock = DockStyle.Fill;
            btn_exit.Image = Properties.Resources.sprite_exit;
            btn_exit.Location = new Point(0, 0);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(437, 221);
            btn_exit.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_exit.TabIndex = 2;
            btn_exit.TabStop = false;
            btn_exit.Click += btn_exit_Click;
            btn_exit.MouseEnter += btn_exit_MouseEnter;
            btn_exit.MouseLeave += btn_exit_MouseLeave;
            // 
            // guestPanel
            // 
            guestPanel.Anchor = AnchorStyles.Bottom;
            guestPanel.Controls.Add(btn_logInAsGuest);
            guestPanel.Location = new Point(783, 629);
            guestPanel.Name = "guestPanel";
            guestPanel.Size = new Size(437, 221);
            guestPanel.TabIndex = 3;
            // 
            // btn_logInAsGuest
            // 
            btn_logInAsGuest.Dock = DockStyle.Fill;
            btn_logInAsGuest.Image = Properties.Resources.sprite_guest;
            btn_logInAsGuest.Location = new Point(0, 0);
            btn_logInAsGuest.Name = "btn_logInAsGuest";
            btn_logInAsGuest.Size = new Size(437, 221);
            btn_logInAsGuest.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_logInAsGuest.TabIndex = 2;
            btn_logInAsGuest.TabStop = false;
            btn_logInAsGuest.Click += btn_logInAsGuest_Click;
            btn_logInAsGuest.MouseEnter += btn_logInAsGuest_MouseEnter;
            btn_logInAsGuest.MouseLeave += btn_logInAsGuest_MouseLeave;
            // 
            // userPanel
            // 
            userPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            userPanel.Controls.Add(btn_logInAsUser);
            userPanel.Location = new Point(105, 629);
            userPanel.Name = "userPanel";
            userPanel.Size = new Size(437, 221);
            userPanel.TabIndex = 2;
            // 
            // btn_logInAsUser
            // 
            btn_logInAsUser.Dock = DockStyle.Fill;
            btn_logInAsUser.Image = Properties.Resources.sprite_user;
            btn_logInAsUser.Location = new Point(0, 0);
            btn_logInAsUser.Name = "btn_logInAsUser";
            btn_logInAsUser.Size = new Size(437, 221);
            btn_logInAsUser.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_logInAsUser.TabIndex = 2;
            btn_logInAsUser.TabStop = false;
            btn_logInAsUser.Click += btn_logInAsUser_Click;
            btn_logInAsUser.MouseEnter += btn_logInAsUser_MouseEnter;
            btn_logInAsUser.MouseLeave += btn_logInAsUser_MouseLeave;
            // 
            // titlePanel
            // 
            titlePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            titlePanel.Controls.Add(title);
            titlePanel.Location = new Point(12, 98);
            titlePanel.Name = "titlePanel";
            titlePanel.Size = new Size(1900, 288);
            titlePanel.TabIndex = 0;
            // 
            // title
            // 
            title.Dock = DockStyle.Fill;
            title.Image = Properties.Resources.sprite_title;
            title.Location = new Point(0, 0);
            title.Name = "title";
            title.Size = new Size(1900, 288);
            title.SizeMode = PictureBoxSizeMode.StretchImage;
            title.TabIndex = 0;
            title.TabStop = false;
            // 
            // backdrop1
            // 
            backdrop1.Dock = DockStyle.Fill;
            backdrop1.Image = Properties.Resources.backdrop_title;
            backdrop1.Location = new Point(0, 0);
            backdrop1.Name = "backdrop1";
            backdrop1.Size = new Size(1924, 973);
            backdrop1.SizeMode = PictureBoxSizeMode.StretchImage;
            backdrop1.TabIndex = 1;
            backdrop1.TabStop = false;
            // 
            // panelLogIn
            // 
            panelLogIn.Location = new Point(526, 72);
            panelLogIn.Name = "panelLogIn";
            panelLogIn.Size = new Size(1025, 742);
            panelLogIn.TabIndex = 18;
            // 
            // TitleScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 973);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TitleScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EcoCalc Plus";
            WindowState = FormWindowState.Maximized;
            Load += TitleScreen_Load;
            KeyDown += TitleScreen_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            exitPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btn_exit).EndInit();
            guestPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btn_logInAsGuest).EndInit();
            userPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btn_logInAsUser).EndInit();
            titlePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)title).EndInit();
            ((System.ComponentModel.ISupportInitialize)backdrop1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel titlePanel;
        private PictureBox backdrop1;
        private PictureBox title;
        private Panel userPanel;
        private Panel guestPanel;
        private PictureBox btn_logInAsGuest;
        private Label enterLbl;
        private PictureBox btn_logInAsUser;
        private Panel exitPanel;
        private PictureBox btn_exit;
        private Panel panelLogIn;
        private Krypton.Toolkit.KryptonLabel versionLbl;
    }
}

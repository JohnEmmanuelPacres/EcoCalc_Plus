namespace EcoCalc_Plus
{
    partial class UserDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDashboard));
            dashboardBg = new PictureBox();
            panel1 = new Panel();
            loadingOverlay = new Panel();
            loadingLabel = new Krypton.Toolkit.KryptonLabel();
            progressBar = new Krypton.Toolkit.KryptonProgressBar();
            bgmPanel = new Panel();
            bgmBtn = new PictureBox();
            gamePanel = new Panel();
            globalCarbonPanel = new Panel();
            profileLbl = new Label();
            profilePanel = new Panel();
            profileBtn = new PictureBox();
            panelAnalytics = new Panel();
            panelGlobe = new Panel();
            panelCalculator = new Panel();
            menuPanel = new Panel();
            gameBtn = new PictureBox();
            gameLbl = new Label();
            analyticsLbl = new Label();
            analyticsPanel = new Panel();
            analyticBtn = new PictureBox();
            calcFootprintLbl = new Label();
            calcPanel = new Panel();
            cfCalcBtn = new PictureBox();
            welcomeGreetLbl = new Label();
            extPanel = new Panel();
            exitAppBtn = new PictureBox();
            globalCrbnPanel = new Panel();
            globalCarbonBtn = new PictureBox();
            returnTitlePanel = new Panel();
            titleScreenBtn = new PictureBox();
            titlePanel = new Panel();
            title = new PictureBox();
            exitLbl = new Label();
            globalCarbonLbl = new Label();
            returnTSLbl = new Label();
            ((System.ComponentModel.ISupportInitialize)dashboardBg).BeginInit();
            panel1.SuspendLayout();
            loadingOverlay.SuspendLayout();
            bgmPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bgmBtn).BeginInit();
            profilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)profileBtn).BeginInit();
            menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gameBtn).BeginInit();
            analyticsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)analyticBtn).BeginInit();
            calcPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cfCalcBtn).BeginInit();
            extPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)exitAppBtn).BeginInit();
            globalCrbnPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)globalCarbonBtn).BeginInit();
            returnTitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)titleScreenBtn).BeginInit();
            titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)title).BeginInit();
            SuspendLayout();
            // 
            // dashboardBg
            // 
            dashboardBg.BackColor = Color.Transparent;
            dashboardBg.Dock = DockStyle.Fill;
            dashboardBg.Image = Properties.Resources.backdrop_dashboard;
            dashboardBg.Location = new Point(0, 0);
            dashboardBg.Name = "dashboardBg";
            dashboardBg.Size = new Size(1902, 1033);
            dashboardBg.SizeMode = PictureBoxSizeMode.StretchImage;
            dashboardBg.TabIndex = 1;
            dashboardBg.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(loadingOverlay);
            panel1.Controls.Add(progressBar);
            panel1.Controls.Add(bgmPanel);
            panel1.Controls.Add(gamePanel);
            panel1.Controls.Add(globalCarbonPanel);
            panel1.Controls.Add(profileLbl);
            panel1.Controls.Add(profilePanel);
            panel1.Controls.Add(panelAnalytics);
            panel1.Controls.Add(panelGlobe);
            panel1.Controls.Add(panelCalculator);
            panel1.Controls.Add(menuPanel);
            panel1.Controls.Add(gameLbl);
            panel1.Controls.Add(analyticsLbl);
            panel1.Controls.Add(analyticsPanel);
            panel1.Controls.Add(calcFootprintLbl);
            panel1.Controls.Add(calcPanel);
            panel1.Controls.Add(welcomeGreetLbl);
            panel1.Controls.Add(extPanel);
            panel1.Controls.Add(globalCrbnPanel);
            panel1.Controls.Add(returnTitlePanel);
            panel1.Controls.Add(titlePanel);
            panel1.Controls.Add(exitLbl);
            panel1.Controls.Add(globalCarbonLbl);
            panel1.Controls.Add(returnTSLbl);
            panel1.Controls.Add(dashboardBg);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1902, 1033);
            panel1.TabIndex = 22;
            // 
            // loadingOverlay
            // 
            loadingOverlay.Controls.Add(loadingLabel);
            loadingOverlay.Location = new Point(463, 469);
            loadingOverlay.Name = "loadingOverlay";
            loadingOverlay.Size = new Size(923, 60);
            loadingOverlay.TabIndex = 23;
            // 
            // loadingLabel
            // 
            loadingLabel.Location = new Point(38, 8);
            loadingLabel.Name = "loadingLabel";
            loadingLabel.Size = new Size(869, 40);
            loadingLabel.StateCommon.ShortText.Color1 = Color.Lime;
            loadingLabel.StateCommon.ShortText.Font = new Font("Minecraft", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loadingLabel.TabIndex = 43;
            loadingLabel.Values.Text = "LOADING GLOBAL CARBON DATA. PLEASE WAIT...";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(681, 535);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(513, 51);
            progressBar.StateCommon.Back.Color1 = Color.Green;
            progressBar.StateCommon.Content.ShortText.Font = new Font("Minecraft", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            progressBar.StateDisabled.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.OneNote;
            progressBar.StateNormal.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.OneNote;
            progressBar.TabIndex = 44;
            progressBar.Text = "SETTING UP DATA AND MAP RESOURCES";
            progressBar.Values.Text = "SETTING UP DATA AND MAP RESOURCES";
            // 
            // bgmPanel
            // 
            bgmPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bgmPanel.Controls.Add(bgmBtn);
            bgmPanel.Location = new Point(1810, 12);
            bgmPanel.Name = "bgmPanel";
            bgmPanel.Size = new Size(80, 80);
            bgmPanel.TabIndex = 42;
            // 
            // bgmBtn
            // 
            bgmBtn.BackColor = Color.Transparent;
            bgmBtn.Dock = DockStyle.Fill;
            bgmBtn.Image = Properties.Resources.sprite_Sound;
            bgmBtn.Location = new Point(0, 0);
            bgmBtn.Name = "bgmBtn";
            bgmBtn.Size = new Size(80, 80);
            bgmBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            bgmBtn.TabIndex = 39;
            bgmBtn.TabStop = false;
            bgmBtn.Click += bgmBtn_Click;
            bgmBtn.MouseEnter += bgmBtn_MouseEnter;
            bgmBtn.MouseLeave += bgmBtn_MouseLeave;
            // 
            // gamePanel
            // 
            gamePanel.Location = new Point(16, 626);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(91, 78);
            gamePanel.TabIndex = 38;
            // 
            // globalCarbonPanel
            // 
            globalCarbonPanel.Location = new Point(16, 535);
            globalCarbonPanel.Name = "globalCarbonPanel";
            globalCarbonPanel.Size = new Size(91, 78);
            globalCarbonPanel.TabIndex = 37;
            // 
            // profileLbl
            // 
            profileLbl.AutoSize = true;
            profileLbl.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            profileLbl.ForeColor = Color.White;
            profileLbl.Location = new Point(125, 109);
            profileLbl.Name = "profileLbl";
            profileLbl.Size = new Size(52, 28);
            profileLbl.TabIndex = 37;
            profileLbl.Text = "ME";
            // 
            // profilePanel
            // 
            profilePanel.Controls.Add(profileBtn);
            profilePanel.Location = new Point(106, 12);
            profilePanel.Name = "profilePanel";
            profilePanel.Size = new Size(88, 82);
            profilePanel.TabIndex = 36;
            // 
            // profileBtn
            // 
            profileBtn.Dock = DockStyle.Fill;
            profileBtn.Image = Properties.Resources.sprite_profile;
            profileBtn.Location = new Point(0, 0);
            profileBtn.Name = "profileBtn";
            profileBtn.Size = new Size(88, 82);
            profileBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            profileBtn.TabIndex = 34;
            profileBtn.TabStop = false;
            profileBtn.Click += profileBtn_Click;
            profileBtn.MouseEnter += profileBtn_MouseEnter;
            profileBtn.MouseLeave += profileBtn_MouseLeave;
            // 
            // panelAnalytics
            // 
            panelAnalytics.Location = new Point(16, 343);
            panelAnalytics.Name = "panelAnalytics";
            panelAnalytics.Size = new Size(88, 84);
            panelAnalytics.TabIndex = 24;
            // 
            // panelGlobe
            // 
            panelGlobe.Location = new Point(16, 441);
            panelGlobe.Name = "panelGlobe";
            panelGlobe.Size = new Size(91, 78);
            panelGlobe.TabIndex = 36;
            // 
            // panelCalculator
            // 
            panelCalculator.Location = new Point(16, 247);
            panelCalculator.Name = "panelCalculator";
            panelCalculator.Size = new Size(88, 84);
            panelCalculator.TabIndex = 23;
            // 
            // menuPanel
            // 
            menuPanel.Controls.Add(gameBtn);
            menuPanel.Location = new Point(12, 12);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(88, 82);
            menuPanel.TabIndex = 35;
            // 
            // gameBtn
            // 
            gameBtn.Dock = DockStyle.Fill;
            gameBtn.Image = Properties.Resources.sprite_gameLogo;
            gameBtn.Location = new Point(0, 0);
            gameBtn.Name = "gameBtn";
            gameBtn.Size = new Size(88, 82);
            gameBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            gameBtn.TabIndex = 34;
            gameBtn.TabStop = false;
            gameBtn.Click += gameBtn_Click;
            gameBtn.MouseEnter += gameBtn_MouseEnter;
            gameBtn.MouseLeave += gameBtn_MouseLeave;
            // 
            // gameLbl
            // 
            gameLbl.AutoSize = true;
            gameLbl.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gameLbl.ForeColor = Color.White;
            gameLbl.Location = new Point(12, 109);
            gameLbl.Name = "gameLbl";
            gameLbl.Size = new Size(90, 28);
            gameLbl.TabIndex = 0;
            gameLbl.Text = "PLAY";
            // 
            // analyticsLbl
            // 
            analyticsLbl.Anchor = AnchorStyles.Bottom;
            analyticsLbl.AutoSize = true;
            analyticsLbl.Font = new Font("Minecraft", 25.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            analyticsLbl.ForeColor = Color.Gold;
            analyticsLbl.Location = new Point(520, 841);
            analyticsLbl.Name = "analyticsLbl";
            analyticsLbl.Size = new Size(215, 86);
            analyticsLbl.TabIndex = 33;
            analyticsLbl.Text = "Footprint\r\nAnalytics";
            analyticsLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // analyticsPanel
            // 
            analyticsPanel.Anchor = AnchorStyles.Bottom;
            analyticsPanel.Controls.Add(analyticBtn);
            analyticsPanel.Location = new Point(520, 622);
            analyticsPanel.Name = "analyticsPanel";
            analyticsPanel.Size = new Size(214, 212);
            analyticsPanel.TabIndex = 25;
            // 
            // analyticBtn
            // 
            analyticBtn.Dock = DockStyle.Fill;
            analyticBtn.Image = Properties.Resources.sprite_analyticsBtn;
            analyticBtn.Location = new Point(0, 0);
            analyticBtn.Name = "analyticBtn";
            analyticBtn.Size = new Size(214, 212);
            analyticBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            analyticBtn.TabIndex = 4;
            analyticBtn.TabStop = false;
            analyticBtn.Click += analyticBtn_Click;
            analyticBtn.MouseEnter += analyticBtn_MouseEnter;
            analyticBtn.MouseLeave += analyticBtn_MouseLeave;
            // 
            // calcFootprintLbl
            // 
            calcFootprintLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            calcFootprintLbl.AutoSize = true;
            calcFootprintLbl.Font = new Font("Minecraft", 25.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            calcFootprintLbl.ForeColor = Color.Lime;
            calcFootprintLbl.Location = new Point(172, 841);
            calcFootprintLbl.Name = "calcFootprintLbl";
            calcFootprintLbl.Size = new Size(240, 129);
            calcFootprintLbl.TabIndex = 32;
            calcFootprintLbl.Text = "Carbon \r\nFootprint \r\nCalculator";
            calcFootprintLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // calcPanel
            // 
            calcPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            calcPanel.Controls.Add(cfCalcBtn);
            calcPanel.Location = new Point(184, 622);
            calcPanel.Name = "calcPanel";
            calcPanel.Size = new Size(214, 212);
            calcPanel.TabIndex = 31;
            // 
            // cfCalcBtn
            // 
            cfCalcBtn.Dock = DockStyle.Fill;
            cfCalcBtn.Image = Properties.Resources.sprite_calculatorBtn;
            cfCalcBtn.Location = new Point(0, 0);
            cfCalcBtn.Name = "cfCalcBtn";
            cfCalcBtn.Size = new Size(214, 212);
            cfCalcBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            cfCalcBtn.TabIndex = 3;
            cfCalcBtn.TabStop = false;
            cfCalcBtn.Click += cfCalcBtn_Click;
            cfCalcBtn.MouseEnter += cfCalcBtn_MouseEnter;
            cfCalcBtn.MouseLeave += cfCalcBtn_MouseLeave;
            // 
            // welcomeGreetLbl
            // 
            welcomeGreetLbl.AutoSize = true;
            welcomeGreetLbl.Font = new Font("8-bit Arcade In", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            welcomeGreetLbl.ForeColor = Color.SaddleBrown;
            welcomeGreetLbl.Location = new Point(267, 30);
            welcomeGreetLbl.Name = "welcomeGreetLbl";
            welcomeGreetLbl.Size = new Size(536, 54);
            welcomeGreetLbl.TabIndex = 22;
            welcomeGreetLbl.Text = "Welcome, User!";
            // 
            // extPanel
            // 
            extPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            extPanel.Controls.Add(exitAppBtn);
            extPanel.Location = new Point(1516, 622);
            extPanel.Name = "extPanel";
            extPanel.Size = new Size(214, 212);
            extPanel.TabIndex = 26;
            // 
            // exitAppBtn
            // 
            exitAppBtn.Dock = DockStyle.Fill;
            exitAppBtn.Image = Properties.Resources.sprite_exitBtn;
            exitAppBtn.Location = new Point(0, 0);
            exitAppBtn.Name = "exitAppBtn";
            exitAppBtn.Size = new Size(214, 212);
            exitAppBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            exitAppBtn.TabIndex = 6;
            exitAppBtn.TabStop = false;
            exitAppBtn.Click += exitAppBtn_Click;
            exitAppBtn.MouseEnter += exitAppBtn_MouseEnter;
            exitAppBtn.MouseLeave += exitAppBtn_MouseLeave;
            // 
            // globalCrbnPanel
            // 
            globalCrbnPanel.Anchor = AnchorStyles.Bottom;
            globalCrbnPanel.Controls.Add(globalCarbonBtn);
            globalCrbnPanel.Location = new Point(1202, 622);
            globalCrbnPanel.Name = "globalCrbnPanel";
            globalCrbnPanel.Size = new Size(214, 212);
            globalCrbnPanel.TabIndex = 25;
            // 
            // globalCarbonBtn
            // 
            globalCarbonBtn.Dock = DockStyle.Fill;
            globalCarbonBtn.Image = Properties.Resources.sprite_earthBtn;
            globalCarbonBtn.Location = new Point(0, 0);
            globalCarbonBtn.Name = "globalCarbonBtn";
            globalCarbonBtn.Size = new Size(214, 212);
            globalCarbonBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            globalCarbonBtn.TabIndex = 5;
            globalCarbonBtn.TabStop = false;
            globalCarbonBtn.Click += globalCarbonBtn_Click;
            globalCarbonBtn.MouseEnter += globalCarbonBtn_MouseEnter;
            globalCarbonBtn.MouseLeave += globalCarbonBtn_MouseLeave;
            // 
            // returnTitlePanel
            // 
            returnTitlePanel.Anchor = AnchorStyles.Bottom;
            returnTitlePanel.Controls.Add(titleScreenBtn);
            returnTitlePanel.Location = new Point(860, 626);
            returnTitlePanel.Name = "returnTitlePanel";
            returnTitlePanel.Size = new Size(214, 212);
            returnTitlePanel.TabIndex = 24;
            // 
            // titleScreenBtn
            // 
            titleScreenBtn.Dock = DockStyle.Fill;
            titleScreenBtn.Image = Properties.Resources.sprite_titleScreenBtn;
            titleScreenBtn.Location = new Point(0, 0);
            titleScreenBtn.Name = "titleScreenBtn";
            titleScreenBtn.Size = new Size(214, 212);
            titleScreenBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            titleScreenBtn.TabIndex = 4;
            titleScreenBtn.TabStop = false;
            titleScreenBtn.Click += titleScreenBtn_Click;
            titleScreenBtn.MouseEnter += titleScreenBtn_MouseEnter;
            titleScreenBtn.MouseLeave += titleScreenBtn_MouseLeave;
            // 
            // titlePanel
            // 
            titlePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            titlePanel.Controls.Add(title);
            titlePanel.Location = new Point(183, 87);
            titlePanel.Name = "titlePanel";
            titlePanel.Size = new Size(1546, 340);
            titlePanel.TabIndex = 22;
            // 
            // title
            // 
            title.Dock = DockStyle.Fill;
            title.Image = Properties.Resources.sprite_title;
            title.Location = new Point(0, 0);
            title.Name = "title";
            title.Size = new Size(1546, 340);
            title.SizeMode = PictureBoxSizeMode.StretchImage;
            title.TabIndex = 0;
            title.TabStop = false;
            // 
            // exitLbl
            // 
            exitLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            exitLbl.AutoSize = true;
            exitLbl.Font = new Font("Minecraft", 25.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitLbl.ForeColor = Color.Red;
            exitLbl.Location = new Point(1577, 841);
            exitLbl.Name = "exitLbl";
            exitLbl.Size = new Size(105, 43);
            exitLbl.TabIndex = 30;
            exitLbl.Text = "Exit";
            exitLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // globalCarbonLbl
            // 
            globalCarbonLbl.Anchor = AnchorStyles.Bottom;
            globalCarbonLbl.AutoSize = true;
            globalCarbonLbl.Font = new Font("Minecraft", 25.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            globalCarbonLbl.ForeColor = Color.Cyan;
            globalCarbonLbl.Location = new Point(1213, 841);
            globalCarbonLbl.Name = "globalCarbonLbl";
            globalCarbonLbl.Size = new Size(203, 129);
            globalCarbonLbl.TabIndex = 29;
            globalCarbonLbl.Text = "Global \r\nCarbon\r\nEmission";
            globalCarbonLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // returnTSLbl
            // 
            returnTSLbl.Anchor = AnchorStyles.Bottom;
            returnTSLbl.AutoSize = true;
            returnTSLbl.Font = new Font("Minecraft", 25.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            returnTSLbl.ForeColor = Color.Azure;
            returnTSLbl.Location = new Point(844, 841);
            returnTSLbl.Name = "returnTSLbl";
            returnTSLbl.Size = new Size(257, 86);
            returnTSLbl.TabIndex = 28;
            returnTSLbl.Text = "Return to\r\nTitlescreen\r\n";
            returnTSLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UserDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EcoCalc Plus - User";
            WindowState = FormWindowState.Maximized;
            Load += UserDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dashboardBg).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            loadingOverlay.ResumeLayout(false);
            loadingOverlay.PerformLayout();
            bgmPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bgmBtn).EndInit();
            profilePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)profileBtn).EndInit();
            menuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gameBtn).EndInit();
            analyticsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)analyticBtn).EndInit();
            calcPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cfCalcBtn).EndInit();
            extPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)exitAppBtn).EndInit();
            globalCrbnPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)globalCarbonBtn).EndInit();
            returnTitlePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)titleScreenBtn).EndInit();
            titlePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)title).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox dashboardBg;
        private Panel panel1;
        private Label welcomeGreetLbl;
        private Panel extPanel;
        private PictureBox exitAppBtn;
        private Panel globalCrbnPanel;
        private PictureBox globalCarbonBtn;
        private Panel returnTitlePanel;
        private PictureBox titleScreenBtn;
        private Panel titlePanel;
        private PictureBox title;
        private Label exitLbl;
        private Label globalCarbonLbl;
        private Label returnTSLbl;
        private Label calcFootprintLbl;
        private Panel calcPanel;
        private PictureBox cfCalcBtn;
        private Label analyticsLbl;
        private Panel analyticsPanel;
        private PictureBox analyticBtn;
        private PictureBox gameBtn;
        private Label gameLbl;
        private Panel menuPanel;
        private Panel panelCalculator;
        private Panel panelGlobe;
        private Panel panelAnalytics;
        private Label profileLbl;
        private Panel profilePanel;
        private PictureBox profileBtn;
        private Panel globalCarbonPanel;
        private Panel gamePanel;
        private Panel bgmPanel;
        private PictureBox bgmBtn;
        private Krypton.Toolkit.KryptonLabel loadingLabel;
        private Krypton.Toolkit.KryptonProgressBar progressBar;
        private Panel loadingOverlay;
    }
}
namespace EcoCalc_Plus
{
    partial class GuestDashboard
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuestDashboard));
            dashboardBg = new PictureBox();
            sidebarTransition = new System.Windows.Forms.Timer(components);
            bgPanel = new Panel();
            bgmPanel = new Panel();
            bgmBtn = new PictureBox();
            panelCalculator = new Panel();
            welcomeGreetLbl = new Label();
            exitLbl = new Label();
            returnTSLbl = new Label();
            calcFootprintLbl = new Label();
            extPanel = new Panel();
            exitAppBtn = new PictureBox();
            returnTitlePanel = new Panel();
            titleScreenBtn = new PictureBox();
            calcPanel = new Panel();
            cfCalcBtn = new PictureBox();
            titlePanel = new Panel();
            title = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dashboardBg).BeginInit();
            bgPanel.SuspendLayout();
            bgmPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bgmBtn).BeginInit();
            extPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)exitAppBtn).BeginInit();
            returnTitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)titleScreenBtn).BeginInit();
            calcPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cfCalcBtn).BeginInit();
            titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)title).BeginInit();
            SuspendLayout();
            // 
            // dashboardBg
            // 
            dashboardBg.Dock = DockStyle.Fill;
            dashboardBg.Image = Properties.Resources.backdrop_dashboard;
            dashboardBg.Location = new Point(0, 0);
            dashboardBg.Name = "dashboardBg";
            dashboardBg.Size = new Size(1902, 1033);
            dashboardBg.SizeMode = PictureBoxSizeMode.StretchImage;
            dashboardBg.TabIndex = 0;
            dashboardBg.TabStop = false;
            // 
            // bgPanel
            // 
            bgPanel.BackColor = Color.Transparent;
            bgPanel.Controls.Add(bgmPanel);
            bgPanel.Controls.Add(panelCalculator);
            bgPanel.Controls.Add(welcomeGreetLbl);
            bgPanel.Controls.Add(exitLbl);
            bgPanel.Controls.Add(returnTSLbl);
            bgPanel.Controls.Add(calcFootprintLbl);
            bgPanel.Controls.Add(extPanel);
            bgPanel.Controls.Add(returnTitlePanel);
            bgPanel.Controls.Add(calcPanel);
            bgPanel.Controls.Add(titlePanel);
            bgPanel.Controls.Add(dashboardBg);
            bgPanel.Dock = DockStyle.Fill;
            bgPanel.Location = new Point(0, 0);
            bgPanel.Name = "bgPanel";
            bgPanel.Size = new Size(1902, 1033);
            bgPanel.TabIndex = 2;
            // 
            // bgmPanel
            // 
            bgmPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bgmPanel.Controls.Add(bgmBtn);
            bgmPanel.Location = new Point(1810, 12);
            bgmPanel.Name = "bgmPanel";
            bgmPanel.Size = new Size(80, 80);
            bgmPanel.TabIndex = 43;
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
            // panelCalculator
            // 
            panelCalculator.Location = new Point(71, 373);
            panelCalculator.Name = "panelCalculator";
            panelCalculator.Size = new Size(88, 84);
            panelCalculator.TabIndex = 24;
            // 
            // welcomeGreetLbl
            // 
            welcomeGreetLbl.AutoSize = true;
            welcomeGreetLbl.Font = new Font("8-bit Arcade In", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            welcomeGreetLbl.ForeColor = Color.SaddleBrown;
            welcomeGreetLbl.Location = new Point(183, 30);
            welcomeGreetLbl.Name = "welcomeGreetLbl";
            welcomeGreetLbl.Size = new Size(577, 54);
            welcomeGreetLbl.TabIndex = 23;
            welcomeGreetLbl.Text = "Welcome, Guest!";
            // 
            // exitLbl
            // 
            exitLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            exitLbl.AutoSize = true;
            exitLbl.Font = new Font("Minecraft", 25.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitLbl.ForeColor = Color.Red;
            exitLbl.Location = new Point(1576, 865);
            exitLbl.Name = "exitLbl";
            exitLbl.Size = new Size(105, 43);
            exitLbl.TabIndex = 17;
            exitLbl.Text = "Exit";
            exitLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // returnTSLbl
            // 
            returnTSLbl.Anchor = AnchorStyles.Bottom;
            returnTSLbl.AutoSize = true;
            returnTSLbl.Font = new Font("Minecraft", 25.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            returnTSLbl.ForeColor = Color.Azure;
            returnTSLbl.Location = new Point(856, 865);
            returnTSLbl.Name = "returnTSLbl";
            returnTSLbl.Size = new Size(257, 86);
            returnTSLbl.TabIndex = 15;
            returnTSLbl.Text = "Return to\r\nTitlescreen\r\n";
            returnTSLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // calcFootprintLbl
            // 
            calcFootprintLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            calcFootprintLbl.AutoSize = true;
            calcFootprintLbl.Font = new Font("Minecraft", 25.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            calcFootprintLbl.ForeColor = Color.Lime;
            calcFootprintLbl.Location = new Point(171, 865);
            calcFootprintLbl.Name = "calcFootprintLbl";
            calcFootprintLbl.Size = new Size(240, 129);
            calcFootprintLbl.TabIndex = 14;
            calcFootprintLbl.Text = "Carbon \r\nFootprint \r\nCalculator";
            calcFootprintLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // extPanel
            // 
            extPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            extPanel.Controls.Add(exitAppBtn);
            extPanel.Location = new Point(1515, 646);
            extPanel.Name = "extPanel";
            extPanel.Size = new Size(214, 212);
            extPanel.TabIndex = 13;
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
            // returnTitlePanel
            // 
            returnTitlePanel.Anchor = AnchorStyles.Bottom;
            returnTitlePanel.Controls.Add(titleScreenBtn);
            returnTitlePanel.Location = new Point(872, 646);
            returnTitlePanel.Name = "returnTitlePanel";
            returnTitlePanel.Size = new Size(214, 212);
            returnTitlePanel.TabIndex = 11;
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
            // calcPanel
            // 
            calcPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            calcPanel.Controls.Add(cfCalcBtn);
            calcPanel.Location = new Point(183, 646);
            calcPanel.Name = "calcPanel";
            calcPanel.Size = new Size(214, 212);
            calcPanel.TabIndex = 3;
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
            // titlePanel
            // 
            titlePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            titlePanel.Controls.Add(title);
            titlePanel.Location = new Point(183, 87);
            titlePanel.Name = "titlePanel";
            titlePanel.Size = new Size(1546, 340);
            titlePanel.TabIndex = 2;
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
            // GuestDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(bgPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GuestDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EcoCalc Plus - Guest";
            WindowState = FormWindowState.Maximized;
            Load += GuestDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dashboardBg).EndInit();
            bgPanel.ResumeLayout(false);
            bgPanel.PerformLayout();
            bgmPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bgmBtn).EndInit();
            extPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)exitAppBtn).EndInit();
            returnTitlePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)titleScreenBtn).EndInit();
            calcPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cfCalcBtn).EndInit();
            titlePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)title).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox dashboardBg;
        private System.Windows.Forms.Timer sidebarTransition;
        private Panel titlePanel;
        private Label exitLbl;
        private Panel calcPanel;
        private PictureBox cfCalcBtn;
        private Panel returnTitlePanel;
        private PictureBox titleScreenBtn;
        private Panel extPanel;
        private PictureBox exitAppBtn;
        private Label returnTSLbl;
        private Label calcFootprintLbl;
        private PictureBox title;
        private Panel bgPanel;
        private Label welcomeGreetLbl;
        private Panel panelCalculator;
        private Panel bgmPanel;
        private PictureBox bgmBtn;
    }
}
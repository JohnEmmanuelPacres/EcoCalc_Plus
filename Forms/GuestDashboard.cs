using EcoCalc_Plus.UtilityClass;

namespace EcoCalc_Plus
{
    public partial class GuestDashboard : CreateParamsForm
    {
        private Image _originalCalculator, _originalTitleScreen, _originalExit, _originalBGM;
        private string _username;
        private SoundManager _soundManager = new SoundManager();

        SoundManager bgSound = TitleScreen._soundManager;

        public GuestDashboard()
        {
            InitializeComponent();
            InitializeDashboard();
            _username = "Guest";
        }

        private void ChooseFX()
        {
            string soundPath = Path.Combine(Application.StartupPath, "assets", "Audio", "audio_choose.wav");
            _soundManager.PlaySoundEffect(soundPath);
        }

        private void SelectFX()
        {
            string soundPath = Path.Combine(Application.StartupPath, "assets", "Audio", "audio_selected.wav");
            _soundManager.PlaySoundEffect(soundPath);
        }

        private void InitializeDashboard()
        {
            titlePanel.Parent = dashboardBg;
            _originalCalculator = cfCalcBtn.Image;
            _originalTitleScreen = titleScreenBtn.Image;
            _originalExit = exitAppBtn.Image;
            _originalBGM = bgmBtn.Image;
            panelCalculator.Dock = DockStyle.Fill;
            DashboardHelper.SetParent(calcPanel, dashboardBg);
            DashboardHelper.SetParent(returnTitlePanel, dashboardBg);
            DashboardHelper.SetParent(extPanel, dashboardBg);
            DashboardHelper.SetParent(calcFootprintLbl, dashboardBg);
            DashboardHelper.SetParent(returnTSLbl, dashboardBg);
            DashboardHelper.SetParent(exitLbl, dashboardBg);
            DashboardHelper.SetParent(welcomeGreetLbl, dashboardBg);
            DashboardHelper.SetParent(bgmPanel, dashboardBg);

            if (!TitleScreen.isMuted)
            {
                bgSound.SetVolume(100f);
                bgmBtn.Image = _originalBGM;
            }
            else
            {
                bgSound.SetVolume(0f);
                bgmBtn.Image = Properties.Resources.sprite_NoSound;
            }
        }

        private void GuestDashboard_Load(object sender, EventArgs e)
        {
            calcFootprintLbl.Visible = false;
            returnTSLbl.Visible = false;
            exitLbl.Visible = false;
            panelCalculator.Visible = false;
        }

        //mouse enter mouse leave events <<start>>
        private void cfCalcBtn_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(cfCalcBtn, calcFootprintLbl,
            Properties.Resources.sprite_calculatorBtnAni, _originalCalculator, true);
        }

        private void cfCalcBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(cfCalcBtn, calcFootprintLbl,
            Properties.Resources.sprite_calculatorBtnAni, _originalCalculator, false);
        }

        private void titleScreenBtn_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(titleScreenBtn, returnTSLbl,
            Properties.Resources.sprite_titleScreenBtnAni, _originalTitleScreen, true);
        }

        private void titleScreenBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(titleScreenBtn, returnTSLbl,
            Properties.Resources.sprite_titleScreenBtnAni, _originalTitleScreen, false);
        }

        private void exitAppBtn_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(exitAppBtn, exitLbl,
            Properties.Resources.sprite_exitBtnLarge, _originalExit, true);
        }

        private void exitAppBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(exitAppBtn, exitLbl,
            Properties.Resources.sprite_exitBtnLarge, _originalExit, false);
        }

        //mouse enter mouse leave events <<end>>

        private void titleScreenBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            this.Close();
            if (Application.OpenForms["TitleScreen"] is TitleScreen titleScreen)
            {
                titleScreen.Show();
            }
            else
            {
                titleScreen = new TitleScreen();
                titleScreen.Show();
            }
        }

        private void exitAppBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void cfCalcBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            bool saveData = false;
            if (panelCalculator.Controls.OfType<CFCalculator>().Any())
            {
                return;
            }
            CFCalculator cfcalc = new CFCalculator(_username, saveData);
            cfcalc.TopLevel = false;
            cfcalc.FormBorderStyle = FormBorderStyle.None;
            cfcalc.Dock = DockStyle.Fill;
            panelCalculator.Controls.Add(cfcalc);
            cfcalc.Show();
            cfcalc.FormClosing += (s, args) =>
            {
                panelCalculator.Visible = false;
                panelCalculator.Controls.Remove(cfcalc);
            };
            panelCalculator.Visible = true;
        }

        private void bgmBtn_Click(object sender, EventArgs e)
        {
            if (bgmBtn.Image == _originalBGM)
            {
                bgmBtn.Image = Properties.Resources.sprite_NoSound;
                bgSound.SetVolume(0f);
                TitleScreen.isMuted = true;
            }
            else
            {
                bgmBtn.Image = _originalBGM;
                bgSound.SetVolume(100f);
                TitleScreen.isMuted = false;
            }
        }

        private void bgmBtn_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void bgmBtn_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}

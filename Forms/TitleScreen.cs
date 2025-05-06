using EcoCalc_Plus.UtilityClass;
using System.IO;
using System.Reflection;

namespace EcoCalc_Plus
{
    public partial class TitleScreen : CreateParamsForm
    {
        private bool _isLoginPanelActive = false;
        public static SoundManager _soundManager = new SoundManager();
        private Image _originalLogInUserBtn, _originalLogInGuestBtn, _originalExit, _originalBGM;

        public static bool isMuted;

        public TitleScreen()
        {
            InitializeComponent();
            BackgroundMusic();
            this.HandleCreated += (s, e) => SlideFormIn();
            this.HandleCreated += (s, e) => FadeInForm();
            this.FormClosed += TitleScreen_FormClosed;
            this.KeyDown += TitleScreen_KeyDown;

            titlePanel.Parent = backdrop1;
            guestPanel.Parent = backdrop1;
            userPanel.Parent = backdrop1;
            enterLbl.Parent = backdrop1;
            versionLbl.Parent = backdrop1;

            guestPanel.Visible = false;
            userPanel.Visible = false;
            exitPanel.Visible = false;

            _originalLogInUserBtn = btn_logInAsUser.Image;
            _originalLogInGuestBtn = btn_logInAsGuest.Image;
            _originalExit = btn_exit.Image;

            this.DoubleBuffered = true;
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

        private void BackgroundMusic()
        {
            string soundPath = Path.Combine(Application.StartupPath, "assets", "Audio", "audio_bg.wav");
            _soundManager.PlayBackgroundMusic(soundPath, loop: true);
        }

        private async void FadeInForm()
        {
            this.Opacity = 0;
            for (double i = 0; i <= 1; i += 0.05)
            {
                await Task.Delay(5);
                BeginInvoke(new Action(() => this.Opacity = i));
            }
        }

        private async void SlideFormIn()
        {
            int startX = this.Location.X;
            int startY = this.Location.Y - 50;
            int targetY = this.Location.Y;

            while (startY < targetY)
            {
                await Task.Delay(5);
                BeginInvoke(new Action(() => this.Location = new Point(startX, startY)));
                startY += 5;
            }
        }

        private void TitleScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch(System.InvalidOperationException er)
            {
                Application.Exit();
            }
        }

        private void TitleScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_isLoginPanelActive && (!guestPanel.Visible || !userPanel.Visible))
            {
                enterLbl.Visible = false;
                guestPanel.Visible = true;
                userPanel.Visible = true;
                exitPanel.Visible = true;
                this.Invalidate();
            }
        }

        private void btn_logInAsUser_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityGeneral.ApplyHoverEffect(btn_logInAsUser, Properties.Resources.sprite_userAlt,
                _originalLogInUserBtn, true);
        }

        private void btn_logInAsUser_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityGeneral.ApplyHoverEffect(btn_logInAsUser, Properties.Resources.sprite_userAlt,
                _originalLogInUserBtn, false);
        }

        private void btn_logInAsGuest_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityGeneral.ApplyHoverEffect(btn_logInAsGuest, Properties.Resources.sprite_guestAlt,
                _originalLogInGuestBtn, true);
        }

        private void btn_logInAsGuest_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityGeneral.ApplyHoverEffect(btn_logInAsGuest, Properties.Resources.sprite_guestAlt,
                _originalLogInGuestBtn, false);
        }

        private void btn_exit_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityGeneral.ApplyHoverEffect(btn_exit,
                Properties.Resources.sprite_exitAlt, _originalExit, true);
        }

        private void btn_exit_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityGeneral.ApplyHoverEffect(btn_exit,
                Properties.Resources.sprite_exitAlt, _originalExit, false);
        }

        private void btn_logInAsUser_Click(object sender, EventArgs e)
        {
            SelectFX();
            _isLoginPanelActive = true; // Set flag when login panel is shown

            panelLogIn.BringToFront();
            titlePanel.Visible = false;
            userPanel.Visible = false;
            guestPanel.Visible = false;
            exitPanel.Visible = false;

            if (panelLogIn.Controls.OfType<LogInAsUser>().Any())
            {
                return;
            }

            LogInAsUser login = new LogInAsUser();
            login.TopLevel = false;
            login.FormBorderStyle = FormBorderStyle.None;
            login.Dock = DockStyle.Fill;
            panelLogIn.Controls.Add(login);
            panelLogIn.Location = new Point(500, 72);
            login.Show();
            login.FormClosing += (s, args) =>
            {
                _isLoginPanelActive = false; // Reset flag when login panel closes
                panelLogIn.Visible = false;
                panelLogIn.Controls.Remove(login);
                titlePanel.Visible = true;
                guestPanel.Visible = true;
                userPanel.Visible = true;
                exitPanel.Visible = true;
            };
            panelLogIn.Visible = true;
        }

        private void btn_logInAsGuest_Click(object sender, EventArgs e)
        {
            SelectFX();
            GuestDashboard guestDashboard = new GuestDashboard();
            this.Hide();
            guestDashboard.Show();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            SelectFX();
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void TitleScreen_Load(object sender, EventArgs e)
        {
            panelLogIn.Visible = false;
        }

        private void bgmBtn_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void bgmBtn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}

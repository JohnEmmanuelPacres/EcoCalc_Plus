using EcoCalc_Plus.Forms;
using EcoCalc_Plus.UtilityClass;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace EcoCalc_Plus
{

    public partial class UserDashboard : CreateParamsForm
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool Repaint);

        private Process _unityProcess;

        SoundManager bgSound = TitleScreen._soundManager;
        
        private Image _originalCalculator, _originalTitleScreen, _originalGlobal, _originalExit,
            _originalAnalytics, _originalGoon, _originalProfile, _originalBGM;
        private string _username;
        private CarbonFootprintMap _carbonMap;
        private SoundManager _soundManager = new SoundManager();

        public UserDashboard(string username)
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            InitializeDashboard();

            _username = username;
            panelCalculator.Dock = DockStyle.Fill;
            panelAnalytics.Dock = DockStyle.Fill;
            globalCarbonPanel.Dock = DockStyle.Fill;
            gamePanel.Dock = DockStyle.Fill;
            DashboardHelper.SetParent(welcomeGreetLbl, dashboardBg);
            welcomeGreetLbl.Text = $"Welcome, User {_username}!";
        }

        private void InitializeDashboard()
        {
            titlePanel.Parent = dashboardBg;
            _originalCalculator = cfCalcBtn.Image;
            _originalTitleScreen = titleScreenBtn.Image;
            _originalGlobal = globalCarbonBtn.Image;
            _originalExit = exitAppBtn.Image;
            _originalAnalytics = analyticBtn.Image;
            _originalGoon = gameBtn.Image;
            _originalProfile = profileBtn.Image;
            _originalBGM = bgmBtn.Image;
            loadingLabel.Visible = false;
            loadingOverlay.Visible = false;
            progressBar.Visible = false;
            DashboardHelper.SetParent(calcPanel, dashboardBg);
            DashboardHelper.SetParent(returnTitlePanel, dashboardBg);
            DashboardHelper.SetParent(globalCrbnPanel, dashboardBg);
            DashboardHelper.SetParent(extPanel, dashboardBg);
            DashboardHelper.SetParent(calcFootprintLbl, dashboardBg);
            DashboardHelper.SetParent(returnTSLbl, dashboardBg);
            DashboardHelper.SetParent(globalCarbonLbl, dashboardBg);
            DashboardHelper.SetParent(exitLbl, dashboardBg);
            DashboardHelper.SetParent(analyticsPanel, dashboardBg);
            DashboardHelper.SetParent(analyticsLbl, dashboardBg);
            DashboardHelper.SetParent(menuPanel, dashboardBg);
            DashboardHelper.SetParent(gameLbl, dashboardBg);
            DashboardHelper.SetParent(profilePanel, dashboardBg);
            DashboardHelper.SetParent(profileLbl, dashboardBg);
            DashboardHelper.SetParent(bgmPanel, dashboardBg);
            DashboardHelper.SetParent(loadingOverlay, dashboardBg);
            this.DoubleBuffered = true;
            DetermineMuted();
        }

        private void UserDashboard_Load(object sender, EventArgs e)
        {
            calcFootprintLbl.Visible = false;
            returnTSLbl.Visible = false;
            globalCarbonLbl.Visible = false;
            exitLbl.Visible = false;
            analyticsLbl.Visible = false;
            gameLbl.Visible = false;
            panelCalculator.Visible = false;
            panelGlobe.Visible = false;
            panelAnalytics.Visible = false;
            globalCarbonPanel.Visible = false;
            gamePanel.Visible = false;
            profileLbl.Visible = false;
            Refresh();
            Update();
        }

        private void DetermineMuted()
        {
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
            bool saveData = true;
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

        private void analyticBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SelectFX();
                var analyticsControl = panelAnalytics.Controls.OfType<AnalyticsControl>().FirstOrDefault();

                if (analyticsControl == null)
                {
                    analyticsControl = new AnalyticsControl(_username)
                    {
                        Dock = DockStyle.Fill
                    };

                    analyticsControl.RequestClose += (s, e) =>
                    {
                        panelAnalytics.Controls.Remove(analyticsControl);
                        panelAnalytics.Visible = false;
                    };

                    panelAnalytics.Controls.Add(analyticsControl);
                }

                panelAnalytics.Visible = true;
                analyticsControl.BringToFront();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show($"Empty dataset! Error: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private async void globalCarbonBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            // Show loading BEFORE any work starts
            ShowLoading(true);

            try
            {
                await Task.Delay(1); // Better than Task.Delay(1)

                CarbonFootprintMap carbonMapControl = null;

                // First check if control exists
                carbonMapControl = globalCarbonPanel.Controls.OfType<CarbonFootprintMap>().FirstOrDefault();

                if (carbonMapControl == null)
                {
                    // Create and configure on UI thread
                    carbonMapControl = new CarbonFootprintMap(_username)
                    {
                        Dock = DockStyle.Fill
                    };

                    carbonMapControl.RequestClose += (s, args) =>
                    {
                        globalCarbonPanel.Visible = false;
                        globalCarbonPanel.Controls.Remove(carbonMapControl);
                        ShowLoading(false);
                    };

                    globalCarbonPanel.Controls.Add(carbonMapControl);
                    carbonMapControl.BringToFront();
                }

                // Make visible before loading
                globalCarbonPanel.Visible = true;
                carbonMapControl.BringToFront();

                // Load data asynchronously
                await Task.Run(() =>
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        carbonMapControl.InitializeDataGridForCF();
                    });
                });

                // Initialize map if needed
                await carbonMapControl.InitializeAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ShowLoading(false);
            }
        }

        private void ShowLoading(bool show)
        {
            if (loadingOverlay.InvokeRequired)
            {
                loadingOverlay.Invoke(new Action<bool>(ShowLoading), show);
                return;
            }

            loadingOverlay.Visible = show;
            progressBar.Visible = show;
            loadingLabel.Visible = show;

            if (show)
            {
                progressBar.Style = ProgressBarStyle.Marquee;
                progressBar.MarqueeAnimationSpeed = 60;
                progressBar.Value = 0; // Reset value
                loadingOverlay.BringToFront(); // Crucial!
                Application.DoEvents(); // Force immediate redraw
                this.Cursor = Cursors.WaitCursor;
            }
            else
            {
                progressBar.Style = ProgressBarStyle.Continuous;
                this.Cursor = Cursors.Default;
            }
        }

        private void profileBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            var profileControl = new UserProfile(_username);
            var hostForm = new Form
            {
                Size = new Size(1171, 612),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.None,
                MaximizeBox = false,
                MinimizeBox = false
            };
            hostForm.Controls.Add(profileControl);
            profileControl.Dock = DockStyle.Fill;
            hostForm.ShowDialog();
        }

        private void gameBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            this.Hide();
            bgSound.SetVolume(0f);
            try
            {
                // Kill existing Unity process if running
                if (_unityProcess != null && !_unityProcess.HasExited)
                {
                    _unityProcess.Kill();
                    _unityProcess = null;
                    System.Threading.Thread.Sleep(200); // Brief pause after kill
                }

                // Set paths and verify critical files exist
                string resourcesPath = Path.Combine(Application.StartupPath, "Resources", "minigame files");
                string unityExePath = Path.Combine(resourcesPath, "EcoCalc minigame.exe");
                string dataFolderPath = Path.Combine(resourcesPath, "EcoCalc minigame_Data");
                string monoDllPath = Path.Combine(resourcesPath, "MonoBleedingEdge", "EmbedRuntime", "mono-2.0-bdwgc.dll");
                string unityPlayerPath = Path.Combine(resourcesPath, "UnityPlayer.dll");

                // Verify all required files exist
                var missingFiles = new List<string>();
                if (!File.Exists(unityExePath)) missingFiles.Add("EcoCalc minigame.exe");
                if (!File.Exists(monoDllPath)) missingFiles.Add("mono-2.0-bdwgc.dll");
                if (!File.Exists(unityPlayerPath)) missingFiles.Add("UnityPlayer.dll");
                if (!Directory.Exists(dataFolderPath)) missingFiles.Add("EcoCalc minigame_Data folder");

                if (missingFiles.Count > 0)
                {
                    MessageBox.Show($"Missing required files:\n{string.Join("\n", missingFiles)}",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Launch Unity game as separate window
                _unityProcess = new Process();
                _unityProcess.StartInfo.FileName = unityExePath;
                _unityProcess.StartInfo.WorkingDirectory = resourcesPath;
                _unityProcess.StartInfo.UseShellExecute = true; // Changed to true for separate window
                _unityProcess.StartInfo.CreateNoWindow = false; // Changed to false to show window
                _unityProcess.EnableRaisingEvents = true;

                _unityProcess.Exited += (s, args) =>
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Show();
                        this.BringToFront();
                        DetermineMuted();
                    });
                    _unityProcess?.Dispose();
                    _unityProcess = null;
                    
                };

                if (!_unityProcess.Start())
                {
                    MessageBox.Show("Failed to start Unity process", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to launch Unity game: {ex.Message}\n\n{ex.StackTrace}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                try
                {
                    if (_unityProcess != null && !_unityProcess.HasExited)
                    {
                        _unityProcess.Kill();
                        _unityProcess.Dispose();
                    }
                }
                finally
                {
                    _unityProcess = null;
                }
            }
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

        //mouse hover designs
        private void profileBtn_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(profileBtn, profileLbl,
                Properties.Resources.sprite_profileAlt, _originalProfile, true);
        }

        private void profileBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(profileBtn, profileLbl,
                Properties.Resources.sprite_profileAlt, _originalProfile, false);
        }

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
        private void globalCarbonBtn_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(globalCarbonBtn, globalCarbonLbl,
            Properties.Resources.sprite_earth, _originalGlobal, true);
        }
        private void globalCarbonBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(globalCarbonBtn, globalCarbonLbl,
            Properties.Resources.sprite_earth, _originalGlobal, false);
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
        private void analyticBtn_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(analyticBtn, analyticsLbl,
            Properties.Resources.sprite_analyticsBtnAni, _originalAnalytics, true);
        }
        private void analyticBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(analyticBtn, analyticsLbl,
            Properties.Resources.sprite_analyticsBtnAni, _originalAnalytics, false);
        }
        private void gameBtn_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(gameBtn, gameLbl,
                Properties.Resources.sprite_gameLogoAlt, _originalGoon, true);
        }
        private void gameBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(gameBtn, gameLbl,
                Properties.Resources.sprite_gameLogoAlt, _originalGoon, false);
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
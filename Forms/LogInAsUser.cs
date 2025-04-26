using EcoCalc_Plus.UtilityClass;
using System.Data.OleDb;

namespace EcoCalc_Plus
{
    public partial class LogInAsUser : Form
    {
        private Image _originalLogin, _originalCreate, _originalReturnTitle;
        private SoundManager _soundManager;

        public LogInAsUser()
        {
            InitializeComponent();
            UISetup();
        }

        private void UISetup()
        {
            this.DoubleBuffered = true;
            Refresh();
            returnTTBtn.Refresh();
            returnTTBtn.Update();
            _originalLogin = logInBtnpic.Image;
            _originalCreate = createAccBtnpic.Image;
            _originalReturnTitle = returnTTBtn.Image;
            passwordTbx.PasswordChar = '*';
            panelCreate.Dock = DockStyle.Fill;
            customLogInMessageBox1.Visible = false;
            _soundManager = new SoundManager();
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

        private void invisibleBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            passwordTbx.PasswordChar = '*';
            visibleBtn.BringToFront();
        }

        private void visibleBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            passwordTbx.PasswordChar = '\0';
            invisibleBtn.BringToFront();
        }

        private void LogInAsUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void returnTTBtn_Click(object sender, EventArgs e)
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

        private void createAccBtnpic_Click(object sender, EventArgs e)
        {
            SelectFX();
            visibleBtn.Visible = false;
            invisibleBtn.Visible = false;
            forgotPasswordLink.Visible = false;
            if (panelCreate.Controls.OfType<CreateUser>().Any())
            {
                return;
            }
            CreateUser create = new CreateUser();
            create.TopLevel = false;
            create.FormBorderStyle = FormBorderStyle.None;
            create.Dock = DockStyle.Fill;
            panelCreate.Controls.Add(create);
            create.Show();
            passLbl.Visible = false;
            create.FormClosing += (s, args) =>
            {
                panelCreate.Visible = false;
                passLbl.Visible = true;
                panelCreate.Controls.Remove(create);
                visibleBtn.Visible = true;
                invisibleBtn.Visible = true;
                forgotPasswordLink.Visible = true;
            };
            panelCreate.Visible = true;
        }

        private void logInBtnpic_Click(object sender, EventArgs e)
        {
            SelectFX();
            string username = usernameTbx.Text;
            string password = passwordTbx.Text;

            string connectionString = DatabaseHelper.ConnectionString;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your username and password.");
                return;
            }

            HashPassword hashPassword = new HashPassword();
            string hashedPass = hashPassword.HashedPassword(password);

            if (!DatabaseHelper.DatabaseExists())
            {
                MessageBox.Show("Database file not found. Please ensure the database is correctly installed.",
                    "DATABASE MISSING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM [Users] WHERE StrComp([Username], @Username, 0) = 0 AND [Password] = @Password";
                    using (OleDbCommand command = new OleDbCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", hashedPass);

                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            visibleBtn.Visible = false;
                            invisibleBtn.Visible = false;
                            forgotPasswordLink.Visible = false;
                            customLogInMessageBox1.Visible = true;
                            customLogInMessageBox1.Dock = DockStyle.Fill;
                            customLogInMessageBox1.OkClicked += (s, args) =>
                            {
                                if (Application.OpenForms["TitleScreen"] is TitleScreen titleScreen)
                                {
                                    titleScreen.Hide();
                                }
                                UserDashboard dashboard = new UserDashboard(username);
                                dashboard.Show();
                                this.Close();
                            };
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Please try again", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message);
                }
            }
        }

        private void forgotPasswordLink_Click(object sender, EventArgs e)
        {
            SelectFX();
            HideControls();

            var resetControl = new PasswordReset();
            resetControl.ResetCompleted += (s, args) =>
            {
                panelCreate.Controls.Remove(resetControl);
                ShowLoginControls();
            };
            resetControl.CancelRequested += (s, args) =>
            {
                panelCreate.Controls.Remove(resetControl);
                ShowLoginControls();
            };

            panelCreate.Controls.Add(resetControl);
            resetControl.Location = new Point(
                (panelCreate.Width - resetControl.Width) / 2,
                (panelCreate.Height - resetControl.Height) / 2
                );
            panelCreate.Visible = true;
        }


        private void HideControls()
        {
            usernameLbl.Visible = false;
            usernameTbx.Visible = false;
            passwordTbx.Visible = false;
            logInBtnpic.Visible = false;
            createAccBtnpic.Visible = false;
            forgotPasswordLink.Visible = false;
            passLbl.Visible = false;
            visibleBtn.Visible = false;
            invisibleBtn.Visible = false;
        }
        private void ShowLoginControls()
        {
            usernameLbl.Visible = true;
            usernameTbx.Visible = true;
            passwordTbx.Visible = true;
            logInBtnpic.Visible = true;
            createAccBtnpic.Visible = true;
            forgotPasswordLink.Visible = true;
            passLbl.Visible = true;
            visibleBtn.Visible = true;
            invisibleBtn.Visible = true;
            panelCreate.Visible = false;
        }

        private void LogInAsUser_Load(object sender, EventArgs e)
        {
            panelCreate.Visible = false;
        }

        private void logInBtnpic_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            this.Cursor = Cursors.Hand;
            MouseEventsUtilityGeneral.ApplyHoverEffect(logInBtnpic,
            Properties.Resources.sprite_logInAlt, _originalLogin, true);
        }
        private void logInBtnpic_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityGeneral.ApplyHoverEffect(logInBtnpic,
            Properties.Resources.sprite_logIn, _originalLogin, false);
        }

        private void createAccBtnpic_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityGeneral.ApplyHoverEffect(createAccBtnpic,
            Properties.Resources.sprite_createAltBtn, _originalCreate, true);
        }

        private void createAccBtnpic_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityGeneral.ApplyHoverEffect(createAccBtnpic,
            Properties.Resources.sprite_createBtn, _originalCreate, false);
        }

        private void visibleBtn_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void invisibleBtn_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void invisibleBtn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void visibleBtn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void forgotPasswordLink_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void forgotPasswordLink_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void returnTTBtn_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityGeneral.ApplyHoverEffect(returnTTBtn, Properties.Resources.sprite_returnTitle,
                _originalReturnTitle, true);
        }

        private void returnTTBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityGeneral.ApplyHoverEffect(returnTTBtn, Properties.Resources.sprite_returnTitle,
                _originalReturnTitle, false);
        }
    }
}

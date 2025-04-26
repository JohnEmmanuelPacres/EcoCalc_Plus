using EcoCalc_Plus.UtilityClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace EcoCalc_Plus
{
    public partial class CreateUser : Form
    {
        private Image _originalSignup, _originalReturn;
        private SoundManager _soundManager = new SoundManager();

        public CreateUser()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            Refresh();

            returnTTBtn.Refresh();
            returnTTBtn.Update();

            _originalSignup = signUpBtn.Image;
            _originalReturn = returnTTBtn.Image;

            passwordTbx.PasswordChar = '*';
            maleRadioBtn.Checked = true;
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

        private void visibleBtn_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void visibleBtn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void invisibleBtn_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void invisibleBtn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void visibleBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            passwordTbx.PasswordChar = '\0';
            invisibleBtn.BringToFront();
        }

        private void invisibleBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            passwordTbx.PasswordChar = '*';
            visibleBtn.BringToFront();
        }

        private void returnTTBtn_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityGeneral.ApplyHoverEffect(returnTTBtn, Properties.Resources.sprite_return, 
                _originalReturn, true);
        }
        private void returnTTBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityGeneral.ApplyHoverEffect(returnTTBtn, Properties.Resources.sprite_return,
                _originalReturn, false);
        }
        private void returnTTBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            this.Close();
        }

        private bool UserExists(string username, string email, OleDbConnection conn)
        {
            string query = "SELECT COUNT(*) FROM [Users] WHERE [Username] = @Username OR [Email] = @Email";
            using (OleDbCommand command = new OleDbCommand(query, conn))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Email", email);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void signUpBtnpic_Click(object sender, EventArgs e)
        {
            SelectFX();
            string username = usernameTbx.Text;
            string email = emailTbx.Text;
            string password = passwordTbx.Text;
            string sex = maleRadioBtn.Checked ? "M " : "F";

            string connectionString = DatabaseHelper.ConnectionString;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!maleRadioBtn.Checked && !femaleRadioBtn.Checked)
            {
                MessageBox.Show("Please select your gender.");
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
                    if (UserExists(username, email, conn))
                    {
                        MessageBox.Show("Username or email already exists.");
                        return;
                    }
                    string query = "INSERT INTO [Users] ([Username], [Password], [Email], [Sex]) VALUES (@Username, @Password, @Email, @Sex)";
                    using (OleDbCommand command = new OleDbCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", hashedPass);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Sex", sex);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Account created successfully!");
                            usernameTbx.Text = "";
                            emailTbx.Text = "";
                            passwordTbx.Text = "";
                            maleRadioBtn.Checked = false;
                            femaleRadioBtn.Checked = false;
                        }
                        else
                        {
                            MessageBox.Show("Account creation failed.");
                        }
                    }
                }
                catch (OleDbException ex)
                {
                    if (ex.Message.Contains("duplicate"))
                    {
                        MessageBox.Show("Username or email already exists.");
                    }
                    else
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message);
                }
            }
        }

        private void signUpBtn_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityGeneral.ApplyHoverEffect(signUpBtn,
            Properties.Resources.sprite_signUpAlt, _originalSignup, true);
        }

        private void signUpBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityGeneral.ApplyHoverEffect(signUpBtn,
            Properties.Resources.sprite_signUpAlt, _originalSignup, false);
        }
    }
}

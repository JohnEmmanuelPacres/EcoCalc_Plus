using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcoCalc_Plus.UtilityClass;
using EcoCalc_Plus.CarbonFootrpintCalculator;
using System.Data.OleDb;

namespace EcoCalc_Plus
{
    public partial class UpdateAccount : UserControl
    {
        private Image _originalExit, _originalUpdate;
        private readonly int _userId;
        private readonly string _currentUsername;
        public event EventHandler RequestClose;
        public event EventHandler AccountUpdated;
        private SoundManager _soundManager = new SoundManager();

        public UpdateAccount(string username)
        {
            InitializeComponent();
            _originalExit = exitBtn.Image;
            _originalUpdate = updateAccBtn.Image;
            _currentUsername = username;
            var repository = new CarbonFootprintRepository();
            _userId = repository.GetUserId(username);
            newUsernameTbx.Text = username;
            oldPassTbx.PasswordChar = '*';
            newPassTbx.PasswordChar = '*';
            retypePassTbx.PasswordChar = '*';
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

        private void exitBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        private void updateAccBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            string newUsername = newUsernameTbx.Text;
            string oldPassword = oldPassTbx.Text;
            string newPassword = newPassTbx.Text;
            string retypePassword = retypePassTbx.Text;

            if (string.IsNullOrWhiteSpace(newUsername))
            {
                ShowError("Please enter a new username");
                return;
            }

            if (string.IsNullOrWhiteSpace(oldPassword))
            {
                ShowError("Please enter your current password");
                return;
            }

            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                if (newPassword != retypePassword)
                {
                    ShowError("New password and retyped password don't match");
                    return;
                }

                if (newPassword.Length < 8)
                {
                    ShowError("Password must be at least 8 characters long");
                    return;
                }
            }

            try
            {
                HashPassword hashPassword = new HashPassword();
                string hashedOldPassword = hashPassword.HashedPassword(oldPassword);

                string connectionString = DatabaseHelper.ConnectionString;

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM [Users] WHERE [UserID] = ? AND [Password] = ?";
                    using (OleDbCommand command = new OleDbCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@UserID", _userId);
                        command.Parameters.AddWithValue("@Password", hashedOldPassword);

                        int count = (int)command.ExecuteScalar();

                        if (count == 0)
                        {
                            ShowError("Current password is incorrect");
                            return;
                        }
                    }
                }

                bool usernameUpdated = false;
                if (newUsername != _currentUsername)
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string query = "UPDATE [Users] SET [Username] = ? WHERE [UserID] = ?";
                        using (OleDbCommand command = new OleDbCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@Username", newUsername);
                            command.Parameters.AddWithValue("@UserID", _userId);
                            usernameUpdated = command.ExecuteNonQuery() > 0;
                        }
                    }
                }
                bool passwordUpdated = false;
                if (!string.IsNullOrWhiteSpace(newPassword))
                {
                    string hashedNewPassword = hashPassword.HashedPassword(newPassword);
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        string query = "UPDATE [Users] SET [Password] = ? WHERE [UserID] = ?";
                        using (OleDbCommand command = new OleDbCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@Password", hashedNewPassword);
                            command.Parameters.AddWithValue("@UserID", _userId);
                            passwordUpdated = command.ExecuteNonQuery() > 0;
                        }
                    }
                }

                string message = "Account updated successfully!";
                if (usernameUpdated && passwordUpdated)
                    message = "Username and password updated successfully!";
                else if (usernameUpdated)
                    message = "Username updated successfully!";
                else if (passwordUpdated)
                    message = "Password updated successfully!";

                MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                oldPassTbx.Text = "";
                newPassTbx.Text = "";
                retypePassTbx.Text = "";

                AccountUpdated?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                ShowError($"An error occurred: {ex.Message}");
            }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void exitBtn_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityGeneral.ApplyHoverEffect(exitBtn,
                Properties.Resources.sprite_exitBtnLarge, _originalExit, true);
        }

        private void exitBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityGeneral.ApplyHoverEffect(exitBtn,
                Properties.Resources.sprite_exitBtnLarge, _originalExit, false);
        }

        private void updateAccBtn_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityGeneral.ApplyHoverEffect(updateAccBtn,
                Properties.Resources.sprite_updateAccAlt, _originalUpdate, true);
        }

        private void updateAccBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityGeneral.ApplyHoverEffect(updateAccBtn,
                Properties.Resources.sprite_updateAccAlt, _originalUpdate, false);
        }

        private void invisibleOldBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            oldPassTbx.PasswordChar = '*';
            visibleOldBtn.BringToFront();
        }

        private void invisibleNewBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            newPassTbx.PasswordChar = '*';
            visibleNewBtn.BringToFront();
        }

        private void invisibleReBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            retypePassTbx.PasswordChar = '*';
            visibleReBtn.BringToFront();
        }

        private void visibleOldBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            oldPassTbx.PasswordChar = '\0';
            invisibleOldBtn.BringToFront();
        }

        private void visibleNewBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            newPassTbx.PasswordChar = '\0';
            invisibleNewBtn.BringToFront();
        }

        private void visibleReBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            retypePassTbx.PasswordChar = '\0';
            invisibleReBtn.BringToFront();
        }

        private void visibleOldBtn_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void visibleOldBtn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void visibleNewBtn_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void visibleNewBtn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void visibleReBtn_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void visibleReBtn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void invisibleOldBtn_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void invisibleOldBtn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void invisibleNewBtn_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void invisibleNewBtn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void invisibleReBtn_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void invisibleReBtn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}

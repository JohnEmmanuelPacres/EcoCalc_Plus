using EcoCalc_Plus.UtilityClass;
using Krypton.Toolkit;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EcoCalc_Plus
{
    public partial class ResetPasswordControl : UserControl
    {
        private string _email;
        private SoundManager _soundManager;

        public event EventHandler PasswordResetComplete = delegate { };
        public event EventHandler CancelRequested = delegate { };

        public ResetPasswordControl(string email)
        {
            InitializeComponent();
            _email = email;
            _soundManager = new SoundManager();
            if (!this.DesignMode)
            {
                SetupButtonFunctionality();
            }
            UISetup();
        }

        private void UISetup()
        {
            confirmTextBox.PasswordChar = '*';
            newPasswordTextBox.PasswordChar = '*';
        }

        private void SetupButtonFunctionality()
        {
            resetButton.Click += (sender, e) => ResetPassword();
            cancelButton.Click += (sender, e) =>
            {
                SelectFX();
                CancelRequested?.Invoke(this, EventArgs.Empty);
            };
        }

        private void ResetPassword()
        {
            SelectFX();

            if (!ValidatePasswordsMatch())
                return;

            if (!ValidateResetToken())
                return;

            if (UpdateUserPassword())
            {
                PasswordResetComplete?.Invoke(this, EventArgs.Empty);
            }
        }

        private bool ValidatePasswordsMatch()
        {
            if (newPasswordTextBox.Text != confirmTextBox.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateResetToken()
        {
            string userEnteredToken = tokenTextBox.Text.Trim();

            var tokenInfo = DatabaseHelper.GetResetToken(_email);

            if (tokenInfo == null ||
                tokenInfo.Value.Token != userEnteredToken ||
                tokenInfo.Value.Expiration < DateTime.Now)
            {
                MessageBox.Show("Invalid or expired reset token.", "Token Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool UpdateUserPassword()
        {
            try
            {
                var hashPassword = new HashPassword();
                string hashedPassword = hashPassword.HashedPassword(newPasswordTextBox.Text);

                // Update password and clear reset token
                bool success = DatabaseHelper.UpdatePassword(_email, hashedPassword) &&
                              DatabaseHelper.ClearResetToken(_email);

                if (success)
                {
                    MessageBox.Show("Password has been reset successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }

                MessageBox.Show("Failed to reset password. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SelectFX()
        {
            string soundPath = Path.Combine(Application.StartupPath, "assets", "Audio", "audio_selected.wav");
            _soundManager.PlaySoundEffect(soundPath);
        }

        private void newPassVisibleBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            newPasswordTextBox.PasswordChar = '\0';
            newPassInvisibleBtn.BringToFront();
        }

        private void newPassInvisibleBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            newPasswordTextBox.PasswordChar = '*';
            newPassVisibleBtn.BringToFront();
        }

        private void confirmPassVisibleBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            confirmTextBox.PasswordChar = '\0';
            confirmPassVisibleBtn.BringToFront();
        }

        private void confirmPassInvisibleBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            confirmTextBox.PasswordChar = '*';
            confirmPassInvisibleBtn.BringToFront();
        }
    }
}

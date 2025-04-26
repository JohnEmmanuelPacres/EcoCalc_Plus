using EcoCalc_Plus.UtilityClass;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;

namespace EcoCalc_Plus
{
    public partial class PasswordReset : UserControl
    {
        private SoundManager _soundManager;
        public event EventHandler ResetCompleted = delegate { };
        public event EventHandler CancelRequested = delegate { };
        public PasswordReset()
        {
            if (!this.DesignMode)
            {
                InitializeComponent();
            }
            _soundManager = new SoundManager();

            sendResetButton.Click += (sender, e) => SendResetLink(emailTextBox.Text);
            cancelButton.Click += (sender, e) => CancelRequested?.Invoke(this, EventArgs.Empty);
        }

        private void SelectFX()
        {
            string soundPath = Path.Combine(Application.StartupPath, "assets", "Audio", "audio_selectCalc.wav");
            _soundManager.PlaySoundEffect(soundPath);
        }

        private void SendResetLink(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter your email address.");
                return;
            }

            if (!DatabaseHelper.EmailExists(email))
            {
                MessageBox.Show("No account found with that email address.");
                return;
            }

            string resetToken = GenerateResetToken();
            DateTime expiration = DateTime.Now.AddHours(1);

            if (!DatabaseHelper.StoreResetToken(email, resetToken, expiration))
            {
                MessageBox.Show("Failed to generate reset token. Please try again.");
                return;
            }

            try
            {
                // Send the actual email
                SendEmail(email, resetToken);

                MessageBox.Show("Password reset link has been sent to your email address.",
                          "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ShowResetPasswordControl(email, resetToken);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email: {ex.Message}");
            }
        }

        private void SendEmail(string recipientEmail, string resetToken)
        {
            // Configure these values in your app.config or settings
            string smtpServer = "smtp.gmail.com"; // e.g., "smtp.gmail.com"
            int smtpPort = 587; // Typically 587 for TLS
            string smtpUsername = "pacresjohn029@gmail.com";
            string smtpPassword = "tclj rfdy nnag uyla";
            string fromEmail = "pacresjohn029@gmail.com";
            string appName = "EcoCalc Plus";

            using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(fromEmail, appName),
                    Subject = $"{appName} Password Reset",
                    Body = $@"You requested a password reset for {appName}. Your reset token is: {resetToken}. This token will expire in 1 hour. If you didn't request this, please ignore this email.",
                    IsBodyHtml = false // Set to true if you want HTML formatting
                };

                mail.To.Add(recipientEmail);
                client.Send(mail);
            }
        }

        private void ShowResetPasswordControl(string email, string token)
        {
            HideControls();
            var resetPasswordControl = new ResetPasswordControl(email);
            resetPasswordControl.PasswordResetComplete += (s, e) =>
            {
                this.Controls.Remove(resetPasswordControl);
                ResetCompleted?.Invoke(this, EventArgs.Empty);
                ShowControls();
            };
            resetPasswordControl.CancelRequested += (s, e) =>
            {
                this.Controls.Remove(resetPasswordControl);
                this.Visible = true;
                ShowControls();
            };

            this.Controls.Add(resetPasswordControl);
            this.Visible = true;
        }

        private void HideControls()
        {
            emailLabel.Visible = false;
            emailTextBox.Visible = false;
            sendResetButton.Visible = false;
            cancelButton.Visible = false;
        }

        private void ShowControls()
        {
            emailLabel.Visible = true;
            emailTextBox.Visible = true;
            sendResetButton.Visible = true;
            cancelButton.Visible = true;
        }

        private string GenerateResetToken()
        {
            return Guid.NewGuid().ToString() + DateTime.Now.Ticks.ToString();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            SelectFX();
        }

        private void sendResetButton_Click(object sender, EventArgs e)
        {
            SelectFX();
        }
    }
}

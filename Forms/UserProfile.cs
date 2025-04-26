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
using EcoCalc_Plus.Forms;

namespace EcoCalc_Plus
{
    public partial class UserProfile : UserControl
    {
        public event EventHandler RequestClose;
        private Image _originalUpdateAcc, _originalDeleteAcc, _originalExit, _originalMascot;
        private DataTable _footprintData;
        private readonly CarbonFootprintRepository _repository;
        private readonly int _userId;
        string _userSex;
        private SoundManager _soundManager = new SoundManager();
        public UserProfile(string username)
        {
            InitializeComponent();

            _originalUpdateAcc = updateAccBtn.Image;
            _originalDeleteAcc = deleteAccBtn.Image;
            _originalMascot = mascotPic.Image; //sprite_rawbot
            _originalExit = exitBtn.Image;
            _repository = new CarbonFootprintRepository();
            _userId = _repository.GetUserId(username);
            userLbl.Text = $"{username}";
            userIDLbl.Text = $"{_userId}";

            updatePanel.Visible = false;

            DashboardHelper.SetParent(exitBtn, userPanel);

            LoadProfileData();
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

        private void LoadProfileData()
        {
            try
            {
                _footprintData = _repository.GetUserFootprintHistory(_userId);
                _userSex = _repository.GetUserSex(_userId);
                if (_userSex == "F")
                {
                    mascotPic.Image = Properties.Resources.sprite_rawbotGirl;
                }
                else
                {
                    mascotPic.Image = _originalMascot;
                }
                CalculateDisplayAverage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateDisplayAverage()
        {
            if (_footprintData == null || _footprintData.Rows.Count == 0)
            {
                aveVehicleVal.Text = "0.00";
                aveHEVal.Text = "0.00";
                aveAppliancesVal.Text = "0.00";
                aveWasteVal.Text = "0.00";
                overallTotalVal.Text = "0.00";
                overallAveVal.Text = "0.00";
                return;
            }

            double SafeCalculate(string columnName, Func<IEnumerable<double>, double> operation)
            {
                var values = _footprintData.AsEnumerable()
                    .Where(row => !row.IsNull(columnName))
                    .Select(row => Convert.ToDouble(row[columnName]));

                return values.Any() ? operation(values) : 0.0;
            }

            double avgVehicle = SafeCalculate("VehicularEmission", vals => vals.Average());
            double avgHE = SafeCalculate("HomeEnergyEmission", vals => vals.Average());
            double avgAppliances = SafeCalculate("AppliancesEmission", vals => vals.Average());
            double avgWaste = SafeCalculate("WasteEmission", vals => vals.Average());

            double totalVehicle = SafeCalculate("VehicularEmission", vals => vals.Sum());
            double totalHE = SafeCalculate("HomeEnergyEmission", vals => vals.Sum());
            double totalAppliances = SafeCalculate("AppliancesEmission", vals => vals.Sum());
            double totalWaste = SafeCalculate("WasteEmission", vals => vals.Sum());

            double overallTotal = totalVehicle + totalHE + totalAppliances + totalWaste;
            double overallAve = (avgVehicle + avgHE + avgAppliances + avgWaste) / 4;

            if (unitComboBox.SelectedIndex == 1)
            {
                avgVehicle /= 2205;
                avgHE /= 2205;
                avgAppliances /= 2205;
                avgWaste /= 2205;

                totalVehicle /= 2205;
                totalHE /= 2205;
                totalAppliances /= 2205;
                totalWaste /= 2205;

                overallTotal = (totalVehicle + totalHE + totalAppliances + totalWaste);
                overallAve = (avgVehicle + avgHE + avgAppliances + avgWaste) / 4;
            }

            aveVehicleVal.Text = avgVehicle.ToString("N2");
            aveHEVal.Text = avgHE.ToString("N2");
            aveAppliancesVal.Text = avgAppliances.ToString("N2");
            aveWasteVal.Text = avgWaste.ToString("N2");
            overallTotalVal.Text = overallTotal.ToString("N2");
            overallAveVal.Text = overallAve.ToString("N2");
        }

        private void updateAccBtn_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityGeneral.ApplyHoverEffect(updateAccBtn, Properties.Resources.sprite_updateAccAlt, _originalUpdateAcc, true);
        }

        private void updateAccBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityGeneral.ApplyHoverEffect(updateAccBtn, Properties.Resources.sprite_updateAcc, _originalUpdateAcc, false);
        }

        private void deleteAccBtn_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityGeneral.ApplyHoverEffect(deleteAccBtn, Properties.Resources.sprite_deleteAccAlt, _originalDeleteAcc, true);
        }

        private void deleteAccBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityGeneral.ApplyHoverEffect(deleteAccBtn, Properties.Resources.sprite_deleteAcc, _originalDeleteAcc, false);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            var hostForm = this.FindForm();
            if (hostForm != null)
            {
                hostForm.DialogResult = DialogResult.Cancel;
                hostForm.Close();
            }
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

        private void updateAccBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            var updateControl = new UpdateAccount(userLbl.Text)
            {
                Dock = DockStyle.Fill
            };

            updateControl.RequestClose += (s, args) =>
            {
                updatePanel.Controls.Remove(updateControl);
                updatePanel.Visible = false;
            };

            updateControl.AccountUpdated += (s, args) =>
            {
                var result = MessageBox.Show("Account updated successfully. Would you like to refresh the data?",
                    "Success",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    LoadProfileData();
                }
            };

            updatePanel.Controls.Clear();
            updatePanel.Controls.Add(updateControl);
            updatePanel.Visible = true;
            updatePanel.BringToFront();
        }

        private void deleteAccBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            var confirmResult = MessageBox.Show(
                "WARNING: This will permanently delete your account and ALL associated data.\n\n" +
                "This action can't be undone. Are you sure you want to continue?",
                "Confirm Account Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                var repository = new CarbonFootprintRepository();
                bool success = repository.DeleteUserAccount(_userId);
                if (success)
                {
                    MessageBox.Show("Account deleted successfully.",
                          "Account Deleted",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);

                    Program.RestartApplication();
                }
                else
                {
                    MessageBox.Show("Failed to delete account. Please try again.",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting account: {ex.Message}",
                      "Error",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
            }
        }

        private void unitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateDisplayAverage();
        }
    }
}

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

namespace EcoCalc_Plus
{
    public partial class CustomLogInMessageBox : UserControl
    {
        private SoundManager _soundManager = new SoundManager();
        public event EventHandler OkClicked;
        public CustomLogInMessageBox()
        {
            InitializeComponent();
        }

        private void SelectFX()
        {
            string soundPath = Path.Combine(Application.StartupPath, "assets", "Audio", "audio_selected.wav");
            _soundManager.PlaySoundEffect(soundPath);
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            OkClicked?.Invoke(this, EventArgs.Empty);
        }

        private void CustomLogInMessageBox_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                //....stuff
            }
        }
    }
}

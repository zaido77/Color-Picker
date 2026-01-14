using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Color_Picker
{
    public partial class frmColorPicker : Form
    {

        public frmColorPicker()
        {
            InitializeComponent();

            pbRGBCopy.Tag = "RGB";
            pbHexaCopy.Tag = "Hexadecimal";

            pbRedValueCopy.Tag = "Red Value";
            pbGreenValueCopy.Tag = "Green Value";
            pbBlueValueCopy.Tag = "Blue Value";
        }

        private void tbColors_Scroll(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(tbRed.Value, tbGreen.Value, tbBlue.Value);

            this.BackColor = color;
            tbRed.BackColor = color;
            tbGreen.BackColor = color;
            tbBlue.BackColor = color;

            lblRed.Text = tbRed.Value.ToString();
            lblBlue.Text = tbBlue.Value.ToString();
            lblGreen.Text = tbGreen.Value.ToString();

            lblRGB.Text = $"({lblRed.Text}, {lblGreen.Text}, {lblBlue.Text})";
            lblHexa.Text = $"#{tbRed.Value:X2}{tbGreen.Value:X2}{tbBlue.Value:X2}";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbRed.Value = 255;
            tbGreen.Value = 255;
            tbBlue.Value = 255;

            this.BackColor = Color.White;

            tbRed.BackColor = Color.White;
            tbGreen.BackColor = Color.White;
            tbBlue.BackColor = Color.White;

            lblRed.Text = "255";
            lblGreen.Text = "255";
            lblBlue.Text = "255";

            lblRGB.Text = "(255, 255, 255)";
            lblHexa.Text = "#FFFFFF";
        }

        void ShowNotifyBalloon(PictureBox pbCopy)
        {
            notifyIcon1.Icon = SystemIcons.Information;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipTitle = "Copy Success";
            notifyIcon1.BalloonTipText = $"{pbCopy.Tag.ToString()} Copied Successfully!";
            notifyIcon1.ShowBalloonTip(5);
        }

        Label GetCopyLabel(PictureBox pbCopy)
        {
            if (pbCopy == pbRGBCopy) return lblRGB;
            if (pbCopy == pbHexaCopy) return lblHexa;

            if (pbCopy == pbRedValueCopy) return lblRed;
            if (pbCopy == pbGreenValueCopy) return lblGreen;
            if (pbCopy == pbBlueValueCopy) return lblBlue;

            return null;
        }

        private void pbCopy_Click(object sender, EventArgs e)
        {
            PictureBox pbCopy = (PictureBox)sender;

            Label lbl = GetCopyLabel(pbCopy);

            if (lbl != null && !string.IsNullOrWhiteSpace(lbl.Text))
            {
                Clipboard.SetText(lbl.Text);
                ShowNotifyBalloon(pbCopy);
            }
        }

    }
}

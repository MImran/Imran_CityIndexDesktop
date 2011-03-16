using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenSaverConfigurator
{
    public partial class FormConfiguration : Form
    {
        public FormConfiguration()
        {
            InitializeComponent();
        }


        CityIndexHelper.ConfigurationHelper CIConfigHelper;

        CityIndexHelper.UIConfiguration uiConfiguration;


        private void FormScreenSaver_Load(object sender, EventArgs e)
        {
            loadSettings();
            bindSlider();
            bindColors();
            bindFontNames();
            bindFontSizes();
        }
        private void loadSettings()
        {
            CIConfigHelper = new CityIndexHelper.ConfigurationHelper(Application.StartupPath);
            uiConfiguration = CIConfigHelper.GetConfigurations();
        }

        private void bindSlider()
        {
            this.trackBarOpacity.Value = uiConfiguration.Opacity / 10;
        }
        private void bindColors()
        {
            this.panelBackColor.BackColor = Color.FromArgb(uiConfiguration.BackColor);
            this.labelForeColor.ForeColor = Color.FromArgb(uiConfiguration.ForeColor);
        }
        private void bindFontNames()
        {
            FontFamily[] systemFonts = FontFamily.Families;
            foreach (FontFamily font in systemFonts)
            {
                this.comboBoxFont.Items.Add(font.Name);
            }

            comboBoxFont.SelectedItem = uiConfiguration.FontName;
        }
        private void bindFontSizes()
        {
            double baseIncriment = 9;
            for (int i = 0; i < 10; i++)
            {
                this.comboBoxFontSize.Items.Add(baseIncriment);
                baseIncriment += 0.5;
            }

            comboBoxFontSize.SelectedItem = uiConfiguration.FontSize;
        }

        private void buttonSelectBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.FullOpen = true;
            colorDlg.Color = panelBackColor.BackColor;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                panelBackColor.BackColor = colorDlg.Color;
            }
        }

        private void buttonSelectForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.FullOpen = true;
            colorDlg.Color = labelForeColor.ForeColor;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                labelForeColor.ForeColor = colorDlg.Color;
            }
        }

        private void buttonTestScreenSaver_Click(object sender, EventArgs e)
        {

        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            CIConfigHelper = new CityIndexHelper.ConfigurationHelper(Application.StartupPath);

            uiConfiguration.Opacity = trackBarOpacity.Value * 10;
            uiConfiguration.BackColor = panelBackColor.BackColor.ToArgb();
            uiConfiguration.ForeColor = labelForeColor.ForeColor.ToArgb();
            uiConfiguration.FontName = comboBoxFont.SelectedItem.ToString();
            uiConfiguration.FontSize = Convert.ToDouble(comboBoxFontSize.SelectedItem.ToString());

            CIConfigHelper.SetConfigurations(uiConfiguration);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elvis.Properties;
using ElvisDataModel.Configuration;

namespace Elvis.Forms
{
    public partial class ParameterEditorForm : Form
    {
        SystemConfiguration SystemConfiguration { get; set; }

        public ParameterEditorForm()
        {
            InitializeComponent();
            CustomiseColours();            
        }

        private void CustomiseColours()
        {
            BackColor = parametersGroupBox.BackColor = Settings.Default.ColourBackground;
            ForeColor = parametersGroupBox.ForeColor = Settings.Default.ColourText;
        }

        private void ParameterEditorForm_Load(object sender, EventArgs e)
        {
            SystemConfiguration = ConfigurationCoordinator.LoadConfiguration();
            parametersPropertyGrid.SelectedObject = SystemConfiguration;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            ConfigurationCoordinator.SaveConfiguration(SystemConfiguration);
        }
    }
}

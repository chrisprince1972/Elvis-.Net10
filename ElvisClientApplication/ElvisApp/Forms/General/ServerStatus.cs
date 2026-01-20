using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Elvis.Common;

namespace Elvis.Forms.General
{
    public partial class ServerStatus : UserControl
    {
        private List<string> servers = new List<string>()
        {
            "PTCCL3SQL.porttalbot.pcswales.corusgroup.com",         //Main Server
            "PTSSELVISTEST.porttalbot.pcswales.corusgroup.com",     //Test Server
            "PTPCSQLCLUSTER.porttalbot.pcswales.corusgroup.com",    //Miscast Server
            "PTCCINSQL.porttalbot.pcswales.corusgroup.com",         //Caster Data Server
            "PS_PI.porttalbot.pcswales.corusgroup.com",             //PI Server
            "PTBOSAPP.porttalbot.pcswales.corusgroup.com"           //Populator Server
        };

        public ServerStatus()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button Refresh Event Handler.
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PingServers();
        }

        /// <summary>
        /// Runs the ping commands on the servers and 
        /// colours the Panels depending on success.
        /// </summary>
        public void PingServers()
        {
            foreach (string server in servers)
            {
                IPStatus serverStatus = CommonMethods.PingHost(server);
                ColourServer(serverStatus, GetPanelByServerName(server));
            }
        }

        /// <summary>
        /// Finds the Panel to Colour by Server Name.
        /// </summary>
        /// <param name="server">The Name of the server.</param>
        /// <returns>The Panel associated with that server.</returns>
        private Panel GetPanelByServerName(string server)
        {
            switch (server)
            {
                case "PTCCL3SQL.porttalbot.pcswales.corusgroup.com":
                    return pnlPTCCL3SQL;
                case "PTSSELVISTEST.porttalbot.pcswales.corusgroup.com":
                    return pnlPTSSELVISTEST;
                case "PTPCSQLCLUSTER.porttalbot.pcswales.corusgroup.com":
                    return pnlPTPCSQLCLUSTER;
                case "PTCCINSQL.porttalbot.pcswales.corusgroup.com":
                    return pnlPTCCINSQL;
                case "PS_PI.porttalbot.pcswales.corusgroup.com":
                    return pnlPSPI;
                case "PTBOSAPP.porttalbot.pcswales.corusgroup.com":
                    return pnlPTBOSAPP;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Checks the status and colours a 
        /// panel depending on the result.
        /// </summary>
        private void ColourServer(IPStatus iPStatus, Panel pnlToColour)
        {
            if (pnlToColour != null)
            {
                if (iPStatus != IPStatus.Unknown)
                {
                    pnlToColour.ForeColor = Color.Black;
                    pnlToColour.BackColor = ColorTranslator.FromHtml("#26F43E");//Green
                    return;
                }
                pnlToColour.ForeColor = Color.White;
                pnlToColour.BackColor = ColorTranslator.FromHtml("#e12301");//Red
            }
        }
    }
}

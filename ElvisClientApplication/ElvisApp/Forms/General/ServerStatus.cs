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
        // NOTE:
        // Ping checks HOST reachability, not SQL Server instance.
        // So use "CPLAPTOP" (or "localhost"), not "CPLAPTOP\\MSSQLSERVER01".

        // Legacy servers are kept commented (not deleted).
        private readonly List<string> servers = new List<string>()
        {
            // Legacy:
            // "PTCCL3SQL.porttalbot.pcswales.corusgroup.com",         //Main Server
            // "PTSSELVISTEST.porttalbot.pcswales.corusgroup.com",     //Test Server

            // Local replacements:
            "CPLAPTOP",   //Main Server (local host)
            "localhost",  //Test Server (local host)

            // Leave these as-is if you still want to show status for them:
            "PTPCSQLCLUSTER.porttalbot.pcswales.corusgroup.com",    //Miscast Server
            "PTCCINSQL.porttalbot.pcswales.corusgroup.com",         //Caster Data Server
            "PS_PI.porttalbot.pcswales.corusgroup.com",             //PI Server
            "PTBOSAPP.porttalbot.pcswales.corusgroup.com"           //Populator Server
        };

        public ServerStatus()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PingServers();
        }

        public void PingServers()
        {
            foreach (string server in servers)
            {
                IPStatus serverStatus = CommonMethods.PingHost(server);
                ColourServer(serverStatus, GetPanelByServerName(server));
            }
        }

        private Panel GetPanelByServerName(string server)
        {
            switch (server)
            {
                // Legacy mappings (kept):
                // case "PTCCL3SQL.porttalbot.pcswales.corusgroup.com":
                //     return pnlPTCCL3SQL;
                // case "PTSSELVISTEST.porttalbot.pcswales.corusgroup.com":
                //     return pnlPTSSELVISTEST;

                // Local replacements map onto the existing panels:
                case "CPLAPTOP":
                    return pnlPTCCL3SQL;      // reuse "Main Server" panel
                case "localhost":
                    return pnlPTSSELVISTEST;  // reuse "Test Server" panel

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

        private void ColourServer(IPStatus iPStatus, Panel pnlToColour)
        {
            if (pnlToColour != null)
            {
                if (iPStatus != IPStatus.Unknown)
                {
                    pnlToColour.ForeColor = Color.Black;
                    pnlToColour.BackColor = ColorTranslator.FromHtml("#26F43E"); // Green
                    return;
                }
                pnlToColour.ForeColor = Color.White;
                pnlToColour.BackColor = ColorTranslator.FromHtml("#e12301"); // Red
            }
        }
    }
}

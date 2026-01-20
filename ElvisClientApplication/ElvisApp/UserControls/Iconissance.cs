//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Drawing;
//using System.Net;
//using System.Net.Sockets;
//using System.Windows.Forms;

//public class Iconissance
//{
//    private string multiCastIP = "224.5.6.7";
//    private int multiCastPort = 9998;
//    private Socket sockIn;
//    private Label lblV1, lblV2;
//    private Label lblCAS1, lblCAS2;
//    private Label lblRH, lblRD;
//    private Secondary.NET.ControlMiniUnit miniCAS1;
//    private Secondary.NET.ControlMiniUnit miniCAS2;
//    private Secondary.NET.ControlMiniUnit miniRH;
//    private Secondary.NET.ControlMiniUnit miniRD;
//    private Secondary.NET.ControlUnit maxiCAS1;
//    private Secondary.NET.ControlUnit maxiCAS2;
//    private Secondary.NET.ControlUnit maxiRH;
//    private Secondary.NET.ControlUnit maxiRD;
//    private global::Secondary.NET.Form1 form1;

//    public Iconissance(global::Secondary.NET.Form1 form,
//                       Label lblv1,
//                       Label lblv2,
//                       Label lblcas1,
//                       Label lblcas2,
//                       Label lblrh,
//                       Label lblrd,
//                       Secondary.NET.ControlMiniUnit minicas1,
//                       Secondary.NET.ControlMiniUnit minicas2,
//                       Secondary.NET.ControlMiniUnit minirh,
//                       Secondary.NET.ControlMiniUnit minird,
//                       Secondary.NET.ControlUnit maxicas1,
//                       Secondary.NET.ControlUnit maxicas2,
//                       Secondary.NET.ControlUnit maxirh,
//                       Secondary.NET.ControlUnit maxird)
//    {
//        form1 = form;
//        lblV1 = lblv1;
//        lblV2 = lblv2;
//        lblCAS1 = lblcas1;
//        lblCAS2 = lblcas2;
//        lblRH = lblrh;
//        lblRD = lblrd;
//        miniCAS1 = minicas1;
//        miniCAS2 = minicas2;
//        miniRH = minirh;
//        miniRD = minird;
//        maxiCAS1 = maxicas1;
//        maxiCAS2 = maxicas2;
//        maxiRH = maxirh;
//        maxiRD = maxird;

//        IPAddress ip = IPAddress.Parse(multiCastIP);

//        sockIn = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
//        sockIn.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
//        sockIn.Bind(new IPEndPoint(IPAddress.Any, multiCastPort));
//        sockIn.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(ip, IPAddress.Any));

//        PostRead();
//    }

//    private void PostRead()
//    {
//        sockIn.BeginReceive(buffer,
//                            0,
//                            buffer.Length,
//                            SocketFlags.None,
//                            new AsyncCallback(ReceiveData),
//                            null);
//    }

//    private byte[] buffer = new byte[16 * 1024];

//    private void ReceiveData(IAsyncResult asyn)
//    {
//        int bytesread = sockIn.EndReceive(asyn);
//        if (bytesread > 0)
//        {
//            string combi = Encoding.UTF8.GetString(buffer, 0, bytesread);
//            foreach (string str in combi.Split('\n'))
//            {
//                if (str.StartsWith("Loc=V1 ")) UpdateUnit(lblV1, null, null, str);
//                else if (str.StartsWith("Loc=V2 ")) UpdateUnit(lblV2, null, null, str);
//                else if (str.StartsWith("Loc=CAS1 ")) UpdateUnit(lblCAS1, miniCAS1, maxiCAS1, str);
//                else if (str.StartsWith("Loc=CAS2 ")) UpdateUnit(lblCAS2, miniCAS2, maxiCAS2, str);
//                else if (str.StartsWith("Loc=RH ")) UpdateUnit(lblRH, miniRH, maxiRH, str);
//                else if (str.StartsWith("Loc=RD ")) UpdateUnit(lblRD, miniRD, maxiRD, str);
//            }
//        }
//        PostRead();
//    }

//    private void UpdateUnit(Label lbl, Secondary.NET.ControlMiniUnit mini, Secondary.NET.ControlUnit maxi, string str)
//    {
//        string heat = "0";
//        string ladle = "0";
//        string state = "";
//        string loc = "";
//        string off = null;
//        foreach (string eq in str.Split(' '))
//        {
//            string[] pair = eq.Split('=');
//            switch (pair[0])
//            {
//                case "Loc":
//                    loc = pair[1];
//                    break;
//                case "St":
//                    state = pair[1].Replace('_', ' ');
//                    break;
//                case "Off":
//                    if (pair[1] == "1") off = "PM/Standby";
//                    else if (pair[1] == "2") off = "Reline";
//                    break;
//                case "Heat":
//                    heat = pair[1];
//                    break;
//                case "Ladle":
//                    ladle = pair[1];
//                    break;
//                default:
//                    break;
//            }
//        }
//        if (off != null) state = off;

//        if (form1.IsHandleCreated)
//        {
//            form1.BeginInvoke(new MethodInvoker(delegate
//            {
//                string txt;
//                if (heat != "0") txt = state + " " + heat;
//                else if (ladle != "0") txt = state + " " + ladle;
//                else txt = state;
//                lbl.Text = loc + " " + txt;
//                if (mini != null)
//                {
//                    mini.Status = txt;
//                    mini.HeatNumber = int.Parse(heat);
//                    mini.LadleNumber = int.Parse(ladle);
//                }
//                if (maxi != null)
//                {
//                    maxi.HeatNumber = int.Parse(heat);
//                    maxi.LadleNumber = int.Parse(ladle);
//                    maxi.Status = txt;
//                }
//            }));
//        }
//    }
//}

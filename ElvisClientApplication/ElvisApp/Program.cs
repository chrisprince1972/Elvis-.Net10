using Elvis.Common;
using NLog;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Elvis
{
    public static class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Sets up a global catch for errors
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Forms.MainForm main = new Forms.MainForm();

            //Only log login if running deployed version
            //TODO: fix this block commented out on conversion
            //if (ApplicationDeployment.IsNetworkDeployed)
            //{
            //    if (main.Text.Contains("Development"))
            //        logger.Info("Login - Development v" + HelperFunctions.GetVersionNumber());
            //    else
            //        logger.Info("Login - v" + HelperFunctions.GetVersionNumber());
            //}
            //else if (!Debugger.IsAttached) 
            //{
            //    if (main.Text.Contains("Development"))
            //        logger.Info("Login - Standalone Development v" + HelperFunctions.GetVersionNumber());
            //    else
            //        logger.Info("Login - Standalone v" + HelperFunctions.GetVersionNumber());
            //}

            Application.Run(main);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string userInfo = CommonMethods.UnknownErrorHandled();
            logger.ErrorException(string.Format(
                "Unknown Error! Additional Info: Data - {0}: InnerException - {1}: "
                + " Message - {2}: Source - {3}: TargetSite - {4}: "
                + " UserInfo - {5}",
                e.Exception.Data, e.Exception.InnerException, e.Exception.Message,
                e.Exception.Source, e.Exception.TargetSite, userInfo), e.Exception);
            Application.Exit();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string userInfo = CommonMethods.UnknownErrorHandled();
            logger.Error(string.Format(
                "Unknown Error! Additional Info: {0}: UserInfo - {1}",
                e.ExceptionObject, userInfo)
                );
            Application.Exit();
        }
    }
}
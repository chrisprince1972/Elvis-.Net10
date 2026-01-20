//using System;
//using System.Runtime.ConstrainedExecution;
//using System.Runtime.InteropServices;
//using System.Security;
//using System.Security.Permissions;
//using System.Security.Principal;
//using Microsoft.Win32.SafeHandles;
//using NLog;

//namespace Elvis.Common
//{
//    /// <summary>
//    /// Impersonates a user to perform specific actions while the object is in context.
//    /// Inspired by example on MSDN WindowsIdentity.Impersonate Method 
//    /// https://msdn.microsoft.com/en-us/library/w070t6ka(v=vs.110).aspx
//    /// </summary>
//    class Impersonate : IDisposable
//    {
//        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
//        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
//            int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);

//        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
//        public extern static bool CloseHandle(IntPtr handle);

//        private string Username { get; set; }
//        private string DomainName { get; set; }
//        private string Password { get; set; }
//        private bool Disposed { get; set; }

//        private SafeTokenHandle TokenHandle { get; set; }
//        private WindowsIdentity Identity { get; set; }
//        private WindowsImpersonationContext ImpersonationContext { get; set; }
//        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

//        /// <summary>
//        /// Constructor.
//        /// 
//        /// </summary>
//        /// <param name="domainName">Domain of user to impersonate.</param>
//        /// <param name="username">Username of user to impersonate.</param>
//        /// <param name="password">Password of user to impersonate.</param>
//        /// 
//        /// <exception cref="System.ArgumentException">
//        ///     userToken is 0.-or-userToken is duplicated and invalid for impersonation.
//        /// </exception>
//        /// <exception cref="System.Security.SecurityException">
//        ///    The caller does not have the correct permissions. -or-A Win32 error occurred.
//        /// </exception>
//        /// <exception cref="System.ComponentModel.Win32Exception">
//        ///    The Win32 error code associated with this exception.
//        /// </exception>
//        /// <exception cref="System.InvalidOperationException">
//        ///    An anonymous identity attempted to perform an impersonation.
//        /// </exception>
//        public Impersonate(string domainName, string username, string password)
//        {
//            this.DomainName = domainName;
//            this.Username = username;
//            this.Password = password;
//            this.Disposed = false;
//            this.ImpersonationContext = GetContext();
//        }

//        /// <summary>
//        /// Gets the impersonation context.
//        /// Seperated out so the constructor is not too complicated.
//        /// </summary>
//        /// 
//        /// <returns>
//        /// Impersionation context of the user passed in at the constructor.
//        /// </returns>
//        /// 
//        /// <exception cref="System.ArgumentException">
//        ///     userToken is 0.-or-userToken is duplicated and invalid for impersonation.
//        /// </exception>
//        /// <exception cref="System.Security.SecurityException">
//        ///    The caller does not have the correct permissions. -or-A Win32 error occurred.
//        /// </exception>
//        /// <exception cref="System.ComponentModel.Win32Exception">
//        ///    The Win32 error code associated with this exception.
//        /// </exception>
//        /// <exception cref="System.InvalidOperationException">
//        ///    An anonymous identity attempted to perform an impersonation.
//        /// </exception>
//        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
//        private WindowsImpersonationContext GetContext()
//        {
//            WindowsImpersonationContext impersonation = null;
//            try
//            {
//                // Get the user token for the specified user, domain, and password using the 
//                // unmanaged LogonUser method. 
//                // The local machine name can be used for the domain name to impersonate a user on this machine.
//                const int LOGON32_PROVIDER_DEFAULT = 0;
//                //This parameter causes LogonUser to create a primary token. 
//                const int LOGON32_LOGON_INTERACTIVE = 2;

//                // Call LogonUser to obtain a handle to an access token. 
//                SafeTokenHandle tokenHandle;
//                bool returnValue = LogonUser(
//                    this.Username, 
//                    this.DomainName, 
//                    this.Password,
//                    LOGON32_LOGON_INTERACTIVE, 
//                    LOGON32_PROVIDER_DEFAULT,
//                    out tokenHandle);
//                this.TokenHandle = tokenHandle;

//                if (false == returnValue)
//                {
//                    int ret = Marshal.GetLastWin32Error();
//                    logger.Error("Impersonate::GetContext -- LogonUser failed with error code : {0}.", ret);
//                    throw new System.ComponentModel.Win32Exception(ret);
//                }

//                string currentName = WindowsIdentity.GetCurrent().Name;

//                // Use the token handle returned by LogonUser. 
//                this.Identity = new WindowsIdentity(this.TokenHandle.DangerousGetHandle());
//                impersonation = this.Identity.Impersonate();
//            }
//            catch (Exception ex)
//            {
//                logger.ErrorException("Impersonate::GetContext -- Exception occurred. ", ex);
//            }

//            return impersonation;
//        }

//        /// <summary>
//        /// Destructor.
//        /// </summary>
//        public void Dispose()
//        {
//            if (!this.Disposed)
//            {
//                this.Disposed = true;

//                if (this.TokenHandle != null)
//                {
//                    this.TokenHandle.Dispose();
//                }
//                if (this.Identity != null)
//                {
//                    this.Identity.Dispose();
//                }
//                if (this.ImpersonationContext != null)
//                {
//                    this.ImpersonationContext.Dispose();
//                }
//            }
//        }
//    }

//    public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
//    {
//        private SafeTokenHandle()
//            : base(true)
//        {
//        }

//        [DllImport("kernel32.dll")]
//        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
//        [SuppressUnmanagedCodeSecurity]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        private static extern bool CloseHandle(IntPtr handle);

//        protected override bool ReleaseHandle()
//        {
//            return CloseHandle(handle);
//        }
//    }

//}




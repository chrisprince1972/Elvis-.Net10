using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using ElvisDataModel.EDMX;
using NLog;
using ElvisDataModel;

namespace Elvis.Common
{
    /// <summary>
    /// Static class providing security framework functionality.
    /// </summary>
    public static class SecurityLayer
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Sets the Thread.CurrentPrincipal to a Generic Principal with a list of custom
        /// roles where they have been defined in the Elvis database for that user.
        /// </summary>
        public static void SetCurrentPrincipal()
        {
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            string[] roles = { "StandardUser" };

            try
            {
                User user = EntityHelper.Users.GetUserByName(windowsIdentity.Name);
                if (user != null)
                {
                    roles = user.Roles.Select(r => r.RoleName).ToArray<string>();
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Loading user -- ", ex);
            }

            // Construct a GenericIdentity object based on the current Windows
            // identity name and authentication type.
            GenericIdentity genericIdentity = new GenericIdentity(
                windowsIdentity.Name, windowsIdentity.AuthenticationType);

            // Construct a transient GenericPrincipal object based on the generic identity
            // and custom roles for the user, and assign to the CurrentPrincipal.
            Thread.CurrentPrincipal = new GenericPrincipal(genericIdentity, roles);
        }

        /// <summary>
        /// Returns a collection of roles for a given user.
        /// </summary>
        /// <param name="username">The user's username.</param>
        /// <returns>A collection of the user's roles.</returns>
        public static IEnumerable<Role> GetRolesForUser(string username)
        {
            IEnumerable<Role> roles = null;
            try
            {
                roles = EntityHelper.Users.GetRolesForUser(username);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Loading user's roles -- ", ex);
            }
            return roles;
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="user">The User to delete</param>
        /// <returns>True if the user was deleted.</returns>
        public static bool DeleteUser(User user)
        {
            bool isDeleted = false;

            try
            {
                isDeleted = EntityHelper.Users.DeleteUser(user);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Error Deleting User -- ", ex);
            }

            return isDeleted;
        }

        /// <summary>
        /// Returns a collection of all Elvis roles.
        /// </summary>
        /// <returns>A collection of roles</returns>
        public static List<Role> GetAllRoles()
        {
            List<Role> roles = null;
            try
            {
                roles = EntityHelper.Roles.GetAllRoles();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Loading all roles -- ", ex);
            }
            return roles;
        }

        /// <summary>
        /// Gets a distinct list of usernames from the Elvis log.
        /// </summary>
        /// <returns>A collection of fully-qualified domain names</returns>
        public static List<string> GetPreviousLoginNames()
        {
            List<string> logins = null;
            try
            {
                logins = EntityHelper.Logs.GetPreviousLoginNames().ToList();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Loading previous login names -- ", ex);
            }
            return logins;
        }
    }
}

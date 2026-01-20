using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using ElvisDataModel.EDMX;

namespace ElvisDataModel
{
    public static partial class EntityHelper
    {
        #region User table functions
        public static class Users
        {
            /// <summary>
            /// TABLE -- Security.Users.
            /// Returns an Elvis user from a username.
            /// </summary>
            /// <param name="username">The full DOMAIN\UserName of the user</param>
            /// <returns>A user, including their roles if any.</returns>
            public static User GetUserByName(string username)
            {
                using (SecuritySchemaEntities ctx = new SecuritySchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.Users
                        .Include("Roles")
                        .SingleOrDefault(u => u.Username == username);
                }
            }

            /// <summary>
            /// Retrieves a user's roles from their username.
            /// </summary>
            /// <param name="username">Full domain username</param>
            /// <returns>A collection of the User's roles.</returns>
            public static IEnumerable<Role> GetRolesForUser(string username)
            {
                return GetUserByName(username).Roles;
            }

            /// <summary>
            /// Retrieves a user's roles from an entity object.
            /// </summary>
            /// <param name="user">Instance of a user</param>
            /// <returns>A collection of the User's roles.</returns>
            public static IEnumerable<Role> GetRolesForUser(User user)
            {
                return GetUserByName(user.Username).Roles;
            }

            /// <summary>
            /// Retrieves a user's roles from a GenericPrincipal instance.
            /// </summary>
            /// <param name="genericPrincipal">GenericPrincipal for the user</param>
            /// <returns>A collection of the User's roles.</returns>
            public static IEnumerable<Role> GetRolesForUser(GenericPrincipal genericPrincipal)
            {
                return GetUserByName(genericPrincipal.Identity.Name).Roles;
            }

            /// <summary>
            /// Retrieves a list of all named Elvis users.
            /// </summary>
            /// <returns>A collection of User instances.</returns>
            public static List<User> GetAllUsers()
            {
                using (SecuritySchemaEntities ctx = new SecuritySchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.Users.Include("Roles").OrderBy(u => u.Username).ToList();
                }
            }

            /// <summary>
            /// Deletes an Elvis user.
            /// </summary>
            /// <param name="user">The user to delete.</param>
            /// <returns>Value greater than zero if successful.</returns>
            public static bool DeleteUser(User user)
            {
                int numObjectsChanged = 0;

                if (user != null)
                {
                    using (SecuritySchemaEntities ctx = new SecuritySchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                    {
                        ctx.Users.Attach(user);
                        ctx.Users.DeleteObject(user);
                        numObjectsChanged = ctx.SaveChanges();
                    }
                }
                return numObjectsChanged > 0;
            }
        }
        #endregion

        #region Roles tables functions
        public static class Roles
        {
            /// <summary>
            /// TABLE -- Security.Roles
            /// </summary>
            /// <returns>A list of Elvis Roles.</returns>
            public static List<Role> GetAllRoles()
            {
                using (SecuritySchemaEntities ctx = new SecuritySchemaEntities(EntityHelper.ElvisDBSettings.ConnectionString))
                {
                    return ctx.Roles.ToList();
                }
            }
        }
        #endregion
    }
}

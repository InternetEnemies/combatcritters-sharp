namespace CombatCrittersSharp.rest.routes
{
    public static class UsersRoutes
    {
        /// <summary>
        /// -GET
        /// </summary>
        /// <returns></returns>
        public static string GetAllUsers()
        {
            return "/admin/users";
        }

        /// <summary>
        /// -DELETE a user by ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>The delete user routes</returns>
        public static string DeleteUser(int userId)
        {
            return $"/admin/users/{userId}";
        }

    }
}
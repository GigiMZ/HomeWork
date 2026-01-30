namespace UserManager
{
    class Program
    {
        static void Main()
        {
            User u1 = new User("test1234", "test123");
            User u2 = new User("test12333", "test123");
            User u3 = new User("test1234444", "test123");
            User u4 = new User("test1235555", "2323");
            User u5 = new User("test1230000", "1111");
            User u6 = new User("test123456781", "123456");
            User u7 = new User("test123456782", "123456");
            User u8 = new User("test123456783", "123456");
            User u9 = new User("test123456784", "123456");
            User u10 = new User("test123456785", "123456");
            User u11 = new User("test123456786", "123456");
            User u12 = new User("test123456787", "123456");
            
            Console.WriteLine(UserManager.Register(u1));
            Console.WriteLine(UserManager.Register(u2));
            Console.WriteLine(UserManager.Register(u3));
            Console.WriteLine(UserManager.Register(u4));
            Console.WriteLine(UserManager.Register(u5));
            Console.WriteLine(UserManager.Register(u6));
            Console.WriteLine(UserManager.Register(u7));
            Console.WriteLine(UserManager.Register(u8));
            Console.WriteLine(UserManager.Register(u9));
            Console.WriteLine(UserManager.Register(u10));
            Console.WriteLine(UserManager.UnRegister(u4.Username));
            // Console.WriteLine(UserManager.Register(u4));
            Console.WriteLine(UserManager.Register(u11));
            Console.WriteLine(UserManager.Register(u12));
            Console.WriteLine(UserManager.Register(u4));
            Console.WriteLine(UserManager.UnRegister(u11.Username));
            Console.WriteLine(UserManager.UnRegister(u1.Username));
            Console.WriteLine(UserManager.UnRegister(u2.Username));
            Console.WriteLine(UserManager.UnRegister(u7.Username));
            Console.WriteLine(UserManager.Register(u7));
            Console.WriteLine(UserManager.UnRegister(u9.Username));
            

            // foreach (var user in UserManager._users)
            // {
            //     Console.Write(user?.Username+", ");
            // }
        }
    }

    class User
    {
        public User(string username, string password)
        {
            ValidateUsername(username);
            ValidatePassword(password);
            Username = username;
            Password = password;
        }

        public string Username { get; }
        public string Password { get; private set; }

        public void ChangePassword(string currentPassword, string newPassword)
        {
            if (currentPassword == newPassword)
                throw new ArgumentException("New password cannot be the same as the current password.");
            if (Password != currentPassword)
                throw new ArgumentException("Current password is incorrect.");

            ValidatePassword(newPassword);
            Password = newPassword;
        }

        private static void ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be null or empty.");
            if (username.Length < 8)
                throw new ArgumentException("Username must be at least 8 characters long.");
        }

        private static void ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be null or empty.");
            if (password.Length < 4)
                throw new ArgumentException("Password must be at least 4 characters long.");
        }
    }

    static class UserManager
    {
        private static User?[] _users = new User?[10];

        public static int Register(User? user)
        {
            if (user == null)
                return -1;

            if (UserExists(user.Username))
                return -2;

            int emptyIndex = GetEmptySlotIndex();
            // Modify Systems so if there is no empty slot, it should add a new slot dynamically.
            // For now, we return -3 to indicate no available slots.

            _users[emptyIndex] = user;
            return 0;
        }

        public static bool Login(string username, string password)
            => GetUser(username)?.Password == password;

        public static bool UnRegister(string username)
        {
            int index = GetUserIndex(username);
            if (index == -1)
                return false;
            _users[index] = null;
            NullRemover();
            return true;
        }

        private static void NullRemover()
        {
            User?[] newArray = new User[_users.Length-1];
            int calibrator = 0;
            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i] == null)
                {
                    calibrator++;
                    continue;
                }
                newArray[i - calibrator] = _users[i];
            }
            _users = newArray;
        }

        private static int GetUserIndex(string username)
        {
            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i]?.Username == username)
                    return i;
            }

            return -1;
        }

        private static User? GetUser(string username)
        {
            int index = GetUserIndex(username);
            return index != -1
                ? _users[index]
                : null;
        }

        private static bool UserExists(string username)
            => GetUserIndex(username) != -1;

        private static int GetEmptySlotIndex()
        {
            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i] == null)
                    return i;
            }

            return ResizeUsers();
        }

        private static int ResizeUsers()
        {
            int newIndex = _users.Length + 1;
            User?[] newUsers = new User[newIndex];
            for (int i = 0; i < newIndex-1; i++)
            {
                newUsers[i] = _users[i];
            }
            _users = newUsers;
            return newIndex-1;
        }
    }
}
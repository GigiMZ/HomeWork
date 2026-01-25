namespace UserManager
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(UserManager.Login("nika1998", "123")); //false
            User user1 = new User();
            user1.Username = "nika1998";
            user1.Password = "123";
            Console.WriteLine(UserManager.Register(user1)); //0
            Console.WriteLine(UserManager.Register(user1)); //-2
            User user2 = new User() { Username = "Nino9796", Password = "9796" };
            Console.WriteLine(UserManager.Register(user2)); //0
            Console.WriteLine(UserManager.Login("nika1998", "123")); //true
            Console.WriteLine(UserManager.Login("nika1998", "111")); //false
            Console.WriteLine(UserManager.UnRegister("nikusha1998")); //false
            Console.WriteLine(UserManager.UnRegister("nika1998")); //true
            Console.WriteLine(UserManager.Login("nika1998", "123")); //false
        }
    }

    //davadot dacva, rom Username-ze ar sheizlebodes 8 simboloze ufro naklebi mnishvnelobis minicheba.
    class User
    {
        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (value.Length >= 8)
                {
                    _username = value;
                }
                Console.WriteLine("Username is less than 8 characters.");
            }
        }
        public string Password { get; set; }
    }

    static class UserManager
    {
        private static User?[] _users = new User?[10];

        public static int Register(User u)
        {
            /* funqciam unda modzebnos _users masivshi pirveli tavisufali elementi (anu elementi
            * romlis mnishvnelobac null-is tolia) da mianichos mas gadmocemuli useris obieqti (parametri u).
            * oghond, unda gaitvaliswinos shemdegi pirobebi:
            * 1. gadmocemul parametrshi uechveli unda iyos username da paroli.
            *    tu parametrebi araa mowodebuli, shewyvitos registracia da daabrunos -1.
            * 2. gadaamowmos rom username unikaluri iyos, anu tu romelime elements gaachnia igive saxelis username
            *    shewyvitos registracia da daabrunos -2.
            * 3. tu masivshi agharaa carieli elementebi (anu sheivso 10ive), mashin daabrunos -3.
            * tu arcerti zeda shemtxveva ar moxda daaregistriros momxmarebeli (mianichos masivis elements)
            * da daabrunos 0.
            */
            
            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i] == null)
                {
                    _users[i] = u;
                    return 0;
                }

                if (_users[i].Username == u.Username)
                {
                    return -2;
                }
                
            }

            return -3;
        }

        public static bool Login(string username, string password)
        {
            /* funqciam unda modzebnos arsebobs tu ara _users masivshi chanaweri (elementi),
            * romelsac gaachnia igive Username da Paroli rac gadmogvces parametrebshi.
            * tu aseti chanaweri ipova daabrunos true, winaaghmdeg shemtxvevashi false. */

            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i] == null) return false;
                if (_users[i].Username == username && _users[i].Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool UnRegister(string username)
        {
            /*  funqciam unda modzebnos arsebobs tu ara _users masivshi chanaweri (elementi),
            * romelsac gaachnia igive Username rac gadmogvces parametrshi.
            * tu aseti chanaweri ipova masivis elementze mianichos null (rashic vgulisxmobt washlas)
            * da daabrunos true, winaaghmdeg shemtxvevashi false.*/

            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i] == null) return false;
                if (_users[i].Username == username)
                {
                    _users[i] = null;
                    return true;
                }
            }

            return false;
        }
    }
}
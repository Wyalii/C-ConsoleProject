namespace Project
{
    public class User
    {
        private string name;
        private string password;
        private string id;
        private bool isAdmin;
        private bool logedIn;
        private double balance;

        public double Balance{
            get{return balance;}
            set{balance = value;}
        }

        public string Name {
            get{return name;}
            set{name = value;}
        }

        public string Password {
            get{return password;}
            set{password = value;}
        }

        public string Id {
            get{return id;}
            set{id = value;}
        }

        public bool IsAdmin {
            get{return isAdmin;}
            set{isAdmin = value;}
        }

        public bool LogedIn {
            get{return logedIn;}
            set{logedIn = value;}
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Password: {Password}, IsAdmin: {IsAdmin}, LogedIn: {LogedIn}, Balance: {Balance}";
        }
    }
}
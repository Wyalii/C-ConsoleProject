namespace Project
{
    public class User
    {
        private string name;
        private string password;
        private string id;
        private double balance;
        private bool isadmin;
        private bool logedin;

        public string Name{
            get{return name;}
            set{name = value;}
        }
        public string Password{
            get{return password;}
            set{password = value;}
        }
        public string Id{
            get{ return id;}
            set {id = value;}
        }
        public double Balance {
            get{return balance;}
            set{balance = value;}
        }

        public bool IsAdmin
        {
            get{return isadmin;}
            set{isadmin = value;}
        }

        public bool LogedIn
        {
            get{return logedin;}
            set{logedin = value;}
        }

        public override string ToString()
        {
            return $" User - Id: {Id}, Name: {Name}, Password: {Password}, Balance: {Balance}, Admin: {IsAdmin}, LogedIn: {LogedIn}.";
        }

    }
}
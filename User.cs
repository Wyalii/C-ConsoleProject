namespace Project
{
    class User
    {
        private string name;
        private string password;
        private int id;
        private int balance;

        public string Name{
            get{return name;}
            set{name = value;}
        }
        public string Password{
            get{return password;}
            set{password = value;}
        }
        public int Id{
            get{ return id;}
            set {id = value;}
        }
        public int Balance {
            get{return balance;}
            set{balance = value;}
        }

        public override string ToString()
        {
            return $" Id: {Id}, Name: {Name}, Password: {Password}, Balance: {Balance}.";
        }

    }
}
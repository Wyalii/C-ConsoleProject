namespace Project
{
    public class Product
    {
        private string name;
        private int id;
        private int quantity;
        private int price;

        public string Name
        {
           get{return name;}
           set{name = value;}
        }

        public int Id
        {
            get{return id;}
            set{id = value;}
        }

        public int  Quantity
        {
            get{return quantity;}
            set{quantity = value;}
        }

        public int Price 
        {
            get{return price;}
            set{price = value;}
        }

        public override string ToString()
        {
            return $"Product -  Id: {Id}, Name: {Name}, Quantity: {Quantity}, Price: {Price}.";
        }
    }
}
namespace Project
{
    public class Product
    {
        private string name;
        private string id;
        private double price;
        private int quantity;
        string owner;

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }


        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public override string ToString()
        {
            return $"Id: {Id}, Product Name: {Name}, Product Price: {Price}, Product Quantity: {Quantity} ";
        }
    }
}
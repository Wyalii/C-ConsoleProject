using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace Project
{
    public class ProductsCRUD
    {
        static string GuidIdGenerator()
        {
            return Guid.NewGuid().ToString();
        }
        List<Product> products = new List<Product>()
        {
           new Product(){Name = "Apple", Id = GuidIdGenerator(), Price = 3,Quantity = 200},
           new Product(){Name = "Banana", Id = GuidIdGenerator(), Price = 5,Quantity = 200},
           new Product(){Name = "Watermelon", Id = GuidIdGenerator(), Price = 15,Quantity = 200},
           new Product(){Name = "Pen", Id = GuidIdGenerator(), Price = 1,Quantity = 200},
           new Product(){Name = "Bag", Id = GuidIdGenerator(), Price = 25,Quantity = 200},
        };

        
        public void PrintProducts()
        {
            var Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var ProductsListRoute = Path.Combine(Desktop, "Products.json");
          
            if(!File.Exists(ProductsListRoute))
            {
                Console.WriteLine("Creating File..");
                File.WriteAllText(ProductsListRoute,"[]");
                var getProducts = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(ProductsListRoute));
                getProducts.AddRange(products);
                var JsonedList = JsonSerializer.Serialize(getProducts);
                File.WriteAllText(ProductsListRoute,JsonedList);
                Console.WriteLine($"Created File at : {ProductsListRoute}");
                foreach(var product in getProducts)
                {
                  Console.WriteLine(product);
                }
                
            }else{
              var getData = File.ReadAllText(ProductsListRoute);
              var getProducts = JsonSerializer.Deserialize<List<User>>(getData);
              
              foreach(var product in getProducts)
              {
                Console.WriteLine(product);
              }
            }

          
            
        }

        public void AddProduct()
        {

            var Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var ProductsListRoute = Path.Combine(Desktop, "Products.json");
            
            try
            {
                Console.WriteLine("Product Name:");
                string name = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name,@"[a-zA-Z]"))
                {
                    Console.WriteLine($"Invalid Input: {name}, please try again.");
                    name = Console.ReadLine();
                }


                Console.WriteLine("Product Price:");
                double price;
                while (!double.TryParse(Console.ReadLine(),out price))
                {
                    Console.WriteLine($"Invalid Price Input, please try again.");
                }


                Console.WriteLine("Product Quantity:");
                int quantity;
                while(!int.TryParse(Console.ReadLine(), out quantity))
                {
                   Console.WriteLine($"Invalid Quantity Input, please try again.");
                }


                Console.WriteLine("ID is randomly generated.");
                string id = GuidIdGenerator();

                Product product = new Product(){Name = name, Price = price, Id = id, Quantity = quantity};
                if(!File.Exists(ProductsListRoute))
                {
                  Console.WriteLine("Creating File..");
                  File.WriteAllText(ProductsListRoute,"[]");
                  Console.WriteLine($"Created File at : {ProductsListRoute}");
                }

                var getData = File.ReadAllText(ProductsListRoute);
                var getProducts = JsonSerializer.Deserialize<List<Product>>(getData);
                getProducts.Add(product);
                var JsonedList = JsonSerializer.Serialize(getProducts);
                File.WriteAllText(ProductsListRoute,JsonedList);
                Console.WriteLine($"added product: {product}");
              
             
                
            }
            catch (System.Exception)
            {
                
                throw;
            }
            
        }

        public void RemoveProduct()
        {
            var Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var ProductsListRoute = Path.Combine(Desktop, "Products.json");
            bool start = false;

            do
            {
                try
                {
                    if(!File.Exists(ProductsListRoute))
                    {
                        Console.WriteLine("Creating File..");
                        File.WriteAllText(ProductsListRoute,"[]");
                        Console.WriteLine($"Created File at : {ProductsListRoute}");
                    }
                        var getProducts = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(ProductsListRoute));
                        if(getProducts == null || getProducts.Count == 0)
                        {
                            Console.WriteLine("no products to remove.");
                            return;
                        }
                        Console.WriteLine("Write ID to Remove Product:");
                        string id = Console.ReadLine();
                        var ProductToRemove = getProducts.FirstOrDefault(u => u.Id == id);
                        if(ProductToRemove != null)
                        {
                            getProducts.Remove(ProductToRemove);
                            var JsonedList = JsonSerializer.Serialize(getProducts);
                            File.WriteAllText(ProductsListRoute,JsonedList);
                            Console.WriteLine($"Product Removed: {ProductToRemove}");
                            start = false;
                        }else{
                            throw new Exception($"Product: {ProductToRemove.Id}, doesnt exists, try again.");
                        }

                }
                catch (Exception ex)
                {
                  Console.WriteLine(ex.Message);
                  start = true;
                }
            } while (false);
        }

        public void UpdateProduct()
        {
            var Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var ProductsListRoute = Path.Combine(Desktop, "Products.json");
            bool start = false;

            do
            {
                try
                {
                    if(!File.Exists(ProductsListRoute))
                    {
                      Console.WriteLine("Creating File..");
                      File.WriteAllText(ProductsListRoute,"[]");
                      Console.WriteLine($"Created File at : {ProductsListRoute}");
                    }

                    var getProducts = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(ProductsListRoute));
                    Console.WriteLine("Write Product ID to Update Product");
                    string id = Console.ReadLine();
                    var MatchingProduct = getProducts.FirstOrDefault(p => p.Id == id);
                    if(MatchingProduct == null)
                    {
                        throw new Exception($"Product with ID: {id}, Doesn't Exists, try again.");
                    }
                    
                      Console.WriteLine("Write New Product Name:");
                      string NewName = Console.ReadLine();
                      Console.WriteLine("Write New Product Price:");
                      double NewPrice = double.Parse(Console.ReadLine());
                      Console.WriteLine("Write New Product Quantity:");
                      int NewQuantity = int.Parse(Console.ReadLine());
                      Product UpdatedProduct = new Product(){Name = NewName, Price = NewPrice, Quantity = NewQuantity, Id = id};
                      MatchingProduct = UpdatedProduct;
                      getProducts.Add(MatchingProduct);
                      var JsonProducts = JsonSerializer.Serialize(getProducts);
                      File.WriteAllText(ProductsListRoute,JsonProducts);
                      start = false;
                    
                    
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                    start = true;

                }
            } while (true);
        }
    }
}
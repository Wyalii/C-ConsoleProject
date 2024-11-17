using System.Net;
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

            if (!File.Exists(ProductsListRoute))
            {
                Console.WriteLine("Creating File..");
                File.WriteAllText(ProductsListRoute, "[]");
                var UploadProducts = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(ProductsListRoute));
                UploadProducts.AddRange(products);
                var UploadProductsJson = JsonSerializer.Serialize(UploadProducts);
                File.WriteAllText(ProductsListRoute, UploadProductsJson);
                Console.WriteLine($"Created File at : {ProductsListRoute}");
            }

            var getData = File.ReadAllText(ProductsListRoute);
            var getProducts = JsonSerializer.Deserialize<List<Product>>(getData);

            foreach (var product in getProducts)
            {
                Console.WriteLine(product);
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
                while (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, @"[a-zA-Z]"))
                {
                    Console.WriteLine($"Invalid Input: {name}, please try again.");
                    name = Console.ReadLine();
                }


                Console.WriteLine("Product Price:");
                double price;
                while (!double.TryParse(Console.ReadLine(), out price))
                {
                    Console.WriteLine($"Invalid Price Input, please try again.");
                }


                Console.WriteLine("Product Quantity:");
                int quantity;
                while (!int.TryParse(Console.ReadLine(), out quantity))
                {
                    Console.WriteLine($"Invalid Quantity Input, please try again.");
                }


                Console.WriteLine("ID is randomly generated.");
                string id = GuidIdGenerator();

                Product product = new Product() { Name = name, Price = price, Id = id, Quantity = quantity };

                if (!File.Exists(ProductsListRoute))
                {
                    Console.WriteLine("Creating File..");
                    File.WriteAllText(ProductsListRoute, "[]");
                    var UploadProducts = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(ProductsListRoute));
                    UploadProducts.AddRange(products);
                    var UploadProductsJson = JsonSerializer.Serialize(UploadProducts);
                    File.WriteAllText(ProductsListRoute, UploadProductsJson);
                    Console.WriteLine($"Created File at : {ProductsListRoute}");
                }

                var getData = File.ReadAllText(ProductsListRoute);
                var getProducts = JsonSerializer.Deserialize<List<Product>>(getData);
                var MatchingProduct = getProducts.FirstOrDefault(p => p.Name == product.Name);
                if (MatchingProduct != null)
                {
                    Console.WriteLine("Product already exists.");

                }
                else
                {
                    getProducts.Add(product);
                    var JsonedList = JsonSerializer.Serialize(getProducts);
                    File.WriteAllText(ProductsListRoute, JsonedList);
                    Console.WriteLine($"added product: {product.Name}");
                }




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
            var PurchasedListRoute = Path.Combine(Desktop, "UserPurchases.json");
            bool start = false;

            do
            {
                try
                {
                    if (!File.Exists(ProductsListRoute))
                    {
                        Console.WriteLine("Creating File..");
                        File.WriteAllText(ProductsListRoute, "[]");
                        var UploadProducts = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(ProductsListRoute));
                        UploadProducts.AddRange(products);
                        var UploadProductsJson = JsonSerializer.Serialize(UploadProducts);
                        File.WriteAllText(ProductsListRoute, UploadProductsJson);
                        Console.WriteLine($"Created File at : {ProductsListRoute}");
                    }
                    var getProducts = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(ProductsListRoute));

                    if (getProducts == null || getProducts.Count == 0)
                    {
                        Console.WriteLine("no products to remove.");
                        break;
                    }
                    Console.WriteLine("Write ID to Remove Product:");
                    string id = Console.ReadLine();

                    var ProductToRemove = getProducts.FirstOrDefault(u => u.Id == id);

                    if (ProductToRemove == null)
                    {
                        Console.WriteLine($"Product: {id}, doesnt exists, try again");
                        break;
                    }


                    if (File.Exists(PurchasedListRoute))
                    {
                        var getPurchased = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(PurchasedListRoute));

                        getPurchased.RemoveAll(p => p.Id == id);
                        File.WriteAllText(PurchasedListRoute, JsonSerializer.Serialize(getPurchased));

                    }

                    getProducts.Remove(ProductToRemove);
                    var JsonedList = JsonSerializer.Serialize(getProducts);
                    File.WriteAllText(ProductsListRoute, JsonedList);
                    Console.WriteLine($"Product Removed: {ProductToRemove}");
                    start = false;

                }
                catch (Exception ex)
                {

                }
            } while (start);
        }

        public void UpdateProduct()
        {
            var Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var ProductsListRoute = Path.Combine(Desktop, "Products.json");
            var PurchasedListRoute = Path.Combine(Desktop, "UserPurchases.json");
            bool start = false;

            do
            {
                try
                {
                    if (!File.Exists(ProductsListRoute))
                    {
                        Console.WriteLine("Creating File..");
                        File.WriteAllText(ProductsListRoute, "[]");
                        var UploadProducts = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(ProductsListRoute));
                        UploadProducts.AddRange(products);
                        var UploadProductsJson = JsonSerializer.Serialize(UploadProducts);
                        File.WriteAllText(ProductsListRoute, UploadProductsJson);
                        Console.WriteLine($"Created File at : {ProductsListRoute}");
                    }



                    var getProducts = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(ProductsListRoute));
                    var getPurchases = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(PurchasedListRoute));

                    if (getProducts == null || getProducts.Count == 0)
                    {
                        Console.WriteLine("No products found to update.");
                        return;
                    }


                    Console.WriteLine("Write Product ID to Update Product");
                    string id = Console.ReadLine();
                    var MatchingProduct = getProducts.FirstOrDefault(p => p.Id == id);

                    if (MatchingProduct == null)
                    {
                        Console.WriteLine($"Product with ID: {id}, Doesn't Exists, try again.");
                        break;
                    }

                    Console.WriteLine("Write New Product Name:");
                    string NewName = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(NewName) || !Regex.IsMatch(NewName, @"[a-zA-Z]"))
                    {
                        Console.WriteLine($"Invalid Input: {NewName}, please try again.");
                        NewName = Console.ReadLine();
                    }


                    Console.WriteLine("Write New Product Price:");

                    double NewPrice;
                    while (!double.TryParse(Console.ReadLine(), out NewPrice))
                    {
                        Console.WriteLine($"Invalid Price Input, please try again.");
                    }

                    Console.WriteLine("Write New Product Quantity:");
                    int NewQuantity;

                    while (!int.TryParse(Console.ReadLine(), out NewQuantity))
                    {
                        Console.WriteLine($"Invalid Quantity Input, please try again.");
                    }



                    if (File.Exists(PurchasedListRoute))
                    {

                        getPurchases.ForEach(p =>
                        {
                            if (p.Id == id)
                            {
                                p.Name = NewName;
                                p.Price = NewPrice;
                                p.Quantity = NewQuantity;
                            }
                        });

                        var UpdatedPurchases = JsonSerializer.Serialize(getPurchases);
                        File.WriteAllText(PurchasedListRoute, UpdatedPurchases);

                    }

                    MatchingProduct.Name = NewName;
                    MatchingProduct.Price = NewPrice;
                    MatchingProduct.Quantity = NewQuantity;


                    var JsonProducts = JsonSerializer.Serialize(getProducts);
                    File.WriteAllText(ProductsListRoute, JsonProducts);
                    Console.WriteLine($"Updated Product: {MatchingProduct.Name}.");
                    start = false;


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    start = true;

                }
            } while (start);
        }

        public void BuyProduct()
        {
            bool start = false;
            do
            {
                var Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var ProductsListRoute = Path.Combine(Desktop, "Products.json");
                var LoggedInUserRoute = Path.Combine(Desktop, "LoggedInUsers.json");
                var UserPurchasesRoute = Path.Combine(Desktop, "UserPurchases.json");
                var RegisteredUsersRoute = Path.Combine(Desktop, "RegisteredUsers.json");

                if (!File.Exists(UserPurchasesRoute))
                {
                    Console.WriteLine("Creating a File...");
                    File.WriteAllText(UserPurchasesRoute, "[]");
                    Console.WriteLine($"Created File at: {UserPurchasesRoute}");
                }

                if (!File.Exists(ProductsListRoute))
                {
                    Console.WriteLine("Creating File..");
                    File.WriteAllText(ProductsListRoute, "[]");
                    var UploadProducts = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(ProductsListRoute));
                    UploadProducts.AddRange(products);
                    var UploadProductsJson = JsonSerializer.Serialize(UploadProducts);
                    File.WriteAllText(ProductsListRoute, UploadProductsJson);
                    Console.WriteLine($"Created File at : {ProductsListRoute}");
                }

                var getProducts = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(ProductsListRoute));
                var userPurchases = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(UserPurchasesRoute));
                var loggedInUserList = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(LoggedInUserRoute));
                var registeredUsersList = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(RegisteredUsersRoute));

                if (loggedInUserList == null)
                {
                    Console.WriteLine("User is not Logged In.");
                    break;
                }


                if (registeredUsersList == null)
                {
                    Console.WriteLine("User is not Logged In.");
                    break;
                }

                Console.WriteLine("Write ID of Product to buy it.");
                string id = Console.ReadLine();
                var MatchingProduct = getProducts.FirstOrDefault(p => p.Id == id);
                if (MatchingProduct == null)
                {
                    Console.WriteLine($"Product with ID: {id}, Doesn't Exists, try again.");
                    continue;
                }

                var getLoggedInUser = loggedInUserList.First();
                var getRegisteredUser = registeredUsersList.FirstOrDefault(u => u.Id == getLoggedInUser.Id);
                if (getRegisteredUser == null)
                {
                    Console.WriteLine("registered user is not found.");
                    break;
                }

                if (getLoggedInUser.Balance >= MatchingProduct.Price)
                {
                    if (MatchingProduct.Quantity <= 0)
                    {
                        Console.WriteLine("No Products left to buy.");
                    }
                    var newLoggedInBalance = getLoggedInUser.Balance - MatchingProduct.Price;
                    var newRegisteredBalance = getRegisteredUser.Balance - MatchingProduct.Price;
                    var newProductQuantity = MatchingProduct.Quantity - 1;

                    MatchingProduct.Quantity = newProductQuantity;
                    getLoggedInUser.Balance = newLoggedInBalance;
                    getRegisteredUser.Balance = newRegisteredBalance;



                    File.WriteAllText(RegisteredUsersRoute, JsonSerializer.Serialize(registeredUsersList));

                    File.WriteAllText(LoggedInUserRoute, JsonSerializer.Serialize(loggedInUserList));

                    File.WriteAllText(ProductsListRoute, JsonSerializer.Serialize(getProducts));

                    Product PurchasedProduct = new Product()
                    {
                        Id = MatchingProduct.Id,
                        Name = MatchingProduct.Name,
                        Price = MatchingProduct.Price,
                        Quantity = MatchingProduct.Quantity,
                        Owner = getLoggedInUser.Id,
                    };

                    userPurchases.Add(PurchasedProduct);

                    File.WriteAllText(UserPurchasesRoute, JsonSerializer.Serialize(userPurchases));
                    Console.WriteLine($"Purchased:{MatchingProduct.Name}");
                }
                else
                {
                    Console.WriteLine("Not Enough Balance, please update your balance.");
                    break;
                }


            } while (start);
        }


        public void PrintPurchasesHistory()
        {
            bool start = false;
            do
            {
                var Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var PurchasesRoute = Path.Combine(Desktop, "UserPurchases.json");
                var LoggedInUserRoute = Path.Combine(Desktop, "LoggedInUsers.json");

                if (!File.Exists(LoggedInUserRoute))
                {
                    Console.WriteLine("User is not logged in.");
                    break;
                }

                if (!File.Exists(PurchasesRoute))
                {
                    Console.WriteLine("User has not bought anything.");
                    break;
                }
                var getPurchasedHistory = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(PurchasesRoute));
                var getLoggedInUsersList = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(LoggedInUserRoute));
                var getLoggedInUser = getLoggedInUsersList.First();

                if (getPurchasedHistory == null || getPurchasedHistory.Count() == 0)
                {
                    Console.WriteLine("User has not bought anything");
                }
                var getAllPurchasedProducts = getPurchasedHistory.FindAll(p => p.Owner == getLoggedInUser.Id);
                if (getAllPurchasedProducts == null)
                {
                    Console.WriteLine("User has no Purchase History.");
                }
                foreach (var product in getAllPurchasedProducts)
                {
                    Console.WriteLine($"User Has Bought: {product.Name} for {product.Price}$");
                }
            } while (start);
        }

        public void UpdateBalance()
        {
            bool start = false;

            do
            {
                var Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var RegisteredUsersRoute = Path.Combine(Desktop, "RegisteredUsers.json");
                var LoggedInUsersRoute = Path.Combine(Desktop, "LoggedInUsers.json");

                if (!File.Exists(LoggedInUsersRoute))
                {
                    Console.WriteLine("User is not logged in.");
                    break;
                }

                if (!File.Exists(RegisteredUsersRoute))
                {
                    Console.WriteLine("User is not registered.");
                    break;
                }

                var LoggedInUsersList = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(LoggedInUsersRoute));
                var LoggedInUser = LoggedInUsersList.First();
                var registeredUsersList = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(RegisteredUsersRoute));
                var RegisteredUser = registeredUsersList.FirstOrDefault(u => u.Id == LoggedInUser.Id);

                if (RegisteredUser == null)
                {
                    Console.WriteLine("User is not registered.");
                    break;
                }

                if (LoggedInUser == null)
                {
                    Console.WriteLine("User is not logged in.");
                    break;
                }

                Console.WriteLine($"User: {LoggedInUser.Name}'s Balance is: {LoggedInUser.Balance}");
                Console.WriteLine("Update your Balance:");
                double balance;
                while (!double.TryParse(Console.ReadLine(), out balance))
                {
                    Console.WriteLine($"Invalid Price Input, please try again.");
                }

                var NewBalance1 = LoggedInUser.Balance + balance;
                LoggedInUser.Balance = NewBalance1;
                var NewBalance2 = RegisteredUser.Balance + balance;
                RegisteredUser.Balance = NewBalance2;

                Console.WriteLine($"{LoggedInUser.Name}'s new balance:{NewBalance1}");

                File.WriteAllText(LoggedInUsersRoute, JsonSerializer.Serialize(LoggedInUsersList));
                File.WriteAllText(RegisteredUsersRoute, JsonSerializer.Serialize(registeredUsersList));



            } while (start);
        }
    }
}
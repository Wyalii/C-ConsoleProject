using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace Project
{
    public class Registration
    {
        string GuidIdGenerator()
        {
            return Guid.NewGuid().ToString();
        }
        
        public void Register()
        {
            var Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var RegisteredUsersRoute = Path.Combine(Desktop,"RegisteredUsers.json");
            bool start = false;
            List<User> usersList = new List<User>(){
                new User(){Name = "AdminName", Password = "AdminPassword", Id = "AdminId", Balance = 1, IsAdmin = true, LogedIn = false},
            };

            do
            {
              try
              {   
               Console.WriteLine("Creating Account.");
               Console.WriteLine();

               Console.WriteLine("Write Name:");  
               string name = Console.ReadLine();

               Console.WriteLine("Write Password:");
               string password = Console.ReadLine();

               Console.WriteLine("Write Balance:");
               double balance;
               string balanceinput = Console.ReadLine();


               while(string.IsNullOrWhiteSpace(balanceinput) || !double.TryParse(balanceinput, out balance) || balance <= 0 )
               {
                Console.WriteLine($"Invalid Input: {balanceinput}, try again");
                balanceinput = Console.ReadLine();
               }

               while(string.IsNullOrWhiteSpace(name) || Regex.IsMatch(name,@"^\d+$"))
               {
                Console.WriteLine($"Invalid Input: {name}, try again");
                name = Console.ReadLine();
               }
               
               while(string.IsNullOrWhiteSpace(password) || Regex.IsMatch(password,@"^\d+$"))
               {
                  Console.WriteLine($"Invalid Input: {password}, try again");
                  password = Console.ReadLine();
               }


              if(name == "AdminName" || password == "AdminPassword"){
                throw new ArgumentException("Cant Register Admin.");
              }

              User user = new User(){Name = name,Password = password, Balance = balance,Id = GuidIdGenerator(),LogedIn = false, IsAdmin = false};
            
              
             
              if(!File.Exists(RegisteredUsersRoute))
              {
                Console.WriteLine("File Doesn't Exists.");
                Console.WriteLine("Creating a File...");
                File.WriteAllText(RegisteredUsersRoute,"[]");
                Console.WriteLine($"File Created: {RegisteredUsersRoute}");
              }
                
              var ReadData = File.ReadAllText(RegisteredUsersRoute);
              var GetUsers = JsonSerializer.Deserialize<List<User>>(ReadData);
              var MatchingUser = GetUsers.FirstOrDefault(u => u.Name == user.Name);

              if(MatchingUser != null)
              {
                throw new Exception($"User: {MatchingUser} is Already Registered");
              }
                 
              GetUsers.Add(user);
              var UpdateFile = JsonSerializer.Serialize(GetUsers);
              File.WriteAllText(RegisteredUsersRoute,UpdateFile);
              Console.WriteLine($"User: {user.Name} | Registered.");
              start = false;
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
                start = true;
            }
            } while (start);
        }
    }
}
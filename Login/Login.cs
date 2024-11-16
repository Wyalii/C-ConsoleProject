using System.Text.Json;
using System.Text.RegularExpressions;
namespace Project
{
  public class Login
  {
    public bool admin = false;
    public User user = new User();

    List<User> usersList = new List<User>(){
          new User(){Name = "AdminName", Password = "AdminPassword", Id = "AdminId", Balance = 1, IsAdmin = true, LogedIn = false},
      };

    public User LoginFunc()
    {
      while (true)
      {
        try
        {
          var Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
          var RegisteredUsersRoute = Path.Combine(Desktop, "RegisteredUsers.json");
          var LoggedInUsersRoute = Path.Combine(Desktop, "LoggedInUsers.json");

          Console.WriteLine("Write Name:");
          string name = Console.ReadLine();
          Console.WriteLine("Write Password");
          string password = Console.ReadLine();

          while (string.IsNullOrWhiteSpace(name) || Regex.IsMatch(name, @"^\d+$"))
          {
            Console.WriteLine($"Invalid Input: {name}, try again");
            name = Console.ReadLine();
          }

          while (string.IsNullOrWhiteSpace(password) || Regex.IsMatch(password, @"^\d+$"))
          {
            Console.WriteLine($"Invalid Input: {password}, try again");
            password = Console.ReadLine();
          }


          if (!File.Exists(RegisteredUsersRoute))
          {
            Console.WriteLine("Creating File..");
            File.WriteAllText(RegisteredUsersRoute, "[]");
            var registeredAdmin = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(RegisteredUsersRoute));
            registeredAdmin.AddRange(usersList);
            var WriteAdminJson = JsonSerializer.Serialize(registeredAdmin);
            File.WriteAllText(RegisteredUsersRoute, WriteAdminJson);
            Console.WriteLine($"Created File at : {RegisteredUsersRoute}");
          }

          if (!File.Exists(LoggedInUsersRoute))
          {
            Console.WriteLine("Creating New LogedIn Users File..");
            File.WriteAllText(LoggedInUsersRoute, "[]");
            Console.WriteLine($"Created File At: {LoggedInUsersRoute}");
          }

          var RegisteredUsers = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(RegisteredUsersRoute));
          var MatchingUser = RegisteredUsers.FirstOrDefault(u => u.Name == name && u.Password == password);

          if (MatchingUser == null)
          {
            Console.WriteLine("User is not Registered, please try again");
            continue;
          }

          if (MatchingUser.Name == "AdminName" && MatchingUser.Password == "AdminPassword")
          {
            MatchingUser.IsAdmin = true;
            Console.WriteLine("Identified Admin!");
          }



          user = MatchingUser;
          var LogedInUser = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(LoggedInUsersRoute));
          LogedInUser.Clear();
          LogedInUser.Add(MatchingUser);
          var JsonUser = JsonSerializer.Serialize(LogedInUser);
          File.WriteAllText(LoggedInUsersRoute, JsonUser);
          Console.WriteLine($"User: {MatchingUser.Name} | Has LogedIn.");


          return MatchingUser;
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          return null;
        }


      }



    }
  }
}
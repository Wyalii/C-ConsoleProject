using System.Text.Json;
namespace Project
{
    public class LoginFunction
    {
        public bool Login(User user)
        {
           JsonCRUD jsonCRUD = new JsonCRUD();
           UsersList usersList = new UsersList();
           LogedInUsersPath logedInUsersPath = new LogedInUsersPath();
           LogedInUsers logedInUsersList = new LogedInUsers();
           RegisteredUsersPath registeredUsersPath = new RegisteredUsersPath();

           
           
           var LogedInUsersJson = jsonCRUD.GetDataFromFile(logedInUsersPath.FilePath);
           
           
            try
           {

            if(user == null)
            {
             throw new UserDontExists("User with provided name or password doesn't exists.");
             
            }

               if(user.Name != "AdminName" && user.Password != "AdminPassword")
               {
                
                user.LogedIn = true;
                LogedInUsersJson.Clear();
                LogedInUsersJson.Add(user);
                jsonCRUD.PutDataToFile(logedInUsersPath.FilePath,LogedInUsersJson);
                Console.WriteLine($"User: {user} LogedIn.");
                return false;
                
               }

               if(user.Name == "AdminName" && user.Password == "AdminPassword")
               {
                user.IsAdmin = true;
                user.LogedIn = true;
                LogedInUsersJson.Clear();
                LogedInUsersJson.Add(user);
                jsonCRUD.PutDataToFile(logedInUsersPath.FilePath,LogedInUsersJson);
                Console.WriteLine($"Admin has Joined: {user}");
                return false;
                
               }
           
           }
           catch (UserDontExists ex)
           {
            Console.WriteLine(ex.Message);
            return true;
           
           }
           catch(UserAlreadyLogedIn ex)
           {
             Console.WriteLine(ex.Message);
             return true;
           }

           
           return false;
        }
    }
}
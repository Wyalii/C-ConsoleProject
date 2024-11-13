using System.Text.Json;
namespace Project
{
    public class LoginFunction
    {
        public void Login(User user)
        {
           JsonCRUD jsonCRUD = new JsonCRUD();
           UsersList usersList = new UsersList();
           LogedInUsersPath logedInUsersPath = new LogedInUsersPath();
           FilePathUtil filePathUtil =  new FilePathUtil();
           LogedInUsers logedInUsers = new LogedInUsers();

           var Users = jsonCRUD.GetDataFromFile(filePathUtil.FilePath);
           var MatchingUser = Users.FirstOrDefault(u => u.Name == user.Name && u.Password == user.Password && u.Id == user.Id);

           try
           {
            if(MatchingUser == null)
           {
            throw new UserDontExists("User with provided name or password doesn't exists.");
           }
             
             if(MatchingUser.Name != "AdminName" && MatchingUser.Password != "AdminPassword")
             {
                
                MatchingUser.LogedIn = true;
                logedInUsers.UsersLogedIn.Add(MatchingUser);
                jsonCRUD.PutDataToFile(logedInUsersPath.FilePath,logedInUsers.UsersLogedIn);
                Console.WriteLine($"User: {MatchingUser} LogedIn.");
                
             }

             if(MatchingUser.Name == "AdminName" && MatchingUser.Password == "AdminPassword")
             {
                MatchingUser.IsAdmin = true;
                MatchingUser.LogedIn = true;
                logedInUsers.UsersLogedIn.Add(MatchingUser);
                jsonCRUD.PutDataToFile(logedInUsersPath.FilePath,logedInUsers.UsersLogedIn);
                Console.WriteLine($"Admin has Joined: {MatchingUser}");
             }
            
           
           }
           catch (UserDontExists ex)
           {
            Console.WriteLine(ex.Message);
           }

           
        }
    }
}
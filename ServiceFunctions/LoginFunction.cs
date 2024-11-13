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
           
           try
           {
            if(user == null)
            {
             throw new UserDontExists("User with provided name or password doesn't exists.");
            }
            User MatchingUser = Users.FirstOrDefault(u => u.Name.Trim().ToLower() == user.Name.Trim().ToLower() && u.Password.Trim().ToLower() == user.Password.Trim().ToLower() && u.Id.Trim().ToLower() == user.Id.Trim().ToLower());
             
             if( MatchingUser != null)
             {
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
           
           }
           catch (UserDontExists ex)
           {
            Console.WriteLine(ex.Message);
           }

           
        }
    }
}
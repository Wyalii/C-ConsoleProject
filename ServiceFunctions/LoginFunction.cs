using System.Text.Json;
namespace Project
{
    public class LoginFunction
    {
        public void Login(string name, string password)
        {
           JsonCRUD jsonCRUD = new JsonCRUD();
           UsersList usersList = new UsersList();
           FilePathUtil FilePathUtil = new FilePathUtil();
           LogedInUser logedInUser = new LogedInUser();

           var Users = jsonCRUD.GetDataFromFile(FilePathUtil.FilePath);
           var MatchingUser = Users.FirstOrDefault(u => u.Name == name && u.Password == password);

           try
           {
            if(MatchingUser == null)
           {
            throw new UserDontExists("User with provided name or password doesn't exists.");
           }
             
             if(MatchingUser.Name != "AdminName" && MatchingUser.Password != "AdminPassword")
             {
                MatchingUser.LogedIn = true;
                logedInUser.UserLogedIn.Add(MatchingUser);
                Console.WriteLine($"User: {MatchingUser} LogedIn.");
                
             }

             if(MatchingUser.Name == "AdminName" && MatchingUser.Password == "AdminPassword")
             {
                MatchingUser.IsAdmin = true;
                MatchingUser.LogedIn = true;
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
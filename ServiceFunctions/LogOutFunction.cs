namespace Project
{
    public class LogOutFunction
    {
        JsonCRUD jsonCRUD = new JsonCRUD();
        LogedInUsersPath logedInUsersPath = new LogedInUsersPath();

        public void LogOut(User user)
        {
          
          try
          {

            if( user == null){
                throw new NullUserObj("User parameter is null.");
            }

            var LoggedInUsersJson = jsonCRUD.GetDataFromFile(logedInUsersPath.FilePath);
            var LoggedInUser = LoggedInUsersJson.FirstOrDefault(u => u.Name == user.Name && u.Password == user.Password);
            if(LoggedInUser == null)
            {
              throw new UserIsNotLogedIn("User Is Not LoggedIn.");
            }
            
            LoggedInUser.LogedIn = false;
            LoggedInUsersJson.Remove(LoggedInUser);
            var UpdatedJsonUsersList = jsonCRUD.PutDataToFile(logedInUsersPath.FilePath,LoggedInUsersJson);
            Console.WriteLine($"User: {LoggedInUser} is Logged Out.");
          }
          catch (UserIsNotLogedIn ex)
          {
            Console.WriteLine(ex.Message);
          }
          catch(NullUserObj ex){
             Console.WriteLine(ex.Message);
          }
        }
    }
}
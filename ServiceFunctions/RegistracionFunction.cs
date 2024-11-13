using System.Linq.Expressions;
using System.Text.Json;

namespace Project
{
    public class RegistrationFunction
    {

        JsonCRUD jsonCRUD =  new JsonCRUD();
        UsersList usersList = new UsersList();
        FilePathUtil FilePathUtil = new FilePathUtil();
        static private string GuidIdGenerator()
        {
            return Guid.NewGuid().ToString();
        }
        

       public void Register(string name, string password, double balance)
       {

         try
         {
         
            if(password == "AdminPassword" || name == "AdminName" || name == "AdminPassword" || password == "AdminName")
            {
              throw new CantRegisterAdmin("EXCEPTION: Cannot Register Admin.");
            }
            
            List<User> ListOfUsers = jsonCRUD.GetDataFromFile(FilePathUtil.FilePath);
            var existingUser = ListOfUsers.FirstOrDefault(u => u.Name == name);

            if(existingUser != null)
            {
              throw new UserAlredyExists("user with same name alredy exists.");
            }

            var user = new User(){Name = name, Password = password, Balance = balance, IsAdmin = false,Id = GuidIdGenerator(),LogedIn = false};
            
            ListOfUsers.Add(user);
            var UsersInJson = jsonCRUD.PutDataToFile(FilePathUtil.FilePath,ListOfUsers);
            Console.WriteLine($"User: {user}, Signed Up.");
         }
         catch (UserAlredyExists ex)
         {
            Console.WriteLine(ex.Message);
         }
         catch(CantRegisterAdmin ex)
         {
            Console.WriteLine(ex.Message);
         }     
       
       }
        
   }
        
}
    

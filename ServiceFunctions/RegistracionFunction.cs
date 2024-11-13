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
          }
          catch (CantRegisterAdmin ex)
          {
            Console.WriteLine(ex.Message);
          }


          if(password != "AdminPassword" && name != "AdminName")
          {
            

            var user = new User(){Name = name, Password = password, Balance = balance, IsAdmin = false,Id = GuidIdGenerator(),LogedIn = false};
            
            try
            {
              if(!usersList.users.Exists(i => i.Id == user.Id))
             {

               List<User> ListOfUsers = jsonCRUD.GetDataFromFile(FilePathUtil.FilePath);
               ListOfUsers.Add(user);
               usersList.users.AddRange(ListOfUsers);
               var UsersInJson = jsonCRUD.PutDataToFile(FilePathUtil.FilePath,usersList.users);
               Console.WriteLine($"User: {user}, Signed Up.");
            }else{
                throw new UserAlredyExists($" EXCEPTION: User with id: {user.Id} alredy exists.");
            }
            }
            catch (UserAlredyExists ex)
            {
              Console.WriteLine(ex.Message);
            }

            
          }

          
       }
    }
}
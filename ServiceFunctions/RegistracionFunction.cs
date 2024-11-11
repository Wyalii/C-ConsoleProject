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
        

       public void Register(string name, string password, int balance)
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
            

            var user = new User(){Name = name, Password = password, Balance = balance, IsAdmin = false,Id = GuidIdGenerator()};
            
            try
            {
              if(!usersList.users.Exists(i => i.Id == user.Id))
             {
               usersList.users.Add(user);

               if(!File.Exists(FilePathUtil.FilePath)){
                Console.WriteLine("File Doesn't Exists, Creating New File...");
                File.WriteAllText(FilePathUtil.FilePath,JsonSerializer.Serialize(new List<User>(), new JsonSerializerOptions{WriteIndented = true}));
                Console.WriteLine($"Created File at: {FilePathUtil.FilePath}");
               }
               

               List<User> ListOfUsers = jsonCRUD.GetDataFromFile(FilePathUtil.FilePath);
               ListOfUsers.Add(user);
               usersList.users = ListOfUsers;
               var UsersInJson = jsonCRUD.PutDataToFile(FilePathUtil.FilePath,ListOfUsers);
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
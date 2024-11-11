using System.Linq.Expressions;
using System.Text.Json;

namespace Project
{
    public class RegistrationFunction
    {

        JsonCRUD jsonCRUD =  new JsonCRUD();
        static private string GuidIdGenerator()
        {
            return Guid.NewGuid().ToString();
        }
        UsersList usersList = new UsersList();

       public void Register(string name, string password, int balance)
       {
          if(password != "AdminPassword" && name != "AdminName")
          {
            string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string FilePath = Path.Combine(DesktopPath,"test.json");

            var user = new User(){Name = name, Password = password, Balance = balance, IsAdmin = false,Id = GuidIdGenerator()};
            
            try
            {
              if(!usersList.users.Exists(i => i.Id == user.Id))
             {
               usersList.users.Add(user);

               if(!File.Exists(FilePath)){
                File.WriteAllText(FilePath,JsonSerializer.Serialize(new List<User>(), new JsonSerializerOptions{WriteIndented = true}));
               }

               List<User> ListOfUsers = jsonCRUD.GetDataFromFile(FilePath);
               ListOfUsers.Add(user);
               usersList.users = ListOfUsers;
               var UsersInJson = jsonCRUD.PutDataToFile(FilePath,ListOfUsers);
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
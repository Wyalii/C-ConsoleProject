using System.Linq.Expressions;
using System.Text.Json;

namespace Project
{
    public class RegistrationFunction
    {

        static private string GuidIdGenerator()
        {
            return Guid.NewGuid().ToString();
        }
         
        public List<User>users = new List<User>()
        {
          new User(){Name = "AdminName", Password = "AdminPassword", Id = "ThisIsAdminId", Balance = 0},
        };
       public void Register(string name, string password, int balance)
       {
          if(password != "AdminPassword" && name != "AdminName")
          {
            string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string FilePath = Path.Combine(DesktopPath,"test.json");

            var user = new User(){Name = name, Password = password, Balance = balance, IsAdmin = false,Id = GuidIdGenerator()};
            

            try
            {
              if(!users.Exists(i => i.Id == user.Id))
             {
               users.Add(user);

               if(!File.Exists(FilePath)){
                File.WriteAllText(FilePath,JsonSerializer.Serialize(new List<User>(), new JsonSerializerOptions{WriteIndented = true}));
               }

               var readJsonFile = File.ReadAllText(FilePath);
               var JsonUsersList = JsonSerializer.Deserialize<List<User>>(readJsonFile);
               JsonUsersList.Add(user);
               users = JsonUsersList;
               var JsonSerialized = JsonSerializer.Serialize(JsonUsersList, new JsonSerializerOptions{WriteIndented = true});
               File.WriteAllText(FilePath,JsonSerialized);
               foreach(var item in users)
               {
                Console.WriteLine(item);
               }
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
using System.Text.Json;
namespace Project
{
    public class JsonCRUD
    {

      UsersList usersList =  new UsersList();
        public List<User> GetDataFromFile(string filePath)
        {
          if(!File.Exists(filePath)){
                Console.WriteLine("File Doesn't Exists, Creating New File...");
                File.WriteAllText(filePath,JsonSerializer.Serialize(usersList.users, new JsonSerializerOptions{WriteIndented = true}));
                Console.WriteLine($"Created File at: {filePath}");
          }
           var readJsonFile = File.ReadAllText(filePath);
           var JsonUsersList = JsonSerializer.Deserialize<List<User>>(readJsonFile);

           return JsonUsersList;
        }

        public bool PutDataToFile(string filePath,List<User> jsonUsersList)
        {

          if(!File.Exists(filePath)){
                Console.WriteLine("File Doesn't Exists, Creating New File...");
                File.WriteAllText(filePath,JsonSerializer.Serialize(jsonUsersList, new JsonSerializerOptions{WriteIndented = true}));
                Console.WriteLine($"Created File at: {filePath}");
          }
          
          var JsonSerialized = JsonSerializer.Serialize(jsonUsersList, new JsonSerializerOptions {WriteIndented = true});
          File.WriteAllText(filePath,JsonSerialized);
          return true;
        }
    }
}
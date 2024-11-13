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
                File.WriteAllText(filePath,JsonSerializer.Serialize(new List<User>(), new JsonSerializerOptions{WriteIndented = true}));
                Console.WriteLine($"Created File at: {filePath}");
          }
           var readJsonFile = File.ReadAllText(filePath);
           var JsonUsersList = JsonSerializer.Deserialize<List<User>>(readJsonFile);

           return JsonUsersList;
        }

        public bool PutDataToFile(string filePath,List<User> jsonUser)
        {

          if(!File.Exists(filePath)){
                Console.WriteLine("File Doesn't Exists, Creating New File...");
                File.WriteAllText(filePath,JsonSerializer.Serialize(jsonUser, new JsonSerializerOptions{WriteIndented = true}));
                Console.WriteLine($"Created File at: {filePath}");
                return true;
          }
          
          var JsonSerialized = JsonSerializer.Serialize(jsonUser, new JsonSerializerOptions {WriteIndented = true});
          File.WriteAllText(filePath,JsonSerialized);
          return true;
        }
    }
}
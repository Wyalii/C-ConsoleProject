using System.Text.Json;
namespace Project
{
    public class JsonCRUD
    {
        public List<User> GetDataFromFile(string filePath)
        {
           var readJsonFile = File.ReadAllText(filePath);
           var JsonUsersList = JsonSerializer.Deserialize<List<User>>(readJsonFile);
           return JsonUsersList;
        }

        public bool PutDataToFile(string filePath,List<User> jsonUsersList)
        {
          var JsonSerialized = JsonSerializer.Serialize(jsonUsersList, new JsonSerializerOptions {WriteIndented = true});
          File.WriteAllText(filePath,JsonSerialized);
          return true;
        }
    }
}
using System.Text.Json;

namespace Project
{
    public class Logout
    {
        public void Exit()
        {
            var Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var LoggedInUserRoute = Path.Combine(Desktop, "LoggedInUsers.json");
            var getLoggedInUser = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(LoggedInUserRoute));
            getLoggedInUser.Clear();
            File.WriteAllText(LoggedInUserRoute, JsonSerializer.Serialize(getLoggedInUser));
        }
    }
}
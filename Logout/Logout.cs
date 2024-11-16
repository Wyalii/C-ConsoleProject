using System.Text.Json;

namespace Project
{
    public class Logout
    {
        public void Exit()
        {
            var Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var UserPurchasesRoute = Path.Combine(Desktop, "UserPurchases.json");
            var LoggedInUserRoute = Path.Combine(Desktop, "LoggedInUsers.json");

            if (File.Exists(UserPurchasesRoute))
            {
                var getPurchased = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(UserPurchasesRoute));
                getPurchased.Clear();
                File.WriteAllText(UserPurchasesRoute, JsonSerializer.Serialize(getPurchased));

            }

            var getLoggedInUser = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(LoggedInUserRoute));
            getLoggedInUser.Clear();
            File.WriteAllText(LoggedInUserRoute, JsonSerializer.Serialize(getLoggedInUser));
        }
    }
}
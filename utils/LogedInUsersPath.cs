namespace Project
{
    public class LogedInUsersPath
    {
        private static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string filePath = Path.Combine(desktopPath,"LogedInUsers.json");

        public string FilePath
        {
            get{return filePath;}
        }
    }
}
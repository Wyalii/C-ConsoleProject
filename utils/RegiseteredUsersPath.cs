namespace Project
{
    public class RegisteredUsersPath
    {
        private static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string filePath = Path.Combine(desktopPath,"test.json");

        public string FilePath
        {
            get{return filePath;}
        }

    }
}
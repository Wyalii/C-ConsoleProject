namespace Project
{
    public class FilePathUtil
    {
        private static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string filePath = Path.Combine(desktopPath,"test.json");

        public string FilePath
        {
            get{return filePath;}
        }

    }
}
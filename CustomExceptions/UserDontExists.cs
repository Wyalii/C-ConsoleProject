namespace Project
{
    public class UserDontExists :Exception
    {
        public UserDontExists(string message) :base(message)
        {
            
        }
    }
}
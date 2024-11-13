namespace Project
{
    public class UserAlreadyLogedIn : Exception
    {
        public UserAlreadyLogedIn (string message) : base(message)
        {
            
        }
    }
}
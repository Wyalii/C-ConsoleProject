namespace Project
{
    public class UserAlreadyLoggedOut : Exception
    {
        public UserAlreadyLoggedOut (string message):base(message)
        {

        }
    }
}
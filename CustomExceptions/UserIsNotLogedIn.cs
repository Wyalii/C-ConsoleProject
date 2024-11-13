namespace Project
{
    public class UserIsNotLogedIn : Exception
    {
        public UserIsNotLogedIn(string message):base(message)
        {
            
        }
    } 
}
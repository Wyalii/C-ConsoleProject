namespace Project
{
    public class UserAlredyExists : Exception
    {
       public UserAlredyExists(string message) : base(message){

       }
    }
}
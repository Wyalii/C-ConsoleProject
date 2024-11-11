namespace Project
{
    public class CantRegisterAdmin : Exception
    {
       public CantRegisterAdmin(string message) :base(message)
       {
        
       }
    }

}
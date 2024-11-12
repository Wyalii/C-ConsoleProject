namespace Project
{
   class Program
   {
     static void Main()
     {
        RegistrationFunction registration = new RegistrationFunction();
        LoginFunction login =  new LoginFunction();
        
        
        var user = new User(){Name = "Mariam",Password = "Password123",IsAdmin = false, Id = "159649ee-b5e4-4a2e-b626-18a6c907bf17",LogedIn = false};
        login.Login(user);
        
        
     }
   }
}
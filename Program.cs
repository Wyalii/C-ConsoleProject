namespace Project
{
   class Program
   {
     static void Main()
     {
        RegistrationFunction registration = new RegistrationFunction();
        LoginFunction login =  new LoginFunction();
        RegisterService registerService = new RegisterService();
        LoginService loginService = new LoginService();
        loginService.LogIn();
        
        
        
     }
   }
}
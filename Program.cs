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
        LogOutFunction logOutFunction = new LogOutFunction();
        var testUser = new User(){
         Name = "Giorgi",
         Id = "c445882c-66ee-40c8-8679-ab09afd2df53",
         Password = "123paroli",
         IsAdmin = false,
         LogedIn = true,
         Balance = 123,
        };
        LogedInUsers logedInUsers = new LogedInUsers();
       
        loginService.LogIn();
        
        
        
        
     }
   }
}
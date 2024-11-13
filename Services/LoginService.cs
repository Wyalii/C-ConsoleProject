using System.Security.Cryptography.X509Certificates;

namespace Project
{
    public class LoginService 
    {
        LoginFunction loginFunction = new LoginFunction();
        InputValidations inputValidations = new InputValidations();
        JsonCRUD jsonCRUD = new JsonCRUD();
        RegisteredUsersPath registeredUsersPath = new RegisteredUsersPath();
        
        public void LogIn()
        {
          bool start = false;
          
          string UserInputUsername;
          string UserInputPassword;
          
          bool CheckNameInput;
          bool CheckPasswordInput;
          
          do
          {
            Console.WriteLine("Login User.");
            Console.WriteLine("Username:");
            UserInputUsername = Console.ReadLine();
            Console.WriteLine("Password:");
            UserInputPassword = Console.ReadLine();
        
            CheckNameInput = inputValidations.StringInputValidate(UserInputUsername);
            CheckPasswordInput = inputValidations.StringInputValidate(UserInputPassword);
        
            if(CheckNameInput == false)
            {
              Console.WriteLine("Username Input was Invalid, try again.");
              start = true;
            }else if(CheckPasswordInput == false)
            {
              Console.WriteLine("Password Input was Invalid, try again.");
              start = true;
            }else{
              start = false;
            }

           var ListFromJson = jsonCRUD.GetDataFromFile(registeredUsersPath.FilePath);

           var MatchingUser = ListFromJson.FirstOrDefault(u => u.Name == UserInputUsername && u.Password == UserInputPassword);
           var sheshvla = loginFunction.Login(MatchingUser);

           }while (start);
 
           
        
        }
    }
}
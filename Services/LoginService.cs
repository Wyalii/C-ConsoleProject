using System.Security.Cryptography.X509Certificates;

namespace Project
{
    public class LoginService 
    {
        LoginFunction loginFunction = new LoginFunction();
        InputValidations inputValidations = new InputValidations();
        JsonCRUD jsonCRUD = new JsonCRUD();
        FilePathUtil FilePathUtil = new FilePathUtil();
        public void LogIn()
        {
          bool start = false;
          
          string UserInputUsername;
          string UserInputPassword;
          string BalanceInput;
          bool CheckNameInput;
          bool CheckPasswordInput;
          bool CheckBalanceInput;
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

           }while (start);
 
           var ListFromJson = jsonCRUD.GetDataFromFile(FilePathUtil.FilePath);

           var MatchingUser = ListFromJson.FirstOrDefault(u => u.Name.Trim().ToLower() == UserInputUsername.Trim().ToLower() && u.Password.Trim().ToLower() == UserInputPassword.Trim().ToLower());
           loginFunction.Login(MatchingUser);
        }
    }
}
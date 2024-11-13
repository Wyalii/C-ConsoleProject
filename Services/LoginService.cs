using System.Security.Cryptography.X509Certificates;

namespace Project
{
    public class LoginService 
    {
        UsersList usersList = new UsersList();
        LoginFunction loginFunction = new LoginFunction();
        InputValidations inputValidations = new InputValidations();
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

          } while (start);
 

          var MatchingUser = usersList.users.Where(u => u.Name == UserInputUsername && u.Password == UserInputPassword);

          
        }
    }
}
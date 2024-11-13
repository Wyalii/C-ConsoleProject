using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Project
{
    public class RegisterService
    {
        public void Registration()
        {
          RegistrationFunction registration = new RegistrationFunction();
          InputValidations inputValidations = new InputValidations();

          bool start = false;
          
          string UserInputUsername;
          string UserInputPassword;
          string BalanceInput;
          do
          {
          Console.WriteLine("Create Your Name, Password, Balance.");
          Console.WriteLine("Username:");
          UserInputUsername = Console.ReadLine();
          Console.WriteLine("Password:");
          UserInputPassword = Console.ReadLine();
          Console.WriteLine("Balance:");
          BalanceInput = Console.ReadLine();

          bool CheckNameInput = inputValidations.StringInputValidate(UserInputUsername);
          bool CheckPasswordInput = inputValidations.StringInputValidate(UserInputPassword);
          bool CheckBalanceInput = inputValidations.NumbersInputValidation(BalanceInput);
          
          if(CheckNameInput == false)
          {
            Console.WriteLine("Username Input was Invalid, try again.");
            start = true;
          }else if(CheckPasswordInput == false)
          {
            Console.WriteLine("Password Input was Invalid, try again.");
            start = true;
          }else if(CheckBalanceInput == false)
          {
            Console.WriteLine("Balance Input was Invalid, try again.");
            start = true;
          }else{
            start = false;
          }

          } while (start);

          double UserInputBalance = double.Parse(BalanceInput); 
          registration.Register(UserInputUsername,UserInputPassword,UserInputBalance);        

        }
    }
}
using System.Text.RegularExpressions;

namespace Project
{
    public class RegisterService
    {
        public void Registration()
        {
          int number;
          Console.WriteLine("Create Your Name, Password, Balance.");
          Console.WriteLine("Username:");
          string UserInputUsername = Console.ReadLine();
          Console.WriteLine("Password:");
          string UserInputPassword = Console.ReadLine();
          Console.WriteLine("Balance:");
          double Double;
          string BalanceInput = Console.ReadLine();


         try
         {
            if(!Regex.IsMatch(BalanceInput,@"^\d+(\.\d+)?$"))
          {
            throw new OnlyInt("EXCEPTION: Balance should only contain numbers.");
          }


          if(string.IsNullOrWhiteSpace(UserInputUsername))
          {
            throw new NullSpaceInput("EXCEPTION: Username Cannot contain only empty spaces and it cant be null.");
          }

          if(Regex.IsMatch(UserInputUsername,@"^\d+$"))
          {
            throw new OnlyIntInput("EXCEPTION: Username cant be integers only.");
          }

          if(string.IsNullOrWhiteSpace(UserInputPassword))
          {
            throw new NullSpaceInput("EXCEPTION: Password Cannot contain only empty spaces and it cant be null.");
          }

          if(Regex.IsMatch(UserInputPassword,@"^\d+$"))
          {
            throw new OnlyIntInput("EXCEPTION: Password cant be integers only.");
          }
          
         }
         catch (OnlyInt ex)
         {
           Console.WriteLine(ex.Message);
         }
         catch(NullSpaceInput ex)
         {
           Console.WriteLine(ex.Message);
         }
         catch(OnlyIntInput ex)
         {
            Console.WriteLine(ex.Message);
         }


           double UserInputBalance = double.Parse(BalanceInput);         

        }
    }
}
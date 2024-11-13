using System.Text.RegularExpressions;
namespace Project
{
    public class InputValidations
    {
        public bool StringInputValidate(string StringInput)
        {
          try
          {
            if(string.IsNullOrWhiteSpace(StringInput))
          {
            throw new NullSpaceInput("EXCEPTION: this input Cannot contain only empty spaces and it cant be null.");
          }

          if(Regex.IsMatch(StringInput,@"^\d+$"))
          {
            throw new OnlyIntInput("EXCEPTION: this input cant be integers only.");
          }
          }
          catch (NullSpaceInput ex)
          {
            Console.WriteLine(ex.Message);
            return false;
          }
          catch (OnlyIntInput ex)
          {
            Console.WriteLine(ex.Message);
            return false;
          }

          return true;
        }

        public bool NumbersInputValidation(string NumberInput)
        {
          try
          {
            if(!Regex.IsMatch(NumberInput,@"^\d+(\.\d+)?$"))
          {
            throw new OnlyInt("EXCEPTION: this input should only contain numbers.");
          }
          }
          catch (OnlyInt ex)
          {
            Console.WriteLine(ex.Message);
            return false;
          }
          return true;
        }
    }
}
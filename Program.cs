using System.Text.Json;

namespace Project
{
  public class Program
  {
    static void Main()
    {
      Registration registration = new Registration();
      var Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      var LoggedInUsersRoute = Path.Combine(Desktop,"LoggedInUsers.json");
      Login login = new Login();
      ProductsCRUD productsCRUD = new ProductsCRUD();
      bool start = false;
      bool start2 = false;
      bool nextMenu = false;
      User check1 = new User();

      do
      {
        Console.WriteLine("1-Register, 2-Login");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
          case 1:
            registration.Register();
            start = true;
            
          break;

          case 2:
            check1 = login.LoginFunc();
            
            start = false;
            nextMenu = true;
          break;

          default:
          start = true;
          break;
        }
      } while (start);



     if(nextMenu == true)
     {
       if(check1.IsAdmin == true)
       {
         do
         {
            Console.WriteLine("Identifed Admin.");
            Console.WriteLine("Admin Services:");
            Console.WriteLine("1-PrintProducts");
            Console.WriteLine("2-AddProduct");
            Console.WriteLine("3-RemoveProduct");
            Console.WriteLine("4-UpdateProduct");
            Console.WriteLine("5-Loggout");
            int chocie = int.Parse(Console.ReadLine());
        switch (chocie)
        {
          case 1:
           productsCRUD.PrintProducts();
           Console.WriteLine(" do you want to continue app?");
           Console.WriteLine("Y/N");
           string choice = Console.ReadLine();
           if(choice == "Y" || choice == "y")
           {
            start2 = true;
           }else{
            start2 = false;
           }
           
          break;

          case 2:

          productsCRUD.AddProduct();

           Console.WriteLine(" do you want to continue app?");
           Console.WriteLine("Y/N");
            choice = Console.ReadLine();
           if(choice == "Y" || choice == "y")
           {
            start2 = true;
           }else{
            start2 = false;
           }
           

          break;


          case 3:

           productsCRUD.RemoveProduct();
           Console.WriteLine(" do you want to continue app?");
           Console.WriteLine("Y/N");
           choice = Console.ReadLine();
           if(choice == "Y" || choice == "y")
           {
            start2 = true;
           }else{
            start2 = false;
           }
           
        
          break;

          
          case 4:

           productsCRUD.UpdateProduct();
           Console.WriteLine(" do you want to continue app?");
           Console.WriteLine("Y/N");
           choice = Console.ReadLine();
           if(choice == "Y" || choice == "y")
           {
            start2 = true;
           }else{
            start2 = false;
           }
           

          break;

          case 5:

          break;


          default:
            start2 = true;
          break;
        }
         } while (start2);
       }


       if(check1.IsAdmin == false)
       {
         do
         {
            Console.WriteLine("Identifed User.");
            Console.WriteLine("User Services:");
            Console.WriteLine("1-PrintProducts");
            Console.WriteLine("2-BuyProduct");
            Console.WriteLine("3-CheckBalance");
            Console.WriteLine("4-UpdateBalance");
            Console.WriteLine("5-Exit");
            int chocie = int.Parse(Console.ReadLine());
        switch (chocie)
        {
          case 1:
           productsCRUD.PrintProducts();
           Console.WriteLine(" do you want to continue app?");
           Console.WriteLine("Y/N");
           string choice = Console.ReadLine();
           if(choice == "Y" || choice == "y")
           {
            start2 = true;
           }else{
            start2 = false;
           }
           
          break;

          case 2:
          

           Console.WriteLine(" do you want to continue app?");
           Console.WriteLine("Y/N");
            choice = Console.ReadLine();
           if(choice == "Y" || choice == "y")
           {
            start2 = true;
           }else{
            start2 = false;
           }
           

          break;


          case 3:

           Console.WriteLine(" do you want to continue app?");
           Console.WriteLine("Y/N");
           choice = Console.ReadLine();
           if(choice == "Y" || choice == "y")
           {
            start2 = true;
           }else{
            start2 = false;
           }
           
        
          break;

          
          case 4:

           Console.WriteLine(" do you want to continue app?");
           Console.WriteLine("Y/N");
           choice = Console.ReadLine();
           if(choice == "Y" || choice == "y")
           {
            start2 = true;
           }else{
            start2 = false;
           }
           

          break;

          case 5:
           start2 = false;
          break;


          default:
            start2 = true;
          break;
        }
         } while (start2);
       }

     }
     
    }
  }
}
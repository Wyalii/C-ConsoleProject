namespace Project
{
  public class Menu
  {
    public User ReturnedUser = new User();
    bool nextMenu = false;
    Registration registration = new Registration();
    Login login = new Login();
    ProductsCRUD productsCRUD = new ProductsCRUD();
    public bool RegAndLoginMenu()
    {

      bool start = false;

      do
      {
        Console.WriteLine("1-Register, 2-Login");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
          Console.WriteLine("Invalid input. Please enter a number.");
        }
        switch (choice)
        {
          case 1:
            registration.Register();
            start = true;

            break;

          case 2:
            ReturnedUser = login.LoginFunc();

            start = false;
            nextMenu = true;

            break;

          default:
            start = true;
            break;
        }
      } while (start);

      return nextMenu;

    }

    public void ServicesMenu()
    {
      bool start = false;

      if (nextMenu == true)
      {
        if (ReturnedUser.IsAdmin == true)
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
                if (choice == "Y" || choice == "y")
                {
                  start = true;
                }
                else
                {
                  start = false;
                }

                break;

              case 2:

                productsCRUD.AddProduct();
                Console.WriteLine(" do you want to continue app?");
                Console.WriteLine("Y/N");
                choice = Console.ReadLine();
                if (choice == "Y" || choice == "y")
                {
                  start = true;
                }
                else
                {
                  start = false;
                }

                break;


              case 3:

                productsCRUD.RemoveProduct();
                Console.WriteLine(" do you want to continue app?");
                Console.WriteLine("Y/N");
                choice = Console.ReadLine();
                if (choice == "Y" || choice == "y")
                {
                  start = true;
                }
                else
                {
                  start = false;
                }


                break;


              case 4:

                productsCRUD.UpdateProduct();
                Console.WriteLine(" do you want to continue app?");
                Console.WriteLine("Y/N");
                choice = Console.ReadLine();
                if (choice == "Y" || choice == "y")
                {
                  start = true;
                }
                else
                {
                  start = false;
                }


                break;

              case 5:

                break;


              default:
                start = true;
                break;
            }
          } while (start);
        }


        if (ReturnedUser.IsAdmin == false)
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
                if (choice == "Y" || choice == "y")
                {
                  start = true;
                }
                else
                {
                  start = false;
                }

                break;

              case 2:
                Console.WriteLine(" do you want to continue app?");
                Console.WriteLine("Y/N");
                choice = Console.ReadLine();
                if (choice == "Y" || choice == "y")
                {
                  start = true;
                }
                else
                {
                  start = false;
                }

                break;


              case 3:
                Console.WriteLine(" do you want to continue app?");
                Console.WriteLine("Y/N");
                choice = Console.ReadLine();
                if (choice == "Y" || choice == "y")
                {
                  start = true;
                }
                else
                {
                  start = false;
                }



                break;


              case 4:
                Console.WriteLine(" do you want to continue app?");
                Console.WriteLine("Y/N");
                choice = Console.ReadLine();
                if (choice == "Y" || choice == "y")
                {
                  start = true;
                }
                else
                {
                  start = false;
                }


                break;

              case 5:
                start = false;
                break;


              default:
                start = true;
                break;
            }
          } while (start);
        }

      }
    }
  }
}
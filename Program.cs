using System.Text.Json;

namespace Project
{
  public class Program
  {
    static void Main()
    {
      Menu menu = new Menu();
      menu.RegAndLoginMenu();
      menu.ServicesMenu();

    }
  }
}
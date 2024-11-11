namespace Project
{
   class Program
   {
     static void Main()
     {
        RegistrationService registration = new RegistrationService();
        registration.Register("Giorgi","Password123",123);
        
     }
   }
}
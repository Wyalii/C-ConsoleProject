namespace Project
{
   class Program
   {
     static void Main()
     {
        RegistrationFunction registration = new RegistrationFunction();
        registration.Register("Giorgi","Password123",123);
        registration.Register("Mariami","Password???",1231);
        
     }
   }
}
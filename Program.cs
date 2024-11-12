namespace Project
{
   class Program
   {
     static void Main()
     {
        RegistrationFunction registration = new RegistrationFunction();
        LoginFunction login =  new LoginFunction();
        
        registration.Register("Mariam","Password123",999999999);
        
        
     }
   }
}
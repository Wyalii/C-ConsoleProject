namespace Project
{
    public class RegistrationService
    {

        static private string GuidIdGenerator()
        {
            return Guid.NewGuid().ToString();
        }
         
        private List<User>users = new List<User>()
        {
          new User(){Name = "AdminName", Password = "AdminPassword", Id = "ThisIsAdminId", Balance = 0},
        };
       public void Register(string name, string password, int balance)
       {
          if(password != "AdminPassword" && name != "AdminName")
          {
            var user = new User(){Name = name, Password = password, Balance = balance, IsAdmin = false,Id = GuidIdGenerator()};
            if(!users.Exists(i => i.Id == user.Id))
            {
               users.Add(user);
            }else{
                throw new UserAlredyExists($"User with id: {user.Id} alredy exists.");
            }
          }
       }
    }
}
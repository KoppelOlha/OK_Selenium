public class User
{  
    public string Login { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
    public string Role { get; set; }

    public static User GetDefaultUser()
    {
        return new User("admin", "admin", "Ivan", "Petrov" );
    }

    public static User RegularUser()
    {
        return new User( "user1", "user1pass", "UserOneFN", "UserOneLN" );
    }

    public User(string login, string password, string firstName, string lastName) {
        Login = login;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Role = "";
    }

    public User (string login, string password, string firstName, string lastName, string role)
    {
        Login = login;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Role = role;
    }
}

using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using SelectTest.Providers;

namespace SelectTest;

public static class Program
{
    public static void Main()
    {
        var selector = new ApiSelector { "Id", "Name", "Users.Id" };

        var data = new UserGroup ("1", "Test", new List<User>
        {
            new User ("1", "Fred Flinstone", "Fred@gmail.com", "Fred", "Flinstone"),
            new User ("2", "Barney Rubble", "Barney@gmail.com", "Barney", "Rubble") 
        });

        var provider = new FlatDictionaryProvider();
        var result = provider.Execute(data);
    }
}


public record User(string Id, string Name, string Email, string FirstName, string LastName);

public record UserGroup(string Id, string Name, IEnumerable<User> Users);

public class ApiSelector : Collection<string>
{
}



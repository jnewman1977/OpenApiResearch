// See https://aka.ms/new-console-template for more information

using Api.Client;

var baseUrl = "https://localhost:7210";
var client = new ApiClient(baseUrl, new HttpClient());

var data = await client
    .UserGroupAsync()
    .ConfigureAwait(true);

data.ToList().ForEach(g =>
{
    Console.WriteLine($"Group - Id: {g.Id}, Name: {g.Name}");
    g.Users.ToList().ForEach(u => Console.WriteLine(
        $"User - Id: {u.Id}, Name: {u.Name}, Email: {u.Email}, First Name: {u.FirstName}, Last Name: {u.LastName}"));
});

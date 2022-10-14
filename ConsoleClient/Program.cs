// See https://aka.ms/new-console-template for more information

using Api.Client;

var baseUrl = "https://localhost:7210";
var client = new ApiClient(baseUrl, new HttpClient());

var groups = await client.UserGroupAsync();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("{0}Groups{0}", Environment.NewLine);
Console.ResetColor();

groups.ToList().ForEach(g =>
{
    Console.WriteLine($"Group - Id: {g.Id}, Name: {g.Name}");
});

var group = groups.Skip(2).Take(1).First();
var users = await client.UsersAsync(group.Id);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"{Environment.NewLine}Users for Group [{group.Id}] - {group.Name}{Environment.NewLine}");
Console.ResetColor();

users.ToList().ForEach(u =>
{
    Console.WriteLine($"User - Id: {u.Id}, Name: {u.Name}, Email: {u.Email}, First Name: {u.FirstName}, Last Name: {u.LastName}");
});

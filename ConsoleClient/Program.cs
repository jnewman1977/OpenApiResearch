// See https://aka.ms/new-console-template for more information

using Api.Client;

var baseUrl = "https://localhost:7210";
var client = new ApiClient(baseUrl, new HttpClient());

// var data = await client
//     .UserGroupAsync()
//     .ConfigureAwait(true);

var data = await client.UsersAsync("633df04e15036b35f4b1ce89").ConfigureAwait(true);

// data.ToList().ForEach(g =>
// {
//     Console.WriteLine($"Group - Id: {g.Id}, Name: {g.Name}");
//     g.Users.ToList().ForEach(u => Console.WriteLine(
//         $"User - Id: {u.Id}, Name: {u.Name}, Email: {u.Email}, First Name: {u.FirstName}, Last Name: {u.LastName}"));
// });

data.ToList().ForEach(u =>
{
    Console.WriteLine($"User - Id: {u.Id}, Name: {u.Name}, Email: {u.Email}, First Name: {u.FirstName}, Last Name: {u.LastName}");
});

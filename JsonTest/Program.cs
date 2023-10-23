using System.Text.Json;
using System.Text.Json.Serialization;
//using System.Text.Json.Serialization;

string path = @"/Users/macbook/Projects/Json_Test/ReadThisInfo.json";
using (FileStream fs = new FileStream(path, FileMode.Open))
{
    var books = await JsonSerializer.DeserializeAsync<List<Book>>(fs);
    foreach (var book in books)
    {
        Console.WriteLine($"PublishingHouseId: {book.PublishingHouseId} | Title: {book.Title} \nPublishingHouse:");
        Console.WriteLine($"Id: {book.PublishingHouse.Id} | Name: {book.PublishingHouse.Name} | Adress: {book.PublishingHouse.Adress}" + '\n');
    }
}

Console.ReadKey();

/*var options = new JsonSerializerOptions
{
    WriteIndented = true,
    IncludeFields = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
};
*/

public class Book
{
    public Book(int publishingHouseId, string title)
    {
        PublishingHouseId = publishingHouseId;
        Title = title;

    }
    public int PublishingHouseId { get; set; }
    public string Title { get; set; }
    public PublishingHouseDetail PublishingHouse { get; set; }

}


public class PublishingHouseDetail
{ 
    public PublishingHouseDetail (int id, string name, string adress)
    {
        Id = id;
        Name = name;
        Adress = adress;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }

}
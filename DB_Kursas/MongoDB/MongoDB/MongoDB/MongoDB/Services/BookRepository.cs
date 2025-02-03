using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Models;

namespace MongoDB.Services;

public class BookRepository
{
    private readonly IMongoCollection<Book> _books;

    public BookRepository(string connectionString)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("Bookstore");
        _books = database.GetCollection<Book>("books");
    }

    public Book AddBook(string name, int numberOfPages)
    {
        var book = new Book(ObjectId.GenerateNewId(), name, numberOfPages)
        {
            Pages = new List<Page>(numberOfPages)
        };
        _books.InsertOne(book);
        return book;
    }

    public List<Book> FindBooks(string fieldName, string value)
    {
        var filter = Builders<Book>.Filter.Eq(fieldName, value);
        return _books.Find(filter).ToList();
    }

    public void UpdateBook(string fieldName, string oldValue, Book newValue)
    {
        var filter = Builders<Book>.Filter.Eq(fieldName, oldValue);
        _books.ReplaceOne(filter, newValue);
    }

    public void DeleteBook(string fieldName, string value)
    {
        var filter = Builders<Book>.Filter.Eq(fieldName, value);
        _books.DeleteMany(filter);
    }
}

using MongoDB.Bson;

namespace MongoDB.Models;

public class Page
{
    public ObjectId Id { get; set; }
    public string Content { get; set; }

    public Page(ObjectId id)
    {
        Id = id;
        Content = $"Page content #{id.Timestamp}";
    }
}

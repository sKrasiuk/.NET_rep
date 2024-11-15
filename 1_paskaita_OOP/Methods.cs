using _1_paskaita_OOP;

public static class Methods
{
    public static List<Book> GetBooksByAuthor(List<Book> books, string authorName)
    {
        List<Book> searchResult = new();

        foreach (var book in books)
        {
            if (book.Author == authorName)
            {
                searchResult.Add(book);
            }
        }

        return searchResult;
    }
}
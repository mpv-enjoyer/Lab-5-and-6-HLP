Book book = new("my_book", "author_surname", "author_name");
book.Print();
book.Name = null;
book.Print();

BookGenre bookGenre = new("my_book 2", "author_surname", "author_name", GenreType.Romance);
bookGenre.Print();
bookGenre.Genre = GenreType.HistoricalFiction;
bookGenre.Print();

BookGenrePubl bookGenrePubl = new("my_book 3", "author_surname", "author_name", GenreType.Romance, "ООО ЗНАМЕНИТЫЕ КНИГИ");
bookGenrePubl.Print();
bookGenrePubl.Publisher = "ОАО ЗАВОД";
bookGenrePubl.Print();

class Book
{
	private string _name;
	public string? Name
	{
		get { return _name; }
		set { _name = value ?? "[empty]"; }
	}
	private string _authorSurname;
    public string? AuthorSurname
    {
        get { return _authorSurname; }
        set { _authorSurname = value ?? "[empty]"; }
    }
    private string _authorName;
    public string? AuthorName
    {
        get { return _authorName; }
        set { _authorName = value ?? "[empty]"; }
    }
    public Book(string name, string authorsurname, string authorname)
    {
        _name = name;
        _authorSurname = authorsurname;
        _authorName = authorname;
    }
    public virtual void Print()
    {
        Console.WriteLine($"Name {Name} Author: {AuthorSurname} {AuthorName}.");
    }
}

enum GenreType
{
    Romance,
    DetectiveMystery,
    Horror,
    Thriller,
    HistoricalFiction,
}

class BookGenre : Book
{
    private GenreType _genre;
    public GenreType Genre
    {
        get { return _genre; }
        set { _genre = value; }
    }
    public BookGenre(string name, string authorsurname, string authorname, GenreType genre) : base(name, authorsurname, authorname)
    {
        _genre = genre;
    }
    public override void Print()
    {
        Console.Write($"Genre {Genre} ");
        base.Print();
    }
}
sealed class BookGenrePubl : BookGenre
{
    private string _publisher;
    public string Publisher
    {
        get { return _publisher; }
        set { _publisher = value ?? "[empty]"; }
    }
    public BookGenrePubl(string name, string authorsurname, string authorname, GenreType genre, string publisher) :
        base(name, authorsurname, authorname, genre)
    {
        _publisher = publisher;
    }
    public override void Print()
    {
        Console.Write($"Publisher {Publisher} ");
        base.Print();
    }
}
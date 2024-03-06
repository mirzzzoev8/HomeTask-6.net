using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class BookServices
{
    private readonly DapperContext _context;
    public BookServices()
    {
        _context = new DapperContext();
    }
    public List<Books> GetBooks()
    {
        var qq = "select * from books";
        return _context.Connection().Query<Books>(qq).ToList();
    }

    public void AddBook(Books books)
    {
        var qq = "insert into books (title,data) values (@title,@data)";
        _context.Connection().Execute(qq , books);
    }

    public void UpdateBook(Books books)
    {
        var qq = "update books set title = @title,data = @data  where id = @id";
        _context.Connection().Execute(qq , books); 
    }
    
    public void DeleteBook(int id)
    {
        var qq = "delete from books where id = @id";
        _context.Connection().Execute(qq, new {Id = id});
    }
    public Books GetBookByTitle(string title)
    {
        return _context.Connection().Query<Books>("select * from Books where Title = @title",new{title=title}).FirstOrDefault()!;
    }
    public Books GetBookById(int id)
    {
        var sql = "select * from books where id = @id";
        var result = _context.Connection().ExecuteReader(sql, new { Id = id });
        var book = new Books();
        if (result.Read())
        {
            book.Id = result.GetInt32(0);
            book.Title = result.GetString(1);
            book.Data = result.GetDateTime(2);
            return book;
        }

        return new Books();
    }
    
}

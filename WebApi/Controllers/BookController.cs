using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly BookServices _bookservices;
    public BookController()
    {
        _bookservices = new BookServices();
    }
    [HttpPost("add - book")]
    public void AddBook(Books book)
    {
        _bookservices.AddBook(book);
    }
    [HttpGet("get-books")]
    public List<Books> GetBooks()
    {
        return _bookservices.GetBooks();
    }
    [HttpPut("update-book")]
    public void UpdateBook(Books books)
    {
        _bookservices.UpdateBook(books);
    }
    [HttpDelete("delete-book")]
    public void DeleteBook(int id)
    {
        _bookservices.DeleteBook(id);
    }
    [HttpGet("get - book by title")]
    public Books GetBookbyTitle(string title)
    {
        return _bookservices.GetBookByTitle(title);
    }
    [HttpGet("get-books-by-id")]
    public Books GetBooksById(int id)
    {
        return _bookservices.GetBookById(id);
    }    
    
}

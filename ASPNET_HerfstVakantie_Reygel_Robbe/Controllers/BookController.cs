using System.Collections.Generic;
using System.Linq;
using ASPNET_HerfstVakantie_Reygel_Robbe.Entities;
using ASPNET_HerfstVakantie_Reygel_Robbe.Models;
using ASPNET_HerfstVakantie_Reygel_Robbe.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace ASPNET_HerfstVakantie_Reygel_Robbe.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        //GET

        [HttpGet("/books")]
        public IActionResult Index()
        {
            var model = new BookListViewModel { Books = new List<BookDetailViewModel>() };
            var allBooks = _bookService.GetAllBooks();
            model.Books.AddRange(allBooks.Select(ConvertBookToBookDetailViewModel).ToList());
            return View(model);
        }

        [HttpGet("/books/{id}")]
        public IActionResult Detail([FromRoute] int id)
        {
            if (id == 0)
            {
                var vm = new BookEditDetailViewModel
                {
                    CreationDate = DateTime.Now
                };

                return View("Detail", vm);
            }
            else
            {
                var book = _bookService.GetBookById(id);
                if (book == null)
                {
                    return NotFound();
                }

                var vm = ConvertBookToEditDetailViewModel(book);
                vm.Genres = _bookService.GetAllGenres().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                }
                ).ToList();
                return View(vm);
            }
        }

        [HttpGet("/api/books")]
        public IActionResult IndexAsJson()
        {
            var model = new BookListViewModel { Books = new List<BookDetailViewModel>() };
            var allBooks = _bookService.GetAllBooks();
            model.Books.AddRange(allBooks.Select(ConvertBookToBookDetailViewModel).ToList());
            return new JsonResult(model);
        }


        //POST


        [HttpPost("/books")]
        public IActionResult Persist([FromForm] BookEditDetailViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var book = vm.Id == 0 ? new Book() : _bookService.GetBookById(vm.Id);
                book.Title = vm.Title;
                book.Genre = vm.GenreId.HasValue ? _bookService.GetGenreById(vm.GenreId.Value) : null;
                book.CreationDate = vm.CreationDate;
                book.ISBN = vm.ISBN;
                _bookService.Persist(book);

                return Redirect("/books");
            }
            return View("Detail", vm);
        }


        [HttpPost("/books/delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _bookService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        //Functions

        public BookEditDetailViewModel ConvertBookToEditDetailViewModel(Book book)
        {
            var vm = new BookEditDetailViewModel
            {
                Id = book.Id,
                Title = book.Title,
                CreationDate = book.CreationDate,
                Genre = book.Genre?.Name,
                GenreId = book.Genre?.Id
            };
            return vm;
        }


        protected BookDetailViewModel ConvertBookToBookDetailViewModel(Book book)
        {
            return new BookDetailViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                CreationDate = book.CreationDate,
                Author = string.Join(";", book.Authors.Select(x => x.Author.FullName)),
                Genre = book.Genre?.Name,
                ISBN = book.ISBN
            };
        }
    }
}
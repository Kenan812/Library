using Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows;

namespace Library.ViewModel
{
    class CustomerPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private LibraryDbTool _libraryDbTool;

        public string UserName { get; set; }
       
        public CustomerPageViewModel(string username)
        {
            _libraryDbTool = new LibraryDbTool();
            UserName = username;
        }

        public List<string> GetAllAuthors()
        {
            DataTable dt = _libraryDbTool.UserRepository.AuthorsRepo.GetAuthorsInfo();
            List<string> authors = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                authors.Add(dt.Rows[i]["FirstName"].ToString() + " " + dt.Rows[i]["LastName"].ToString());
            }


            return authors;
        }

        public DataTable GetBooksByAuthor(string firstname, string lastname)
        {
            return _libraryDbTool.UserRepository.BooksOnSalesRepo.GetBooksOnSaleByAuthor(firstname, lastname);
        }


        public List<string> GetAllBooks()
        {
            DataTable dt = _libraryDbTool.UserRepository.BooksRepo.GetBooksInfo();
            List<string> books = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                books.Add(dt.Rows[i]["BookName"].ToString());
            }
            Thread.Sleep(100);
            
            return books;
        }


        public DataTable GetBookByBookName(string bookname)
        {
            return _libraryDbTool.UserRepository.BooksOnSalesRepo.GetBooksOnSaleByBookName(bookname);
        }

        public List<string> GetAllGenres()
        {
            DataTable dt = _libraryDbTool.UserRepository.GenreRepo.GetGenresInfo();
            List<string> genres = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                genres.Add(dt.Rows[i]["GenreName"].ToString());
            }
            Thread.Sleep(100);

            return genres;
        }


        public DataTable GetBookByGenre(string genreName)
        {
            return _libraryDbTool.UserRepository.BooksOnSalesRepo.GetBooksOnSaleByGenreName(genreName);
        }


        public DataTable GetLatestAddedBooks()
        {
            return _libraryDbTool.UserRepository.BooksOnSalesRepo.GetMostRecentBooks();
        }

        public DataTable GetMostPopularAuthors()
        {
            return _libraryDbTool.UserRepository.AuthorsRepo.GetMostPopularAuthors();
        }

        public DataTable GetMostPopularBooks()
        {
            return _libraryDbTool.UserRepository.BooksRepo.GetMostPopularBooks();
        }

        public DataTable GetMostPopularGenres()
        {
            return _libraryDbTool.UserRepository.GenreRepo.GetMostPopularGenres();
        }


        public DataTable GetMyBooks()
        {
            return _libraryDbTool.UserRepository.SoldBooksRepo.GetSoldBooksForUser(UserName);
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

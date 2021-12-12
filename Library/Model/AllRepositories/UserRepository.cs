using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model.AllRepositories
{
    class UserRepository
    {
        private AuthorsRepository _authors;
        public AuthorsRepository AuthorsRepo { get => _authors ?? new AuthorsRepository(); }


        private AdminsRepository _admins;
        public AdminsRepository AdminsRepo { get => _admins ?? new AdminsRepository(); }

        private BooksRepository _books ;
        public BooksRepository BooksRepo { get => _books ?? new BooksRepository(); }

        private GenresRepository _genres;
        public GenresRepository GenreRepo { get => _genres ?? new GenresRepository(); }

        private CustomersRepository _customers;
        public CustomersRepository CustomersRepo { get => _customers ?? new CustomersRepository(); }

        private BooksGenresRepository _booksGenres;
        public BooksGenresRepository BooksGenresRepo { get => _booksGenres ?? new BooksGenresRepository(); }

        private PublishingHousesRepository _publishingHouses;
        public PublishingHousesRepository PublishingHousesRepo { get => _publishingHouses ?? new PublishingHousesRepository(); }

        private BooksOnSalesRepository _booksOnSales;
        public BooksOnSalesRepository BooksOnSalesRepo { get => _booksOnSales ?? new BooksOnSalesRepository(); }

        private ReservedBooksRepository _reservedBooks;
        public ReservedBooksRepository ReservedBooksRepo { get => _reservedBooks ?? new ReservedBooksRepository(); }

        private SoldBooksRepository _soldBooksRepository;
        public SoldBooksRepository SoldBooksRepo { get => _soldBooksRepository ?? new SoldBooksRepository(); }
    }
}

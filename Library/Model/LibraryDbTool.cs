using Library.Model.AllRepositories;
using Library.Model.Tables;
using Library.Properties;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

namespace Library.Model
{
    class LibraryDbTool
    {
        private UserRepository _userRepository;

        public UserRepository UserRepository
        {
            get { return _userRepository; }
        }

        public LibraryDbTool()
        {
            _userRepository = new UserRepository();
        }


        /// <summary>
        /// Checks if there exist tables
        /// If not creates all missing tables
        /// </summary>
        public void CreateAllTablesOnCheck()
        {
            if (!CheckTableExistence("Authors"))
                _userRepository.AuthorsRepo.CreateTable();

            if (!CheckTableExistence("Genres"))
                _userRepository.GenreRepo.CreateTable();

            if (!CheckTableExistence("Books"))
                _userRepository.BooksRepo.CreateTable();

            if (!CheckTableExistence("BooksGenres"))
                _userRepository.BooksGenresRepo.CreateTable();

            if (!CheckTableExistence("PublishingHouses"))
                _userRepository.PublishingHousesRepo.CreateTable();

            if (!CheckTableExistence("BooksOnSale"))
                _userRepository.BooksOnSalesRepo.CreateTable();

            if (!CheckTableExistence("Customers"))
                _userRepository.CustomersRepo.CreateTable();

            if (!CheckTableExistence("Admins"))
                _userRepository.AdminsRepo.CreateTable();

            if (!CheckTableExistence("Reservedbooks"))
                _userRepository.ReservedBooksRepo.CreateTable();

            if (!CheckTableExistence("Soldbooks"))
                _userRepository.SoldBooksRepo.CreateTable();
        }


        public void InsertInitialValues()
        {
            _userRepository.AuthorsRepo.InsertInitialValues();
            _userRepository.BooksRepo.InsertInitialValues();
            _userRepository.GenreRepo.InsertInitialValues();
            _userRepository.BooksGenresRepo.InsertInitialValues();
            _userRepository.PublishingHousesRepo.InsertInitialValues();
            _userRepository.BooksOnSalesRepo.InsertInitialValues();
        }





        // Returns 'true' if query creates existing table
        // Returns 'false' otherwise
        private bool CheckTableExistence(string tableName)
        {
            SqlConnection _connection = new SqlConnection(Resources.connectionString);

            _connection.Open();
            DataTable dataTable = _connection.GetSchema("Tables");

            foreach (DataRow row in dataTable.Rows)
            {
                string dbTableName = row[2].ToString();

                if (dbTableName == tableName)
                {
                    _connection.Close();
                    return true;  // Table already exists in DB
                }
            }

            _connection.Close();
            return false;
        }



        /// <summary>
        /// Checks if current launch is first(if there exists at least 1 admin launch is NOT first)
        /// Returns true if first
        /// Returns false otherwise
        /// </summary>
        public bool IsFirstLaunch()
        {
            if (_userRepository.AdminsRepo.GetAdminCount() != 0) return false;

            return true;
        }
    }
}

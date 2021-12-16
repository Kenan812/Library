using Library.Model.Tables;
using Library.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

namespace Library.Model.AllRepositories
{
    class GenresRepository
    {
        private GenresTable _genresTable;

        public GenresRepository()
        {
            _genresTable = new GenresTable(Resources.connectionString);
        }

        public void CreateTable()
        {
            _genresTable.Create();
        }

        public void Insert(string genreName)
        {
            _genresTable.Insert(new List<string>() { genreName });
        }

        public void Update(string id, string genrename)
        {
            try
            {
                _genresTable.Update(Int32.Parse(id), new List<string>() { genrename });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Delete(string id)
        {
            try
            {
                _genresTable.Delete(Int32.Parse(id));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void InsertInitialValues()
        {
            _genresTable.InsertAllInitialValues();
        }

        public DataTable GetGenresInfo()
        {
            return _genresTable.GetGenresInfo();
        }


        /// <summary>
        /// RETURN: 
        ///     values[0] = genrename
        /// </summary>
        public List<string> GetGenreInfo(string genreId)
        {
            try
            {
                return _genresTable.GetGenreInfo(Int32.Parse(genreId));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }



    }
}

using Library.Model.Tables;
using Library.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace Library.Model.AllRepositories
{
    class PublishingHousesRepository
    {
        private PublishingHousesTable _publishingHousesTable;

        public PublishingHousesRepository()
        {
            _publishingHousesTable = new PublishingHousesTable(Resources.connectionString);
        }

        public void CreateTable()
        {
            _publishingHousesTable.Create();
        }

        public void Insert(string publishinghouseName)
        {
            _publishingHousesTable.Insert(new List<string>() { publishinghouseName });
        }

        public void Update(string id, string publishinghouseName)
        {
            try
            {
                _publishingHousesTable.Update(Int32.Parse(id), new List<string>() { publishinghouseName });
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
                _publishingHousesTable.Delete(Int32.Parse(id));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void InsertInitialValues()
        {
            _publishingHousesTable.InsertAllInitialValues();
        }

        public DataTable GetPublishingHousesInfo()
        {
            return _publishingHousesTable.GetPublishingHousesInfo();
        }


        /// <summary>
        /// RETURN: 
        ///     values[0] = publishing house name
        /// </summary>
        public List<string> GetPublishingHouseInfo(string pubHouseId)
        {
            try
            {
                return _publishingHousesTable.GetPublishingHouseInfo(Int32.Parse(pubHouseId));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Message: {ex.Message}\n\n\nError Stack Trace: {ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }


    }
}

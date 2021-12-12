using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;


namespace Library.Model.Interfaces
{
    interface ITable
    {
        void Create();

        void Insert(IEnumerable<String> values);

        void Update(int id, IEnumerable<String> values);

        void Delete(int id);
    }
}

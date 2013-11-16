using SE_Matrix_2d_v_14.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Matrix_2d_v_14.DB
{
    /// <summary>
    /// Конетекст БД
    /// </summary>
    public class SeDataContext : DataContext
    {
        // Pass the connection string to the base class.
        public SeDataContext(string connectionString)
            : base(connectionString)
        { }

        // Specify a table
        public Table<Model_SettingsSymbols> DB_SettingsSymbol;
        
        // Specify a table
        public Table<Module_Languages> DB_Language;

        // Specify a table
        public Table<Model_Colors> DB_Color;
    }
}

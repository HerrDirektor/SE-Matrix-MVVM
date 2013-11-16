using SE_Matrix_2d_v_14.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Matrix_2d_v_14.DB
{
    public class CheckDbExist
    {
        /// <summary>
        /// Проверяет, существует ли заданная БД, и если нет - создает и заполняет начальными данными
        /// </summary>
        /// <param name="DBConnectionString">Строка подклчение к БД</param>
         public CheckDbExist(string DBConnectionString)
         {
             // Create the database if it does not exist.
             using (SeDataContext db = new SeDataContext(DBConnectionString))
             {
                 if (db.DatabaseExists() == false)
                 {
                     db.CreateDatabase();

                     new FillSettingsSymbol(db);
                     new FillColors(db);
                     new FillLanguages(db);

                     db.SubmitChanges();
                 }
             }
         }
    }
}

using SE_Matrix_2d_v_14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Matrix_2d_v_14.DB
{
    public class FillLanguages
    {
        /// <summary>
        /// Заполняет таблицу Model_Colors начальными данными
        /// </summary>
        /// <param name="db">Объект БД, в которую занести изменения</param>
        public FillLanguages(SeDataContext db)
        {
            db.DB_Language.InsertOnSubmit(new Module_Languages { Name = "English", ValueFrom = 64, ValueTo = 127, NameForTranslate = "a", Selected = true });
            db.DB_Language.InsertOnSubmit(new Module_Languages { Name = "Russion", ValueFrom = 1040, ValueTo = 1103, NameForTranslate = "a", Selected = false });
            db.DB_Language.InsertOnSubmit(new Module_Languages { Name = "Chinese", ValueFrom = 19968, ValueTo = 20223, NameForTranslate = "a", Selected = false });
            db.DB_Language.InsertOnSubmit(new Module_Languages { Name = "Numbers", ValueFrom = 48, ValueTo = 57, NameForTranslate = "a", Selected = false });
        }
    }
}

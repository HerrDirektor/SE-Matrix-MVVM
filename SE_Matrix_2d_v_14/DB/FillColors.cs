using SE_Matrix_2d_v_14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Matrix_2d_v_14.DB
{
    public class FillColors
    {
        /// <summary>
        /// Заполняет таблицу Model_Colors начальными данными
        /// </summary>
        /// <param name="db">Объект БД, в которую занести изменения</param>
        public FillColors(SeDataContext db)
        {
            db.DB_Color.InsertOnSubmit(new Model_Colors { Name = "Param_Color_FirstSymbol", Value = "#FFF8F8FF", NameForTranslate = "a" });
            db.DB_Color.InsertOnSubmit(new Model_Colors { Name = "Param_Color_Background", Value = "#FF000000", NameForTranslate = "a" });
            db.DB_Color.InsertOnSubmit(new Model_Colors { Name = "Param_Color_GradientFrom", Value = "#FF00FF00", NameForTranslate = "a" });
            db.DB_Color.InsertOnSubmit(new Model_Colors { Name = "Param_Color_GradientTo", Value = "#FF00AA99", NameForTranslate = "a" });
        }
    }
}

using SE_Matrix_2d_v_14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Matrix_2d_v_14.DB
{
    public class FillSettingsSymbol
    {
        /// <summary>
        /// Заполняет таблицу Model_Colors начальными данными
        /// </summary>
        /// <param name="db">Объект БД, в которую занести изменения</param>
        public FillSettingsSymbol(SeDataContext db)
        {
            db.DB_SettingsSymbol.InsertOnSubmit(new Model_SettingsSymbols { Param_Name = "Param_Iteration", Param_Value = 6, NameForTranslate = "a" });
            db.DB_SettingsSymbol.InsertOnSubmit(new Model_SettingsSymbols { Param_Name = "Param_CountSimultaneously", Param_Value = 3, NameForTranslate = "a" });
            db.DB_SettingsSymbol.InsertOnSubmit(new Model_SettingsSymbols { Param_Name = "Param_SpeedTo", Param_Value = 50, NameForTranslate = "a" });
            //db.DB_SettingsSymbol.InsertOnSubmit(new Model_SettingsSymbols { Param_Name = "Param_AddingSize", Param_Value = 2, NameForTranslate = "a" });
            db.DB_SettingsSymbol.InsertOnSubmit(new Model_SettingsSymbols { Param_Name = "Param_FontSize", Param_Value = 15, NameForTranslate = "a" });
            db.DB_SettingsSymbol.InsertOnSubmit(new Model_SettingsSymbols { Param_Name = "Param_MinLength", Param_Value = 5, NameForTranslate = "a" });
            db.DB_SettingsSymbol.InsertOnSubmit(new Model_SettingsSymbols { Param_Name = "Param_MaxLength", Param_Value = 15, NameForTranslate = "a" });
            db.DB_SettingsSymbol.InsertOnSubmit(new Model_SettingsSymbols { Param_Name = "Param_WindowWidth", Param_Value = 420, NameForTranslate = "a" });
            db.DB_SettingsSymbol.InsertOnSubmit(new Model_SettingsSymbols { Param_Name = "Param_WindowHeight", Param_Value = 671, NameForTranslate = "a" });
        }
    }
}

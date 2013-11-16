using SE_Matrix_2d_v_14.Models;
using SE_Matrix_2d_v_14.Resources;
using SE_Matrix_2d_v_14.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SE_Matrix_2d_v_14.Helpers
{
    public class SE_FillOC
    {
        /// <summary>
        /// Заполняем ObservableCollection
        /// </summary>
        /// <param name="model">Вытяжка из БД с нужной таблицы</param>
        /// <returns>ObservableCollection</returns>
        public ObservableCollection<Model_SettingsSymbols> FillSettingsSymbols(IQueryable<Model_SettingsSymbols> model)
        {
            ObservableCollection<Model_SettingsSymbols> _itemObservableCollection = new ObservableCollection<Model_SettingsSymbols>();
            foreach(var toFill in model)
            {
                _itemObservableCollection.Add(
                  new Model_SettingsSymbols {
                      ID = toFill.ID,
                      Param_Name = toFill.Param_Name,
                      Param_Value = toFill.Param_Value,
                      NameForTranslate = AppResources.ResourceManager.GetString(toFill.Param_Name, AppResources.Culture),
                  });
            }
            return _itemObservableCollection;
        }

        /// <summary>
        /// Заполняем ObservableCollection Model_Matrixes
        /// </summary>
        /// <param name="rowsNumber">Количество строк в матрице</param>
        /// <param name="columnsNumber">Количество столбцов в матрице</param>
        /// <returns>ObservableCollection</returns>
        public ObservableCollection<Model_Matrixes> FillMatrixes(int rowsNumber, int columnsNumber)
        {
            ObservableCollection<Model_Matrixes> _itemObservableCollection = new ObservableCollection<Model_Matrixes>();
           
            for (int rows = 0; rows < rowsNumber; rows++)
            {
                for (int columns = 0; columns < columnsNumber; columns++)
                {
                    _itemObservableCollection.Add(new Model_Matrixes()
                    {
                        Matrix_Name = columns + "_" + rows,
                        Matrix_Text = "",
                        Matrix_FontSize = 15,
                        Matrix_Foreground = new SolidColorBrush(Colors.Cyan)
                    });
                }
            }
            return _itemObservableCollection;
        }

        /// <summary>
        /// Заполняем ObservableCollection
        /// </summary>
        /// <param name="model">Вытяжка из БД с нужной таблицы</param>
        /// <returns>ObservableCollection</returns>
        public ObservableCollection<Model_Colors> FillColors(IQueryable<Model_Colors> model)
        {
            ObservableCollection<Model_Colors> _itemObservableCollection = new ObservableCollection<Model_Colors>();

            foreach (var toFill in model)
            {
                _itemObservableCollection.Add(
                  new Model_Colors
                  {
                      ID = toFill.ID,
                      Name = toFill.Name,
                      Value = toFill.Value,
                      NameForTranslate = AppResources.ResourceManager.GetString(toFill.Name, AppResources.Culture),
                  });
            }
            return _itemObservableCollection;
        }

        /// <summary>
        /// Заполняем ObservableCollection
        /// </summary>
        /// <param name="model">Вытяжка из БД с нужной таблицы</param>
        /// <returns>ObservableCollection</returns>
        public ObservableCollection<Module_Languages> FillLanguages(IQueryable<Module_Languages> model)
        {
            ObservableCollection<Module_Languages> _itemObservableCollection = new ObservableCollection<Module_Languages>();

            foreach (var toFill in model)
            {
                _itemObservableCollection.Add(
                  new Module_Languages
                  {
                      ID = toFill.ID,
                      Name = toFill.Name,
                      ValueFrom = toFill.ValueFrom,
                      ValueTo = toFill.ValueTo,
                      NameForTranslate = AppResources.ResourceManager.GetString(toFill.Name, AppResources.Culture),
                      Selected = toFill.Selected
                  });
            }
            return _itemObservableCollection;
        }
    }
}

using SE_Matrix_2d_v_14.DB;
using SE_Matrix_2d_v_14.Helpers;
using SE_Matrix_2d_v_14.Models;
using SE_Matrix_2d_v_14.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace SE_Matrix_2d_v_14.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private SeDataContext db;

        public MainViewModel(string SeDBConnectionString)
        {
            db = new SeDataContext(SeDBConnectionString);

            ItemSourceSettingsSymbols = new ObservableCollection<Model_SettingsSymbols>();
            ItemSourceMatrix = new ObservableCollection<Model_Matrixes>();
            ItemSourceSettingsColors = new ObservableCollection<Model_Colors>();
            ItemSourceLanguage = new ObservableCollection<Module_Languages>();
        }
        
        #region ItemSourceSettingsSymbols
        /// <summary>
        /// ViewModel. Коллекция объектов ItemSourceSettingsSymbols.
        /// </summary>
        private ObservableCollection<Model_SettingsSymbols> _itemSourceSettingsSymbols;
        public ObservableCollection<Model_SettingsSymbols> ItemSourceSettingsSymbols
        {
            get { return _itemSourceSettingsSymbols; }
            set
            {
                _itemSourceSettingsSymbols = value;
                NotifyPropertyChanged("ItemSourceSettingsSymbols");
            }
        }
        #endregion

        #region ItemSourceSettingsColors
        /// <summary>
        /// ViewModel. Коллекция объектов ItemSourceSettingsColors.
        /// </summary>
        private ObservableCollection<Model_Colors> _itemSourceSettingsColors;
        public ObservableCollection<Model_Colors> ItemSourceSettingsColors
        {
            get { return _itemSourceSettingsColors; }
            set
            {
                _itemSourceSettingsColors = value;              
                NotifyPropertyChanged("ItemSourceSettingsColors");
            }
        }
        #endregion

        #region ItemSourceMatrix
        /// <summary>
        /// ViewModel. Коллекция объектов ItemSourceMatrix.
        /// </summary>
        private ObservableCollection<Model_Matrixes> _itemSourceMatrix;
        public ObservableCollection<Model_Matrixes> ItemSourceMatrix
        {
            get { return _itemSourceMatrix; }
            set
            {
                _itemSourceMatrix = value;
                NotifyPropertyChanged("ItemSourceMatrix");
            }
        }
        #endregion

        #region ItemSourceMatrixBackground
        /// <summary>
        /// ViewModel. Коллекция объектов ItemSourceMatrixBackground.
        /// </summary>
        public SolidColorBrush _itemSourceMatrixBackground;
        public SolidColorBrush ItemSourceMatrixBackground { 
            get{return _itemSourceMatrixBackground;}
            set {
                _itemSourceMatrixBackground = value;
                NotifyPropertyChanged("ItemSourceMatrixBackground");
            }
        }
        #endregion

        #region ItemSourceLanguage
        /// <summary>
        /// ViewModel. Коллекция объектов ItemSourceMatrixBackground.
        /// </summary>
        private ObservableCollection<Module_Languages> _itemSourceLanguage;
        public ObservableCollection<Module_Languages> ItemSourceLanguage
        {
            get { return _itemSourceLanguage; }
            set
            {
                _itemSourceLanguage = value;
                NotifyPropertyChanged("ItemSourceLanguage");
            }
        }
        #endregion

        #region ItemSourceLanguageSelected
        /// <summary>
        /// ViewModel. Коллекция объектов ItemSourceMatrixBackground.
        /// </summary>
        private Module_Languages _itemSourceLanguageSelected;
        public Module_Languages ItemSourceLanguageSelected
        {
            get { return _itemSourceLanguageSelected; }
            set
            {
                _itemSourceLanguageSelected = value;
                NotifyPropertyChanged("ItemSourceLanguageSelected");
            }
        }
        #endregion

        /// <summary>
        /// ViewModel. Сохранение в БД
        /// </summary>
        public void SaveChangesToDB()
        {
            db.SubmitChanges();
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }
      
        int coef = 20;
        /// <summary>
        /// ViewModel. Создает и добавляет несколько объектов ViewModel в коллекцию элементов.
        /// </summary>
        public void LoadData()
        {
            // Получаем данные из БД по таблице Model_SettingsSymbols
            IQueryable<Model_SettingsSymbols> InDB_SettingsSymbol = (from Model_SettingsSymbols todo in db.DB_SettingsSymbol
                                                                    select todo);
                     
            Param_WindowWidth = InDB_SettingsSymbol.Where(x => x.Param_Name == "Param_WindowWidth").FirstOrDefault().Param_Value;
            Param_WindowHeight = InDB_SettingsSymbol.Where(x => x.Param_Name == "Param_WindowHeight").FirstOrDefault().Param_Value;
            rowsNumber = (int)Math.Round(Param_WindowHeight / (decimal)coef, MidpointRounding.AwayFromZero);
            columnsNumber = (int)Math.Round(Param_WindowWidth / (decimal)coef, MidpointRounding.AwayFromZero) - 1;

            // Заполняем ItemSourceSettingsSymbols, которая связанна со страницей настроеек, которые необходимо вводить как числа
            _itemSourceSettingsSymbols = new SE_FillOC().FillSettingsSymbols(InDB_SettingsSymbol.Where(x => x.Param_Name != "Param_WindowWidth" && x.Param_Name != "Param_WindowHeight"));

            // Создаем сетку, где будет выводиться матрица
            _itemSourceMatrix = new SE_FillOC().FillMatrixes(rowsNumber, columnsNumber);

            // Получаем данные из БД по таблице Model_Colors
            IQueryable<Model_Colors> InDB_Colors = (from Model_Colors todo in db.DB_Color
                                                    select todo);

            // Заполняем ItemSourceSettingsColors, которая связана с настройками цветов
            _itemSourceSettingsColors = new SE_FillOC().FillColors(InDB_Colors);

            // Получаем данные из БД по таблице Module_Languages
            IQueryable<Module_Languages> InDB_Languages = (from Module_Languages todo in db.DB_Language
                                                           select todo);

            // Заполняем ItemSourceLanguage, которая связана с настройками языка символов матрицы
            _itemSourceLanguage = new SE_FillOC().FillLanguages(InDB_Languages);

            // Инициализируем цветфона матрицы
            ItemSourceMatrixBackground = SE_Colors.StringToBrush(ItemSourceSettingsColors.Where(x => x.Name == "Param_Color_Background").SingleOrDefault().Value);

            // Устанавливаем язык символов и символы матрицы из БД
            ItemSourceLanguageSelected = ItemSourceLanguage.Where(z => z.Selected == true).SingleOrDefault();
            LanguageFrom = ItemSourceLanguage.Where(z => z.Selected == true).SingleOrDefault().ValueFrom;
            LanguageTo   = ItemSourceLanguage.Where(z => z.Selected == true).SingleOrDefault().ValueTo;
            this.IsDataLoaded = true;
        }

        #region UpdateSettingsSymbolsByID
        /// <summary>
        /// ViewModel. Обновляем настройки таблицы Model_SettingsSymbols в БД по ID
        /// </summary>
        public void UpdateSettingsSymbolsByID(Model_SettingsSymbols SettingsSymbolsForDelete)
        {
            var query = (from Model_SettingsSymbols todo in db.DB_SettingsSymbol
                         where todo.ID == SettingsSymbolsForDelete.ID
                         select todo).First();

            query.Param_Value = SettingsSymbolsForDelete.Param_Value;

            db.SubmitChanges();

            ItemSourceSettingsSymbols.Where(v => v.ID == SettingsSymbolsForDelete.ID).SingleOrDefault().Param_Value = SettingsSymbolsForDelete.Param_Value;
        }
        #endregion

        #region UpdateSettingsSymbolsByName
        /// <summary>
        /// ViewModel. Обновляем настройки таблицы Model_SettingsSymbols в БД по имени
        /// </summary>
        public void UpdateSettingsSymbolsByName(Model_SettingsSymbols SettingsSymbolsForDelete)
        {
            var query = (from Model_SettingsSymbols todo in db.DB_SettingsSymbol
                         where todo.Param_Name == SettingsSymbolsForDelete.Param_Name
                         select todo).SingleOrDefault();

            query.Param_Value = SettingsSymbolsForDelete.Param_Value;

            db.SubmitChanges();
        }
        #endregion

        #region UpdateSettingsColorByID
        /// <summary>
        /// ViewModel. Обновляем настройки таблицы Model_Colors в БД по ID
        /// </summary>
        public void UpdateSettingsColorByID(Model_Colors SettingsSymbolsForDelete)
        {
            var query = (from Model_Colors todo in db.DB_Color
                         where todo.ID == SettingsSymbolsForDelete.ID
                         select todo).First();

            query.Value = SettingsSymbolsForDelete.Value;

            db.SubmitChanges();

            ItemSourceSettingsColors.Where(v => v.ID == SettingsSymbolsForDelete.ID).SingleOrDefault().Value = SettingsSymbolsForDelete.Value;

            // При изменении фона матрицы обновляем свойство класса, с которым свзано свойство Background во View
            ItemSourceMatrixBackground = SE_Colors.StringToBrush(ItemSourceSettingsColors.Where(x => x.Name == "Param_Color_Background").SingleOrDefault().Value);
        }
        #endregion

        #region UpdateSelectedLanguageByID
        /// <summary>
        /// ViewModel. Обновляем настройки таблицы Module_Languages в БД по ID
        /// </summary>
        public void UpdateSettingsColorByID(Module_Languages forUpdate)
        {
            var query = (from Module_Languages todo in db.DB_Language
                         where todo.Selected == true
                         select todo).SingleOrDefault();

            query.Selected = false;

            db.SubmitChanges();

            var query1 = (from Module_Languages todo in db.DB_Language
                          where todo.ID == forUpdate.ID
                         select todo).SingleOrDefault();

            query1.Selected = true;

            db.SubmitChanges();

            // Обновляем язык символов и символы матрицы из БД
            ItemSourceLanguage.Where(c => c.Selected == true).SingleOrDefault().Selected = false;
            ItemSourceLanguage.Where(c => c.ID == forUpdate.ID).SingleOrDefault().Selected = true;
            ItemSourceLanguageSelected = ItemSourceLanguage.Where(z => z.Selected == true).SingleOrDefault();
            LanguageFrom               = ItemSourceLanguage.Where(z => z.Selected == true).SingleOrDefault().ValueFrom;
            LanguageTo                 = ItemSourceLanguage.Where(z => z.Selected == true).SingleOrDefault().ValueTo;
        }
        #endregion

        #region Class params
        public SolidColorBrush TheColorOfFirstSymbol { get; set; }
        public SolidColorBrush TheColorOfBackground { get; set; }
        public SolidColorBrush TheColorOfGradientFromBrush { get; set; }
        public SolidColorBrush TheColorOfGradientToBrush { get; set; }
        public Dictionary<string, int> TheColorOfGradientFromDictionary { get; set; }
        public Dictionary<string, int> TheColorOfGradientToDictionary { get; set; }
        int Param_Iteration { get; set; }
        int Param_MinLength { get; set; }
        int Param_MaxLength { get; set; }
        int Param_SpeedTo { get; set; }
        int rowsNumber { get; set; }
        int columnsNumber { get; set; }
        int Param_WindowWidth { get; set; }
        int Param_WindowHeight { get; set; }
        int Param_FontSize { get; set; }
        int LanguageFrom { get; set; }
        int LanguageTo { get; set; }
        Random random = new Random();
        SE_Colors SE_Colors = new SE_Colors();
        #endregion

        /// <summary>
        /// Нужно для возможности запускать одинм нажатием больше одной змейки одновременно
        /// </summary>
        public void Start()
        {          
            for (int i = 0; i < ItemSourceSettingsSymbols.Where(v => v.Param_Name == "Param_CountSimultaneously").SingleOrDefault().Param_Value; i++ )
            {
                 MoveMatrix();
            }          
        }

        /// <summary>
        /// ViewModel. Matrix. Функция входа в Матрицу. Задаются основные праматры
        /// и количество повторений змейки
        /// </summary>
        public async Task MoveMatrix()
        {
            Param_Iteration = ItemSourceSettingsSymbols.Where(v => v.Param_Name == "Param_Iteration").SingleOrDefault().Param_Value;
            Param_MinLength = ItemSourceSettingsSymbols.Where(v => v.Param_Name == "Param_MinLength").SingleOrDefault().Param_Value;
            Param_MaxLength = ItemSourceSettingsSymbols.Where(v => v.Param_Name == "Param_MaxLength").SingleOrDefault().Param_Value;
            Param_SpeedTo   = ItemSourceSettingsSymbols.Where(v => v.Param_Name == "Param_SpeedTo").SingleOrDefault().Param_Value;
            Param_FontSize  = ItemSourceSettingsSymbols.Where(v => v.Param_Name == "Param_FontSize").SingleOrDefault().Param_Value;

            TheColorOfFirstSymbol            =  SE_Colors.StringToBrush(ItemSourceSettingsColors.Where(z => z.Name == "Param_Color_FirstSymbol").SingleOrDefault().Value);
            TheColorOfBackground             =  SE_Colors.StringToBrush(ItemSourceSettingsColors.Where(x1 => x1.Name == "Param_Color_Background").SingleOrDefault().Value);
            TheColorOfGradientFromBrush      =  SE_Colors.StringToBrush(ItemSourceSettingsColors.Where(x2 => x2.Name == "Param_Color_GradientFrom").SingleOrDefault().Value);
            TheColorOfGradientToBrush        =  SE_Colors.StringToBrush(ItemSourceSettingsColors.Where(x3 => x3.Name == "Param_Color_GradientTo").SingleOrDefault().Value);
            TheColorOfGradientFromDictionary =  SE_Colors.StringToDictionary(ItemSourceSettingsColors.Where(x4 => x4.Name == "Param_Color_GradientFrom").SingleOrDefault().Value);
            TheColorOfGradientToDictionary   =  SE_Colors.StringToDictionary(ItemSourceSettingsColors.Where(x5 => x5.Name == "Param_Color_GradientTo").SingleOrDefault().Value);

            for (int i = 0; i < Param_Iteration; i++)
            {
                // Начало змейки по горизонтали случайным образом
                int ranX = random.Next(0, columnsNumber);

                // Начало змейки по вертикали случайным образом
                int ranY = random.Next( -Param_MaxLength , rowsNumber);

                // Длина змейки случайным образом
                int length = random.Next(Param_MinLength, Param_MaxLength);

                // Скорость смены символов в змейке случайным образом
                int time = random.Next(5, Param_SpeedTo);
              
                //Обработка змейки
                await MoveMatrixElements(ranX, ranY, length, time);
            }
        }

        /// <summary>
        /// ViewModel. Matrix. Определяет какие и сколько элементов показывать и с какой скоростью
        /// </summary>
        /// <param name="x">Начало змейки по оси х</param>
        /// <param name="y">Начало змейки по оси у</param>
        /// <param name="length">Длина звейки</param>
        /// <param name="time">Время между добавлением нового символа к змейке</param>
        public async Task MoveMatrixElements(int x, int y, int length, int time)
        {
            // Словарь для хранения идентификаторов ячеек, которые вызывались на предыдущем этапе.
            Dictionary<int, Model_Matrixes> dicElem = new Dictionary<int, Model_Matrixes>();

            int count = 0;
            int fail = 0;

            for (int i = 0; i < length; i++)
            {
                if ((y + i) < rowsNumber && (y + i) >= 0)
                {
                    string elementNameToMove = x + "_" + (y + i);
                    Model_Matrixes elementToMove = ItemSourceMatrix.Where(xx => xx.Matrix_Name == elementNameToMove).SingleOrDefault();
                    dicElem[count] = (elementToMove);

                    await MatrixElementsChange(elementToMove, time, TheColorOfFirstSymbol);

                    // Перебираем все  элементы, составляющие змейку на данном этапе. С каждым циклом она увеличивается, пока не достигнет нужной длины.
                    for (int k = 0; k <= count; k++)
                    {
                        //Извлекаем элементы, которые должны следовать за самым ярким. Создаем эффект "затухания" цвета
                        Model_Matrixes previousElement = dicElem[k];

                        Dictionary<string, int> coefficientFromGradient = new SE_Colors().GetСoefficientFromGradient(TheColorOfGradientFromDictionary, TheColorOfGradientToDictionary, count);
                        SolidColorBrush colorSymbol = SE_Colors.GetSymbolColorForGradient(TheColorOfGradientFromDictionary, coefficientFromGradient, (i - fail - k));

                        Task dsvv = MatrixElementsChange(previousElement, time, colorSymbol);
                    }
                    count++;
                }
                else
                {
                    // Что б сверху матрица красиво падала.
                    fail++;
                }
            }
        }

        /// <summary>
        /// ViewModel. Matrix. Задает цвет, количество смены символов, затухание
        /// элементов матрицы
        /// /// </summary>
        /// <param name="element">Объект типа Model_Matrixes</param>
        /// <param name="timeOut">Время, сфомированное случайным образом на основе данных,
        /// введенных в настройках</param>
        /// <param name="NewColor">Цвет символа</param>
        public async Task MatrixElementsChange(Model_Matrixes element, int timeOut, SolidColorBrush NewColor)
        {
            element.Matrix_Text = RandomActualSymbol();
            element.Matrix_Foreground = NewColor;
            element.Matrix_FontSize = Param_FontSize;
            await Task.Delay(timeOut);
        }

        /// <summary>
        /// Случайным образом в зависимости от выбранного языка определяет символ
        /// </summary>
        /// <returns>Возвращаем символ, который вывести</returns>
        public string RandomActualSymbol()
        {
            // Выбираем случайнфй символ в диапазоне от первого до последнего символа в заданом языке
            return char.ConvertFromUtf32(this.random.Next((int)LanguageFrom, (int)LanguageTo));
        }
    }
}

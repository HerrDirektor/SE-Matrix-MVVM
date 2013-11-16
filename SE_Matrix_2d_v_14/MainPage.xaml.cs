using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SE_Matrix_2d_v_14.Models;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Media;

namespace SE_Matrix_2d_v_14
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Конструктор
        public MainPage()
        {
            InitializeComponent();

            // Задайте для контекста данных элемента управления listbox пример данных
            this.DataContext = App.ViewModel;
        }

        // Загрузка данных для элементов ViewModel
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
            App.ViewModel.SaveChangesToDB();
        }


        private bool _updateSettings = false;
        public bool UpdateSettings
        {
            get { return _updateSettings; }
            set { _updateSettings = value; }
        }

        /// <summary>
        /// Если текст в поле изменился и его длина больше 0, то меняем флаг на true, что
        /// при срабатывании события потери фокуса позволит изменить данные в модели и БД
        /// </summary>
        private void Event_TextBox_TextChanged_SettingSymbols(object sender, TextChangedEventArgs e)
        {
            TextBox paramToUpdate = sender as TextBox;

            if (paramToUpdate.Text.Length > 0)
            {
                UpdateSettings = true;
            }
        }

        /// <summary>
        /// Если UpdateSettings == true, то меняем данные в модели и БД на те, что ввели
        /// </summary>
        private void Event_TextBox_LostFocus_SettingsSymbols(object sender, RoutedEventArgs e)
        {
            TextBox paramToUpdate = sender as TextBox;

            if (UpdateSettings == true)
            {
                UpdateSettings = false;
                Model_SettingsSymbols updateInTable = new Model_SettingsSymbols
                {
                    ID = Convert.ToInt32(paramToUpdate.Tag),
                    Param_Value = Convert.ToInt32(paramToUpdate.Text)
                };
                App.ViewModel.UpdateSettingsSymbolsByID(updateInTable);               
            }
        }

        /// <summary>
        /// При завершении загрузки обновляем размеры поля, где выводится матрица
        /// </summary>
        private void Event_LongListSelector_OnLoaded_Matrix(object sender, RoutedEventArgs e)
        {
            LongListSelector paramToUpdate = sender as LongListSelector;

            Model_SettingsSymbols updateHeightInTable = new Model_SettingsSymbols
            {
                Param_Name = "Param_WindowHeight",
                Param_Value = Convert.ToInt32(paramToUpdate.ActualHeight)
            };
            App.ViewModel.UpdateSettingsSymbolsByName(updateHeightInTable);

            Model_SettingsSymbols updateWigthInTable = new Model_SettingsSymbols
            {
                Param_Name = "Param_WindowWidth",
                Param_Value = Convert.ToInt32(paramToUpdate.ActualWidth)
            };
            App.ViewModel.UpdateSettingsSymbolsByName(updateWigthInTable);
        }

        /// <summary>
        /// При нажатии на область, где выводится матрица - добавляем заданное ранее в настройках новое количество змеек.
        /// </summary>
        private async void Event_LongListSelector_Tap_StartMatrix(object sender, System.Windows.Input.GestureEventArgs e)
        {
             App.ViewModel.Start();
        }

        /// <summary>
        /// После выбора цвета и нажатия на соответствующий прямоугольник - сохраняем новый цвет в БД и обновляем модель
        /// </summary>
        private void Event_Rectangle_Tap_ChangeColor(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Rectangle paramToUpdate = sender as Rectangle;

            Model_Colors updateInTable = new Model_Colors
            {
                ID = Convert.ToInt32(paramToUpdate.Tag),
                Value = ColorPicker.Color.ToString()
            };
            App.ViewModel.UpdateSettingsColorByID(updateInTable);
        }

        /// <summary>
        /// После выбора языка меняем данные в модели и БД
        /// </summary>
        private void Event_ListPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Module_Languages selectedItem = ((sender as ListPicker).SelectedItem as Module_Languages);

            Module_Languages updateInTable = new Module_Languages
            {
                ID = selectedItem.ID
            };
            App.ViewModel.UpdateSettingsColorByID(updateInTable);
        }
    }
}
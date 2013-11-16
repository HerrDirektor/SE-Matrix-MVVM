using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SE_Matrix_2d_v_14.Models
{
    [Table]
    public class Model_Matrixes : ModelBase
    {
        // Define ID: private field, public property, and database column.
        private int _id;
        /// <summary>
        /// Таблица Model_Matrixes ID
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    NotifyPropertyChanging("ID");
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        private string _matrix_Name;
        /// <summary>
        /// Таблица Model_Matrixes Matrix_Name
        /// </summary>
        [Column]
        public string Matrix_Name
        {
            get { return _matrix_Name; }
            set
            {
                if (_matrix_Name != value)
                {
                    NotifyPropertyChanging("Matrix_Name");
                    _matrix_Name = value;
                    NotifyPropertyChanged("Matrix_Name");
                }
            }
        }

        private string _matrix_Text;
        /// <summary>
        /// Таблица Model_Matrixes Matrix_Text
        /// </summary>
        [Column]
        public string Matrix_Text
        {
            get { return _matrix_Text; }
            set
            {
                if (_matrix_Text != value)
                {
                    NotifyPropertyChanging("Matrix_Text");
                    _matrix_Text = value;
                    NotifyPropertyChanged("Matrix_Text");
                }
            }
        }

        private int _matrix_FontSize;
        /// <summary>
        /// Таблица Model_Matrixes Matrix_FontSize
        /// </summary>
        [Column]
        public int Matrix_FontSize
        {
            get { return _matrix_FontSize; }
            set
            {
                if (_matrix_FontSize != value)
                {
                    NotifyPropertyChanging("Matrix_FontSize");
                    _matrix_FontSize = value;
                    NotifyPropertyChanged("Matrix_FontSize");
                }
            }
        }

        private SolidColorBrush _matrix_Foreground;
        /// <summary>
        /// Таблица Model_Matrixes Matrix_Foreground
        /// </summary>
        [Column]
        public SolidColorBrush Matrix_Foreground
        {
            get { return _matrix_Foreground; }
            set
            {
                if (_matrix_Foreground != value)
                {
                    NotifyPropertyChanging("Matrix_Foreground");
                    _matrix_Foreground = value;
                    NotifyPropertyChanged("Matrix_Foreground");
                }
            }
        }
    }
}

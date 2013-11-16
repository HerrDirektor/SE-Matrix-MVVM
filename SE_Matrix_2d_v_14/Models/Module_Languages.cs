using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Matrix_2d_v_14.Models
{
    [Table]
    public class Module_Languages : ModelBase
    {
        // Define ID: private field, public property, and database column.
        private int _id;
        /// <summary>
        /// Таблица Model_SettingsSymbols ID
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

        // Имя параметра
        private string _name;
        /// <summary>
        /// Таблица Model_SettingsSymbols ID
        /// </summary>
        [Column]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    NotifyPropertyChanging("Name");
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        // Имя параметра
        private string _nameForTranslate;
        /// <summary>
        /// Таблица Model_SettingsSymbols ID
        /// </summary>
        [Column]
        public string NameForTranslate
        {
            get { return _nameForTranslate; }
            set
            {
                if (_nameForTranslate != value)
                {
                    NotifyPropertyChanging("NameForTranslate");
                    _nameForTranslate = value;
                    NotifyPropertyChanged("NameForTranslate");
                }
            }
        }

        // Значение параметра
        private int _valueFrom;
        /// <summary>
        /// Таблица Model_SettingsSymbols ValueFrom
        /// </summary>
        [Column]
        public int ValueFrom
        {
            get { return _valueFrom; }
            set
            {
                if (_valueFrom != value)
                {
                    NotifyPropertyChanging("ValueFrom");
                    _valueFrom = value;
                    NotifyPropertyChanged("ValueFrom");
                }
            }
        }

        // Значение параметра
        private int _valueTo;
        /// <summary>
        /// Таблица Model_SettingsSymbols ValueTo
        /// </summary>
        [Column]
        public int ValueTo
        {
            get { return _valueTo; }
            set
            {
                if (_valueTo != value)
                {
                    NotifyPropertyChanging("ValueTo");
                    _valueTo = value;
                    NotifyPropertyChanged("ValueTo");
                }
            }
        }

        private bool _selected;
        /// <summary>
        /// Таблица Model_SettingsSymbols Selected
        /// </summary>
        [Column]
        public bool Selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    NotifyPropertyChanging("Selected");
                    _selected = value;
                    NotifyPropertyChanged("Selected");
                }
            }
        }
    }
}

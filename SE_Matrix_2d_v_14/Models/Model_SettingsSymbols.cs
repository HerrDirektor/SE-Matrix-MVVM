using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Matrix_2d_v_14.Models
{
    [Table()]
    public class Model_SettingsSymbols : ModelBase
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

        private string _param_Name;
        /// <summary>
        /// Таблица Model_SettingsSymbols Param_Name
        /// </summary>
        [Column]
        public string Param_Name
        {
            get { return _param_Name; }
            set
            {
                if (_param_Name != value)
                {
                    NotifyPropertyChanging("Param_Name");
                    _param_Name = value;
                    NotifyPropertyChanged("Param_Name");
                }
            }
        }

        private int _param_Value;
        /// <summary>
        /// Таблица Model_SettingsSymbols Param_Value
        /// </summary>
        [Column]
        public int Param_Value
        {
            get { return _param_Value; }
            set
            {
                if (_param_Value != value)
                {
                    NotifyPropertyChanging("Param_Value");
                    _param_Value = value;
                    NotifyPropertyChanged("Param_Value");
                }
            }
        }

        private string _nameForTranslate;
        /// <summary>
        /// Таблица Model_SettingsSymbols NameForTranslate
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

        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;
    }
}

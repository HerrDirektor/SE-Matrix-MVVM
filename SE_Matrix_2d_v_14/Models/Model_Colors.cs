using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SE_Matrix_2d_v_14.Models
{
    [Table]
    [DataContract]
    public class Model_Colors : ModelBase
    {
        // Define ID: private field, public property, and database column.
        private int _id;
        /// <summary>
        /// Таблица Model_Colors ID
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

        private string _name;
        /// <summary>
        /// Таблица Model_Colors Name
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

        private string _nameForTranslate;
        /// <summary>
        /// Таблица Model_Colors NameForTranslate
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

        private string _value;
        /// <summary>
        /// Таблица Model_Colors Value
        /// </summary>
        [Column]
        public string Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    NotifyPropertyChanging("Value");
                    _value = value;
                    NotifyPropertyChanged("Value");
                }
            }
        }
    }

}

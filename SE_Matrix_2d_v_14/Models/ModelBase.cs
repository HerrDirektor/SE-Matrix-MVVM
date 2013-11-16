using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Matrix_2d_v_14.Models
{
    public class ModelBase : INotifyPropertyChanged, INotifyPropertyChanging
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        protected void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }
}

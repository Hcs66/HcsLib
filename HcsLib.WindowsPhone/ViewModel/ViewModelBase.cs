//--------------------------------------------------------------------------------
// 文件描述：ViewModel基类
// 文件作者：
// 创建日期：2009-08-29
// 修改记录： 
//--------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;

namespace HcsLib.WindowsPhone.ViewModel
{
    /// <summary>
    /// Base class for all ViewModel classes in the application.
    /// It provides support for property change notifications 
    /// and has a DisplayName property.  This class is abstract.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        private Boolean isBusy = false;
        private Boolean failed = false;
        private String errorMessage = String.Empty;

        #region Constructor

        protected ViewModelBase()
        {
        }

        #endregion // Constructor

        public bool Failed
        {
            get { return failed; }
            set
            {
                failed = value;
                OnPropertyChanged("Failed");
            }
        }

        public String ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        public bool IsDataLoaded
        {
            get;
            protected set;
        }

        public bool IsBusy
        {
            get;
            protected set;
        }

        public abstract void LoadData();

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            //this.VerifyPropertyName(propertyName);

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                try
                {
                    handler(this, e);
                }
                catch 
                {
                }
              
            }
        }

        #endregion // INotifyPropertyChanged Members

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public void Dispose()
        {
            this.OnDispose();
        }

        /// <summary>
        /// Child classes can override this method to perform 
        /// clean-up logic, such as removing event handlers.
        /// </summary>
        protected virtual void OnDispose()
        {
        }

        #endregion // IDisposable Members
    }

    public class SearchCompletedEventArgs : EventArgs
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }
    }
}
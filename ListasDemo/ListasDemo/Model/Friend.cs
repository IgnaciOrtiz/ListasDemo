using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ListasDemo.Annotations;
using SQLite;

namespace ListasDemo.Model
{
    public class Friend : INotifyPropertyChanged
    {
        private string _firstName;
        private string _phone;
        private string _email;

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value; 
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

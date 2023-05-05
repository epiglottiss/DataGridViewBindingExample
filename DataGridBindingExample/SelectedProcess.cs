using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridBindingExample
{
    public class SelectedProcess : INotifyPropertyChanged
    {
        private int _id;
        public int Id { get { return _id; }
            set
            {
                _id = value;
                this.NotifyPropertyChanged("Id");
            }
        }
        public string Name { get; set; }
        public string InstanceName { get; set; }

        private int _value;
        public int Value { get { return _value; }
            set {
                _value = value;
                
            } }

        public SelectedProcess(int id, string name, string instanceName)
        {
            this._id = id;
            this.Name = name;
            this.InstanceName = instanceName;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}

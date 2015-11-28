using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StudyConfigurationUI.Annotations;

namespace StudyConfigurationUI.ViewModel
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        private double _version = 0.1;
        public string VersionText => "Autosys Studyconfiguation version "+ _version;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

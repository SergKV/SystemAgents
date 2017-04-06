using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Shared.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AgentsUi.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ITab> tabs;
        public RelayCommand NewTabCommand { get; }
        public ICollection<ITab> Tabs { get; }

        public MainViewModel()
        {
            NewTabCommand = new RelayCommand(() => NewTab());

        }

        private void NewTab()
        {
            Tabs.Add(new DateTab());
        }
    }
}
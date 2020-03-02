using System.ComponentModel;

namespace MagicCucaBakeryApp.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public SideBarViewModel SideBarViewModel { get; private set; }

        public MainWindowViewModel()
        {
            SideBarViewModel = new SideBarViewModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
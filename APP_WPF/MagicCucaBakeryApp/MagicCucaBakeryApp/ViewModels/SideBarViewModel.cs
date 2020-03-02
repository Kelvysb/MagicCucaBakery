using MagicCucaBakeryApp.Helpers;
using System.ComponentModel;

namespace MagicCucaBakeryApp.ViewModels
{
    internal class SideBarViewModel : INotifyPropertyChanged
    {
        public bool MenuCollapsed { get; private set; }

        public delegate void MenuClickEventHandler(object sender, MenuClickEventArgs e);

        public CustomCommand CollapseMenuCommand { get; private set; }

        public SideBarViewModel()
        {
            MenuCollapsed = false;
            CollapseMenuCommand = new CustomCommand(OnCollapseMenuCommand, () => true);
        }

        public void OnCollapseMenuCommand()
        {
            MenuCollapsed = !MenuCollapsed;
            PropertyChanged(this, new PropertyChangedEventArgs("MenuCollapsed"));
        }

        private void MenuClickEventHandler()
        {
        }

        public event MenuClickEventHandler PropertyChanged = delegate { };

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
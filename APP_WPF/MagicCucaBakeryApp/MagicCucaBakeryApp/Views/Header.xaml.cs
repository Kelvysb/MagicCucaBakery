using System.Windows;
using System.Windows.Controls;

namespace MagicCucaBakeryApp.Views
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
        }

        private static DependencyProperty menuTarget = DependencyProperty.Register("Folders", typeof(Grid), typeof(Header));

        public DependencyProperty MenuTarget { get => menuTarget; set => menuTarget = value; }
    }
}

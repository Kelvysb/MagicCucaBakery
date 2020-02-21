using System.Windows;
using System.Windows.Controls;

namespace MagicCucaBakeryApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static DependencyProperty targetGrid = DependencyProperty.Register("targetGrid", typeof(Grid), typeof(MainWindow));

        public MainWindow()
        {
            InitializeComponent();
            SetValue(targetGrid, Body);
        }

        public DependencyProperty TargetGrid { get => targetGrid; }
    }
}

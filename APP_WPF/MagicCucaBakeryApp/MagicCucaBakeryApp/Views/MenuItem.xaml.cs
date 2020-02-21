using System.Windows;
using System.Windows.Controls;

namespace MagicCucaBakeryApp.Views
{
    /// <summary>
    /// Interaction logic for MenuItem.xaml
    /// </summary>
    public partial class MenuItem : UserControl
    {

        private static DependencyProperty targetContainer = DependencyProperty.Register("targetContainer", typeof(Grid), typeof(MenuItem));
        private static DependencyProperty target = DependencyProperty.Register("target", typeof(UserControl), typeof(MenuItem));

        public MenuItem()
        {
            InitializeComponent();
            Text = "Menu Item";
            this.DataContext = this;
        }

        public DependencyProperty TargetContainer { get => targetContainer; set => targetContainer = value; }

        public DependencyProperty Target { get => target; set => target = value; }

        public string Text { get; set; }



        private void UserControl_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}

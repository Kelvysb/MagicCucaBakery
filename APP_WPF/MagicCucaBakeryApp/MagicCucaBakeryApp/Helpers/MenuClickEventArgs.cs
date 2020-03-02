using System;
using System.Windows.Controls;

namespace MagicCucaBakeryApp.Helpers
{
    internal class MenuClickEventArgs : EventArgs
    {
        public UserControl TargetControl { get; set; }
    }
}
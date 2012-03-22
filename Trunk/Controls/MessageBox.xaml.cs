using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Controls {
    /// <summary>
    /// Interaktionslogik für MessageBox.xaml
    /// </summary>
    public partial class MerpMessageBox : Window {
        
        static MerpMessageBox _messageBox;

        public MerpMessageBox() {
            InitializeComponent();
        }

        public MerpMessageBoxResult Result { get; set; }

        public static MerpMessageBoxResult Show(string message) {
            return Show(string.Empty, message, string.Empty, MerpMessageBoxButtons.Ok, MerpMessageBoxImage.Default);
        }

        public static MerpMessageBoxResult Show(string title, string message) {
            return Show(title, message, string.Empty, MerpMessageBoxButtons.Ok, MerpMessageBoxImage.Default);
        }

        public static MerpMessageBoxResult Show(string title, string message, string details) {
            return Show(title, message, details, MerpMessageBoxButtons.Ok, MerpMessageBoxImage.Default);
        }

        public static MerpMessageBoxResult Show(string title, string message, string details, MerpMessageBoxButtons anzuzeigendeButtons) {
            return Show(title, message, details, anzuzeigendeButtons, MerpMessageBoxImage.Default);
        }


        public static MerpMessageBoxResult Show(string title, string message, string details, MerpMessageBoxImage image) {
            return Show(title, message, details, MerpMessageBoxButtons.Ok, image);
        }


        public static MerpMessageBoxResult Show(string title, string message, string details, MerpMessageBoxButtons optionen, MerpMessageBoxImage image) {
            _messageBox = new MerpMessageBox();
            MessageBoxViewModel _style = new MessageBoxViewModel(_messageBox, title, message, details, optionen, image);
            _messageBox.DataContext = _style;
            _messageBox.ShowDialog();
            return _messageBox.Result;
        }

       
    }
}

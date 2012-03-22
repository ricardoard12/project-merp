using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using Controls.Commands;


//Steuert die Logik der Messagebox 
namespace Controls {
    class MessageBoxViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _title;
        private string _message;
        private string _messageDetails;
        private ImageSource _imageSource;

        private Visibility _yesNoVisibility;
        private Visibility _cancelVisibility;
        private Visibility _oKVisibility;
        private Visibility _closeVisibility;
        private Visibility _showDetails;

        private MerpMessageBox _messageBox;

        private ActionCommand _yesCommand;
        private ActionCommand _noCommand;
        private ActionCommand _cancelCommand;
        private ActionCommand _closeCommand;
        private ActionCommand _oKCommand;



        public MessageBoxViewModel(MerpMessageBox box, string title, string message, string messagedetail, MerpMessageBoxButtons anzuzeigendeButtons, MerpMessageBoxImage anzuzeigendesImage) {
            Title = title;
            Message = message;
            MessageDetails = messagedetail;
            setAnzuzeigendeButtons(anzuzeigendeButtons);
            setAnzuzeigendesImage(anzuzeigendesImage);
            MessageBox = box;
            setCommands(anzuzeigendeButtons);
            YesCommand = new ActionCommand(OnYesExecuted, OnYesCanExecute);
            }

        private void setCommands(MerpMessageBoxButtons anzuzeigendeButtons) {
            switch (anzuzeigendeButtons) { 
                case MerpMessageBoxButtons.YesNo:
                    YesCommand = new ActionCommand(OnYesExecuted, OnYesCanExecute);
                    NoCommand = new ActionCommand(OnNoExecuted, OnNoCanExecute);
                    break;
                case MerpMessageBoxButtons.YesNoCancel:
                    YesCommand = new ActionCommand(OnYesExecuted, OnYesCanExecute);
                    NoCommand = new ActionCommand(OnNoExecuted, OnNoCanExecute);
                    CancelCommand = new ActionCommand(OnCancelExecuted, OnCancelCanExecute);
                    break;
                case MerpMessageBoxButtons.Close:
                    CloseCommand = new ActionCommand(OnCloseExecuted, OnCloseCanExecute);
                    break;
                case MerpMessageBoxButtons.OkCancel:
                    CancelCommand = new ActionCommand(OnCancelExecuted, OnCancelCanExecute);
                    OkCommand = new ActionCommand(OnOkExecuted, OnOkCanExecute);
                    break;
                case MerpMessageBoxButtons.OkClose:
                    OkCommand = new ActionCommand(OnOkExecuted, OnOkCanExecute);
                    CloseCommand = new ActionCommand(OnCloseExecuted, OnCloseCanExecute);
                    break;
                case MerpMessageBoxButtons.Ok:
                    OkCommand = new ActionCommand(OnOkExecuted, OnOkCanExecute);
                    break;
            }
        }

        

        private void setAnzuzeigendesImage(MerpMessageBoxImage anzuzeigendesImage) {
            string source = @"C:\Projekte\ODS\Controls\Images\Default.png";
            switch (anzuzeigendesImage) {
                case MerpMessageBoxImage.Alarm:
                    source = @"C:\Projekte\ODS\Controls\Images\Alert.png";
                    break;
                case MerpMessageBoxImage.Error:
                    source = @"C:\Projekte\ODS\Controls\Images\Error.png";
                    break;
                case MerpMessageBoxImage.Information:
                    source = @"C:\Projekte\ODS\Controls\Images\Info.png";
                    break;
                case MerpMessageBoxImage.Ok:
                    source = @"C:\Projekte\ODS\Controls\Images\OK.png";
                    break;
                case MerpMessageBoxImage.Frage:
                    source = @"C:\Projekte\ODS\Controls\Images\Help.png";
                    break;
            }
            Uri ImageUri = new Uri(source, UriKind.RelativeOrAbsolute);
            _imageSource = new BitmapImage(ImageUri);
        }

        private void setAnzuzeigendeButtons(MerpMessageBoxButtons anzuzeigendeButtons) {
            switch (anzuzeigendeButtons) { 
                case MerpMessageBoxButtons.YesNo:
                    OkVisibility = CancelVisibility = CloseVisibility = Visibility.Collapsed;
                    break;
                case MerpMessageBoxButtons.YesNoCancel:
                    OkVisibility = CloseVisibility = Visibility.Collapsed;
                    break;
                case MerpMessageBoxButtons.Close:
                    OkVisibility = CancelVisibility = YesNoVisibility = Visibility.Collapsed;
                    break;
                case MerpMessageBoxButtons.OkCancel:
                    YesNoVisibility = CloseVisibility = Visibility.Collapsed;
                    break;
                case MerpMessageBoxButtons.OkClose:
                    YesNoVisibility = CancelVisibility = Visibility.Collapsed;
                    break;
                case MerpMessageBoxButtons.Ok:
                    YesNoVisibility = CancelVisibility = CloseVisibility = Visibility.Collapsed;
                    break;
            }
            if (string.IsNullOrEmpty(this.MessageDetails))
                ShowDetails = Visibility.Collapsed;
            else
                ShowDetails = Visibility.Visible;
        }


        #region Public - Properties

        public string Title {
            get { return _title; }
            set {
                if (_title != value) {
                    _title = value;
                    NotifyPropertyChange("Title");
                }
            }
        }

        public string Message {
            get { return _message; }
            set {
                if (_message != value) {
                    _message = value;
                    NotifyPropertyChange("Message");
                }
            }
        }

        public string MessageDetails {
            get { return _messageDetails; }
            set {
                if (_messageDetails != value) {
                    _messageDetails = value;
                    NotifyPropertyChange("MessageDetails");
                }
            }
        }

        public ImageSource ImageSource {
            get { return _imageSource; }
            set {
                if (_imageSource != value) {

                    _imageSource = value;
                }
                NotifyPropertyChange("ImageSource");
            }
        }

        public Visibility YesNoVisibility {
            get { return _yesNoVisibility; }
            set {
                if (_yesNoVisibility != value) {
                    _yesNoVisibility = value;
                    NotifyPropertyChange("YesNoVisibility");
                }
            }
        }

        public Visibility CancelVisibility {
            get { return _cancelVisibility; }
            set {
                if (_cancelVisibility != value) {
                    _cancelVisibility = value;
                    NotifyPropertyChange("CancelVisibility");
                }
            }
        }

        public Visibility OkVisibility {
            get { return _oKVisibility; }
            set {
                if (_oKVisibility != value) {
                    _oKVisibility = value;
                    NotifyPropertyChange("OkVisibility");
                }
            }
        }

        public Visibility CloseVisibility {
            get { return _closeVisibility; }
            set {
                if (_closeVisibility != value) {
                    _closeVisibility = value;
                    NotifyPropertyChange("CloseVisibility");
                }
            }
        }

        public Visibility ShowDetails {
            get { return _showDetails; }
            set {
                if (_showDetails != value) {
                    _showDetails = value;
                    NotifyPropertyChange("ShowDetails");
                }
            }
        }

        public MerpMessageBox MessageBox {
            get { return _messageBox; }
            set {
                if (_messageBox != value) {

                    _messageBox = value;
                    NotifyPropertyChange("MessageBox");
                }
            }
        }


        public ActionCommand YesCommand {
            get { return _yesCommand; }
            set {
                if (_yesCommand != value) {
                    _yesCommand = value;
                }
                NotifyPropertyChange("YesCommand");
            }
        }


        public ActionCommand NoCommand {
            get { return _noCommand; }
            set {
                if (_noCommand != value) {
                    _noCommand = value;
                }
                NotifyPropertyChange("NoCommand");
            }
        }


        public ActionCommand CancelCommand {
            get { return _cancelCommand; }
            set {
                if (_cancelCommand != value) {
                    _cancelCommand = value;
                }
                NotifyPropertyChange("CancelCommand");
            }
        }



        public ActionCommand CloseCommand {
            get { return _closeCommand; }
            set {
                if (_closeCommand != value) {
                    _closeCommand = value;
                }
                NotifyPropertyChange("CloseCommand");
            }
        }


        public ActionCommand OkCommand {
            get { return _oKCommand; }
            set {
                if (_oKCommand != value) {
                    _oKCommand = value;
                }
                NotifyPropertyChange("OkCommand");
            }
        }


        #endregion 

        
        void OnNoExecuted(object parameter) {
            MessageBox.Result = MerpMessageBoxResult.No;
            MessageBox.Close();
        }

        bool OnNoCanExecute(object parameter) {
            return YesNoVisibility != Visibility.Collapsed;
        }

        void OnCancelExecuted(object parameter) {
            MessageBox.Result = MerpMessageBoxResult.Cancel;
            MessageBox.Close();
        }

        bool OnCancelCanExecute(object parameter) {
            return CancelVisibility != Visibility.Collapsed;
        }

        void OnCloseExecuted(object parameter) {
            MessageBox.Result = MerpMessageBoxResult.Close;
            MessageBox.Close();
        }

        bool OnCloseCanExecute(object parameter) {
            return CloseVisibility != Visibility.Collapsed;
        }

        void OnOkExecuted(object parameter) {
            MessageBox.Result = MerpMessageBoxResult.Ok;
            MessageBox.Close();
        }

        bool OnOkCanExecute(object parameter) {
            return OkVisibility != Visibility.Collapsed;
        }


        void OnYesExecuted(object parameter) {
            MessageBox.Result = MerpMessageBoxResult.Yes;
            MessageBox.Close();
        }

        bool OnYesCanExecute(object parameter) {
            return YesNoVisibility != Visibility.Collapsed;
        }


        private void NotifyPropertyChange(string Property) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp4.Commands;
using WpfApp4.View;

namespace WpfApp4.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {

        private String _userName;
        public String UserName
        {
            get => _userName;
            set => SetPropertyChanged(ref _userName, value);
        }

        private String _userPassword;
        public String UserPassword
        {
            get => _userPassword;
            set => SetPropertyChanged(ref _userPassword, value);
        }

        public ICommand Login 
        { 
            get;
            private set;
        }

        public MainViewModel()
        {
            Login = new RelayCommand(autorize);
        }

        public void autorize(object a)
        {
            using(var context = new PostavshikRuEntities())
            {
                var user = context.Users.FirstOrDefault(x => x.Login == UserName && x.Pass == UserPassword);
                if(user != null)
                {
                    Window1 window1 = new Window1();
                    window1.Show();
                    foreach (Window i in Application.Current.Windows)
                    {
                        if (i is MainWindow) i.Close();
                    }
                }
            }               
        }
    }
}

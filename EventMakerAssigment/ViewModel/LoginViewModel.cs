using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Popups;
using EventMakerAssigment.Annotations;
using EventMakerAssigment.Common;
using EventMakerAssigment.Model;
using EventMakerAssigment.View;

namespace EventMakerAssigment.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        #region InstanceFields

        private ObservableCollection<User> _users;
        private User _currentUser;
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _loginStatus;
        private readonly FrameNavigationClass _frameNavigation;

        #endregion

        #region Constructor(s)

        public LoginViewModel()
        {
            CurrentUser = new User();
            _frameNavigation = new FrameNavigationClass();
            Users = new ObservableCollection<User>()
            {
                new User("xxx","pat","Patrik"),
                new User("xxx","bir","Birendra"),
                new User("xxx","ane","AneMarie"),
                new User("xxx","vit","Vitus"),
            };
        }

        #endregion

        #region Properties

        public ObservableCollection<User> Users { get => _users; set => _users = value; }
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        #endregion

        #region Method(s)

        public async void LoginMethod()
        {
            _loginStatus = false;
            if (Users != null)
            {
                foreach (User user in Users)
                {
                    if (CurrentUser.Id == user.Id && CurrentUser.Password == user.Password )
                    {
                        _loginStatus = true;
                        _frameNavigation.ActivateFrameNavigation(typeof(EventPage));
                        break;
                    }
                    if (_loginStatus == false)
                    {
                        MessageDialog msd = new MessageDialog("Hello", "Insert the correct data");
                        await msd.ShowAsync();
                    }
                }
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EventMakerAssigment.Annotations;
using EventMakerAssigment.Common;
using EventMakerAssigment.Handler;
using EventMakerAssigment.Model;
using EventMakerAssigment.View;


namespace EventMakerAssigment.ViewModel
{
    public class EventViewModel :INotifyPropertyChanged
    {
        #region InstanceFields

        private readonly FrameNavigationClass _frameNavigation;
        private ObservableCollection<Event> _events;
        private Event _selectedEvent;
        public event PropertyChangedEventHandler PropertyChanged;
        private EventHandlerClass EventHandler;
        private DateTimeOffset _date;
        private TimeSpan _time;
        private int _id;
        private string _name;
        private string _description;
        private string _place;

        #endregion

        #region Constructor(s)
        public EventViewModel()
        {
            EventCatalogSingleton = EventCatalogSingleton.GetInstance();
            Events = EventCatalogSingleton.GetCollection();
            EventHandler = new EventHandlerClass(this);
            _selectedEvent = new Event();
            AddCommand = new RelayCommand(EventHandler.CreateEvent);
            DeleteCommand = new RelayCommand(EventHandler.DeleteEvent);
            BackCommand = new RelayCommand(DoBackToLogin);
            GoToCreatePageCommand = new RelayCommand(NavigateToCreateEventPage);
            _frameNavigation = new FrameNavigationClass();
        }
        #endregion

        #region Properties
        internal FrameNavigationClass FrameNavigation => _frameNavigation;
        public EventCatalogSingleton EventCatalogSingleton { get; set; }
        public RelayCommand BackCommand { get; set; }
        public RelayCommand GoToCreatePageCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public ObservableCollection<Event> Events { get => _events; set => _events = value; }
        public Event SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                _selectedEvent = value;
                OnPropertyChanged(nameof(SelectedEvent));
            }
        }

        public DateTimeOffset Date { get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        public TimeSpan Time { get => _time;
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }
        public int Id { get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Name { get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                
            }
        }
        public string Description { get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public string Place { get => _place;
            set
            {
                _place = value;
                OnPropertyChanged(nameof(Place));
            }
        }

       
        #endregion

        #region Method(s)

        public void DoBackToLogin()
        {
            _frameNavigation.ActivateFrameNavigation(typeof(MainPage));
        }

        public void NavigateToCreateEventPage()
        {
            _frameNavigation.ActivateFrameNavigation(typeof(CreateEventPage));
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
       #endregion
    }
}

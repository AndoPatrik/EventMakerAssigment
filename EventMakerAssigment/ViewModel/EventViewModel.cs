using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EventMakerAssigment.Annotations;
using EventMakerAssigment.Common;
using EventMakerAssigment.Handler;
using EventMakerAssigment.Model;

namespace EventMakerAssigment.ViewModel
{
    public class EventViewModel :INotifyPropertyChanged
    {
        #region InstanceFields
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
        }
        #endregion

        #region Properties
        public EventCatalogSingleton EventCatalogSingleton { get; set; }
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
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
       #endregion
    }
}

using System;
using System.Collections.ObjectModel;
using Windows.Foundation.Diagnostics;
using Windows.UI.Popups;
using EventMakerAssigment.Persistency;

namespace EventMakerAssigment.Model
{
   public class EventCatalogSingleton
    {
        #region InstanceFields

        public static ObservableCollection<Event> _events;

        #endregion

        #region Properties

        private PersistencyService PersistencyService { get;}
        private static EventCatalogSingleton Instance { get; set; }

        #endregion

        #region Constructor(s)

        public EventCatalogSingleton()
        {
            _events = new ObservableCollection<Event>();
            PersistencyService = new PersistencyService();
            LoadMethod();
        }

        #endregion

        #region Methods

        private async void LoadMethod()
        {
            try
            {
                _events = await PersistencyService.LoadEventsFromJson();
            }
            catch (Exception e)
            {
                MessageDialog msd = new MessageDialog(e.ToString(),"Failed to load from json");

                _events = new ObservableCollection<Event>()
                {
                    new Event(0,"Description","TestEvent","CPH",new DateTime(2017,12,12)),
                    new Event(1,"Description","TestEvent1","CPH",new DateTime(2017,12,12)),
                    new Event(2,"Description","TestEvent2","CPH",new DateTime(2017,12,12))
                };
            }
        }

        public static EventCatalogSingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new EventCatalogSingleton();
            }
            return Instance;
        }

        public ObservableCollection<Event> GetCollection()
        {
            return _events;
        }

        #endregion
    }
}

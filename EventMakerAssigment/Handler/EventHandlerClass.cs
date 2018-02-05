using System;
using Windows.UI.Popups;
using EventMakerAssigment.Converter;
using EventMakerAssigment.Model;
using EventMakerAssigment.Persistency;
using EventMakerAssigment.ViewModel;

namespace EventMakerAssigment.Handler
{
    class EventHandlerClass
    {
        #region InstanceFields

        private PersistencyService _persistencyService;

        #endregion

        #region Properties

        private EventViewModel EventViewModel { get; }

        #endregion

        #region Constructor(s)

        public EventHandlerClass (EventViewModel evm)
        {
            _persistencyService = new PersistencyService();
            EventViewModel = evm;   
        }

        #endregion

        #region Method(s)

        public async void CreateEvent()
        {
            try
            {
                DateTime date = DateTimeConverter.DateTimeOffsetAndDateTimeSetToDateTime(EventViewModel.Date, EventViewModel.Time);
                EventViewModel.EventCatalogSingleton.GetCollection().Add(new Event(EventViewModel.Id, EventViewModel.Description , EventViewModel.Name , EventViewModel.Place , date ));
                await _persistencyService.SavetoJson(EventViewModel.EventCatalogSingleton.GetCollection());
            }
            catch (Exception e)
            {
                string ex = e.ToString();
                MessageDialog msg = new MessageDialog(ex, "ERROR");
                await msg.ShowAsync();
            }
            
        }

        public async void DeleteEvent()
        {
            EventViewModel.EventCatalogSingleton.GetCollection().Remove(EventViewModel.SelectedEvent);
            await _persistencyService.SavetoJson(EventViewModel.EventCatalogSingleton.GetCollection());
        }

        #endregion

    }
}

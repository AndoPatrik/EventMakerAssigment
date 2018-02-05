using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Storage;
using EventMakerAssigment.Model;

namespace EventMakerAssigment.Persistency
{
    class PersistencyService
    {
        #region Properties

        public ObservableCollection<Event> EventCatalog { get; set; }

        #endregion

        #region Saving and Loadin Events

        public async Task SavetoJson(ObservableCollection<Event> items)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var jsonFile = await localFolder.CreateFileAsync("EventCatalogFile.txt", CreationCollisionOption.ReplaceExisting);
            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Event>));
            using (var stream = await jsonFile.OpenStreamForWriteAsync())
            {
                jsonSerializer.WriteObject(stream, items);
            }
        }

        public async Task<ObservableCollection<Event>> LoadEventsFromJson()
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var jsonFile = await localFolder.GetFileAsync("EventCatalogFile.txt");
            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Event>));
            using (var stream = await jsonFile.OpenStreamForReadAsync())
            {
                EventCatalog = jsonSerializer.ReadObject(stream) as ObservableCollection<Event>;
            }
            return EventCatalog;
        }

        #endregion
    }
}

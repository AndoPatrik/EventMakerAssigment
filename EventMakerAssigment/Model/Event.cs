using System;

namespace EventMakerAssigment.Model
{
    public class Event
    {
        #region InstanceFields

        private int _id;
        private string _description;
        private string name;
        private string place;
        private DateTime _date;

        #endregion

        #region Consturcor(s)

        public Event()
        {
            
        }

        public Event(int id, string description, string name, string place, DateTime date)
        {
            _id = id;
            _description = description;
            this.name = name;
            this.place = place;
            _date = date;
        }

        #endregion

        #region Properties

        public int Id { get => _id; set => _id = value; }
        public string Description { get => _description; set => _description = value; }
        public string Name { get => name; set => name = value; }
        public string Place { get => place; set => place = value; }
        public DateTime Date { get => _date; set => _date = value; }

        #endregion
    }
}

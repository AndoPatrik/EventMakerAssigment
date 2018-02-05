namespace EventMakerAssigment.Model
{
    class User
    {
        #region InstanceFields

        private string _password;
        private string _id;
        private string _name;

        #endregion

        #region Constructor(s)

        public User(string password, string id, string name)
        {
            _password = password;
            _id = id;
            _name = name;
        }

        public User()
        {
            
        }

        #endregion

        #region Properties

        public string Password { get => _password; set => _password = value; }
        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }

        #endregion
    }
}

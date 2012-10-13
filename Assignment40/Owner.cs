using System;

namespace Assignment40
{
    public class Owner
    {
        public Owner(string name, int id) {
            Name = name;
            Id = id;
        }

        public override string ToString()
        {
            return string.Format("Id: {0} - Name: {1}", Id, Name);
        }

        public string Name
        {
            get;
            private set;
        }

        public int Id
        {
            get;
            private set;
        }
    }
}

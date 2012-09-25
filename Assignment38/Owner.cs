using System;

namespace Assignment38
{
    class Owner
    {
        public Owner(string name) {
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}", Name);
        }

        public string Name
        {
            get;
            private set;
        }
    }
}

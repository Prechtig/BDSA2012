using System;

namespace Assignment36
{
    struct CoordState
    {
        public CoordState(int x, int y, int? state)
            : this()
        {
            X = x;
            Y = y;
            State = state;
        }

        public int X
        {
            get;
            private set;
        }

        public int Y
        {
            get;
            private set;
        }

        public int? State
        {
            get;
            private set;
        }
    }
}

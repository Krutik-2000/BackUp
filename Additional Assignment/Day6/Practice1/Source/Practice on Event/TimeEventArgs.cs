using System;

namespace Practice_on_Event
{
    public class TimeEventArgs : EventArgs
    {
        public  int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
    }
}
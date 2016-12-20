using System;

namespace  Demo.Moq.Code.Demo13
{
    public class NotifySalesTeamEventArgs : EventArgs
    {
        public NotifySalesTeamEventArgs(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
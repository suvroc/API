﻿using System.ComponentModel;

namespace AnyStatus.API
{
    public class Folder : Plugin
    {
        public Folder() : base(aggregate: true) { }

        [Browsable(false)]
        public new int Interval { get; set; } = 0;

        [Browsable(false)]
        public new bool ShowNotifications { get; set; } = false;
    }
}

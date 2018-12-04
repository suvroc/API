using System;

namespace AnyStatus.API
{
    [Flags]
    public enum DialogButton
    {
        None = 0,
        Ok = 1,
        Yes = 2,
        No = 4,
        Cancel = 8
    }
}

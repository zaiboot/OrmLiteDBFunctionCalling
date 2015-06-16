using System;
using System.ComponentModel;

namespace POC.Bussines.Model
{
    [Serializable]
    public enum RecordStatusEnum
    {
        [Description("Active")]
        Active=1,

        [Description("Delete")]
        Deleted=2,

        [Description("Archived")]
        Archived=3
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.MODEL.Entities.Base.Abstarct
{
    public interface ILogEntity
    {
        DateTime? CreatedTime { get; set; }

        DateTime? UpdatedTime { get; set; }

        int? CreatedUserId { get; set; }

        int? UpdatedUserId { get; set; }
    }
}

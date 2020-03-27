﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 3/12/2020
    /// Approver: Chase Schulte
    /// 
    /// This is a data transfer object for BaseScheduleVM.
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public class BaseScheduleVM : BaseSchedule
    {
        public List<BaseScheduleLine> BaseScheduleLines { get; set; }
    }
}

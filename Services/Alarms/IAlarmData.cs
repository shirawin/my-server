using Repositories.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Alarms
{
    public interface IAlarmData
    {
        Task<bool> createAlarm(Alarm alarm);

    }
}

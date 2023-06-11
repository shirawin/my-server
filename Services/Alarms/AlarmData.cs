using Microsoft.EntityFrameworkCore;
using Repositories.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Alarms
{
    public class AlarmData:IAlarmData
    {
        private readonly MyDBContext _context;
        public AlarmData(MyDBContext context)
        {
            _context = context;
        }
        public async Task<bool> createAlarm(Alarm alarm)
        {
            var isOk = true;
            await _context.AddAsync(alarm);
            isOk = await _context.SaveChangesAsync() >= 0;
            if (isOk) return true;
            return false;
        }
    }
}

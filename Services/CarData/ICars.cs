using Repositories.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CarData
{
    public interface ICars
    {
        Task<bool> updateDetailsCar(Car car);
    }
}

using Repositories.GeneratedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Travels
{
    public interface ItravelsData
    {
        Task<IEnumerable<Travel>> GetActiveTravels();

        Task<bool> createTravel(Travel travel);

    }
}

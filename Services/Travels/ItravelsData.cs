using Repositories.GeneratedModels;
using Services.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Travels
{
    public interface ItravelsData
    {
        Task<IEnumerable<TravelDto>> GetActiveTravels();

        Task<bool> createTravel(Travel travel);
        Task <List<TravelDto>> filterTravel(FilterTravelsDto filterObj);
        Task<int> sumOfTraves();
        Task<int> takeTravel(int travelID,int volunteerID);     

    }
}

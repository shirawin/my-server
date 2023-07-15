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
        Task<IEnumerable<TravelDto>> GetTravelsByUser(int userId);

        Task<bool> createTravel(Travel travel);
        Task<List<TravelDto>> filterTravel(FilterTravelsDto filterObj);
        Task<List<TravelDto>> filterTravelsByUser(FilterTravelsDto filterObj, int userId);
        Task<int> sumOfTraves();
        Task<bool> takeTravel(int travelID, int volunteerID);
        Task<bool> closeTravel(int travelID);


    }
}
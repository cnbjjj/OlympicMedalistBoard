using Microsoft.EntityFrameworkCore;
using OlympicMedalistBoard.Models;
using OlympicMedalistBoard.DAL;

namespace OlympicMedalistBoard.BLL
{
    public class SportService
    {
        private readonly SportDAL _sportDal;
        private readonly MedalService _medalService;
        private readonly AthleteService _athleteService;

        public SportService(SportDAL sportDal, MedalService medalService, AthleteService athleteService)
        {
            _sportDal = sportDal;
            _medalService = medalService;
            _athleteService = athleteService;
        }

        public List<Sport> GetSports()
        {
            return _sportDal.GetSports();
        }

        public Sport GetSport(int id)
        {
            return _sportDal.GetSport(id);
        }

        public void AddSport(Sport sport)
        {
            _sportDal.AddSport(sport);
        }

        public void UpdateSport(Sport sport)
        {
            _sportDal.UpdateSport(sport);
        }

        public void DeleteSport(int id)
        {
            _medalService.DeleteMedalsBySportId(id);
            _athleteService.DeleteAthletesBySportId(id);
            _sportDal.DeleteSport(id);
        }
    }
}

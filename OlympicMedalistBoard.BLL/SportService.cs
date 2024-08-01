using Microsoft.EntityFrameworkCore;
using OlympicMedalistBoard.Models;
using OlympicMedalistBoard.DAL;

namespace OlympicMedalistBoard.BLL
{
    public class SportService
    {
        private readonly SportDAL _sportDal;

        public SportService(SportDAL sportDal)
        {
            _sportDal = sportDal;
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
            _sportDal.DeleteSport(id);
        }
    }
}

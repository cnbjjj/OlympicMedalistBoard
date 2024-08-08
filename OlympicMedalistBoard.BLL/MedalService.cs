using OlympicMedalistBoard.DAL;
using OlympicMedalistBoard.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlympicMedalistBoard.BLL
{
    public class MedalService
    {
        private readonly MedalDAL _medalDAL;

        public MedalService(MedalDAL medalDAL)
        {
            _medalDAL = medalDAL;
        }

        public List<Medal> GetAllMedals()
        {
            return _medalDAL.GetAllMedals();
        }

        public Medal GetMedalById(int id)
        {
            return _medalDAL.GetMedalById(id);
        }

        public void AddMedal(Medal medal)
        {
            _medalDAL.AddMedal(medal);
        }

        public void UpdateMedal(Medal medal)
        {
            _medalDAL.UpdateMedal(medal);
        }

        public void DeleteMedal(int id)
        {
            _medalDAL.DeleteMedal(id);
        }

        public List<Medal> GetMedalsBySportId(int id)
        {
            return _medalDAL.GetMedalsBySportId(id);
        }

        public List<Medal> GetMedalsByAthleteId(int id)
        {
            return _medalDAL.GetMedalsByAthleteId(id);
        }

        public void DeleteMedalsByAthleteId(int id)
        {
            _medalDAL.DeleteMedalsByAthleteId(id);
        }

        public void DeleteMedalsBySportId(int id)
        {
            _medalDAL.DeleteMedalsBySportId(id);
        }

        public void DeleteMedalsByCountryId(int id)
        {
            _medalDAL.DeleteMedalsByCountryId(id);
        }
    }
}



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

        public async Task<List<Medal>> GetAllMedalsAsync()
        {
            return await _medalDAL.GetAllMedalsAsync();
        }

        public async Task<Medal> GetMedalByIdAsync(int id)
        {
            return await _medalDAL.GetMedalByIdAsync(id);
        }

        public async Task AddMedalAsync(Medal medal)
        {
            await _medalDAL.AddMedalAsync(medal);
        }

        public async Task UpdateMedalAsync(Medal medal)
        {
            await _medalDAL.UpdateMedalAsync(medal);
        }

        public async Task DeleteMedalAsync(int id)
        {
            await _medalDAL.DeleteMedalAsync(id);
        }
    }
}


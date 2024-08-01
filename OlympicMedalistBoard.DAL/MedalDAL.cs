using OlympicMedalistBoard.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlympicMedalistBoard.DAL
{
    public class MedalDAL
    {
        private readonly OlympicMedalistBoardDbContext _context;

        public MedalDAL(OlympicMedalistBoardDbContext context)
        {
            _context = context;
        }

        public async Task<List<Medal>> GetAllMedalsAsync()
        {
            return await _context.Medals.Include(m => m.Athlete).Include(m => m.Sport).ToListAsync();
        }

        public async Task<Medal> GetMedalByIdAsync(int id)
        {
            return await _context.Medals.Include(m => m.Athlete).Include(m => m.Sport)
                .FirstOrDefaultAsync(m => m.MedalID == id);
        }

        public async Task AddMedalAsync(Medal medal)
        {
            _context.Medals.Add(medal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMedalAsync(Medal medal)
        {
            _context.Medals.Update(medal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMedalAsync(int id)
        {
            var medal = await _context.Medals.FindAsync(id);
            if (medal != null)
            {
                _context.Medals.Remove(medal);
                await _context.SaveChangesAsync();
            }
        }
    }
}


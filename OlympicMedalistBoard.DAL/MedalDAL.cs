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

        public List<Medal> GetAllMedals()
        {
            return _context.Medals.Include(m => m.Athlete).Include(m => m.Sport).ToList();
        }

        public Medal GetMedalById(int id)
        {
            return _context.Medals.Include(m => m.Athlete).Include(m => m.Sport)
                .FirstOrDefault(m => m.MedalID == id);
        }

        public void AddMedal(Medal medal)
        {
            _context.Medals.Add(medal);
            _context.SaveChanges();
        }

        public void UpdateMedal(Medal medal)
        {
            _context.Medals.Update(medal);
            _context.SaveChanges();
        }

        public void DeleteMedal(int id)
        {
            var medal = _context.Medals.Find(id);
            if (medal != null)
            {
                _context.Medals.Remove(medal);
                _context.SaveChanges();
            }
        }

        public List<Medal> GetMedalsBySportId(int id)
        {
            return _context.Medals
                .Include(a => a.Athlete)
                .Include(a => a.Sport)
                .Where(a => a.SportID == id).ToList();
        }

        public List<Medal> GetMedalsByAthleteId(int id)
        {
            return _context.Medals
                .Include(a => a.Athlete)
                .Include(a => a.Sport)
                .Where(a => a.AthleteID == id).ToList();
        }
    }
}



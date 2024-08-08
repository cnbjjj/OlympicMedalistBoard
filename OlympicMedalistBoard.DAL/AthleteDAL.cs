using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OlympicMedalistBoard.Models;

namespace OlympicMedalistBoard.DAL
{
    public class AthleteDAL
    {
        private readonly OlympicMedalistBoardDbContext _context;
        public AthleteDAL(OlympicMedalistBoardDbContext context)
        {
            _context = context;
        }

        public List<Athlete> GetAthletes()
        {
            return _context.Athletes
                .AsNoTracking()
                .Include(a => a.Country)
                .Include(a => a.Sport)
                .ToList();
        }

        public Athlete AddAthlete(Athlete athlete)
        {
            _context.Athletes.Add(athlete);
            _context.SaveChanges();
            return athlete;
        }

        public Athlete UpdateAthlete(Athlete athlete)
        {
            _context.Athletes.Update(athlete);
            _context.SaveChanges();
            return athlete;
        }

        public void DeleteAthlete(Athlete athlete)
        {
            //_context.Athletes.Remove(athlete);
            _context.Entry(athlete).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void DeleteAthleteById(int id)
        {
            var athlete = GetAthleteById(id);
            DeleteAthlete(athlete);
        }

        public Athlete GetAthleteById(int id)
        {
            return _context.Athletes.Find(id);
        }

        public List<Athlete> GetAthletesByCountryId(int id)
        {
            return _context.Athletes
                .AsNoTracking()
                .Include(a => a.Country)
                .Include(a => a.Sport)
                .Where(a => a.CountryID == id)
                .ToList();
        }

        public List<Athlete> GetAthletesBySportId(int id)
        {
            return _context.Athletes
                .AsNoTracking()
                .Include(a => a.Country)
                .Include(a => a.Sport)
                .Where(a => a.SportID == id)
                .ToList();
        }

        public void DeleteAthletesBySportId(int id)
        {
            var athletes = GetAthletesBySportId(id);
            foreach (var athlete in athletes)
            {
                DeleteAthlete(athlete);
            }
        }

        public void DeleteAthletesByCountryId(int id)
        {
            var athletes = GetAthletesByCountryId(id);
            foreach (var athlete in athletes)
            {
                DeleteAthlete(athlete);
            }
        }
    }
}

using OlympicMedalistBoard.Models;

namespace OlympicMedalistBoard.DAL
{
    public class SportDAL
    {
        private readonly OlympicMedalistBoardDbContext _context;
        public SportDAL(OlympicMedalistBoardDbContext context) {
            _context = context;
        }

        public List<Sport> GetSports()
        {
            return _context.Sports.ToList();
        }
          
        public Sport GetSport(int id)
        {
            return _context.Sports.Find(id);
        }

        public void AddSport(Sport sport)
        {
            _context.Sports.Add(sport);
            _context.SaveChanges();
        }
         
        public void UpdateSport(Sport sport)
        {
            _context.Sports.Update(sport);
            _context.SaveChanges();
        }

        public void DeleteSport(int id)
        {
            var sport = _context.Sports.Find(id);
            if (sport != null)
            {
                _context.Sports.Remove(sport);
                _context.SaveChanges();
            }
        }

    }
}

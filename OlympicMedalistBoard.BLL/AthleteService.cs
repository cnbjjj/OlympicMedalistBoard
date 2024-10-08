﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlympicMedalistBoard.DAL;
using OlympicMedalistBoard.Models;

namespace OlympicMedalistBoard.BLL
{
    public class AthleteService
    {
        private readonly AthleteDAL _athleteDAL;
        public AthleteService(AthleteDAL athleteDAL)
        {
            _athleteDAL = athleteDAL;
        }

        public List<Athlete> GetAthletes()
        {
            return _athleteDAL.GetAthletes();
        }

        public Athlete AddAthlete(Athlete athlete)
        {
            return _athleteDAL.AddAthlete(athlete);
        }

        public Athlete UpdateAthlete(Athlete athlete)
        {
            return _athleteDAL.UpdateAthlete(athlete);
        }

        public void DeleteAthlete(Athlete athlete)
        {
            _athleteDAL.DeleteAthlete(athlete);
        }

        public void DeleteAthleteById(int id)
        {
            _athleteDAL.DeleteAthleteById(id);
        }

        public Athlete GetAthleteById(int id)
        {
            return _athleteDAL.GetAthleteById(id);
        }

        public List<Athlete> GetAthletesByCountryId(int id)
        {
            return _athleteDAL.GetAthletesByCountryId(id);
        }

        public List<Athlete> GetAthletesBySportId(int id)
        {
            return _athleteDAL.GetAthletesBySportId(id);
        }

        public void DeleteAthletesBySportId(int id)
        {
            _athleteDAL.DeleteAthletesBySportId(id);
        }

        public void DeleteAthletesByCountryId(int id)
        {
            _athleteDAL.DeleteAthletesByCountryId(id);
        }
    }
}

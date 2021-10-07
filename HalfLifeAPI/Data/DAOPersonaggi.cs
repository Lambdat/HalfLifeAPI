using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
using HalfLifeAPI.Models;
using HalfLifeAPI.Services;

namespace HalfLifeAPI.Data
{
    public class DAOPersonaggi : IDAO<Personaggio>
    {

        private Database _db = new Database("half_life");

        //Pattern Singleton per restituire una singola istanza
        private static DAOPersonaggi _instance = null;

        public static DAOPersonaggi GetInstance()
        {
            if (_instance is null)
                _instance = new DAOPersonaggi();

            return _instance;
        }


        public void Aggiungi()
        {
            throw new NotImplementedException();
        }

        public Personaggio Cerca()
        {
            throw new NotImplementedException();
        }

        public void Elimina(int id)
        {
            throw new NotImplementedException();
        }

        public List<Personaggio> Leggi()
        {
            List<Personaggio> ris = new List<Personaggio>();

            List<Dictionary<string, string>> righe = _db.Read("select * from personaggi");

            foreach(var riga in righe)
            {
                Personaggio p = new Personaggio();
                p.FromDictionary(riga);
                ris.Add(p);
            }

 
            return ris;
        }

        public void Modifica()
        {
            throw new NotImplementedException();
        }
    }
}

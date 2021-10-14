using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
using HalfLifeAPI.Models;
using Microsoft.Extensions.Configuration;

namespace HalfLifeAPI.Data
{
    public class DAOPersonaggi : IDAO<Personaggio>
    {

        private Database _db;

        public DAOPersonaggi(IConfiguration config)
        {
            string nomeDatabase = config["nomeDatabase"]; //Configurazione passata nel file appsettings.json
            _db = new Database(nomeDatabase);
        }



        //METODO NON ORM
        public void Aggiungi(Personaggio p)
        {
            bool esitoInserimento = _db.Update("insert into personaggi(nome,potenza,dob) values " +
                $"('{p.Nome}',{p.Potenza},'{p.Dob.ToString("yyyy-MM-dd")}')");

            if (esitoInserimento)
                Console.WriteLine("Inserimento Effettuato");
            else
                Console.WriteLine("Inserimento Non Effettuato");
        }

        //METODO ORM
        public Personaggio Cerca(int id)
        {
            //essendo pochi dati usiamo Linq
            return Leggi().Where(p => p.Id == id).FirstOrDefault();
        }

        public void Elimina(int id)
        {
            bool esitoEliminazione = _db.Update("delete from personaggi where id=" + id);

            if(esitoEliminazione)
                Console.WriteLine("Eliminazione Effettuata");
            else
                Console.WriteLine("Eliminazione Non Effettuata");
        }

        //METODO NON ORM
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

        public void Modifica(Personaggio p,int id)
        {
            bool esitoModifica = _db.Update("update personaggi set " +
                $"nome='{p.Nome}',potenza={p.Potenza},dob='{p.Dob.ToString("yyyy-MM-dd")}' " +
                $"where id={id}");

            if(esitoModifica)
                Console.WriteLine("Modifica Effettuata");
            else
                Console.WriteLine("Modifica Non Effettuata");
        }

    }
}

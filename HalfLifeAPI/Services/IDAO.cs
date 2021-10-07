using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace HalfLifeAPI.Services
{
    interface IDAO
    {

        public List<Entity> Leggi();

        public Entity Cerca();

        public void Aggiungi();

        public void Modifica();

        public void Elimina(int id);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace HalfLifeAPI.Services
{
    public interface IDAO<T>
    {

        public List<T> Leggi();

        public T Cerca();

        public void Aggiungi();

        public void Modifica();

        public void Elimina(int id);

    }
}

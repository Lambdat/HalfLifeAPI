using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HalfLifeAPI.Data
{
    public interface IDAO<T> //<T> sta per generic
    {

        public List<T> Leggi();

        public T Cerca(int id);

        public void Aggiungi(T t);

        public void Modifica(T t, int id);

        public void Elimina(int id);

    }
}

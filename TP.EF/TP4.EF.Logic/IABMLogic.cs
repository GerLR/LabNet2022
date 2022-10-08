using System.Collections.Generic;

namespace TP4.EF.Logic
{
    interface IABMLogic<T>
    {
         List<T> GetAll();
         void Add(T newShippers);
         void Delete(int id);
         void Update(T objetoActualizar);
         T Busqueda(int id);
    }
}

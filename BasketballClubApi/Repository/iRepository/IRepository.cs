using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Repository.iRepository
{
    /// <summary>
    /// Genericki repozitorijum koji nasledjuju odredjeni repozitorijumi
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Metoda za vracanje svih objekata datog tipa iz baze
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();
        /// <summary>
        /// Metoda za vracanje odredjenog objekta iz pomocu ID-a
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T FindById(int id);
        /// <summary>
        /// Metoda za kreiranje novog objekta u bazi
        /// </summary>
        /// <param name="item"></param>
        T Insert(T item);
        /// <summary>
        /// Metoda za azuriranje objekta
        /// </summary>
        /// <param name="item"></param>
        /// <param name="id"></param>
        T Update(T item, int id);
        /// <summary>
        /// Metoda za brisanje trazenog objekta iz baze
        /// </summary>
        /// <param name="item"></param>
        void Delete(T item);
    }
}

using BasketballClub_Rest.Domain;
using BasketballClub_Rest.Repository.iRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClub_Rest.Repository.Repository_Impl
{
    public class RepositorySelection : IRepositorySelection
    {
        private BCContext context;
        public RepositorySelection(BCContext context)
        {
            this.context = context;
        }

        public void Delete(Selection item)
        {
            this.context.Remove(item);
        }

        public Selection FindById(int id)
        {
            return context.Selections.Include(sa=> sa.SelectionAge).Include(p=>p.Players).Include(p => p.Coaches).Include(tr => tr.Trainings).ThenInclude(g => g.Gym).SingleOrDefault(s => s.SelectionID == id);
         }

        public List<Selection> GetAll()
        {
            return context.Selections.Include(sa => sa.SelectionAge).Include(p => p.Players).Include(p => p.Coaches).ToList();
        }

        public List<SelectionAge> GetAllAges()
        {
            return context.SelectionAges.ToList();
        }

        public void Insert(Selection item)
        {
            context.Selections.Add(item);
        }

        public void Update(Selection item, int id)
        {
            Selection updated = context.Selections.Find(id);
            updated.SelectionName = item.SelectionName;
            updated.SelectionAgeID = item.SelectionAgeID;
            context.Selections.Update(updated);
        }
    }
}

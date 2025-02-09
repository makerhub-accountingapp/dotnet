using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.DAL.Interfaces;
using AccountingApp.DB.Contexts;
using AccountingApp.DB.Entities;
using Microsoft.EntityFrameworkCore;
using OnlineRestaurant.TL.Templates;

namespace AccountingApp.DAL.Repositories
{
    public class CategoryRepository(MainContext context) : Repository<Category>(context), ICategoryRepository
    {
        public override IEnumerable<Category> Get()
        {
            return Entities.Include(c => c.Details).OrderBy(c => c.Id);
        }

        public override IEnumerable<Category> Get(Func<Category, bool> predicate)
        {
            return Entities.Include(c => c.Details).Where(predicate).OrderBy(c => c.Id);
        }

        public override Category? GetOne(Func<Category, bool> predicate)
        {
            return Entities.Include(c => c.Details).FirstOrDefault(predicate);
        }
    }
}

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
	public class DetailRepository(MainContext context) : Repository<Detail>(context), IDetailRepository
	{
        public override IEnumerable<Detail> Get()
        {
                return Entities.Include(d => d.Transaction);
        }

        public override IEnumerable<Detail> Get(Func<Detail, bool> predicate)
		{
			return Entities.Include(d => d.Transaction).Where(predicate);
		}

		public override Detail? GetOne(Func<Detail, bool> predicate)
		{
			return Entities.Include(d => d.Transaction).FirstOrDefault(predicate);
		}
	}
}

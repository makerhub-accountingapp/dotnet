using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.BLL.Interfaces
{
	public interface IConvertibleToEntity<TEntity, TForm> where TEntity : class
	{
		public TEntity ToEntity(TForm form);
	}
}

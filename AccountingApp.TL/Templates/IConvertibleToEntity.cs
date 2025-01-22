using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.TL.Templates
{
	public interface IConvertibleToEntity<TEntity, TForm> 
		where TEntity : class
		where TForm : class
	{
		public TEntity ToEntity(TForm form);
	}
}

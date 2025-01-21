using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Tools.Exceptions
{
    public class OperationFailedException(string message) : Exception(message) { }
}

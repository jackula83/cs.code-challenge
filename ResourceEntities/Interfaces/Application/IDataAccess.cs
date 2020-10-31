using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceEntities.Interfaces.Application
{
   public interface IDataAccess
   {
      Task<string> Select();
   }
}

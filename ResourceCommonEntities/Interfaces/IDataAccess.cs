using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceCommonEntities.Interfaces
{
   public interface IDataAccess
   {
      Task<string> Select();
   }
}

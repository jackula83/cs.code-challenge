using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceEntities.Models.Database
{
   public class SalesPersonDataModel
   {
      #region Properties
      public string Name { get; set; }
      public IEnumerable<string> Groups { get; set; }
      #endregion // Properties
   }
}

using ResourceEntities.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceEntities.Interfaces.Application
{
   public interface IRosterManager
   {
      /// <summary>
      /// Registers the sales person as currently servicing a customer
      /// </summary>
      /// <param name="a_person"></param>
      /// <remarks>no requirement for a FinishService routine</remarks>
      void StartService(ISalesPerson a_person);

      bool PersonInService(ISalesPerson a_person);

      void Reset();
   }
}

using ResourceBusinessEntities.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceBusinessEntities.Interfaces.Features
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

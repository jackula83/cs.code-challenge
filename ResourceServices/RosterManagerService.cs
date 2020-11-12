using ResourceBusinessEntities.Interfaces.Application;
using ResourceBusinessEntities.Interfaces.Features;
using ResourceBusinessEntities.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResourceServices
{
   public class RosterManagerService : IRosterManager
   {
      private List<ISalesPerson> m_rosterList = default;

      public RosterManagerService()
         => m_rosterList = new List<ISalesPerson>();

      public bool PersonInService(ISalesPerson a_person)
         => m_rosterList.FirstOrDefault(p => string.Compare(p.Name, a_person.Name, true) == 0) != default;

      public void StartService(ISalesPerson a_person)
      {
         if (!m_rosterList.Contains(a_person))
            m_rosterList.Add(a_person);
      }

      public void Reset()
         => m_rosterList.Clear();
   }
}

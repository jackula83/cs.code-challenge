﻿
using ResourceApplicationEntities.Requests;
using ResourceApplicationEntities.Responses;
using ResourceBusinessEntities.Interfaces.Features;
using ResourceFinder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ResourceFinder.Handlers
{
   public class RosterResetHandler : IRosterResetHandler
   {
      #region Attributes
      private readonly IRosterManager m_rosterManager = default;
      #endregion // Attributes

      #region Construction
      public RosterResetHandler(IRosterManager a_rosterManager)
         => m_rosterManager = a_rosterManager;
      #endregion // Construction

      public async Task<RosterResetResponse> Handle(RosterResetRequest request, CancellationToken cancellationToken)
      {
         await Task.Run(() => m_rosterManager.Reset());
         return new RosterResetResponse();
      }
   }
}
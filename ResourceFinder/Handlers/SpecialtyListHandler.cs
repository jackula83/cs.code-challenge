using ResourceApplicationEntities.Requests;
using ResourceApplicationEntities.Responses;
using ResourceBusinessEntities.Interfaces.Features;
using ResourceBusinessEntities.Interfaces.Models;
using ResourceFinder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ResourceFinder.Handlers
{
   public class SpecialtyListHandler : ISpecialtyListHandler
   {
      #region Attributes
      private readonly ISpecialtyFactory m_specialtyFactory = default;
      #endregion // Attributes

      #region Construction
      public SpecialtyListHandler(ISpecialtyFactory a_specialtyFactory)
         => m_specialtyFactory = a_specialtyFactory;
      #endregion // Construction

      public async Task<SpecialtyListResponse> Handle(SpecialtyListRequest request, CancellationToken cancellationToken)
      {
         List<ISpecialtyModel> specialtyList = await Task.Run(() => m_specialtyFactory.Enumerate());
         return new SpecialtyListResponse { Result = specialtyList };
      }
   }
}

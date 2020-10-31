using ResourceEntities.Interfaces.Application;
using ResourceEntities.Interfaces.Business;
using ResourceEntities.Models.Language;
using ResourceEntities.Requests;
using ResourceEntities.Responses;
using ResourceFinder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceFinder.Handlers
{
   public class LanguageListHandler : ILanguageListHandler
   {
      #region Attributes
      private readonly ILanguageFactory m_languageFactory = default;
      #endregion // Attributes

      #region Construction
      public LanguageListHandler(ILanguageFactory a_languageFactory)
         => m_languageFactory = a_languageFactory;
      #endregion // Construction

      public async Task<LanguageListResponse> Handle(LanguageListRequest a_request)
      {
         List<ILanguageModel> languageList = await Task.Run(() => m_languageFactory.Enumerate());
         return new LanguageListResponse { Result = languageList };
      }
   }
}

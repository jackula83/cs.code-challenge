using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ResourceEntities.Interfaces.Application;
using ResourceEntities.Interfaces.Business;
using ResourceEntities.Models.Language;
using ResourceEntities.Models.Specialty;
using ResourceFinder.Tests.Mocks;
using ResourceServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ResourceFinder.Tests
{
   public abstract class CommonTests
   {
      protected readonly IRosterManager m_rosterManager = default;
      protected readonly ILanguage m_greekLanguage = default;
      protected readonly ILanguage m_englishLanguage = default;
      protected readonly ISpecialty m_tradieSpecialty = default;
      protected readonly ISpecialty m_familySpecialty = default;
      protected readonly ISpecialty m_sportsSpecialty = default;

      protected readonly DataAccessMock m_dataAccess = default;

      protected readonly ITestOutputHelper m_logger = default;

      public CommonTests(ITestOutputHelper a_testOutputHelper)
      {
         m_logger = a_testOutputHelper;

         m_dataAccess = new DataAccessMock();

         m_rosterManager = new RosterManagerService();

         m_greekLanguage = new GreekLanguageModel();
         m_englishLanguage = new EnglishLanguageModel();

         m_tradieSpecialty = new TradieVehicleSpecialtyModel();
         m_familySpecialty = new FamilyCarSpecialtyModel();
         m_sportsSpecialty = new SportsCarSpecialtyModel();
      }

      protected TResultType GetObject<TResultType>(ActionResult a_result)
         where TResultType : class
      {
         try
         {
            string content = (a_result as ContentResult).Content;
            return JsonConvert.DeserializeObject<TResultType>(content);
         }
         catch (Exception ex)
         {
            m_logger.WriteLine(ex.Message);
            Assert.True(false);
         }

         return default;
      }
   }
}

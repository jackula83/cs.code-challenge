using Newtonsoft.Json;
using ResourceApplicationEntities.Requests;
using ResourceApplicationEntities.Responses;
using ResourceBusinessEntities.Interfaces.Features;
using ResourceFinder.Handlers;
using ResourceServices;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ResourceFinder.Tests
{
   public class ResourceControllerTests : CommonTests
   {
      public ResourceControllerTests(ITestOutputHelper a_testOutputHelper) : base(a_testOutputHelper)
      {
      }

      /// tests the default code-challenge test example
      [Fact]
      public async Task TestGet_ByExamples()
      {
         ISpecialtyFactory specialtyFactory = new SpecialtyFactoryService();
         ISalesPersonFactory personFactory = new SalesPersonFactoryService(specialtyFactory);

         await this.TestGet_Expected(m_greekLanguage.Name, m_familySpecialty.SpecialtyCriteria, "Kierra Gentry", specialtyFactory, personFactory);
         await this.TestGet_Expected(m_greekLanguage.Name, m_sportsSpecialty.SpecialtyCriteria, "Thomas Crane", specialtyFactory, personFactory);
         await this.TestGet_Expected(m_englishLanguage.Name, m_sportsSpecialty.SpecialtyCriteria, "Alden Cantrell", specialtyFactory, personFactory);
      }

      // tests expected result when there are no more remaining sales people
      [Fact]
      public async Task TestGet_ToExhaustion()
      {
         ISpecialtyFactory specialtyFactory = new SpecialtyFactoryService();
         ISalesPersonFactory personFactory = new SalesPersonFactoryService(specialtyFactory);

         var handler = new AllocateResourceHandler(personFactory, specialtyFactory, m_rosterManager, m_dataAccess);

         // tests that after 8 requests, we get null returned
         for (int i = 0; i < 8; ++i)
            _ = await handler.Handle(new AllocateResourceRequest(), default);

         var result = this.JsonContent(await handler.Handle(new AllocateResourceRequest(), default));
         var response = this.GetObject<AllocateResourceResponse>(result);

         Assert.NotNull(response);
         Assert.Null(response.Name);
      }

      /// first person that speaks greek is always Cierra Vega
      [Fact]
      public async Task TestGet_LanguageOnlyGreek()
      {
         await this.TestGet_Expected(m_greekLanguage.Name, default, "Cierra Vega");
      }

      /// first person that not necessarily speak greek is always random
      [Fact]
      public async Task TestGet_LanguageOnlyEnglish()
      {
         // TODO introduce IRandomGenerator for predictable random testing
         await this.TestGet_Expected(m_englishLanguage.Name, default, default);
      }

      /// tests tradie special rule
      [Fact]
      public async Task TestGet_Tradie()
      {
         ISpecialtyFactory specialtyFactory = new SpecialtyFactoryService();
         ISalesPersonFactory personFactory = new SalesPersonFactoryService(specialtyFactory);

         await this.TestGet_Expected(m_greekLanguage.Name, m_tradieSpecialty.SpecialtyCriteria, "Alden Cantrell", specialtyFactory, personFactory);
         await this.TestGet_Expected(m_englishLanguage.Name, m_tradieSpecialty.SpecialtyCriteria, "Pierre Cox", specialtyFactory, personFactory);

         // exhaust remaining tradie specialists and ensure we can get another specialist without tradie
         // vehicle specialisation, this is to ensure it conforms to the rule: if no tradie specialists
         // available, go straight to a random specialist. There are only 4 tradie specialists in the dataset.
         await this.TestGet_Expected(m_englishLanguage.Name, m_tradieSpecialty.SpecialtyCriteria, default, specialtyFactory, personFactory);
         await this.TestGet_Expected(m_englishLanguage.Name, m_tradieSpecialty.SpecialtyCriteria, default, specialtyFactory, personFactory);

         // when no tradies are left, get a random tradie
         // TODO introduce IRandomGenerator for predictable random testing
         await this.TestGet_Expected(m_englishLanguage.Name, m_tradieSpecialty.SpecialtyCriteria, default, specialtyFactory, personFactory);
      }

      #region Helpers
      private async Task TestGet_Expected(string a_language, string a_specialty, string a_expectedName, ISpecialtyFactory a_specialtyFactory = default, ISalesPersonFactory a_personFactory = default)
      {
         ISpecialtyFactory specialtyFactory = a_specialtyFactory ?? new SpecialtyFactoryService();
         ISalesPersonFactory personFactory = a_personFactory ?? new SalesPersonFactoryService(specialtyFactory);

         var handler = new AllocateResourceHandler(personFactory, specialtyFactory, m_rosterManager, m_dataAccess);

         // First Customer speaks Greek and is looking for a Family car – Assigned to Kierra Gentry
         var result = this.JsonContent(await handler.Handle(
            new AllocateResourceRequest { Language = a_language, Specialty = a_specialty }, default));
         var response = this.GetObject<AllocateResourceResponse>(result);

         Assert.NotNull(response);
         Assert.NotNull(response.Name);

         if (!string.IsNullOrEmpty(a_expectedName))
            Assert.Equal(a_expectedName, response.Name);

      }
      #endregion // Helpers
   }
}

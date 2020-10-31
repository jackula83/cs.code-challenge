using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ResourceEntities.Interfaces.Application;
using ResourceEntities.Models.Language;
using ResourceEntities.Responses;
using ResourceFinder.Controllers;
using ResourceFinder.Handlers;
using ResourceFinder.Interfaces;
using ResourceFinder.Tests.Mocks;
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
         // TODO refactor this better if time allows
      }

      /// tests the default code-challenge test example
      [Fact]
      public async Task TestGet_ByExamples()
      {
         ISpecialtyFactory specialtyFactory = new SpecialtyFactoryService();
         ISalesPersonFactory personFactory = new SalesPersonFactoryService(specialtyFactory);

         var handler = new AllocateResourceHandler(personFactory, specialtyFactory, m_rosterManager, m_dataAccess);
         var controller = new ResourceController(handler);

         // per example test case

         // First Customer speaks Greek and is looking for a Family car – Assigned to Kierra Gentry
         var result = await controller.Get(m_greekLanguage.Name, m_familySpecialty.SpecialtyCriteria);
         var response = this.GetObject<AllocateResourceResponse>(result);

         Assert.NotNull(response);
         Assert.NotNull(response.Name);
         Assert.Equal("Kierra Gentry", response.Name);

         // Second Customer speaks Greek and is looking for a Sports car – Assigned to Thomas Crane
         result = await controller.Get(m_greekLanguage.Name, m_sportsSpecialty.SpecialtyCriteria);
         response = this.GetObject<AllocateResourceResponse>(result);

         Assert.NotNull(response);
         Assert.NotNull(response.Name);
         Assert.Equal("Thomas Crane", response.Name);

         // Third Customer doesn't speak Greek and is looking for a Sports car – Assigned to Alden Cantrell
         result = await controller.Get(m_englishLanguage.Name, m_sportsSpecialty.SpecialtyCriteria);
         response = this.GetObject<AllocateResourceResponse>(result);

         Assert.NotNull(response);
         Assert.NotNull(response.Name);
         Assert.Equal("Alden Cantrell", response.Name);
      }

      // tests expected result when there are no more remaining sales people
      [Fact]
      public async Task TestGet_ToExhaustion()
      {
         ISpecialtyFactory specialtyFactory = new SpecialtyFactoryService();
         ISalesPersonFactory personFactory = new SalesPersonFactoryService(specialtyFactory);

         var handler = new AllocateResourceHandler(personFactory, specialtyFactory, m_rosterManager, m_dataAccess);
         var controller = new ResourceController(handler);

         // tests that after 8 requests, we get null returned
         for (int i = 0; i < 8; ++i)
            _ = await controller.Get(default, default);

         var result = await controller.Get(default, default);
         var response = this.GetObject<AllocateResourceResponse>(result);

         Assert.NotNull(response);
         Assert.Null(response.Name);
      }

      /// first person that speaks greek is always Cierra Vega
      [Fact]
      public async Task TestGet_LanguageOnlyGreek()
      {
         ISpecialtyFactory specialtyFactory = new SpecialtyFactoryService();
         ISalesPersonFactory personFactory = new SalesPersonFactoryService(specialtyFactory);

         var handler = new AllocateResourceHandler(personFactory, specialtyFactory, m_rosterManager, m_dataAccess);
         var controller = new ResourceController(handler);

         var result = await controller.Get(m_greekLanguage.Name);
         var response = this.GetObject<AllocateResourceResponse>(result);

         Assert.NotNull(response);
         Assert.NotNull(response.Name);
         Assert.Equal("Cierra Vega", response.Name);
      }

      /// first person that not necessarily speak greek is always Cierra Vega
      [Fact]
      public async Task TestGet_LanguageOnlyEnglish()
      {
         ISpecialtyFactory specialtyFactory = new SpecialtyFactoryService();
         ISalesPersonFactory personFactory = new SalesPersonFactoryService(specialtyFactory);

         var handler = new AllocateResourceHandler(personFactory, specialtyFactory, m_rosterManager, m_dataAccess);
         var controller = new ResourceController(handler);

         var result = await controller.Get(m_englishLanguage.Name);
         var response = this.GetObject<AllocateResourceResponse>(result);

         Assert.NotNull(response);
         Assert.NotNull(response.Name);
         Assert.Equal("Cierra Vega", response.Name);
      }

      /// tests tradie special rule
      [Fact]
      public async Task TestGet_Tradie()
      {
         ISpecialtyFactory specialtyFactory = new SpecialtyFactoryService();
         ISalesPersonFactory personFactory = new SalesPersonFactoryService(specialtyFactory);

         var handler = new AllocateResourceHandler(personFactory, specialtyFactory, m_rosterManager, m_dataAccess);
         var controller = new ResourceController(handler);

         // first person tradie regardless of language is always Alden Cantrell
         var result = await controller.Get(m_greekLanguage.Name, m_tradieSpecialty.SpecialtyCriteria);
         var response = this.GetObject<AllocateResourceResponse>(result);

         Assert.NotNull(response);
         Assert.NotNull(response.Name);
         Assert.Equal("Alden Cantrell", response.Name);

         // the next tradie regardless of language is always Pierre Cox
         result = await controller.Get(m_englishLanguage.Name, m_tradieSpecialty.SpecialtyCriteria);
         response = this.GetObject<AllocateResourceResponse>(result);

         Assert.NotNull(response);
         Assert.NotNull(response.Name);
         Assert.Equal("Pierre Cox", response.Name);

         // exhaust remaining tradie specialists and ensure we can get another specialist without tradie
         // vehicle specialisation, this is to ensure it conforms to the rule: if no tradie specialists
         // available, go straight to a random specialist. There are only 4 tradie specialists in the dataset.
         await controller.Get(m_englishLanguage.Name, m_tradieSpecialty.SpecialtyCriteria);
         await controller.Get(m_englishLanguage.Name, m_tradieSpecialty.SpecialtyCriteria);

         result = await controller.Get(m_englishLanguage.Name, m_tradieSpecialty.SpecialtyCriteria);
         response = this.GetObject<AllocateResourceResponse>(result);

         Assert.NotNull(response);
         Assert.NotNull(response.Name);
      }
   }
}

using Microsoft.AspNetCore.Mvc;
using ResourceEntities.Interfaces.Application;
using ResourceEntities.Responses;
using ResourceFinder.Controllers;
using ResourceFinder.Handlers;
using ResourceServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ResourceFinder.Tests
{
   public class RosterControllerTests : CommonTests
   {
      public RosterControllerTests(ITestOutputHelper a_testOutputHelper) : base(a_testOutputHelper)
      {
      }

      [Fact]
      public async Task TestPost_Reset()
      {
         // set up roster consumer
         ISpecialtyFactory specialtyFactory = new SpecialtyFactoryService();
         ISalesPersonFactory personFactory = new SalesPersonFactoryService(specialtyFactory);

         var consumerHandler = new AllocateResourceHandler(personFactory, specialtyFactory, m_rosterManager, m_dataAccess);
         var consumerController = new ResourceController(consumerHandler);

         // set up roster handler
         var rosterHandler = new RosterResetHandler(m_rosterManager);
         var rosterController = new RosterController(rosterHandler);

         // consume until there are no sales persons left
         ActionResult consumerResult = default;
         AllocateResourceResponse consumerResponse = default;

         do
         {
            consumerResult = await consumerController.Get(default);
            consumerResponse = this.GetObject<AllocateResourceResponse>(consumerResult);

            Assert.NotNull(consumerResponse);

         } while (!string.IsNullOrEmpty(consumerResponse.Name));

         // reset the roster
         ActionResult rosterResult = await rosterController.Post();
         RosterResetResponse rosterResponse = this.GetObject<RosterResetResponse>(rosterResult);

         Assert.NotNull(rosterResponse);

         // check that we can get another person from the consumer
         consumerResult = await consumerController.Get(default);
         consumerResponse = this.GetObject<AllocateResourceResponse>(consumerResult);

         Assert.NotNull(consumerResponse);
         Assert.NotNull(consumerResponse.Name);
      }
   }
}

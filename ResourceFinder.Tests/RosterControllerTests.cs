using Microsoft.AspNetCore.Mvc;
using ResourceApplicationEntities.Requests;
using ResourceApplicationEntities.Responses;
using ResourceBusinessEntities.Interfaces.Application;
using ResourceBusinessEntities.Interfaces.Features;
using ResourceFinder.Controllers;
using ResourceFinder.Handlers;
using ResourceFinder.Interfaces;
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

         // set up roster handler
         var rosterHandler = new RosterResetHandler(m_rosterManager);

         // consume until there are no sales persons left
         IActionResult consumerResult = default;
         AllocateResourceResponse consumerResponse = default;

         do
         {
            consumerResult = this.JsonContent(await consumerHandler.Handle(new AllocateResourceRequest(), default));
            consumerResponse = this.GetObject<AllocateResourceResponse>(consumerResult);

            Assert.NotNull(consumerResponse);

         } while (!string.IsNullOrEmpty(consumerResponse.Name));

         // reset the roster
         IActionResult rosterResult = this.JsonContent(await rosterHandler.Handle(new RosterResetRequest(), default));
         RosterResetResponse rosterResponse = this.GetObject<RosterResetResponse>(rosterResult);

         Assert.NotNull(rosterResponse);

         // check that we can get another person from the consumer
         consumerResult = this.JsonContent(await consumerHandler.Handle(new AllocateResourceRequest(), default));
         consumerResponse = this.GetObject<AllocateResourceResponse>(consumerResult);

         Assert.NotNull(consumerResponse);
         Assert.NotNull(consumerResponse.Name);
      }
   }
}

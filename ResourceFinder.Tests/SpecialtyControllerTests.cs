using ResourceEntities.Interfaces.Application;
using ResourceEntities.Interfaces.Business;
using ResourceEntities.Responses;
using ResourceFinder.Controllers;
using ResourceFinder.Handlers;
using ResourceFinder.Tests.DataModels;
using ResourceFinder.Tests.Mocks;
using ResourceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ResourceFinder.Tests
{
   public class SpecialtyControllerTests : CommonTests
   {
      public SpecialtyControllerTests(ITestOutputHelper a_testOutputHelper) : base(a_testOutputHelper)
      {
      }

      [Fact]
      public async Task TestGet_DefaultSpecialtyList()
         => await this.TestGet_Common(new SpecialtyFactoryService(), true);

      [Fact]
      public async Task TestGet_NonDefaultSpecialtyList()
         => await this.TestGet_Common(new SpecialtyFactoryMock());

      private async Task TestGet_Common(ISpecialtyFactory a_specialtyFactory, bool a_removeMock = false)
      {
         List<ISpecialtyModel> specialtyList = a_specialtyFactory.Enumerate();

         if (a_removeMock)
            specialtyList.RemoveAll(x => x.GetType() == typeof(SpecialtyModelMock));

         var handler = new SpecialtyListHandler(a_specialtyFactory);
         var controller = new SpecialtyController(handler);

         var result = await controller.Get();
         var response = this.GetObject<SpecialtyResponseDataModel>(result);

         Assert.NotNull(response);
         Assert.NotNull(response.Result);
         Assert.NotEmpty(response.Result);
         Assert.Equal(specialtyList.Count, response.Result.Count);

         foreach (var specialty in specialtyList)
            Assert.False(response.Result.FirstOrDefault(x => x.Id == specialty.Id && x.SpecialtyCriteria == specialty.SpecialtyCriteria && x.FileName == specialty.FileName) == default);

      }
   }
}

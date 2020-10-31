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
   public class LanguageControllerTests : CommonTests
   {
      public LanguageControllerTests(ITestOutputHelper a_testOutputHelper) : base(a_testOutputHelper)
      {
      }

      [Fact]
      public async Task TestGet_DefaultLanguageList()
         => await this.TestGet_Common(new LanguageFactoryService(), true);

      [Fact]
      public async Task TestGet_NonDefaultLanguageList()
         => await this.TestGet_Common(new LanguageFactoryMock());

      private async Task TestGet_Common(ILanguageFactory a_languageFactory, bool a_removeMock = false)
      {
         List<ILanguageModel> languageList = a_languageFactory.Enumerate();

         if (a_removeMock)
            languageList.RemoveAll(x => x.GetType() == typeof(LanguageModelMock));

         var handler = new LanguageListHandler(a_languageFactory);
         var controller = new LanguageController(handler);

         var result = await controller.Get();
         var response = this.GetObject<LanguageResponseDataModel>(result);

         Assert.NotNull(response);
         Assert.NotNull(response.Result);
         Assert.NotEmpty(response.Result);
         Assert.Equal(languageList.Count, response.Result.Count);

         foreach (var language in languageList)
            Assert.False(response.Result.FirstOrDefault(x => x.Name == language.Name && x.FileName == language.FileName) == default);
      }
   }
}

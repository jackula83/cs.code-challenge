using Newtonsoft.Json;
using ResourceEntities.Interfaces.Fx;
using ResourceEntities.Interfaces.Business;
using ResourceEntities.Requests;
using ResourceEntities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceEntities.Models.Database;
using ResourceEntities.Interfaces.Application;
using ResourceEntities.Utilities;
using ResourceEntities.Models.Specialty;
using System.Security.Cryptography.X509Certificates;
using AllocationStrategy.Interfaces;
using AllocationStrategy.RuleSets;
using ResourceFinder.Interfaces;

namespace ResourceFinder.Handlers
{
   public class AllocateResourceHandler : IAllocateResourceHandler
   {
      #region Attributes
      private readonly ISalesPersonFactory m_personFactory = default;
      private readonly ISpecialtyFactory m_specialtyFactory = default;
      private readonly IRosterManager m_rosterManager = default;
      private readonly IDataAccess m_dataAccess = default;
      #endregion // Attributes

      #region Construction
      public AllocateResourceHandler(ISalesPersonFactory a_personFactory, ISpecialtyFactory a_specialtyFactory, IRosterManager a_rosterManager, IDataAccess a_da)
      {
         m_personFactory = a_personFactory;
         m_specialtyFactory = a_specialtyFactory;
         m_rosterManager = a_rosterManager;
         m_dataAccess = a_da;
      }
      #endregion // Construction

      public async Task<AllocateResourceResponse> Handle(AllocateResourceRequest a_request)
      {
         // get all sales persons from the "database"
         List<ISalesPerson> personList = await this.SelectModelsFromDatabase();

         // filter out the ones already serving a customer
         List<ISalesPerson> availablePersonList = personList.FindAll(p => !m_rosterManager.PersonInService(p));

         // apply the default allocation strategy to get the right person
         IRuleSet ruleSet = new DefaultAllocationRuleSet();
         IStrategyContext strategy = ruleSet.CreateStrategyContext(a_request.Language, a_request.Specialty);
         ISalesPerson chosenPerson = strategy.ApplyRuleSet(availablePersonList);

         // assign the person to a customer
         if (chosenPerson != default)
            m_rosterManager.StartService(chosenPerson);

         return new AllocateResourceResponse { Name = chosenPerson?.Name };
      }

      #region Helpers
      public async Task<List<ISalesPerson>> SelectModelsFromDatabase()
      {
         string databaseJson = await m_dataAccess.Select();
         var dataModelList = JsonConvert.DeserializeObject<List<SalesPersonDataModel>>(databaseJson);

         // make results
         List<ISalesPerson> modelList = new List<ISalesPerson>();
         dataModelList.ForEach(m => modelList.Add(m_personFactory.GetObject(m)));

         return modelList;
      }
      #endregion // Helpers
   }
}

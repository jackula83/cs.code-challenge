using ResourceEntities.Interfaces.Fx;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResourceEntities.Interfaces.Fx
{
   // templated to name this ICommand, however this isn't a CQRS since there's no write operations
   // an additional template base class using generics may be better if I have better understanding of the schema design on the wider application
   public interface IRequestResponseHandler<TRequestType, TResponseType> : IHandler
      where TRequestType : IRequest, new()
      where TResponseType : IResponse, new()
   {
      Task<TResponseType> Handle(TRequestType a_request);
   }
}

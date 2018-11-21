using GraphQL;
using GraphQL.Types;

namespace AppCore.DAL
{
    public class UTLogSchema : Schema
    {
        public UTLogSchema(IDependencyResolver resolver):  base(resolver)
        {
            Query = resolver.Resolve<UTLogQuery>();
            Mutation = resolver.Resolve<UTLogMutation>();
        }
    }
}
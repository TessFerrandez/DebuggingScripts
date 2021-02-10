using System;
using Microsoft.Web.Management.Server;

namespace CurrentRequestsUI
{
    class RequestModuleProvider : ModuleProvider 
    {
        public override Type ServiceType
        {
            get { return null; }
        }
        public override ModuleDefinition GetModuleDefinition(IManagementContext context)
        {
            return new ModuleDefinition(Name, typeof(RequestModule).AssemblyQualifiedName);
        }
        public override bool SupportsScope(ManagementScope scope)
        {
            return true;
        }
    }
}

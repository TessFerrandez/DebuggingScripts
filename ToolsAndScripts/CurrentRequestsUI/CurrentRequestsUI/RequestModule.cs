using System;
using Microsoft.Web.Management.Client;
using System.Windows.Forms;
using Microsoft.Web.Management.Server;

namespace CurrentRequestsUI
{
    internal class RequestModule : Module
    {
        protected override void Initialize(IServiceProvider serviceProvider, Microsoft.Web.Management.Server.ModuleInfo moduleInfo)
        {
            base.Initialize(serviceProvider, moduleInfo);
            //register the Module Page - RequestPage
            IControlPanel controlPanel = (IControlPanel)GetService(typeof(IControlPanel));
            ModulePageInfo modulePageInfo = new ModulePageInfo(this, typeof(RequestPage), "Current Requests", "Displays the current requests in all worker processes");
            controlPanel.RegisterPage(modulePageInfo);
        }
    }
}

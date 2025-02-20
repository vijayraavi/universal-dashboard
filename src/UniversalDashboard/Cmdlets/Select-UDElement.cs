using NLog;
using System.Management.Automation;
using Microsoft.AspNetCore.SignalR;

namespace UniversalDashboard.Cmdlets
{
    [Cmdlet(VerbsCommon.Select, "UDElement")]
    public class SelectUDElementCommand : PSCmdlet
    {
		//private readonly Logger Log = LogManager.GetLogger(nameof(InvokeRedirectCommand));

        [Parameter(Mandatory = true)]
		public string ID { get; set; }

        protected override void EndProcessing()
        {
            var hub = this.GetVariableValue("DashboardHub") as IHubContext<DashboardHub>;
            var connectionId = this.GetVariableValue("ConnectionId") as string;   
            hub.Select(connectionId, ID).Wait();
		}
	}
}

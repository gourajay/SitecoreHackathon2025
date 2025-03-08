using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Text;
using Sitecore.Web.UI.Sheer;

namespace SitecoreHackathon.Commands
{
	public class FridayAI: Command
	{
		public override void Execute(CommandContext context)
		{
			Sitecore.Context.ClientPage.Start(this, "Run", context.Parameters);
		}
		protected static void Run(ClientPipelineArgs args)
		{
			if (!args.IsPostBack)
			{
				UrlString urlString = new UrlString(UIUtil.GetUri("control:CustomForm"));
				SheerResponse.ShowModalDialog(urlString.ToString(), "800", "300", "", true);
				args.WaitForPostBack();
			}

		}
	}
}
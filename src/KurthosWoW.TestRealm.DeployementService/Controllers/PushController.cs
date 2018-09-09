using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KurthosWoW
{
	[Route("api/[controller]")]
	[ApiController]
	public class PushController : ControllerBase
	{
		private ILogger<PushController> Logger { get; }

		/// <inheritdoc />
		public PushController([FromServices] ILogger<PushController> logger)
		{
			Logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		

		[HttpGet]
		public string Get()
		{
			return "Online";
		}

		[HttpPost]
		public async Task<IActionResult> OnRecievedGithubPushEvent([FromBody] GithubWebhookPushEvent pushEvent, [FromServices] DeployedProcessManager processManager)
		{
			if(!ModelState.IsValid)
				return BadRequest();

			//We only want to deploy on staging branch pushes.
			if(!pushEvent.Ref.ToLower().Contains("staging"))
				return Ok();

			//TODO: Setup ASP Logging
			try
			{
				lock(processManager.SyncObj)
				{
					//We should kill before pulling and compiling.
					if(processManager.IsRunning)
						processManager.DeployedProcess.Kill();

					//TODO: We can do some logging or maybe even send some information to a Discord bot.
					//We just directly invoke the batch file that is responsible for handling compilation/git and such.
					//We assume it's in the current directory and that it's named push.bat
					ProcessStartInfo pInfo = new ProcessStartInfo($"{Path.Combine(Directory.GetCurrentDirectory(), "publish", "KurthosWoW.Compilation.Bootstrapper.exe")}");

					Process p = Process.Start(pInfo);
					p.EnableRaisingEvents = true;
					processManager.CompilationTaskProcess = p;
				}

				//We don't wait because github probably expects a quick OK
				return Ok();
			}
			catch(Exception e)
			{
				string error = $"Failed: {e.Message} \n\n {e.StackTrace}";
				Logger.LogError(error);
				return BadRequest(error);
			}
		}
	}
}

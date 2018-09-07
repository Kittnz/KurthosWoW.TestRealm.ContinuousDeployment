using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KurthosWoW
{
	[Route("api/[controller]")]
	[ApiController]
	public class PushController : ControllerBase
	{
		[HttpGet]
		public string Get()
		{
			return "Online";
		}

		[HttpPost]
		public async Task<IActionResult> OnRecievedGithubPushEvent([FromBody] GithubWebhookPushEvent pushEvent)
		{
			if(ModelState.IsValid)
				return BadRequest();

			//TODO: We can do some logging or maybe even send some information to a Discord bot.
			//We just directly invoke the batch file that is responsible for handling compilation/git and such.
			//We assume it's in the current directory and that it's named push.bat
			Process.Start("push.bat");

			//We don't wait because github probably expects a quick OK
			return Ok();
		}
	}
}

using System;
using System.Collections.Generic;
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
		public async Task OnRecievedGithubPushEvent()
		{
			return;
		}
	}
}

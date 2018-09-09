using System;
using Newtonsoft.Json;

namespace KurthosWoW
{
	//From Quicktype.io
	[JsonObject]
	public partial class GithubWebhookPushEvent
	{
		//TODO: Revert this when the model works properly.
		[JsonProperty("ref")]
		public string Ref { get; set; }

		/*[JsonProperty("before")]
		public string Before { get; set; }

		[JsonProperty("after")]
		public string After { get; set; }

		[JsonProperty("created")]
		public bool Created { get; set; }

		[JsonProperty("deleted")]
		public bool Deleted { get; set; }

		[JsonProperty("forced")]
		public bool Forced { get; set; }

		[JsonProperty("base_ref")]
		public object BaseRef { get; set; }

		[JsonProperty("compare")]
		public Uri Compare { get; set; }

		[JsonProperty("commits")]
		public object[] Commits { get; set; }

		[JsonProperty("head_commit")]
		public object HeadCommit { get; set; }

		[JsonProperty("repository")]
		public Repository Repository { get; set; }

		[JsonProperty("pusher")]
		public Pusher Pusher { get; set; }

		[JsonProperty("sender")]
		public Sender Sender { get; set; }*/
	}
}
using Newtonsoft.Json;

namespace KurthosWoW
{
	//From Quicktype.io
	public partial class Pusher
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }
	}
}
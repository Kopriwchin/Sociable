namespace Sociable.Models
{
	public class LikedPost
	{
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }
		public string PostId { get; set; }
		public Post Post { get; set; }
		public bool Active { get; set; }
	}
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sociable.Models
{
	public class Message
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }

		[Required]
		[StringLength(200, MinimumLength = 5)]
		public string Content { get; set; }
		public string URL { get; set; }
		public DateTime Time { get; set; }
		public string UserId { get; set; }
		public virtual ApplicationUser User { get; set; }
		public string SenderId { get; set; }
		public virtual ApplicationUser Sender { get; set; }
		public bool Final { get; set; }
		public string PreviousMessageId { get; set; }
		public virtual Message PreviousMessage { get; set; }
		public string ReplyId { get; set; }
		public virtual Message Reply { get; set; }
	}
}

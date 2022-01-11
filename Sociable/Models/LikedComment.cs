using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sociable.Models
{
	public class LikedComment
	{
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }
		public string CommentId { get; set; }
		public Comment Comment { get; set; }
		public bool Active { get; set; }
	}
}

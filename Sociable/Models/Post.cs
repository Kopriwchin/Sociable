using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sociable.Models
{
	public class Post
	{
		public Post()
		{
			this.Likes = new HashSet<LikedPost>();
			this.Comments = new HashSet<Comment>();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }

		[Required]
		[StringLength(3000, MinimumLength = 5)]
		public string Content { get; set; }

		public string UserId { get; set; }
		public virtual ApplicationUser User { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime TimePosted { get; set; }

		[DataType(DataType.Date)]
		public DateTime TimeEdited { get; set; }
		public bool Visible { get; set; }
		public virtual ICollection<LikedPost> Likes { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
	}
}

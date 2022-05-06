using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sociable.Models
{
	public class ApplicationUser : IdentityUser
	{
		public ApplicationUser()
		{
			this.Posts = new HashSet<Post>();
			this.Comments = new HashSet<Comment>();
			this.LikedPosts = new HashSet<LikedPost>();
			this.LikedComments = new HashSet<LikedComment>();
			this.Messages = new HashSet<Message>();
			this.SentMessages = new HashSet<Message>();
		}
		[Required]
		public DateTime JoinDate { get; set; }
		public DateTime LastLoginDate { get; set; }
		public virtual ICollection<Post> Posts { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
		public virtual ICollection<LikedPost> LikedPosts { get; set; }
		public virtual ICollection<LikedComment> LikedComments { get; set; }
		public virtual ICollection<Message> Messages { get; set; }
		public virtual ICollection<Message> SentMessages { get; set; }
	}
}

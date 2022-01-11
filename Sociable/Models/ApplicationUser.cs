using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
		}
		[Required]
		public DateTime JoinDate { get; set; }
		public ICollection<Post> Posts { get; set; }
		public ICollection<Comment> Comments { get; set; }
		public ICollection<LikedPost> LikedPosts { get; set; }
		public ICollection<LikedComment> LikedComments { get; set; }
	}
}

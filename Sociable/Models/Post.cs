using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sociable.Models
{
    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Likes = new HashSet<LikedPost>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [StringLength(3000, MinimumLength = 5)]
        public string Content { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        public DateTime TimePosted { get; set; }

        public DateTime TimeEdited { get; set; }
        public bool Visible { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<LikedPost> Likes { get; set; }
    }
}

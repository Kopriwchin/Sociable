using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sociable.Models
{
    public class Comment
    {
        public Comment()
        {
            this.Likes = new HashSet<LikedComment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [StringLength(2000, MinimumLength = 1)]
        public string Content { get; set; }
        [Required]

        [DataType(DataType.Date)]
        public DateTime TimeCreated { get; set; }

        [DataType(DataType.Date)]
        public DateTime TimeEdited { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string PostId { get; set; }
        public Post Post { get; set; }
        public ICollection<LikedComment> Likes { get; set; }
    }
}

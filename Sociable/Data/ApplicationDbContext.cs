using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Sociable.Models;

namespace Sociable.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		#region Tables
		public DbSet<Post> Posts { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<LikedComment> LikedComments { get; set; }
		public DbSet<LikedPost> LikedPosts { get; set; }
		public DbSet<Message> Messages { get; set; }
		public new DbSet<ApplicationUser> Users { get; set; }

		#endregion

		#region Configuration
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) { }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> base.OnConfiguring(optionsBuilder);

		#endregion

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			#region EntityModels

			modelBuilder.Entity<ApplicationUser>(entity =>
			{
				entity.HasKey(user => user.Id);

				entity.Property(user => user.JoinDate)
					.HasDefaultValueSql("getdate()");

				entity.Property(user => user.LastLoginDate)
					.HasDefaultValueSql("getdate()");

				entity.HasMany(user => user.Posts)
					.WithOne(post => post.User)
					.HasForeignKey(post => post.UserId)
					.OnDelete(DeleteBehavior.SetNull);

				entity.HasMany(user => user.Messages)
					.WithOne(message => message.User)
					.HasForeignKey(message => message.UserId)
					.OnDelete(DeleteBehavior.NoAction);

				entity.HasMany(user => user.SentMessages)
					.WithOne(message => message.Sender)
					.HasForeignKey(message => message.SenderId)
					.OnDelete(DeleteBehavior.NoAction);
			});

			modelBuilder.Entity<Post>(entity =>
			{
				entity.HasMany(post => post.Comments)
					.WithOne(comment => comment.Post)
					.HasForeignKey(commect => commect.PostId);
			});

			modelBuilder.Entity<Message>(entity =>
			{
				entity.Property(message => message.Time)
					.HasDefaultValueSql("getdate()");

				entity.HasOne(message => message.User)
					.WithMany(user => user.Messages)
					.HasForeignKey(message => message.UserId)
					.OnDelete(DeleteBehavior.NoAction);

				entity.HasOne(message => message.Sender)
					.WithMany(sender => sender.SentMessages)
					.HasForeignKey(message => message.SenderId)
					.OnDelete(DeleteBehavior.NoAction);

				entity.HasOne(message => message.Reply)
					.WithOne(reply => reply.PreviousMessage)
					.HasForeignKey<Message>(reply => reply.PreviousMessageId);

				entity.HasOne(message => message.PreviousMessage)
					.WithOne(prev => prev.Reply)
					.HasForeignKey<Message>(prev => prev.ReplyId);
			});

			modelBuilder.Entity<LikedComment>(entity =>
			{
				entity
				.HasKey(likedComment
					=> new { likedComment.CommentId, likedComment.UserId });

				entity.HasOne(likedComment => likedComment.Comment)
					.WithMany(comment => comment.Likes)
					.HasForeignKey(likedComment => likedComment.CommentId)
					.OnDelete(DeleteBehavior.Cascade);

				entity.HasOne(likedComment => likedComment.User)
					.WithMany(user => user.LikedComments)
					.HasForeignKey(likedComment => likedComment.UserId)
					.OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<LikedPost>(entity => {
				entity.HasKey(likedPost => new { likedPost.PostId, likedPost.UserId });

				entity.HasOne(likedPost => likedPost.Post)
					.WithMany(post => post.Likes)
					.HasForeignKey(likedPost => likedPost.PostId)
					.OnDelete(DeleteBehavior.Cascade);

				entity.HasOne(likedPost => likedPost.User)
					.WithMany(user => user.LikedPosts)
					.HasForeignKey(likedPost => likedPost.UserId)
					.OnDelete(DeleteBehavior.Cascade);
			});

			#endregion

			#region MappingModels
			/*
			modelBuilder.Entity<UserPromoCode>(entity =>
			{
				entity.HasKey(userPromoCode => new { userPromoCode.UserId, userPromoCode.PromoCodeId });

				entity.HasOne(userPromoCode => userPromoCode.User)
					.WithMany(user => user.PromoCodes)
					.HasForeignKey(userPromoCode => userPromoCode.UserId);

				entity.HasOne(userPromoCode => userPromoCode.PromoCode)
					.WithMany(promoCode => promoCode.Users)
					.HasForeignKey(userPromoCode => userPromoCode.PromoCodeId);
			});

			modelBuilder.Entity<PromoCodeOrder>(entity =>
			{
				entity.HasKey(promoCodeOrder => new { promoCodeOrder.PromoCodeId, promoCodeOrder.OrderId });

				entity.HasOne(promoCodeOrder => promoCodeOrder.PromoCode)
					.WithMany(promoCode => promoCode.Orders)
					.HasForeignKey(promoCodeOrder => promoCodeOrder.PromoCodeId);

				entity.HasOne(promoCodeOrder => promoCodeOrder.Order)
					.WithMany(order => order.PromoCodes)
					.HasForeignKey(promoCodeOrder => promoCodeOrder.OrderId);
			});
			*/
			#endregion
		}
	}
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DrawGuessAPI.Model
{
    public partial class drawguessContext : DbContext
    {
        public drawguessContext()
        {
        }

        public drawguessContext(DbContextOptions<drawguessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<PlayerRoom> PlayerRoom { get; set; }
        public virtual DbSet<Room> Room { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:draw-guess.database.windows.net,1433;Initial Catalog=draw-guess;Persist Security Info=False;User ID=tteav;Password=Thongteav123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Content).IsUnicode(false);

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("playerId");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("roomId");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.PlayerName).IsUnicode(false);
            });

            modelBuilder.Entity<PlayerRoom>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.RoomId })
                    .HasName("PKplayerRoom");

                entity.Property(e => e.PlayerRole).IsUnicode(false);

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerRoom)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_playerRoom_playerId");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.PlayerRoom)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_playerRoom_roomId");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Answer).IsUnicode(false);

                entity.Property(e => e.Drawing).IsUnicode(false);

                entity.Property(e => e.RoomName).IsUnicode(false);

                entity.Property(e => e.RoomPin).IsUnicode(false);

                entity.Property(e => e.RoomType).IsUnicode(false);
            });
        }
    }
}

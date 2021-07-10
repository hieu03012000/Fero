using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fero.Data.Models
{
    public partial class FeroContext : DbContext
    {
        public FeroContext()
        {
        }

        public FeroContext(DbContextOptions<FeroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplyCasting> ApplyCasting { get; set; }
        public virtual DbSet<BodyAttribute> BodyAttribute { get; set; }
        public virtual DbSet<BodyAttributeType> BodyAttributeType { get; set; }
        public virtual DbSet<BodyPart> BodyPart { get; set; }
        public virtual DbSet<BodyPartType> BodyPartType { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<BrandCategory> BrandCategory { get; set; }
        public virtual DbSet<CashLevel> CashLevel { get; set; }
        public virtual DbSet<Casting> Casting { get; set; }
        public virtual DbSet<CollectionImage> CollectionImage { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<ModelCasting> ModelCasting { get; set; }
        public virtual DbSet<ModelStyle> ModelStyle { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentAccount> PaymentAccount { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Style> Style { get; set; }
        public virtual DbSet<SubscribeCasting> SubscribeCasting { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<Tattoo> Tattoo { get; set; }
        public virtual DbSet<TattooType> TattooType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost,1433; Database=Fero; User Id=sa; Password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplyCasting>(entity =>
            {
                entity.HasKey(e => new { e.ModelId, e.CastingId });

                entity.Property(e => e.ModelId).HasMaxLength(10);

                entity.HasOne(d => d.Casting)
                    .WithMany(p => p.ApplyCasting)
                    .HasForeignKey(d => d.CastingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplyCasting_Casting");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.ApplyCasting)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplyCasting_Model");
            });

            modelBuilder.Entity<BodyAttribute>(entity =>
            {
                entity.Property(e => e.Value).HasColumnType("decimal(18, 3)");

                entity.HasOne(d => d.BodyAttType)
                    .WithMany(p => p.BodyAttribute)
                    .HasForeignKey(d => d.BodyAttTypeId)
                    .HasConstraintName("FK_BodyAttribute_BodyAttributeType");

                entity.HasOne(d => d.BodyPart)
                    .WithMany(p => p.BodyAttribute)
                    .HasForeignKey(d => d.BodyPartId)
                    .HasConstraintName("FK_BodyAttribute_BodyPart");
            });

            modelBuilder.Entity<BodyAttributeType>(entity =>
            {
                entity.Property(e => e.Measure).HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BodyPart>(entity =>
            {
                entity.Property(e => e.ModelId).HasMaxLength(10);

                entity.HasOne(d => d.BodyPartType)
                    .WithMany(p => p.BodyPart)
                    .HasForeignKey(d => d.BodyPartTypeId)
                    .HasConstraintName("FK_BodyPart_BodyPartType");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.BodyPart)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_BodyPart_Model");
            });

            modelBuilder.Entity<BodyPartType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.BrandCate)
                    .WithMany(p => p.Brand)
                    .HasForeignKey(d => d.BrandCateId)
                    .HasConstraintName("FK_Brand_BrandCategory");
            });

            modelBuilder.Entity<BrandCategory>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CashLevel>(entity =>
            {
                entity.Property(e => e.ModelId).HasMaxLength(10);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.CashLevel)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_CashLevel_Model");
            });

            modelBuilder.Entity<Casting>(entity =>
            {
                entity.Property(e => e.CloseTime).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OpenTime).HasColumnType("datetime");

                entity.Property(e => e.Salary).HasColumnType("decimal(20, 3)");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Casting)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Casting_Brand");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Casting)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Casting_Customer");
            });

            modelBuilder.Entity<CollectionImage>(entity =>
            {
                entity.Property(e => e.Gif)
                    .HasColumnName("gif")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.BodyPart)
                    .WithMany(p => p.CollectionImage)
                    .HasForeignKey(d => d.BodyPartId)
                    .HasConstraintName("FK_CollectionImage_BodyPart");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(10);

                entity.Property(e => e.Fanpage).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(300);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TaxCode).HasMaxLength(20);

                entity.Property(e => e.Token).IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Web).HasMaxLength(100);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UploadDate).HasColumnType("datetime");

                entity.HasOne(d => d.Collection)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.CollectionId)
                    .HasConstraintName("FK_Image_CollectionImage");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.MsgContent)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ReceiverId).HasMaxLength(10);

                entity.Property(e => e.SenderId).HasMaxLength(10);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(10);

                entity.Property(e => e.Avatar).HasMaxLength(200);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.District).HasMaxLength(50);

                entity.Property(e => e.Gifted).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(300);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Province).HasMaxLength(50);

                entity.Property(e => e.SubAddress).HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ModelCasting>(entity =>
            {
                entity.Property(e => e.CustomerReview).HasMaxLength(200);

                entity.Property(e => e.ModelId).HasMaxLength(10);

                entity.Property(e => e.ModelReview).HasMaxLength(200);

                entity.HasOne(d => d.Casting)
                    .WithMany(p => p.ModelCasting)
                    .HasForeignKey(d => d.CastingId)
                    .HasConstraintName("FK_ModelCasting_Casting");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.ModelCasting)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_ModelCasting_Model");
            });

            modelBuilder.Entity<ModelStyle>(entity =>
            {
                entity.HasKey(e => new { e.ModelId, e.StyleId })
                    .HasName("PK__ModelSty__F07AB548A86C097C");

                entity.Property(e => e.ModelId).HasMaxLength(10);

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.ModelStyle)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ModelStyle_Model");

                entity.HasOne(d => d.Style)
                    .WithMany(p => p.ModelStyle)
                    .HasForeignKey(d => d.StyleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ModelStyle_Style");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasMaxLength(10);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.ModelId).HasMaxLength(10);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.PaidDate).HasColumnType("date");

                entity.HasOne(d => d.ModelCasting)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.ModelCastingId)
                    .HasConstraintName("FK_Payment_ModelCasting");

                entity.HasOne(d => d.PaymentAccount)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.PaymentAccountId)
                    .HasConstraintName("FK_Payment_PaymentAccount");
            });

            modelBuilder.Entity<PaymentAccount>(entity =>
            {
                entity.Property(e => e.AccountName).HasMaxLength(50);

                entity.Property(e => e.AccountNumber).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ExpDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.Property(e => e.VertificaionCode).HasMaxLength(100);
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModelId).HasMaxLength(10);

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_Product_Model");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(10);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<Style>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<SubscribeCasting>(entity =>
            {
                entity.HasKey(e => new { e.ModelId, e.CastingId });

                entity.Property(e => e.ModelId).HasMaxLength(10);

                entity.HasOne(d => d.Casting)
                    .WithMany(p => p.SubscribeCasting)
                    .HasForeignKey(d => d.CastingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubscribeCasting_Casting");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.SubscribeCasting)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubscribeCasting_Model");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.EndAt).HasColumnType("datetime");

                entity.Property(e => e.ModelId).HasMaxLength(10);

                entity.Property(e => e.StartAt).HasColumnType("datetime");

                entity.HasOne(d => d.Casting)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.CastingId)
                    .HasConstraintName("FK_Task_Casting");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_Task_Model");
            });

            modelBuilder.Entity<Tattoo>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.HasOne(d => d.BodyPart)
                    .WithMany(p => p.Tattoo)
                    .HasForeignKey(d => d.BodyPartId)
                    .HasConstraintName("FK_Tattoo_BodyPart");

                entity.HasOne(d => d.TattooType)
                    .WithMany(p => p.Tattoo)
                    .HasForeignKey(d => d.TattooTypeId)
                    .HasConstraintName("FK_Tattoo_TattooType");
            });

            modelBuilder.Entity<TattooType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

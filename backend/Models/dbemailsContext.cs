using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backend.Models
{
    public partial class dbemailsContext : DbContext
    {
        public dbemailsContext()
        {
        }

        public dbemailsContext(DbContextOptions<dbemailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbEmailEnviado> TbEmailEnviados { get; set; }
        public virtual DbSet<TbEmailRecebido> TbEmailRecebidos { get; set; }
        public virtual DbSet<TbEmailUsuario> TbEmailUsuarios { get; set; }
        public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("host=localhost;user=root;password=12345;database=dbemails", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<TbEmailEnviado>(entity =>
            {
                entity.HasKey(e => e.IdEmailEnviado)
                    .HasName("PRIMARY");

                entity.ToTable("tb_email_enviado");

                entity.Property(e => e.IdEmailEnviado).HasColumnName("id_email_enviado");

                entity.Property(e => e.DsConteudo)
                    .HasMaxLength(400)
                    .HasColumnName("ds_conteudo");

                entity.Property(e => e.DsEmailDestinatario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ds_email_destinatario");

                entity.Property(e => e.DsEmailRemetente)
                    .HasMaxLength(50)
                    .HasColumnName("ds_email_remetente");

                entity.Property(e => e.DtEnvio)
                    .HasColumnType("datetime")
                    .HasColumnName("dt_envio");

                entity.Property(e => e.NmTitulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nm_titulo");
            });

            modelBuilder.Entity<TbEmailRecebido>(entity =>
            {
                entity.HasKey(e => e.IdEmailRecebido)
                    .HasName("PRIMARY");

                entity.ToTable("tb_email_recebido");

                entity.Property(e => e.IdEmailRecebido).HasColumnName("id_email_recebido");

                entity.Property(e => e.BlLido).HasColumnName("bl_lido");

                entity.Property(e => e.DsConteudo)
                    .HasMaxLength(400)
                    .HasColumnName("ds_conteudo");

                entity.Property(e => e.DsEmailRemetente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ds_email_remetente");

                entity.Property(e => e.DtEnvio)
                    .HasColumnType("datetime")
                    .HasColumnName("dt_envio");

                entity.Property(e => e.NmTitulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nm_titulo");
            });

            modelBuilder.Entity<TbEmailUsuario>(entity =>
            {
                entity.HasKey(e => e.IdEmailUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("tb_email_usuario");

                entity.HasIndex(e => e.IdEmailRecebido, "id_email_recebido");

                entity.HasIndex(e => e.IdUsuario, "id_usuario");

                entity.Property(e => e.IdEmailUsuario).HasColumnName("id_email_usuario");

                entity.Property(e => e.IdEmailRecebido).HasColumnName("id_email_recebido");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdEmailRecebidoNavigation)
                    .WithMany(p => p.TbEmailUsuarios)
                    .HasForeignKey(d => d.IdEmailRecebido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_email_usuario_ibfk_1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TbEmailUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_email_usuario_ibfk_2");
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("tb_usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.DsEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ds_email");

                entity.Property(e => e.DsSenha)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("ds_senha");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

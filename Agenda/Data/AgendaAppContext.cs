using System;
using System.Collections.Generic;
using Agenda.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data;

public partial class AgendaAppContext : DbContext
{
    public AgendaAppContext()
    {
    }

    public AgendaAppContext(DbContextOptions<AgendaAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agendamento> Agendamentos { get; set; }

    public virtual DbSet<Agendum> Agenda { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Notificacao> Notificacaos { get; set; }

    public virtual DbSet<Profissional> Profissionals { get; set; }

    public virtual DbSet<Reagendamento> Reagendamentos { get; set; }

    public virtual DbSet<Servico> Servicos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<AdminEmpresa> AdminEmpresa { get; set; }


//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-81POI2L\\MSSQLSERVER1;Database=AgendaApp;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agendamento>(entity =>
        {
            entity.HasKey(e => e.AgendamentoId).HasName("PK__Agendame__AE013133C6D43B77");

            entity.ToTable("Agendamento");

            entity.Property(e => e.DataHora).HasColumnType("datetime");
            entity.Property(e => e.Observacoes).HasColumnType("text");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Agendamen__Clien__4CA06362");

            entity.HasOne(d => d.Profissional).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.ProfissionalId)
                .HasConstraintName("FK__Agendamen__Profi__4D94879B");

            entity.HasOne(d => d.Servico).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.ServicoId)
                .HasConstraintName("FK__Agendamen__Servi__4E88ABD4");
        });

        modelBuilder.Entity<Agendum>(entity =>
        {
            entity.HasKey(e => e.AgendaId).HasName("PK__Agenda__B9D43614BB537C1A");

            entity.Property(e => e.DataHoraFim).HasColumnType("datetime");
            entity.Property(e => e.DataHoraInicio).HasColumnType("datetime");
            entity.Property(e => e.Disponivel).HasDefaultValue(true);

            entity.HasOne(d => d.Profissional).WithMany(p => p.Agenda)
                .HasForeignKey(d => d.ProfissionalId)
                .HasConstraintName("FK__Agenda__Profissi__49C3F6B7");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Cliente__71ABD087CB374315");

            entity.ToTable("Cliente");

            entity.HasIndex(e => e.UsuarioId, "UQ__Cliente__2B3DE7B97C6533AC").IsUnique();

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Usuario).WithOne(p => p.Cliente)
                .HasForeignKey<Cliente>(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cliente__Usuario__3F466844");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.EmpresaId).HasName("PK__Empresa__7B9F211625258DEF");

            entity.ToTable("Empresa");

            entity.Property(e => e.CorPrimaria)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.CorSecundaria)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LogoURL");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Notificacao>(entity =>
        {
            entity.HasKey(e => e.NotificacaoId).HasName("PK__Notifica__FB9B787C3819DB41");

            entity.ToTable("Notificacao");

            entity.Property(e => e.EnviadoEm).HasColumnType("datetime");
            entity.Property(e => e.StatusEnvio)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Agendamento).WithMany(p => p.Notificacaos)
                .HasForeignKey(d => d.AgendamentoId)
                .HasConstraintName("FK__Notificac__Agend__5165187F");
        });

        modelBuilder.Entity<Profissional>(entity =>
        {
            entity.HasKey(e => e.ProfissionalId).HasName("PK__Profissi__C7415AADD0A52BE9");

            entity.ToTable("Profissional");

            entity.HasIndex(e => e.UsuarioId, "UQ__Profissi__2B3DE7B905BE3EBC").IsUnique();

            entity.Property(e => e.ImgPerfil)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Usuario).WithOne(p => p.Profissional)
                .HasForeignKey<Profissional>(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Profissio__Usuar__4316F928");
        });

        modelBuilder.Entity<Reagendamento>(entity =>
        {
            entity.HasKey(e => e.ReagendamentoId).HasName("PK__Reagenda__071C2486E3BBAE81");

            entity.ToTable("Reagendamento");

            entity.Property(e => e.DataHoraAntiga).HasColumnType("datetime");
            entity.Property(e => e.DataReagendamento)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NovaDataHora).HasColumnType("datetime");

            entity.HasOne(d => d.Agendamento).WithMany(p => p.Reagendamentos)
                .HasForeignKey(d => d.AgendamentoId)
                .HasConstraintName("FK__Reagendam__Agend__5535A963");
        });

        modelBuilder.Entity<Servico>(entity =>
        {
            entity.HasKey(e => e.ServicoId).HasName("PK__Servico__C59767B638C7D867");

            entity.ToTable("Servico");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Servicos)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK__Servico__Empresa__45F365D3");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE7B831B48603");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105348F2B6919").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SenhaHash)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__Empresa__3B75D760");
        });

        modelBuilder.Entity<AdminEmpresa>(entity =>
        {
            entity.HasKey(e => e.AdminEmpresaId).HasName("PK__AdminEmp__907C0E81544ADEF8");

            entity.ToTable("AdminEmpresa");

            entity.HasIndex(e => e.EmpresaId, "UQ_AdminPorEmpresa").IsUnique();

            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

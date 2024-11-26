using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToritosSAC.Entities;

namespace ToritosSAC.DataAccess.Context;

public partial class ToritosDbContext : DbContext
{
    public ToritosDbContext()
    {
    }

    public ToritosDbContext(DbContextOptions<ToritosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignacion> Asignacions { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<DetalleEstadoCuentum> DetalleEstadoCuenta { get; set; }

    public virtual DbSet<DetalleGrupo> DetalleGrupos { get; set; }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Provincium> Provincia { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=localhost;Database=ToritosDB;Trusted_Connection=True;TrustServerCertificate=True;");
        => optionsBuilder.UseSqlServer("Server=.;Database=ToritosDB;Trusted_Connection=True;TrustServerCertificate=True;");
    //optionsBuilder.UseSqlServer("server=localhost; initial catalog=ToritosDB; user id=sa; password=1342; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asignacion>(entity =>
        {
            entity.HasKey(e => e.IdAsignacionI).HasName("PK__Asignaci__AD579960DBEAA5F0");

            entity.ToTable("Asignacion");

            entity.Property(e => e.IdAsignacionI).HasColumnName("IdAsignacion_i");
            entity.Property(e => e.FechaAsignacionD)
                .HasColumnType("datetime")
                .HasColumnName("FechaAsignacion_d");
            entity.Property(e => e.FechaEntregaVehiculoD)
                .HasColumnType("datetime")
                .HasColumnName("FechaEntregaVehiculo_d");
            entity.Property(e => e.IdVehiculoI).HasColumnName("IdVehiculo_i");
            entity.Property(e => e.TipoAsignacionC)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TipoAsignacion_c");

            entity.HasOne(d => d.IdVehiculoINavigation).WithMany(p => p.Asignacions)
                .HasForeignKey(d => d.IdVehiculoI)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignacion_Vehiculo");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdClienteI).HasName("PK__Cliente__F53654E1049B2976");

            entity.ToTable("Cliente");

            entity.HasIndex(e => e.CodigoC, "UQ__Cliente__DB3716BA6AE8EEF6").IsUnique();

            entity.Property(e => e.IdClienteI).HasColumnName("IdCliente_i");
            entity.Property(e => e.ApellidoMaternoNv)
                .HasMaxLength(20)
                .HasColumnName("ApellidoMaterno_nv");
            entity.Property(e => e.ApellidoPaternoNv)
                .HasMaxLength(20)
                .HasColumnName("ApellidoPaterno_nv");
            entity.Property(e => e.CodigoC)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Codigo_c");
            entity.Property(e => e.CorreoAutenticadoBo).HasColumnName("CorreoAutenticado_bo");
            entity.Property(e => e.CorreoNv)
                .HasMaxLength(30)
                .HasColumnName("Correo_nv");
            entity.Property(e => e.DireccionNv)
                .HasMaxLength(140)
                .HasColumnName("Direccion_nv");
            entity.Property(e => e.DireccionRefNv)
                .HasMaxLength(140)
                .HasColumnName("DireccionRef_nv");
            entity.Property(e => e.EstadoC)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Estado_c");
            entity.Property(e => e.EstadoCivilC)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EstadoCivil_c");
            entity.Property(e => e.FechaInscripcionD)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FechaInscripcion_d");
            entity.Property(e => e.FechaNacimientoD)
                .HasColumnType("date")
                .HasColumnName("FechaNacimiento_d");
            entity.Property(e => e.IdDistritoC)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IdDistrito_c");
            entity.Property(e => e.NombreNv)
                .HasMaxLength(50)
                .HasColumnName("Nombre_nv");
            entity.Property(e => e.NroContactoC)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NroContacto_c");
            entity.Property(e => e.NroDocumentoV)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("NroDocumento_v");
            entity.Property(e => e.PasswordBi)
                .HasMaxLength(64)
                .IsFixedLength()
                .HasColumnName("Password_bi");
            entity.Property(e => e.SexoC)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Sexo_c");
            entity.Property(e => e.TipoDocumentoC)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TipoDocumento_c");

            entity.HasOne(d => d.IdDistritoCNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdDistritoC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_Distrito");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamentoC).HasName("PK__Departam__71D43214E82991BA");

            entity.ToTable("Departamento");

            entity.Property(e => e.IdDepartamentoC)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IdDepartamento_c");
            entity.Property(e => e.NombreNv)
                .HasMaxLength(45)
                .HasColumnName("Nombre_nv");
        });

        modelBuilder.Entity<DetalleEstadoCuentum>(entity =>
        {
            entity.HasKey(e => e.IdDetalleEstadoCuentaI).HasName("PK__DetalleE__35DC8DEB2ED090DC");

            entity.Property(e => e.IdDetalleEstadoCuentaI).HasColumnName("IdDetalleEstadoCuenta_i");
            entity.Property(e => e.EstadoCuotaC)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EstadoCuota_c");
            entity.Property(e => e.FechaPagoProgramadaD)
                .HasColumnType("datetime")
                .HasColumnName("FechaPagoProgramada_d");
            entity.Property(e => e.FechaPagoRealD)
                .HasColumnType("datetime")
                .HasColumnName("FechaPagoReal_d");
            entity.Property(e => e.IdDetalleGrupoI).HasColumnName("IdDetalleGrupo_i");
            entity.Property(e => e.MartillazoFechaPagoD)
                .HasColumnType("datetime")
                .HasColumnName("MartillazoFechaPago_d");
            entity.Property(e => e.MartillazoMontoM)
                .HasColumnType("money")
                .HasColumnName("MartillazoMonto_m");
            entity.Property(e => e.MontoCuotaM)
                .HasColumnType("money")
                .HasColumnName("MontoCuota_m");
            entity.Property(e => e.NroCuotaI).HasColumnName("NroCuota_i");
            entity.Property(e => e.PenalidadFechaPagoD)
                .HasColumnType("datetime")
                .HasColumnName("PenalidadFechaPago_d");
            entity.Property(e => e.PenalidadMontoM)
                .HasColumnType("money")
                .HasColumnName("PenalidadMonto_m");

            entity.HasOne(d => d.IdDetalleGrupoINavigation).WithMany(p => p.DetalleEstadoCuenta)
                .HasForeignKey(d => d.IdDetalleGrupoI)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleEstadoCuenta_DetalleGrupo");
        });

        modelBuilder.Entity<DetalleGrupo>(entity =>
        {
            entity.HasKey(e => e.IdDetalleGrupoI).HasName("PK__DetalleG__D8C3997A6B7864DB");

            entity.ToTable("DetalleGrupo");

            entity.Property(e => e.IdDetalleGrupoI).HasColumnName("IdDetalleGrupo_i");
            entity.Property(e => e.ClienteAdminBo).HasColumnName("ClienteAdmin_bo");
            entity.Property(e => e.IdAsignacionI).HasColumnName("IdAsignacion_i");
            entity.Property(e => e.IdClienteI).HasColumnName("IdCliente_i");
            entity.Property(e => e.IdDocumentosI).HasColumnName("IdDocumentos_i");
            entity.Property(e => e.IdGrupoI).HasColumnName("IdGrupo_i");

            entity.HasOne(d => d.IdAsignacionINavigation).WithMany(p => p.DetalleGrupos)
                .HasForeignKey(d => d.IdAsignacionI)
                .HasConstraintName("FK_DetalleGrupo_Asignacion");

            entity.HasOne(d => d.IdClienteINavigation).WithMany(p => p.DetalleGrupos)
                .HasForeignKey(d => d.IdClienteI)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleGrupo_Cliente");

            entity.HasOne(d => d.IdDocumentosINavigation).WithMany(p => p.DetalleGrupos)
                .HasForeignKey(d => d.IdDocumentosI)
                .HasConstraintName("FK_DetalleGrupo_Documentos");

            entity.HasOne(d => d.IdGrupoINavigation).WithMany(p => p.DetalleGrupos)
                .HasForeignKey(d => d.IdGrupoI)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleGrupo_Grupo");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.IdDistritoC).HasName("PK__Distrito__A433531299B66A2A");

            entity.ToTable("Distrito");

            entity.Property(e => e.IdDistritoC)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IdDistrito_c");
            entity.Property(e => e.IdProvinciaC)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IdProvincia_c");
            entity.Property(e => e.NombreNv)
                .HasMaxLength(45)
                .HasColumnName("Nombre_nv");

            entity.HasOne(d => d.IdProvinciaCNavigation).WithMany(p => p.Distritos)
                .HasForeignKey(d => d.IdProvinciaC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Distrito_Provincia");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.IdDocumentoI).HasName("PK__Document__44127E61DB9C4BDD");

            entity.ToTable("Documento");

            entity.Property(e => e.IdDocumentoI).HasColumnName("IdDocumento_i");
            entity.Property(e => e.EstadoC)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Estado_c");
            entity.Property(e => e.FechaAprovacionD)
                .HasColumnType("datetime")
                .HasColumnName("FechaAprovacion_d");
            entity.Property(e => e.FileAntecedentesPenalesBy)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("FileAntecedentesPenales_by");
            entity.Property(e => e.FileDocIdentidadBy)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("FileDocIdentidad_by");
            entity.Property(e => e.FileEquifaxBy)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("FileEquifax_by");
            entity.Property(e => e.FileReciboLuzAguaBy)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("FileReciboLuzAgua_by");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.IdGrupoI).HasName("PK__Grupo__275780A0BED05B0D");

            entity.ToTable("Grupo");

            entity.HasIndex(e => e.CodigoC, "UQ__Grupo__DB3716BA5CAA8F93").IsUnique();

            entity.Property(e => e.IdGrupoI).HasColumnName("IdGrupo_i");
            entity.Property(e => e.CantMaxIntegrantesI).HasColumnName("CantMaxIntegrantes_i");
            entity.Property(e => e.CantidadCuotasI).HasColumnName("CantidadCuotas_i");
            entity.Property(e => e.CodigoC)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Codigo_c");
            entity.Property(e => e.EstadoC)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Estado_c");
            entity.Property(e => e.FechaCreacionD)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FechaCreacion_d");
            entity.Property(e => e.FechaInicioPanderoD)
                .HasColumnType("datetime")
                .HasColumnName("FechaInicioPandero_d");
            entity.Property(e => e.IdModeloVehiculoI).HasColumnName("IdModeloVehiculo_i");
            entity.Property(e => e.PenalidadDc)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Penalidad_dc");
            entity.Property(e => e.PrecioUnidadVehiculoM)
                .HasColumnType("money")
                .HasColumnName("PrecioUnidadVehiculo_m");
            entity.Property(e => e.TipoPeriodoPagoC)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TipoPeriodoPago_c");

            entity.HasOne(d => d.IdModeloVehiculoINavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdModeloVehiculoI)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grupo_ModeloVehiculo");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarcaI).HasName("PK__Marca__3B76F9DD0B857905");

            entity.ToTable("Marca");

            entity.Property(e => e.IdMarcaI).HasColumnName("IdMarca_i");
            entity.Property(e => e.EstadoC)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Estado_c");
            entity.Property(e => e.NombreNv)
                .HasMaxLength(30)
                .HasColumnName("Nombre_nv");
            entity.Property(e => e.SitioWebNv)
                .HasMaxLength(100)
                .HasColumnName("SitioWeb_nv");
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.IdModeloVehiculoI).HasName("PK__Modelo__40D234696068800F");

            entity.ToTable("Modelo");

            entity.Property(e => e.IdModeloVehiculoI).HasColumnName("IdModeloVehiculo_i");
            entity.Property(e => e.IdMarcaI).HasColumnName("IdMarca_i");
            entity.Property(e => e.NombreNv)
                .HasMaxLength(50)
                .HasColumnName("Nombre_nv");
            entity.Property(e => e.PrecioUnidadVehiculoM)
                .HasColumnType("money")
                .HasColumnName("PrecioUnidadVehiculo_m");
            entity.Property(e => e.TipoC)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Tipo_c");

            entity.HasOne(d => d.IdMarcaINavigation).WithMany(p => p.Modelos)
                .HasForeignKey(d => d.IdMarcaI)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Modelo_Marca");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPaisI).HasName("PK__Pais__2A47731C0E23ADBB");

            entity.Property(e => e.IdPaisI)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IdPais_i");
            entity.Property(e => e.NombreNv)
                .HasMaxLength(50)
                .HasColumnName("Nombre_nv");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedorI).HasName("PK__Proveedo__D3B046979CB93ABE");

            entity.ToTable("Proveedor");

            entity.Property(e => e.IdProveedorI).HasColumnName("IdProveedor_i");
            entity.Property(e => e.CargoContactoNv)
                .HasMaxLength(15)
                .HasColumnName("CargoContacto_nv");
            entity.Property(e => e.ContactoV)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Contacto_v");
            entity.Property(e => e.DireccionNv)
                .HasMaxLength(120)
                .HasColumnName("Direccion_nv");
            entity.Property(e => e.IdPaisI)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IdPais_i");
            entity.Property(e => e.NombreNv)
                .HasMaxLength(80)
                .HasColumnName("Nombre_nv");

            entity.HasOne(d => d.IdPaisINavigation).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.IdPaisI)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proveedor_Pais");
        });

        modelBuilder.Entity<Provincium>(entity =>
        {
            entity.HasKey(e => e.IdProvinciaC).HasName("PK__Provinci__AE6D5BEAC72FCA58");

            entity.Property(e => e.IdProvinciaC)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IdProvincia_c");
            entity.Property(e => e.IdDepartamentoC)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IdDepartamento_c");
            entity.Property(e => e.NombreNv)
                .HasMaxLength(45)
                .HasColumnName("Nombre_nv");

            entity.HasOne(d => d.IdDepartamentoCNavigation).WithMany(p => p.Provincia)
                .HasForeignKey(d => d.IdDepartamentoC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Provincia_Departamento");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculoI).HasName("PK__Vehiculo__7084BEB41647FD2B");

            entity.ToTable("Vehiculo");

            entity.HasIndex(e => e.SerieNv, "UQ__Vehiculo__9C2AA6B26D7879BC").IsUnique();

            entity.HasIndex(e => e.PlacaC, "UQ__Vehiculo__D23C233A329B033F").IsUnique();

            entity.Property(e => e.IdVehiculoI).HasColumnName("IdVehiculo_i");
            entity.Property(e => e.AnioFabricacionD)
                .HasColumnType("date")
                .HasColumnName("AnioFabricacion_d");
            entity.Property(e => e.ColorC)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Color_c");
            entity.Property(e => e.EstadoC)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Estado_c");
            entity.Property(e => e.FechaIngresoD)
                .HasColumnType("datetime")
                .HasColumnName("FechaIngreso_d");
            entity.Property(e => e.IdModeloVehiculoI).HasColumnName("IdModeloVehiculo_i");
            entity.Property(e => e.IdProveedorI).HasColumnName("IdProveedor_i");
            entity.Property(e => e.PlacaC)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Placa_c");
            entity.Property(e => e.PrecioCompraVehiculoM)
                .HasColumnType("money")
                .HasColumnName("PrecioCompraVehiculo_m");
            entity.Property(e => e.SerieNv)
                .HasMaxLength(20)
                .HasColumnName("Serie_nv");

            entity.HasOne(d => d.IdModeloVehiculoINavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdModeloVehiculoI)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehiculo_Modelo");

            entity.HasOne(d => d.IdProveedorINavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdProveedorI)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehiculo_Proveedor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net.Webapi.Database.Entities;


namespace Net.Webapi.Database.Mapping
{
    partial class PessoalMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> b)
        {
            b.Property(e=>e.CPF)
            .HasColumnName("cpf")
                       .HasPrecision(11)
                       .HasColumnType("varchar");

            b.Property(e=>e.Idade)
            .HasColumnName("idade")
                .HasColumnType("integer");

            b.Property(e=>e.Nome)
            .HasColumnName("nome")
                .IsRequired()
                .HasPrecision(80)
                .HasColumnType("varchar");

            b.HasKey(e=>e.CPF);

            b.ToTable("pessoa", (string)null);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Webmotors.ApplicationCore.Domains;
using Webmotors.Infra.Extensions;

namespace Webmotors.Infra.Mapping
{
    public class AdMap : EntityTypeConfiguration<Ad>
    {
        public override void Map(EntityTypeBuilder<Ad> builder)
        {
            builder.ToTable("tb_AnuncioWebmotors");

            builder.HasKey(t => t.Id);

            builder.Property(x => x.Make).HasColumnName("marca").IsRequired();
            builder.Property(x => x.Model).HasColumnName("modelo").IsRequired();
            builder.Property(x => x.Version).HasColumnName("versao").IsRequired();
            builder.Property(x => x.YearModel).HasColumnName("ano").IsRequired();
            builder.Property(x => x.KM).HasColumnName("quilometragem").IsRequired();
            builder.Property(x => x.Note).HasColumnName("observacao").IsRequired();
        }
    }
}

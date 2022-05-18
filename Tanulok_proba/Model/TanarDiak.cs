using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tanulok_proba.Model
{
    public class TanarDiak : IEntityTypeConfiguration<TanarDiak>
    {
        public int Id { get; set; }
        public int DiakId { get; set; }
        public Diak Diak { get; set; }
        public int TanarId { get; set; }
        public Tanar Tanar { get; set; }

        public void Configure(EntityTypeBuilder<TanarDiak> builder)
        {
            builder.HasKey(td => new {td.TanarId,td.DiakId});
            builder.HasOne(td => td.Diak).WithMany(d => d.TanarDiak).HasForeignKey(td => td.DiakId);
            builder.HasOne(td => td.Tanar).WithMany(t => t.TanarDiak).HasForeignKey(td => td.TanarId);
        }
    }
}

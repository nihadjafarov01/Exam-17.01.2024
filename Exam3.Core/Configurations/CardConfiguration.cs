using Exam3.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Principal;

namespace Exam3.Core.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.Property(c => c.Title)
                .HasMaxLength(64);

            builder.Property(c => c.Description)
                .HasMaxLength(512);
        }
    }
}

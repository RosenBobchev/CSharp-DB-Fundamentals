using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.EntityConfig
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);

            builder.Property(s => s.Name)
                   .HasMaxLength(100)
                   .IsUnicode();

            builder.Property(s => s.PhoneNumber)
                   .HasColumnType("char(10)")
                   .IsRequired(false)
                   .IsUnicode(false);

            builder.Property(s => s.Birthday)
                   .IsRequired(false);

            builder.HasMany(x => x.CourseEnrollments)
                   .WithOne(x => x.Student)
                   .HasForeignKey(x => x.StudentId);

            builder.HasMany(x => x.HomeworkSubmissions)
                   .WithOne(x => x.Student)
                   .HasForeignKey(x => x.StudentId);
        }
    }
}

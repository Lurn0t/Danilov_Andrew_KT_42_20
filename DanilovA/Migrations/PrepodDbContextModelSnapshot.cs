﻿// <auto-generated />
using DanilovA.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DanilovA.Migrations
{
    [DbContext(typeof(PrepodDbContext))]
    partial class PrepodDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DanilovA.Models.Degree", b =>
                {
                    b.Property<int>("DegreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("degree_id")
                        .HasComment("Идентификатор записи ученой степени");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DegreeId"));

                    b.Property<string>("Name_degree")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(Max)")
                        .HasColumnName("c_name_degree")
                        .HasComment("Название ученой степени");

                    b.HasKey("DegreeId")
                        .HasName("pk_cd_degree_degree_id");

                    b.ToTable("Degree");
                });

            modelBuilder.Entity("DanilovA.Models.Kafedra", b =>
                {
                    b.Property<int>("KafedraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор записи кафедры")
                        .HasComment("Идентификатор записи кафедры");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KafedraId"));

                    b.Property<string>("KafedraName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(Max)")
                        .HasColumnName("Название кафедры")
                        .HasComment("Название кафедры");

                    b.HasKey("KafedraId")
                        .HasName("pk_cd_kafedra_kafedra_id");

                    b.ToTable("cd_kafedra", (string)null);
                });

            modelBuilder.Entity("DanilovA.Models.Prepod", b =>
                {
                    b.Property<int>("PrepodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("prepod_id")
                        .HasComment("Индетификатор записи преподавателя");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrepodId"));

                    b.Property<int>("DegreeId")
                        .HasColumnType("int")
                        .HasColumnName("degree_id")
                        .HasComment("Индетификатор ученой степени");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(Max)")
                        .HasColumnName("c_prepod_firstname")
                        .HasComment("Имя преподавателя");

                    b.Property<int>("KafedraId")
                        .HasColumnType("int")
                        .HasColumnName("kafedra_id")
                        .HasComment("Индетификатор кафедры");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(Max)")
                        .HasColumnName("c_prepod_lastname")
                        .HasComment("Фамилия преподавателя");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(Max)")
                        .HasColumnName("c_prepod_mail")
                        .HasComment("Эл. почта преподавателя");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(Max)")
                        .HasColumnName("c_prepod_middlename")
                        .HasComment("Отчество преподавателя");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(Max)")
                        .HasColumnName("c_prepod_telephone")
                        .HasComment("Номер телефона преподавателя");

                    b.HasKey("PrepodId")
                        .HasName("pk_cd_prepod_prepod_id");

                    b.HasIndex(new[] { "DegreeId" }, "idx_cd_prepod_fk_c_degree_id");

                    b.HasIndex(new[] { "KafedraId" }, "idx_cd_prepod_fk_c_kafedra_id");

                    b.ToTable("cd_prepod", (string)null);
                });

            modelBuilder.Entity("DanilovA.Models.Prepod", b =>
                {
                    b.HasOne("DanilovA.Models.Degree", "Degree")
                        .WithMany()
                        .HasForeignKey("DegreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_c_degree_id");

                    b.HasOne("DanilovA.Models.Kafedra", "Kafedra")
                        .WithMany()
                        .HasForeignKey("KafedraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_c_kafedra_id");

                    b.Navigation("Degree");

                    b.Navigation("Kafedra");
                });
#pragma warning restore 612, 618
        }
    }
}

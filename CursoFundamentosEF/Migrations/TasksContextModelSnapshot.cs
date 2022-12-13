﻿// <auto-generated />
using System;
using CursoFundamentosEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CursoFundamentosEF.Migrations
{
    [DbContext(typeof(TasksContext))]
    partial class TasksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CursoFundamentosEF.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("d22d110c-1064-4a0a-a654-1f5a0f0856ea"),
                            Description = "Category about financial activities",
                            Name = "Financial",
                            Weight = 10
                        },
                        new
                        {
                            CategoryId = new Guid("45f3c893-8e07-4e4c-9f34-fd63f9552636"),
                            Description = "Category about learn activities",
                            Name = "Learn",
                            Weight = 8
                        });
                });

            modelBuilder.Entity("CursoFundamentosEF.Models.Task", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("PriorityTask")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Task", (string)null);

                    b.HasData(
                        new
                        {
                            TaskId = new Guid("18c6b94f-5344-436b-b102-0301e98b1728"),
                            CategoryId = new Guid("d22d110c-1064-4a0a-a654-1f5a0f0856ea"),
                            CreatedAt = new DateTime(2022, 12, 13, 6, 23, 20, 362, DateTimeKind.Utc).AddTicks(1589),
                            PriorityTask = 3,
                            Title = "Check bills of gifts"
                        },
                        new
                        {
                            TaskId = new Guid("90a13ed7-c79f-4a67-a081-bbef420fcf0b"),
                            CategoryId = new Guid("45f3c893-8e07-4e4c-9f34-fd63f9552636"),
                            CreatedAt = new DateTime(2022, 12, 13, 6, 23, 20, 362, DateTimeKind.Utc).AddTicks(1593),
                            PriorityTask = 1,
                            Title = "Learn about compound interest"
                        });
                });

            modelBuilder.Entity("CursoFundamentosEF.Models.Task", b =>
                {
                    b.HasOne("CursoFundamentosEF.Models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CursoFundamentosEF.Models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}

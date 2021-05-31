﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using Hamporsesh.Infrastructure.Data.Context;

namespace Hamporsesh.Web.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20210418114625_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hamporsesh.Web.Data.Entites.Answer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.Property<int>("ShamsiDay")
                        .HasColumnType("int");

                    b.Property<int>("ShamsiMonth")
                        .HasColumnType("int");

                    b.Property<int>("ShamsiYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Hamporsesh.Web.Data.Entites.Choice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AnswerId")
                        .HasColumnType("bigint");

                    b.Property<long>("AnswereId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShamsiDay")
                        .HasColumnType("int");

                    b.Property<int>("ShamsiMonth")
                        .HasColumnType("int");

                    b.Property<int>("ShamsiYear")
                        .HasColumnType("int");

                    b.Property<long>("VisitorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("Hamporsesh.Web.Data.Entites.Poll", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShamsiDay")
                        .HasColumnType("int");

                    b.Property<int>("ShamsiMonth")
                        .HasColumnType("int");

                    b.Property<int>("ShamsiYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("Hamporsesh.Web.Data.Entites.Question", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("PollId")
                        .HasColumnType("bigint");

                    b.Property<int>("ShamsiDay")
                        .HasColumnType("int");

                    b.Property<int>("ShamsiMonth")
                        .HasColumnType("int");

                    b.Property<int>("ShamsiYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PollId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Hamporsesh.Web.Data.Entites.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShamsiDay")
                        .HasColumnType("int");

                    b.Property<int>("ShamsiMonth")
                        .HasColumnType("int");

                    b.Property<int>("ShamsiYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Hamporsesh.Web.Data.Entites.Visitor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("IP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShamsiDay")
                        .HasColumnType("int");

                    b.Property<int>("ShamsiMonth")
                        .HasColumnType("int");

                    b.Property<int>("ShamsiYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("Hamporsesh.Web.Data.Entites.Answer", b =>
                {
                    b.HasOne("Hamporsesh.Web.Data.Entites.Question", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hamporsesh.Web.Data.Entites.Choice", b =>
                {
                    b.HasOne("Hamporsesh.Web.Data.Entites.Answer", null)
                        .WithMany("Choices")
                        .HasForeignKey("AnswerId");
                });

            modelBuilder.Entity("Hamporsesh.Web.Data.Entites.Question", b =>
                {
                    b.HasOne("Hamporsesh.Web.Data.Entites.Poll", null)
                        .WithMany("Questions")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hamporsesh.Web.Data.Entites.Answer", b =>
                {
                    b.Navigation("Choices");
                });

            modelBuilder.Entity("Hamporsesh.Web.Data.Entites.Poll", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Hamporsesh.Web.Data.Entites.Question", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}

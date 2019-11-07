﻿// <auto-generated />
using System;
using KO.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KO.DAL.Migrations
{
    [DbContext(typeof(KO_DbContext))]
    partial class KO_DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("KO.Entities.Exam", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Header")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("KO.Entities.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreatedDate = new DateTime(2019, 11, 7, 12, 29, 11, 841, DateTimeKind.Local).AddTicks(6241),
                            IsDeleted = false,
                            Password = "123",
                            Username = "silan"
                        });
                });

            modelBuilder.Entity("KO.Entities.MemberExam", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ExamID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MemberID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ExamID");

                    b.HasIndex("MemberID");

                    b.ToTable("MemberExams");
                });

            modelBuilder.Entity("KO.Entities.Option", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OptionText")
                        .HasColumnType("TEXT");

                    b.Property<int>("QuestionID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("QuestionID");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("KO.Entities.Question", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ExamID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuestionText")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ExamID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("KO.Entities.MemberExam", b =>
                {
                    b.HasOne("KO.Entities.Exam", "Exam")
                        .WithMany("MemberExams")
                        .HasForeignKey("ExamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KO.Entities.Member", "Member")
                        .WithMany("MemberExams")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KO.Entities.Option", b =>
                {
                    b.HasOne("KO.Entities.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KO.Entities.Question", b =>
                {
                    b.HasOne("KO.Entities.Exam", "Exam")
                        .WithMany("Questions")
                        .HasForeignKey("ExamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

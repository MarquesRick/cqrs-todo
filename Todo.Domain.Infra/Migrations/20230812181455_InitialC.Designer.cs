﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Todo.Domain.Infra.Contexts;

#nullable disable

namespace Todo.Domain.Infra.Migrations
{
    [DbContext(typeof(SQLiteContext))]
    [Migration("20230812181455_InitialC")]
    partial class InitialC
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.18");

            modelBuilder.Entity("Todo.Domain.Entities.TodoItemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasMaxLength(160)
                        .HasColumnType("varchar(160)");

                    b.Property<string>("User")
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.HasKey("Id");

                    b.HasIndex("User");

                    b.ToTable("Todo", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}

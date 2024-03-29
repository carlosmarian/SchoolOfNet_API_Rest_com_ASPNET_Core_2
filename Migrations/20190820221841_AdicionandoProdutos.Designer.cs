﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolOfNet_API_Rest_com_ASPNET_Core_2.Data;

namespace SchoolOfNet_API_Rest_com_ASPNET_Core_2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190820221841_AdicionandoProdutos")]
    partial class AdicionandoProdutos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SchoolOfNet_API_Rest_com_ASPNET_Core_2.Models.Produto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<float>("Preco");

                    b.HasKey("ID");

                    b.ToTable("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;


namespace Isg_Mvc.Models{
    public class BlogContext :DbContext{

        public BlogContext(DbContextOptions<BlogContext> options): base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

            optionsBuilder.UseSqlServer("server=77.245.159.23\\MSSQLSERVER2019;Database=ISG_DB;user Id=isg_odev;Password=Tx?9io52;");

        }


        public DbSet<Blog>Blog{get;set;}

        public DbSet<Author>Author{get;set;}

       


    }


}
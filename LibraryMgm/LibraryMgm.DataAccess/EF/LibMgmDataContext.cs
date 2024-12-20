﻿using LibraryMgm.Model.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LibraryMgm.DataAccess.EF
{
    public class LibMgmDataContext : DbContext
    {
        public LibMgmDataContext() : base("Conn_LibMgmDb")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Translator> Translators { get; set; }
    }
}

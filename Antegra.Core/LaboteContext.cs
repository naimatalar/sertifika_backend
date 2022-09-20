﻿using Labote.Core.Constants;
using Labote.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace Labote.Core
{
    public class LaboteContext : IdentityDbContext<LaboteUser, UserRole, Guid>
    {

        public IConfiguration Configuration { get; }



        public LaboteContext()
        {

        }

        public LaboteContext(DbContextOptions<LaboteContext> options) : base(options)
        {


        }

        public DbSet<MenuModule> MenuModules { get; set; }
        public DbSet<UserMenuModule> UserMenuModules { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentFile> DocumentFiles { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<DocumentAppilication> DocumentAppilications { get; set; }






        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                string json = File.ReadAllText("appsettings.json");
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                string connectionString = jsonObj.ConnectionStrings.LaboteConnection.ToString();
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }






        public override bool Equals(object obj)
        {
            return obj is LaboteContext context &&
                   base.Equals(obj) &&
                   EqualityComparer<IConfiguration>.Default.Equals(Configuration, context.Configuration);
        }
    }

}


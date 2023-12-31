﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static QuanLyDeTai.Models.ThongBao;

namespace QuanLyDeTai.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<ThongBao> ThongBaos { set; get; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
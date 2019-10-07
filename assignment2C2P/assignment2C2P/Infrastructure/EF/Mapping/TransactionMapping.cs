﻿using assignment2C2P.Models.Transactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2C2P.Infrastructure.EF.Mapping
{
    public static class TransactionMapping
    {
        public static ModelBuilder TransactionMap(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Transaction>();
            entity.ToTable("Transactions");
            entity.Property(t => t.CurrencyCode).HasMaxLength(3);
            entity.Property(t => t.TransactionId).ValueGeneratedOnAdd();
            return modelBuilder;
        }
    }
}

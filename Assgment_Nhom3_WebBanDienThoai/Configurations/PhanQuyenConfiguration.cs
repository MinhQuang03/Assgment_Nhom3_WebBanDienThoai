﻿using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations
{
    public class PhanQuyenConfiguration : IEntityTypeConfiguration<PhanQuyen>
    {
        public void Configure(EntityTypeBuilder<PhanQuyen> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}

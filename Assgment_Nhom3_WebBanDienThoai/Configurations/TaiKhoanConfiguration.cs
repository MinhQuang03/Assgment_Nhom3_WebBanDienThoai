using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations
{
    public class TaiKhoanConfiguration : IEntityTypeConfiguration<TaiKhoan>
    {
        public void Configure(EntityTypeBuilder<TaiKhoan> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}

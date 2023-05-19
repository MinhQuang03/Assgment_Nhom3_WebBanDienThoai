using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations
{
    public class ChiTietSanPhamConfiguration : IEntityTypeConfiguration<ChiTietSanPham>
    {
        public void Configure(EntityTypeBuilder<ChiTietSanPham> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.BoNhoTrongs).WithMany().HasForeignKey(p => p.IdBoNhoTrong);

            builder.HasOne(p => p.ChatLieus).WithMany().HasForeignKey(p => p.IdChatLieu);

            builder.HasOne(p => p.ChipCPUs).WithMany().HasForeignKey(p => p.IdChipCPU);

            builder.HasOne(p => p.ChipGPUs ).WithMany().HasForeignKey(p => p.IdChipGPU);
        }
    }
}

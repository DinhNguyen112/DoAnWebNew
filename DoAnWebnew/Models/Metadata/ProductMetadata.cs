using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnWebnew.Models.Metadata
{
    public class ProductMetadata
    {
        [DisplayName("Mã sản phẩm")]
        public int ID_SP { get; set; }
        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage ="Tên không được để trống")]
        public string TENSP { get; set; }
        [DisplayName("Đơn giá")]
        [Required(ErrorMessage = "Đơn giá không được để trống")]
        public Nullable<double> GIA { get; set; }
        [DisplayName("Hình ảnh")]
        public string HINHANH { get; set; }
        [DisplayName("Hạn sử dụng")]
        public Nullable<System.DateTime> HANSUDUNG { get; set; }
        [DisplayName("Sẵn có")]
        public Nullable<bool> COSAN { get; set; }
        [DisplayName("Danh mục")]
        public Nullable<int> ID_LOAI { get; set; }
        [DisplayName("Mô tả")]
        public string MOTA { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnWebnew.Models.Metadata
{
    public class UserMetadata
    {
        [DisplayName("Tài Khoản")]
        [Required(ErrorMessage ="Tài khoản không được để trống")]
        public string USERNAME { get; set; }
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [MinLength(6,ErrorMessage ="Mật khẩu không được ngắn hơn 6 ký tự")]
        public string PASSWORD { get; set; }
    }
}
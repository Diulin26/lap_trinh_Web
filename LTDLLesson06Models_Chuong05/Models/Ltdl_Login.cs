using System.ComponentModel.DataAnnotations;

namespace LTDLLesson06Models.Models
{
    public class Ltdl_Login
    {
        public string LtdlUserName { get; set; } = "";

        [DataType(DataType.Password)]
        public string LtdlPassword { get; set; } = "";
    }
}

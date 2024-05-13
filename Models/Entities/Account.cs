using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC_crud.Models.Entities
{
    public class Account
    {
        [Key] // 將Account_ID設為主鍵
        public int Account_ID { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
    }
}

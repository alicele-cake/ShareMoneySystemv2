using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC_crud.Models.Entities
{
    public class Bill_Detail
    {
        [Key] // 將Bill_ID設為主鍵
        public int Bill_ID { get; set; }
        public string? Bill_Name { get; set; }
        public DateTime Date { get; set; } // 將Date資料型態更改為DateTime
    }
}

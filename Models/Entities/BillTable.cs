using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC_crud.Models.Entities
{
    public class BillTable
    {
        [Key] // 將ID設為主鍵
        public int Bill_ID { get; set; }
        public string Bill_Name { get; set; }
        public decimal Total_Amount { get; set; }
        public decimal Average_Amount { get; set; }
        public int Total_Users { get; set; }

    }
}

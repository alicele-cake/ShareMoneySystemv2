using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC_crud.Models.Entities
{
    public class Bill
    {
        [Key] // 將ID設為主鍵
        public int ID { get; set; }

        [ForeignKey("Bill_Detail")] // 設置外鍵關聯到Bill_Detail的Bill_ID
        public int Bill_ID { get; set; }

        [ForeignKey("Account")] // 設置外鍵關聯到Account的Account_ID
        public int Account_ID { get; set; }

        public float Money { get; set; }
    }
}

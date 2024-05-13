using System.ComponentModel.DataAnnotations;

namespace MVC_crud.Models.Entities
{
    public class Friends
    {
        [Key] // 將Account_ID設為主鍵
        public int F_ID { get; set; }
        public int Account_ID { get; set; }
        public int Friend_ID { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MVC_crud.Models.Entities
{
    public class CheckFriends
    {
        [Key] // 將Account_ID設為主鍵
        public int FriendCount { get; set; }
        //public int FriendName { get; set; }
    }
}

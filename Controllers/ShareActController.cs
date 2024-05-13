using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVC_crud.Data;
using MVC_crud.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace MVC_crud.Controllers
{
    public class ShareActController : Controller
    {
        private readonly MVCDBContext mvcDBContext;
        public ShareActController(MVCDBContext mvcDBContext)
        {
            this.mvcDBContext = mvcDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult createFriends()
        {
            return View();
        }

        public async Task<IActionResult> create()
        {
            int? accountID = HttpContext.Session.GetInt32("accountID");

            //顯示好友
            var sql = @"
SELECT Account.Account_ID, Account.Name, Account.Password
FROM Account
INNER JOIN Friends ON Account.Account_ID = Friends.Friend_ID
WHERE Friends.Account_ID = @user_ID;
";

            // 執行 SQL 查詢，並傳入使用者輸入的 CustomerID 參數
            List<Account>? accounts = await mvcDBContext.Accounts
                .FromSqlRaw(sql,new SqlParameter("@user_ID", accountID))
                .ToListAsync();

            return View(model: accounts);
        }

        [HttpPost]
        public async Task<IActionResult> create(string BillName,int Amount, List<int> selectedAccounts)
        {
            var currentTime = DateTime.Now;

            var sql = @"INSERT INTO Bill_Detail (Bill_Name, Date) VALUES  (@Bill_Name, @currentTime)";

            var accounts = await mvcDBContext.Database.ExecuteSqlRawAsync(sql,
                    new SqlParameter("@Bill_Name", BillName),
                    new SqlParameter("@currentTime", currentTime)
                );

            var Bill_ID_sql = @"SELECT * FROM Bill_Detail 
                                WHERE Bill_ID = (SELECT MAX(Bill_ID) FROM Bill_Detail);
";

            // 執行 SQL 查詢，並傳入使用者輸入的 CustomerID 參數
            List<Bill_Detail>? Bill_ID = await mvcDBContext.Bill_Details
                .FromSqlRaw(Bill_ID_sql)
                .ToListAsync();
            int newBillId = Bill_ID[0].Bill_ID;

            int? accountID = HttpContext.Session.GetInt32("accountID");

            decimal averageAmount = Amount;

            // 將選擇的帳號信息插入到 Bill 表中
            foreach (var accountId in selectedAccounts)
            {
                // 計算每個帳號應支付的平均金額
                averageAmount = Amount / (selectedAccounts.Count+1);

                var insertBillSql = @"INSERT INTO Bill (Bill_ID, Account_ID, Money) VALUES (@Bill_ID, @Account_ID, @Money);";
                await mvcDBContext.Database.ExecuteSqlRawAsync(insertBillSql,
                    new SqlParameter("@Bill_ID", newBillId),
                    new SqlParameter("@Account_ID", accountId),
                    new SqlParameter("@Money", averageAmount)); // 插入平均金額
            }

            //新增自己的帳單

            var insertMyBillSql = @"INSERT INTO Bill (Bill_ID, Account_ID, Money) VALUES (@Bill_ID, @Account_ID, @Money);";
            await mvcDBContext.Database.ExecuteSqlRawAsync(insertMyBillSql,
                new SqlParameter("@Bill_ID", newBillId),
                new SqlParameter("@Account_ID", accountID),
                new SqlParameter("@Money", averageAmount)); // 插入平均金額


            return RedirectToAction("systemView", "System");

        }


        [HttpPost]
        public async Task<IActionResult> createFriends(string FriendName)
        {
            
            int? accountID = HttpContext.Session.GetInt32("accountID");
            //檢查是否有朋友
            var sql = @"
SELECT COUNT(*) AS FriendCount
FROM Friends
WHERE Account_ID = @user_ID  
AND Friend_ID = (
    SELECT Account_ID
    FROM Account
    WHERE Name = @FriendName
);
";

            var CheckFriends = await mvcDBContext.CheckFriendss
                .FromSqlRaw(sql, new SqlParameter("@user_ID", accountID)
                , new SqlParameter("@FriendName", FriendName))
                .ToListAsync();


            //找朋友ID
            var F_sql = @"
SELECT *
FROM Account
WHERE Name = @FriendName;
";

            var CheckFriend_ID = await mvcDBContext.Accounts
                .FromSqlRaw(F_sql, new SqlParameter("@FriendName", FriendName))
                .ToListAsync();
            int Friend_ID = CheckFriend_ID[0].Account_ID;


            if (CheckFriends[0].FriendCount == 0)
            {
                //沒有加入朋友，則插入/加入
                // 將選擇的帳號信息插入到 Bill 表中

                var insertBillSql = @"INSERT INTO Friends (Account_ID, Friend_ID) VALUES (@user_ID, @Friend_ID)";
                await mvcDBContext.Database.ExecuteSqlRawAsync(insertBillSql,
                    new SqlParameter("@user_ID", accountID),
                    new SqlParameter("@Friend_ID", Friend_ID));
                return RedirectToAction("createFriends", "ShareAct");
            }


            
            

            return RedirectToAction("create", "ShareAct");

        }

    }
}

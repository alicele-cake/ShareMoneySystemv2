using Microsoft.AspNetCore.Mvc;
using MVC_crud.Models.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVC_crud.Data;
using Microsoft.AspNetCore.Http;


namespace MVC_crud.Controllers
{
    public class EnterController : Controller
    {
        private readonly MVCDBContext mvcDBContext;
        public EnterController(MVCDBContext mvcDBContext)
        {
            this.mvcDBContext = mvcDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult login()
        {
            return View();
        }

        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(string Name,string password)
        {
            var sql = @"
        select * from Account where Name = @user and Password = @password";

            // 執行 SQL 查詢，並傳入使用者輸入的 Name 和 password 參數
            var Details = await mvcDBContext.Accounts
                .FromSqlRaw(sql, new SqlParameter("@user", Name), new SqlParameter("@password", password))
                .FirstOrDefaultAsync(); // 只取第一個匹配的記錄

            if (Details != null)
            {
                int ID = Details.Account_ID;
                HttpContext.Session.SetInt32("accountID", ID); // 使用 SetInt32 方法將整數存入 Session
                return RedirectToAction("systemView", "System");
            }
            else
            {
                return View("login");
            }

        }

        [HttpPost]
        public async Task<IActionResult> register(string Name, string password,string checkP)
        {
            var check_sql = @"
        select * from Account where Name = @user";

            // 執行 SQL 查詢，並傳入使用者輸入的 CustomerID 參數
            var Details = await mvcDBContext.Accounts
                .FromSqlRaw(check_sql, new SqlParameter("@user", Name))
                .ToListAsync();
            if (checkP == password)
            {
                // 這裡可以將 customerDetails 傳遞給 View 或者進行其他處理
                if (Details.Count == 0)
                {
                    var sql = @"INSERT INTO Account (Name, Password) VALUES (@user, @password);";

                    // 執行 SQL 
                    var Create = await mvcDBContext.Database.ExecuteSqlRawAsync(sql,
                        new SqlParameter("@user", Name),
                        new SqlParameter("@password", password)
                    );

                    return RedirectToAction("login", "Enter");
                    //return View("login");

                }
            }
            else
            {
                return View("register");
            }

            return View("register");
        }



    }
}

using Microsoft.AspNetCore.Mvc;
using MVC_crud.Models.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVC_crud.Data;


namespace MVC_crud.Controllers
{
    public class SystemController : Controller
    {
        private readonly MVCDBContext mvcDBContext;
        public SystemController(MVCDBContext mvcDBContext)
        {
            this.mvcDBContext = mvcDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> systemView()
        {
            // 從 Session 中獲取帳號名稱
            int? accountID = HttpContext.Session.GetInt32("accountID");

            var sql = @"SELECT b.Bill_ID,bd.Bill_Name,bm.Total_Amount,bm.Average_Amount,bp.Total_Users 
                        FROM Bill b
                            INNER JOIN Bill_Detail bd ON b.Bill_ID = bd.Bill_ID
                            LEFT JOIN (
                                        SELECT Bill_ID,SUM(Money) AS Total_Amount,AVG(Money) AS Average_Amount
                                                FROM Bill
                                                    GROUP BY Bill_ID
                                       ) AS bm ON b.Bill_ID = bm.Bill_ID
                            LEFT JOIN (
                                        SELECT Bill_ID,COUNT(Account_ID) AS Total_Users 
                                                FROM Bill
                                                    GROUP BY Bill_ID
                                      ) AS bp ON b.Bill_ID = bp.Bill_ID
                        WHERE b.Account_ID = @user;

";

            // 執行 SQL 查詢，並傳入使用者輸入的 CustomerID 參數
            List<BillTable>? BillTable = await mvcDBContext.BillTables
                .FromSqlRaw(sql, new SqlParameter("@user", accountID))
                .ToListAsync();

            // 這裡可以將 customerDetails 傳遞給 View 或者進行其他處理
            if (BillTable != null)
            {
                return View(model: BillTable);
            }
            else
            {
                return View();
            }

        }

    }
}

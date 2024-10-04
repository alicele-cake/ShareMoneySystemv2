# 分帳系統(MVC架構)描述

**作品名稱:分帳系統(MVC架構)**

## 描述:
這是我的作品。

　　 **C#：** 主要程式語言。

　　 **ASP.NET Core MVC：** 主要的後端架構，程式使用了 MVC（Model-View-Controller）架構模式。

　　 **Entity Framework Core：** ORM（對象關係映射）框架，用於處理與資料庫的交互。

　　 **Razor 語法：** create.cshtml 文件使用 Razor 語法，用於在 ASP.NET 中在 HTML 裡嵌入 C# 的模板語言。

　　 **SQL：** 程式中多次使用 SQL 查詢來與資料庫交互。

## 功能:
　　帳號登入註冊
  
　　創造帳單(依人數分錢)

　　(使用資料庫)
  
　　使用CRUD方式處理資料
  
　　防SQL Injection

## 畫面:
帳號登入註冊:
https://youtu.be/-XaEBzolAEQ?si=t38Mi5VlgbTyRSu7


加入帳單好友:
https://youtu.be/0vgTHBfKTvo?si=CafElshQa93FgC_1
	
創造帳單:
https://youtu.be/dagi1BISU5k?si=sNQZftFrAY81ss7m

使用資料庫:
https://youtu.be/znzMo_mL6Pg?si=-FZMYsRE0szseFKW

## 環境:

## 資料夾說明:
#### Controllers:
　　 Controllers/HomeController.cs

　　 Controllers/EnterController.cs

　　 Controllers/ShareActController.cs

　　 Controllers/SystemController.cs



#### Models:
　　 Models/Entities/Account.cs : 帳號的類別

　　 Models/Entities/Bill.cs : 帳單的類別

　　 Models/Entities/BillTable.cs : 顯示全部選單的類別
 
　　 Models/Entities/Bill_Detail.cs

　　 Models/Entities/CheckFriends.cs : 朋友的類別

　　 Models/Entities/Friends.cs : 顯示擁有的朋友的類別 


#### Views:

　　 Views/Home/Index.cshtml

　　 Views/Enter/login.cshtml

　　 Views/Enter/register.cshtml


　　 Views/ShareAct/create.cshtml

　　 Views/ShareAct/createFriends.cshtml


　　 Views/System/systemView.cshtml


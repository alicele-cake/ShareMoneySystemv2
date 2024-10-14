# 分帳系統(MVC架構)

**作品名稱:分帳系統(MVC架構)**

## 描述:
在學校的課程(高效網頁課程)，根據上課內容(ASP.NET Core)，在期末成果發表前的半成品。

我負責後端，**C#** 為主要程式語言，給組員看得半成品程式(**此Github都是我寫的程式**)。



使用者案例圖:

![UseCaseDiagram2-1](https://github.com/user-attachments/assets/849fb59f-6cc8-40da-bf80-c20826e11b01)

## 功能:
　　帳號登入註冊
  
　　創造帳單(依人數分錢)

　　(使用資料庫)
  
　　使用CRUD方式處理資料
  
　　防SQL Injection

## 畫面:
帳號登入註冊:
https://youtu.be/-XaEBzolAEQ?si=t38Mi5VlgbTyRSu7


加入好友(分帳者):
https://youtu.be/0vgTHBfKTvo?si=CafElshQa93FgC_1
	
創造帳單:
https://youtu.be/dagi1BISU5k?si=sNQZftFrAY81ss7m

使用資料庫:
https://youtu.be/znzMo_mL6Pg?si=-FZMYsRE0szseFKW

## 環境:
Visual Studio 2022
## 資料夾說明:
#### Controllers:
　　 /HomeController.cs : 範本Controllers

　　 /EnterController.cs : 登入註冊與核對系統Controllers

　　 /ShareActController.cs : 添加帳單、朋友(分帳者)Controllers

　　 /SystemController.cs : 使用者帳單管理Controllers



#### Models:
　　 /Entities/Account.cs : 帳號的類別

　　 /Entities/Bill.cs : 對外顯示帳單資訊的類別

　　 /Entities/BillTable.cs : 某帳單的一部分資訊的類別
 
　　 /Entities/Bill_Detail.cs 一筆帳單的時間的類別

　　 /Entities/CheckFriends.cs : 朋友(分帳者)的類別

　　 Models/Entities/Friends.cs : 顯示擁有的朋友(分帳者)的類別 


#### 資料庫結構ERD:

![ERDDiagram1v3-1](https://github.com/user-attachments/assets/8bde7f9c-c9d6-4235-bf32-5822a771c534)





#### Views:

　　 /Home/Index.cshtml : 範本首頁UI(已自動調整其他UI為第一頁面)

　　 /Enter/login.cshtml : 登入UI(為第一頁面)

　　 /Enter/register.cshtml 註冊UI

　　 /Shared/_Layout.cshtml : 共用的導覽列 (Navbar) UI

　　 /ShareAct/create.cshtml : 建立帳單UI

　　 /ShareAct/createFriends.cshtml : 添加朋友(分帳者)UI

　　 /System/systemView.cshtml : 使用者的帳單管理UI


using System;
using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json; // 確保已經引入 Newtonsoft.Json
//Board: 代表公告版，每個 Board 有一個名稱（BoardName）和一個公告列表（Notices）。
//Notice: 代表每條公告，包含公告的ID、日期、標題和發布人。
//LoginInfo: 儲存登錄資訊，包含用戶名稱、今天的簽到時間和上次登錄時間。
//Leave: 儲存假期資訊，包含總時數、已排時數、未排時數、已休時數和剩餘假期百分比。
namespace JsonDemo1_1746
{
    class Program
    {
        static void Main(string[] args)
        {
            var boards = new List<Board>
            {
                new Board
                {
                    BoardName = "行政公告",
                    Notices = new List<Notice>
                    {
                        new Notice { ID = 1, Date = "2025-02-07", Title = "公告114年002號-修訂114年業績獎金、一般研發人員工作績效獎金、業務處行銷組獎金辦法及後勤人員工作績效獎金辦法", Issuer = "羅燕秋" },
                        new Notice { ID = 2, Date = "2025-02-07", Title = "公告114年001號-公告修訂『內部管理制度』、『內部稽核制度』、『永續發展實務守則』及『永續資訊管理與揭露作業辦法』公告114年001號-公告修訂內部管理制度", Issuer = "羅燕秋" },
                        new Notice { ID = 3, Date = "2024-12-03", Title = "公告113年010號-公布114年度自行檢查時間表", Issuer = "羅燕秋" }
                    }
                },
                new Board
                {
                    BoardName = "生活花絮",
                    Notices = new List<Notice>
                    {
                        new Notice { ID = 1, Date = "2024-11-26", Title = "113.11.23~24 員工旅遊照片來囉，讓我們一起重溫南投的美好時光!", Issuer = "林惠芳" }
                    }
                },
                new Board
                {
                    BoardName = "資安公告",
                    Notices = new List<Notice>
                    {
                        new Notice { ID = 1, Date = "2025-01-20", Title = "[資訊處公告]資安概念社交工程宣導篇", Issuer = "陳智民" }
                    }
                },
                new Board { BoardName = "內部推薦", Notices = new List<Notice>() },
                new Board { BoardName = "BU1 宣導", Notices = new List<Notice>() }
            };

            var loginInfo = new LoginInfo
            {
                UserName = "林子晴", // 登錄的用戶名稱
                TodayLogin = "08:30 ~ 09:33", // 今天簽到時間
                LastLogin = "查無紀錄" // 上次登錄紀錄
            };

            var leave = new Leave
            {
                UserName = "林子晴",
                Hours = 52,   //總時數
                Unscheduled = 52, //未排時數
                Scheduled = 0,    //已排時數
                Token = 0,        //已休時數
                RemainingPercent = "100%"  //剩餘幾%時數
            };

            var jsonData = new
            {
                Boards = boards,
                LoginInfo = loginInfo,
                Leave = leave
            };

            // 使用 JsonConvert.SerializeObject 方法將資料物件轉換為 JSON 字符串，並以縮排格式輸出。這樣可以使輸出的 JSON 格式更加可讀。
            //Formatting.Indented 是讓 JSON 產生後有「縮排」和「換行」
            string json = JsonConvert.SerializeObject(jsonData, (Newtonsoft.Json.Formatting)System.Xml.Formatting.Indented);

            // 輸出序列化後的 JSON 字串
            Console.WriteLine(json);
        }
    }

    public class Board
    {  /// <summary>
       /// 公告版名稱
       /// </summary>
        public string BoardName { get; set; }
        /// <summary>
        /// 公告板上的公告列表
        /// </summary>
        public List<Notice> Notices { get; set; }
    }

    public class Notice
    {
        /// <summary>
        /// 每個公告的唯一識別符
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 公告發布的日期
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        ///標題
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 發布人
        /// </summary>
        public string Issuer { get; set; }
    }

    public class LoginInfo
    {
        /// <summary>
        /// 登入的使用者名稱
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 本日簽到時間
        /// </summary>
        public string TodayLogin { get; set; }
        /// <summary>
        /// 上次登入的時間
        /// </summary>
        public string LastLogin { get; set; }
    }

    public class Leave
    {

        /// <summary>
        /// 同仁姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///總時數
        /// </summary>
        public int Hours { get; set; }

        /// <summary>
        /// 未排時數
        /// </summary>
        public int Unscheduled { get; set; }

        /// <summary>
        /// 已排時數
        /// </summary>
        public int Scheduled { get; set; }

        /// <summary>
        ///已休時數
        /// </summary>
        public int Token { get; set; }

        /// <summary>
        /// 剩餘%數
        /// </summary>
        public string RemainingPercent { get; set; }
    }
}

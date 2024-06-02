using System;
using System.Drawing.Drawing2D;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace 日曆
{
    public partial class choice : Form
    {
        private DateTime selectedDate; // 選擇的日期
        private List<Star> stars = new List<Star>(); // 星星列表，用於存儲星星物件
        private Random rand = new Random(); // 隨機數生成器
        private System.Windows.Forms.Timer starTimer; // 用於控制星星閃爍動畫的計時器

        public choice(DateTime diaryDate)
        {
            InitializeComponent();
            selectedDate = diaryDate;

            // 設置透明背景
            SetTransparentBackground(label1);
            SetTransparentBackground(pictureBox1);
            // 初始化星星
            InitializeStars();

            // 初始化星星閃爍動畫定時器
            starTimer = new System.Windows.Forms.Timer();
            starTimer.Interval = 50; // 更新間隔，單位是毫秒
            starTimer.Tick += new EventHandler(StarTimer_Tick); // 綁定計時器事件
            starTimer.Start(); // 啟動計時器

            this.DoubleBuffered = true; // 減少閃爍
        }

        // 設置透明背景的方法
        private void SetTransparentBackground(Control control)
        {
            // 設置 Label 和 PictureBox 背景透明
            label1.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;

            // 確保 Label 和 PictureBox 的父控件是 Form
            this.Controls.Add(label1);
            this.Controls.Add(pictureBox1);
        }

        // 初始化星星的方法
        private void InitializeStars()
        {
            int numStars = 100; // 星星數量
            for (int i = 0; i < numStars; i++)
            {
                int x = rand.Next(this.Width); // 隨機生成星星的 X 座標
                int y = rand.Next(this.Height); // 隨機生成星星的 Y 座標
                float brightness = (float)rand.NextDouble(); // 隨機生成星星的亮度
                int size = rand.Next(2, 6); // 隨機生成星星的大小
                stars.Add(new Star(x, y, brightness, size)); // 將星星加入星星列表
            }
        }

        // 會計按鈕點擊事件處理方法
        private void accountingbutton_Click(object sender, EventArgs e)
        {
            if (DairyManager.AccountingExists(selectedDate)) // 如果選定日期有會計記錄
            {
                Form2 accounting = new Form2(selectedDate); // 創建新的會計表單
                accounting.Owner = this;
                accounting.OpenaccountingForm(selectedDate); // 打開會計記錄表單
                accounting.ShowDialog(); // 以對話框形式顯示表單
            }
            else
            {
                Form2 accountingForm = new Form2(selectedDate); // 創建新的會計表單
                accountingForm.Show(); // 顯示表單
            }
        }

        // 日記按鈕點擊事件處理方法
        private void diarybutton_Click(object sender, EventArgs e)
        {
            if (DairyManager.DiaryExists(selectedDate)) // 如果選定日期有日記
            {
                diarycs diarycs = new diarycs(selectedDate); // 創建新的日記表單
                diarycs.Owner = this;
                diarycs.OpenDiaryForm(selectedDate); // 打開日記表單
                diarycs.ShowDialog(); // 以對話框形式顯示表單
            }
            else
            {
                OpenNewDiaryForm(selectedDate); // 打開新的日記表單
            }
        }

        // 打開新的日記表單的方法
        public void OpenNewDiaryForm(DateTime selectedDate)
        {
            diarycs diaryForm = new diarycs(selectedDate); // 創建新的日記表單
            diaryForm.Owner = this;
            diaryForm.SetDateTimePickerValue(selectedDate); // 設置日期選擇器的值
            diaryForm.ShowDialog(); // 以對話框形式顯示表單
        }

        // DiaryManager 靜態類別，用於管理日記和會計記錄
        public static class DiaryManager
        {
            private static Dictionary<DateTime, string> diaryEntries = new Dictionary<DateTime, string>(); // 用於存儲日記條目的字典，鍵為日期，值為日記內容

            public static string DiariesFolder { get; internal set; } // 定義日記文件夾屬性

            // 獲取指定日期的日記內容
            public static string GetDiaryContent(DateTime date)
            {
                if (diaryEntries.ContainsKey(date))
                {
                    return diaryEntries[date]; // 返回日記內容
                }
                else
                {
                    return null; // 如果沒有日記，返回 null
                }
            }

            // 添加或更新指定日期的日記條目
            public static void AddDiaryEntry(DateTime date, string content)
            {
                diaryEntries[date] = content; // 添加或更新日記條目
            }
        }

        // 星星閃爍動畫的計時器事件處理方法
        private void StarTimer_Tick(object sender, EventArgs e)
        {
            foreach (var star in stars)
            {
                if (star.Increasing) // 如果星星正在變亮
                {
                    star.Brightness += 0.05f; // 增加亮度
                    if (star.Brightness >= 1) // 如果亮度達到最大值
                    {
                        star.Brightness = 1;
                        star.Increasing = false; // 開始變暗
                    }
                }
                else // 如果星星正在變暗
                {
                    star.Brightness -= 0.05f; // 減少亮度
                    if (star.Brightness <= 0) // 如果亮度達到最小值
                    {
                        star.Brightness = 0;
                        star.Increasing = true; // 開始變亮
                    }
                }
            }
            this.Invalidate(); // 觸發重繪
        }

        // 重寫 OnPaint 方法，用於自定義繪製
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 繪製漸變背景
            using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(0, 0, 64), Color.FromArgb(128, 0, 128), LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle); // 用漸變顏色填充背景
            }

            // 繪製星星
            foreach (var star in stars)
            {
                Color starColor = Color.FromArgb((int)(star.Brightness * 255), Color.Yellow); // 根據亮度設置星星顏色
                using (Brush brush = new SolidBrush(starColor))
                {
                    e.Graphics.FillEllipse(brush, star.X, star.Y, star.Size, star.Size); // 繪製星星
                }
            }
        }
    }

    // 星星類別，表示每顆星星的屬性和行為
    public class Star
    {
        public int X { get; set; } // 星星的 X 座標
        public int Y { get; set; } // 星星的 Y 座標
        public float Brightness { get; set; } // 星星的亮度
        public int Size { get; set; } // 星星的大小
        public bool Increasing { get; set; } // 星星的亮度是否在增加

        // 構造函數，初始化星星的位置、亮度、大小和閃爍狀態
        public Star(int x, int y, float brightness, int size)
        {
            X = x;
            Y = y;
            Brightness = brightness;
            Size = size;
            Increasing = true; // 初始狀態為亮度增加
        }
    }
}

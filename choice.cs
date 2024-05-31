using System;
using System.Drawing.Drawing2D;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace 日曆
{
    public partial class choice : Form
    {
        private DateTime selectedDate;
        private List<Star> stars = new List<Star>();
        private Random rand = new Random();
        private System.Windows.Forms.Timer starTimer;

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
            starTimer.Tick += new EventHandler(StarTimer_Tick);
            starTimer.Start();

            this.DoubleBuffered = true; // 減少閃爍
        }
        private void SetTransparentBackground(Control control)
        {
            // 設置 Label 和 PictureBox 背景透明
            label1.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;

            // 確保 Label 和 PictureBox 的父控件是 Form
            this.Controls.Add(label1);
            this.Controls.Add(pictureBox1);
        }
        private void InitializeStars()
        {
            int numStars = 100; // 星星數量
            for (int i = 0; i < numStars; i++)
            {
                int x = rand.Next(this.Width);
                int y = rand.Next(this.Height);
                float brightness = (float)rand.NextDouble();
                int size = rand.Next(2, 6);
                stars.Add(new Star(x, y, brightness, size));
            }
        }
        private void accountingbutton_Click(object sender, EventArgs e)
        {
            if (DairyManager.AccountingExists(selectedDate))
            {
                Form2 accounting = new Form2(selectedDate);
                accounting.Owner = this;
                accounting.OpenaccountingForm(selectedDate);
                accounting.ShowDialog();
            }
            else
            {
                Form2 accountingForm = new Form2(selectedDate);
                accountingForm.Show();
            }
        }

        private void diarybutton_Click(object sender, EventArgs e)
        {
            if (DairyManager.DiaryExists(selectedDate))
            {
                diarycs diarycs = new diarycs(selectedDate);
                diarycs.Owner = this;
                diarycs.OpenDiaryForm(selectedDate);
                diarycs.ShowDialog();
            }
            else
            {
                OpenNewDiaryForm(selectedDate);
            }
        }

        public void OpenNewDiaryForm(DateTime selectedDate)
        {
            diarycs diaryForm = new diarycs(selectedDate);
            diaryForm.Owner = this;
            diaryForm.SetDateTimePickerValue(selectedDate);
            diaryForm.ShowDialog();
        }

        public static class DiaryManager
        {
            private static Dictionary<DateTime, string> diaryEntries = new Dictionary<DateTime, string>();

            public static string DiariesFolder { get; internal set; }

            public static string GetDiaryContent(DateTime date)
            {
                if (diaryEntries.ContainsKey(date))
                {
                    return diaryEntries[date];
                }
                else
                {
                    return null;
                }
            }

            public static void AddDiaryEntry(DateTime date, string content)
            {
                diaryEntries[date] = content;
            }
        }

        private void StarTimer_Tick(object sender, EventArgs e)
        {
            foreach (var star in stars)
            {
                if (star.Increasing)
                {
                    star.Brightness += 0.05f;
                    if (star.Brightness >= 1)
                    {
                        star.Brightness = 1;
                        star.Increasing = false;
                    }
                }
                else
                {
                    star.Brightness -= 0.05f;
                    if (star.Brightness <= 0)
                    {
                        star.Brightness = 0;
                        star.Increasing = true;
                    }
                }
            }
            this.Invalidate(); // 觸發重繪
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 绘制渐变背景
            using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(0, 0, 64), Color.FromArgb(128, 0, 128), LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }

            // 繪製星星
            foreach (var star in stars)
            {
                Color starColor = Color.FromArgb((int)(star.Brightness * 255), Color.Yellow);
                using (Brush brush = new SolidBrush(starColor))
                {
                    e.Graphics.FillEllipse(brush, star.X, star.Y, star.Size, star.Size);
                }
            }
        }
    }
    public class Star
    {
        public int X { get; set; }
        public int Y { get; set; }
        public float Brightness { get; set; }
        public int Size { get; set; }
        public bool Increasing { get; set; }

        public Star(int x, int y, float brightness, int size)
        {
            X = x;
            Y = y;
            Brightness = brightness;
            Size = size;
            Increasing = true;
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 日曆
{
    public partial class memorycs : Form
    {
        public memorycs()
        {
            InitializeComponent();
            memoListBox.DrawItem += memoListBox_DrawItem;
            SetStaticGradientBackground();
        }
        private void SetStaticGradientBackground()
        {
            // 定義極光顏色
            Color[] auroraColors = {
                Color.FromArgb(150, 0, 40, 80), // 深藍色
                Color.FromArgb(150, 0, 120, 60), // 深綠色
                Color.FromArgb(150, 0, 80, 100) // 藍綠色
            };

            // 創建線性漸層筆刷
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.Black, Color.Black, 0F);
            ColorBlend blend = new ColorBlend();
            blend.Positions = new float[] { 0, 0.5f, 1 };
            blend.Colors = auroraColors;
            brush.InterpolationColors = blend;

            // 設置表單的背景為線性漸層筆刷
            this.BackgroundImage = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(this.BackgroundImage);
            g.FillRectangle(brush, this.ClientRectangle);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            InitializeDiariesFolder();
            getset entry = new getset
            {
                title = this.title.Text,
                Memo = Memo.Text,
                Date = DateTime.Today // 记录当前日期，不包含时间
            };

            // 创建存储文件夹的路径
            string folderPath = Path.Combine(Environment.CurrentDirectory, "memory");

            // 如果文件夹不存在，则创建
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // 创建文件路径
            string filePath = Path.Combine(folderPath, this.title.Text + ".json");

            // 创建 JSON 格式的字符串
            string json = JsonConvert.SerializeObject(entry);

            // 写入文件
            File.WriteAllText(filePath, json);

            // 提示用户保存成功
            MessageBox.Show("備忘錄儲存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            memoListBox.Items.Add($"{entry.title} ({entry.Date:yyyy-MM-dd})");

            this.title.Text = null;
            Memo.Text = null;
        }


        public const string memoryfolder = "memory";
        private static void InitializeDiariesFolder()
        {

            if (!Directory.Exists(memoryfolder))
            {
                Directory.CreateDirectory(memoryfolder);
            }
        }



        private void MemoListBox_Click(object sender, EventArgs e)
        {
            // 从 ListBox 选择的项中提取标题，忽略日期部分
            string selectedItem = memoListBox.SelectedItem.ToString();
            string selectedTitle = selectedItem.Substring(0, selectedItem.LastIndexOf(" (")); // 去掉日期部分

            string folderPath = Path.Combine(Environment.CurrentDirectory, "memory");
            string filePath = Path.Combine(folderPath, selectedTitle + ".json");

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                getset entry = JsonConvert.DeserializeObject<getset>(json);

                // 在此处使用 entry 对象，例如显示到 UI 中
                this.title.Text = entry.title;
                Memo.Text = entry.Memo;
            }
            else
            {
                MessageBox.Show("File not found.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.title.Text = "";
            Memo.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 创建存储文件夹的路径
            string folderPath = Path.Combine(Environment.CurrentDirectory, "memory");

            // 如果文件夹存在，则加载其中的文件
            if (Directory.Exists(folderPath))
            {
                var files = Directory.GetFiles(folderPath, "*.json");
                foreach (var file in files)
                {
                    string json = File.ReadAllText(file);
                    getset entry = JsonConvert.DeserializeObject<getset>(json);
                    memoListBox.Items.Add($"{entry.title} ({entry.Date:yyyy-MM-dd})");
                }
            }
        }

        private void deletebutton3_Click(object sender, EventArgs e)
        {
            if (memoListBox.SelectedItem != null)
            {
                // 从 ListBox 选择的项中提取标题，忽略日期部分
                string selectedItem = memoListBox.SelectedItem.ToString();
                string selectedTitle = selectedItem.Substring(0, selectedItem.LastIndexOf(" (")); // 去掉日期部分

                string folderPath = Path.Combine(Environment.CurrentDirectory, "memory");
                string filePath = Path.Combine(folderPath, selectedTitle + ".json");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    memoListBox.Items.Remove(selectedItem);
                    this.title.Text = "";
                    Memo.Text = "";
                    MessageBox.Show("備忘錄已刪除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("File not found.");
                }
            }
            else
            {
                MessageBox.Show("請選擇要刪除的備忘錄。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void memoListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // 获取当前项的文本
            string itemText = memoListBox.Items[e.Index].ToString();

            // 分离标题和日期
            int indexOfDate = itemText.LastIndexOf(" (");
            string title = itemText.Substring(0, indexOfDate);
            string date = itemText.Substring(indexOfDate);

            // 绘制背景
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds); // 选中的背景色
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(e.BackColor), e.Bounds); // 默认背景色
            }

            // 定义字体和颜色
            Font titleFont = e.Font;
            Font dateFont = new Font(e.Font.FontFamily, e.Font.Size - 4);
            Brush titleBrush = new SolidBrush(e.ForeColor);
            Brush dateBrush = Brushes.Gray;

            // 如果项被选中，则改变文字颜色和字体粗细
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                titleFont = new Font(e.Font, FontStyle.Bold);
                dateFont = new Font(e.Font.FontFamily, e.Font.Size - 2, FontStyle.Bold);
                titleBrush = new SolidBrush(Color.FromArgb(0, 121, 121)); // #007979
                dateBrush = new SolidBrush(Color.FromArgb(0, 121, 121)); // #007979
            }

            // 绘制标题
            e.Graphics.DrawString(title, titleFont, titleBrush, e.Bounds.X, e.Bounds.Y);

            // 计算日期部分的绘制位置
            SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
            float dateX = e.Bounds.X + titleSize.Width + 5; // 5 是间隔
            float dateY = e.Bounds.Y;

            // 绘制日期
            e.Graphics.DrawString(date, dateFont, dateBrush, dateX, dateY);

            // 绘制焦点矩形框
            e.DrawFocusRectangle();
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            title.Text = ""; // 清空标题文本框
            Memo.Text = "";  // 清空备忘录文本框
        }
    }
}

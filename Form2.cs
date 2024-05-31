using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;


namespace 日曆
{
    public partial class Form2 : Form
    {
        private DateTime _selectedDate;
        private List<Expense> expenses = new List<Expense>();

        public Form2(DateTime selectedDate)
        {
            // 初始化表單元件
            InitializeComponent();
            // 將選擇的日期賦值給私有變數 _selectedDate
            _selectedDate = selectedDate;
            // 設置日期選擇器 (dateTimePicker1) 的值為選擇的日期
            dateTimePicker1.Value = selectedDate;
            // 打開並加載指定日期的記帳表單
            OpenaccountingForm(_selectedDate);
            // 初始化圓餅圖 (chart1)
            InitializeChart();
            // 更新圓餅圖顯示的資料
            UpdateChart();
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
        private void addAccountButton_Click(object sender, EventArgs e)
        {
            // 從介面中獲取開銷名稱和金額
            string expenseName = accountNameTextBox.Text;
            decimal amount;
            //金額要是數字
            bool isAmountValid = decimal.TryParse(initialBalanceTextBox.Text, out amount);
            // 檢查初始金額有沒有效
            if (isAmountValid)
            {
                // 如果初始金額有效，則創建一個新的 Expense 對象
                Expense newExpense = new Expense(expenseName, amount, _selectedDate);
                // 將新的 Expense 對象添加到 expenses 列表中
                expenses.Add(newExpense);
                // 更新 DataGridView 控制項顯示的資料
                UpdateDataGridView();
                // 清空帳戶名稱和初始金額文本框
                accountNameTextBox.Text = string.Empty;
                initialBalanceTextBox.Text = string.Empty;
                // 更新 DataGridView 控制項和圖表顯示的資料
                UpdateDataGridView();
                UpdateChart();
            }
            else
            {
                // 如果初始金額無效(不是數字)，則顯示錯誤訊息
                MessageBox.Show("請輸入有效的金額。");
            }

        }

        private void UpdateDataGridView()
        {
            // 清空 DataGridView 中現有的行
            accountsDataGridView.Rows.Clear();
            // 逐一檢查 expenses 列表中的每個支出項目，並將其添加到 DataGridView 中
            foreach (var expense in expenses)
            {
                accountsDataGridView.Rows.Add(expense.Name, expense.Amount);
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            // 初始化總和變量
            double total = 0.0;
            // 逐一檢查 DataGridView 的每一行資料紀錄
            foreach (DataGridViewRow row in accountsDataGridView.Rows)
            {
                // 檢查當前行是否不是新行且金額欄位不為空
                // 嘗試將金額欄位轉換為 double
                if (!row.IsNewRow && row.Cells["Amount"].Value != null && double.TryParse(row.Cells["Amount"].Value.ToString(), out double amount))
                {
                    // 如果成功，則將金額加到總和中
                    total += amount;
                }
            }
            MessageBox.Show("總和：" + total.ToString("C"), "總和", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            // 創建一個新的 List<accountingentery> 來存儲會計項目
            List<accountingentery> accountingEntries = new List<accountingentery>();
            // 逐一檢查 DataGridView 的每一行資料紀錄
            foreach (DataGridViewRow row in accountsDataGridView.Rows)
            {
                // 如果不是新的一行
                if (!row.IsNewRow)
                {
                    // 創建一個新的 accountingentery 對象，將該行的數據添加到對象中
                    accountingentery entry = new accountingentery
                    {
                        // 設置日期為 dateTimePicker1 的值
                        Date = dateTimePicker1.Value,
                        // 獲取名為 "NameColumn" 的列的值作為 ExpenseName
                        ExpenseName = row.Cells["NameColumn"].Value.ToString(),
                        // 將 "Amount" 列的值轉換為 decimal 並設置為 Amount
                        Amount = Convert.ToDecimal(row.Cells["Amount"].Value)
                    };
                    // 將創建的 accountingentery 對象添加到 List 中
                    accountingEntries.Add(entry);

                }
            }
            // 將上述紀錄保存到文件中
            DairyManager.accoutingSaveToFile(accountingEntries, _selectedDate);
            // 顯示保存成功的訊息框
            MessageBox.Show("記帳儲存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void OpenaccountingForm(DateTime selectedDate)
        {
            // 文件路徑
            string fileName = selectedDate.ToString("yyyy-MM-dd") + ".json";
            string filePath = Path.Combine(DairyManager.accountingFolder, fileName);

            try
            {
                // 檢查文件路徑存不存在
                if (File.Exists(filePath))
                {
                    // 如果文件存在，讀取文件內容
                    string json = File.ReadAllText(filePath);
                    // 將 JSON 字符串轉換為 List<accountingentery> 對象
                    List<accountingentery> entries = JsonConvert.DeserializeObject<List<accountingentery>>(json);

                    // 清空現有資料
                    expenses.Clear();
                    accountsDataGridView.Rows.Clear();
                    // 將文件中的會計項目添加到 DataGridView 中
                    foreach (var entry in entries)
                    {
                        accountsDataGridView.Rows.Add(entry.ExpenseName, entry.Amount);
                    }
                    // 將文件中的會計項目轉換為 Expense 對象並添加到 expenses 列表中
                    expenses = entries.Select(entry => new Expense(entry.ExpenseName, entry.Amount, entry.Date)).ToList();
                    // 更新圖表
                    UpdateChart();
                }
                else
                {
                    // 如果文件不存在，清空現有資料並更新圖表
                    expenses.Clear();
                    accountsDataGridView.Rows.Clear();
                    UpdateChart();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // 更新 _selectedDate 變數為 DateTimePicker 控制項的值
            _selectedDate = dateTimePicker1.Value;
            // 調用 OpenaccountingForm 方法，打開選定日期的記帳表單
            OpenaccountingForm(_selectedDate);
        }

        private void deletebutton1_Click(object sender, EventArgs e)
        {
            //逐一檢查逐一檢查使用者選擇的資料紀錄
            foreach (DataGridViewRow row in accountsDataGridView.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    var expenseName = row.Cells["NameColumn"].Value.ToString();

                    // 檢查所選行是否不是新行
                    accountsDataGridView.Rows.Remove(row);

                    // 獲取支出名稱
                    var expenseToRemove = expenses.FirstOrDefault(expense => expense.Name == expenseName);
                    if (expenseToRemove != null)
                    {
                        expenses.Remove(expenseToRemove);
                    }

                    // 從圓餅圖中移除相應的資料
                    RemoveFromChart(expenseName);
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {

            accountsDataGridView.Rows.Clear(); // 清除 DataGridView 內容
            expenses.Clear(); // 清空 expenses 列表
            InitializeChart(); // 更新圖表
        }
        private void InitializeChart()
        {
            chart1.Series.Clear(); // 清空圓餅圖中現有的系列
            Series series = chart1.Series.Add("Expenses"); // 添加一個名為 "Expenses" 的新系列
            series.ChartType = SeriesChartType.Pie; // 設置系列的圖表類型為圓餅圖
            series.IsValueShownAsLabel = true; // 將數值顯示為標籤
        }

        private void UpdateChart()
        {
            // 清空圓餅圖中現有的資料點
            chart1.Series["Expenses"].Points.Clear();
            //將expenses 以 Name 進行分组，計算每個支出跟相對應的總金額
            var expenseGroups = expenses.GroupBy(e => e.Name).Select(g => new
            {
                Name = g.Key,
                Total = g.Sum(e => e.Amount)
            });
            //將計算的資料添加到圓餅圖中
            foreach (var group in expenseGroups)
            {
                chart1.Series["Expenses"].Points.AddXY(group.Name, group.Total);
            }
        }

        private void RemoveFromChart(string itemName)
        {
            // 移除指定項目名稱對應的資料點
            var pointToRemove = chart1.Series["Expenses"].Points.FirstOrDefault(point => point.AxisLabel == itemName);
            if (pointToRemove != null)
            {
                chart1.Series["Expenses"].Points.Remove(pointToRemove);
            }
        }
        public class Expense
        {
            public string Name { get; set; } //開銷名稱為字串類型
            public decimal Amount { get; set; } //金額為時進制數字
            public DateTime Date { get; set; } //日期為日期時間類型

            public Expense(string name, decimal amount, DateTime date)
            {
                Name = name;
                Amount = amount;
                Date = date;
            }
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            

        }

    }
}

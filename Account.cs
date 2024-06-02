using System;

namespace 日曆
{
    internal class Expense
    {
        // 定義名稱屬性，自動實現的屬性
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        // 構造函數，接受三個參數：name, amount 和 date，並初始化相應的屬性
        public Expense(string name, decimal amount, DateTime date)
        {
            Name = name; // 初始化開支名稱
            Amount = amount; // 初始化開支金額
            Date = date; // 初始化開支日期
        }
    }
}

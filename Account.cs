using System;

namespace 日曆
{
    internal class Expense
    {
        // 定义名称属性，自动实现的属性
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        // 构造函数，接受三个参数：name, amount 和 date，并初始化相应的属性
        public Expense(string name, decimal amount, DateTime date)
        {
            Name = name;
            Amount = amount;
            Date = date;
        }
    }
}

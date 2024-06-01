using System;

namespace 日曆
{
    internal class accountingentery
    {
        // 定义名称属性，自动实现的属性
        public DateTime Date { get; set; }
        public string ExpenseName { get; set; }
        public decimal Amount { get; set; }

        // 重写 ToString 方法，返回包含日期、项目名称和金额的字符串
        public override string ToString()
        {
            return $"日期: {Date}, 項目: {ExpenseName}, 價錢: {Amount:C}";
        }
    }

}

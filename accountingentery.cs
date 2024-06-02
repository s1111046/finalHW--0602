using System;

namespace 日曆
{
    internal class accountingentery
    {
        // 定義名稱屬性，自動實現的屬性
        public DateTime Date { get; set; }
       
        public string ExpenseName { get; set; }
        
        public decimal Amount { get; set; }

        // 重寫 ToString 方法，返回包含日期、項目名稱和金額的字符串
        public override string ToString()
        {
            return $"日期: {Date}, 項目: {ExpenseName}, 價錢: {Amount:C}";
        }
    }
}

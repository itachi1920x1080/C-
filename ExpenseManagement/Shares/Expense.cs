

using System.Text.Json;

namespace Shares
{
    public class Expense(string code, double amount, string descr)
    {
        public string Code { get; set; } = code;
        public double Amount { get; set; } = amount;
        public string Descr { get; set; } = descr;

        public Expense(): this("", 0, "") { }

    }
}

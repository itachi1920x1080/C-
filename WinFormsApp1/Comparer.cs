public class codecomparer : IComparer<Expense>
{
    public int Compare(Expense x, Expense y)
    {
        if (x.code < y.code) return -1;
        else if (x.code > y.code) return 1;
        else return 0;
    }
}
public class Amountcomparer : IComparer<Expense>
{
    public int Compare(Expense x, Expense y)
    {
        if (x.Amount < y.Amount) return -1;
        else if (x.Amount > y.Amount) return 1;
        else return 0;
    }
}
public class Descrcomparer : IComparer<Expense>
{
    public int Compare(Expense x, Expense y)
    {
        return string.Compare(x.Descr, y.Descr);
    }

}

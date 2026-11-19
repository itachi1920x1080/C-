using System;
using System.Security.Cryptography.X509Certificates;

public class Expense
{
    public int code { get; set; }
    public double Amount { get; set; }
    public string Descr { get; set; }
    public override string ToString()
    {
        return $"Code: {code}, Amount: {Amount}, Description: {Descr}";
    }
}



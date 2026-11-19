namespace ProductLib;

public class Product
{
    public static string DataSeparator { get; set; } = "/";

    public long No { get; set; } = 0;
    public string Name { get; set; } = "";
    public virtual double Price { get; set; } = 0.0;

    public Product Clone()
    {
        return new Product()
        {
            No = No,
            Name = Name,
            Price = Price,
        };
    }  
    public virtual bool SetData(long no, string name, double price)
    {
        No = no;
        Name = name;
        Price = price;
        return true;
    }
    public virtual bool SetData(string data)
    {
        string[] arr = data.Split(Product.DataSeparator);
        if (arr.Length < 3) return false;
        if (long.TryParse(arr[0], out long no) == false) return false;
        string name = arr[1].Trim();
        if (double.TryParse(arr[2], out double price) == false) return false;
        return this.SetData(no, name, price);
    }

    public virtual string Info => $"{No}{Product.DataSeparator}{Name}{Product.DataSeparator}{Price}";

    public override int GetHashCode()
    {
        return No.GetHashCode();
    }
    public override bool Equals(object? obj)
    {
        if (obj is Product other)
        {
            return No == other.No;
        }
        return false;
    }
}

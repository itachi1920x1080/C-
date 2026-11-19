using System.Globalization;

namespace ProductLib;

public class ProductList
{
    protected List<Product> products = new List<Product>();

    public int Count => products.Count;
    public virtual Product? Get(long no)
    {
        lock (products)
        {
            return products.FirstOrDefault(p=>p.No == no)?.Clone();
        }
    }
    public List<Product> ToList() { return products.Select(p=>p.Clone()).ToList(); }

    public virtual bool Add(Product prd)
    {
        if (prd == null) return false;
        lock (products)
        {
            prd = prd.Clone();
            if (!products.Contains(prd))
            {
                products.Add(prd);
                return true;
            }
            return false;
        }
    }
    public virtual Product? Add(string data)
    {
        if (data == null) return null;
        Product prd = new Product();
        if (prd.SetData(data) == false) return null;
        if ( Add(prd)==true) return prd;
        return null;
    }

    public virtual Product? Update(long no, (string Name, double Price) data)
    {
        lock (products)
        {
            Product? found = products.FirstOrDefault(p => p.No == no);
            if (found == null) return null;
            found.Name = data.Name;
            found.Price = data.Price;
            return found.Clone();
        }
    }
    public virtual bool Remove(Product prd)
    {   
        if (prd == null) return false;  
        lock (products)
        {
            if (!products.Contains(prd)) return false;
            return products.Remove(prd);
        }
    }
    public virtual Product? Remove(long no)
    {
        lock (products)
        {
            lock (products)
            {
                Product? found = Get(no);
                var result= Remove(found!);
                if (result == false) return null;
                return found;
            }
        }
    }
    public virtual void Clear()
    {
        lock (products)
        {
            products.Clear();
        }
    }

}

using EntityCollection;
using System.ComponentModel;
using System.Globalization;

namespace PackageDemo;

internal class Program
{
    static void Main(string[] args)
    {
        EntityManager<int, Entity<int>> manager = new EntityManager<int, Entity<int>>();
        manager.EntityAdded += (sender, e) =>
        {
            Console.WriteLine($"Entity Added: ID={e.Key}");
        };
        Entity<int> p2, p4, p6;
        manager.Add(new Person { Key = 1, Name = "Alice" });
        manager.Add(p2 = new Person { Key = 2, Name = "Bob" });
        manager.Add(new Person { Key = 3, Name = "Charlie" });
        manager.Add(p4 = new Person { Key = 4, Name = "Diana" });

        manager.Add(new Product { Key = 5, Description = "product 1" });
        manager.Add(p6 = new Product { Key = 6, Description = "product 2" });
        Console.WriteLine();
        List<Entity<int>> removed = new List<Entity<int>>();
        manager.EntityRemoved += (sender, e) =>
        {
            removed.Add(e);
            //Console.WriteLine($"Entity Removed: ID={e.Key}, Name={e.Name}");
        };
        manager.Remove(p2);
        manager.Remove(p4);
        manager.Remove(p6);

        Console.WriteLine("\nRemaining entities in Manager:");
        foreach (var entity in manager.Entities)
        {
            Console.WriteLine(entity.Info);
        }

        Console.WriteLine("\nRemoved People:");
        foreach (var entity in removed)
        {
            Console.WriteLine(entity.Info);
        }
    }


}
public class Product : Entity<int>
{
    public string Description { get; set; }
    public override string Info => $"Product Id:{Key}; description:{Description}";
    public override string GetTextData()
    {
        return "";
    }
    public override bool SetTextData(string data)
    {
        return true;
    }
}
public class Person : Entity<int>
{
    public string Name { get; set; }

    public override string Info => $"Person id:{Key}, name:{Name}";

    public override string GetTextData()
    {
        return "";
    }

    public override bool SetTextData(string data)
    {
        return true;
    }

}



public class person : Entity<int>
{
    public string Name { get; set; }
    public override string Info => $"Person id:{Key}, name:{Name}";
    public override string GetTextData()
    {
        return "";
    }
    public override bool SetTextData(string data)
    {
        return true;
    }
}

public class EntityManager<TKey, TEntity> where TEntity : Entity<TKey>
{
    private readonly List<TEntity> _entities = new();
    public IReadOnlyList<TEntity> Entities => _entities.AsReadOnly();

    public event EventHandler<TEntity>? EntityAdded;
    public event EventHandler<TEntity>? EntityRemoved;

    public void Add(TEntity entity)
    {
        _entities.Add(entity);
        EntityAdded?.Invoke(this, entity);
    }

    public void Remove(TEntity entity)
    {
        if (_entities.Remove(entity))
        {
            EntityRemoved?.Invoke(this, entity);
        }
    }
}


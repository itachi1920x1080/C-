namespace People.Library;

public class PeopleManager
{
    public event EventHandler<Person>? Added;
    public event EventHandler<Person>? Removed;
    public event EventHandler<Person>? Updated;

    protected List<Person> _pers = new();

    public virtual bool Add(Person per)
    {
        if (_pers.Any(x => x.Id == per.Id)) return false;
        _pers.Add(per);
        Added?.Invoke(this, per);
        return true;
    }
    public virtual Person? Modify(string targetId, string name, Gender gender, byte age) 
    {
        var found = _pers.FirstOrDefault(x => x.Id == targetId);
        if (found != null)
        {
            found.Name = name;
            found.Gender = gender;
            found.Age = age;
            Updated?.Invoke(this, found);
        }
        return found;
    }
    public virtual Person? Remove(string targetId)
    {
        var found = _pers.FirstOrDefault(x => x.Id == targetId);
        if (found != null)
        {
            if (this.Remove(found))
                return found;
            else
                return null;
        }
        return null;
    }
    public virtual bool Remove(Person per)
    {
        var result = _pers.Remove(per);
        if (result == true) Removed?.Invoke(this, per);
        return result;
    }
    public virtual void Clear()
    {
        _pers.Clear();
    }

    public Person? GetPerson(string id)=>_pers.FirstOrDefault(x=>x.Id == id);
    public List<Person> People => new(_pers);
    public byte? MaxAge => _pers.Count==0?null:_pers.Max(x => x.Age);
    public int Count => _pers.Count;

}
namespace PersonEventHandling;

public class PersonList
{
    private List<Person> pers = [];
    public PersonList() => Person.Created += (p) => pers.Add(p); //Step 4

    public List<Person> Elements => new List<Person>(pers);
    public List<string> Genders => pers.Select(p=>p.Gender).Distinct().ToList();
}
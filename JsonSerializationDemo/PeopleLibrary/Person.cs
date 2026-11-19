using System.Data;

namespace PeopleLibrary;
public class Person
{
    public Person() { }
 
    public Person(int id, string name, string gender, byte age)
    {
        Id = id;
        Name = name;
        Gender = gender;
        Age = age;
    }

    public int Id { get; set; } = 0;
    public string Name { get; set; } = "";
    public string Gender { get; set; } = "";
    public byte Age { get; set; } = 0;

    public Person Clone()
    {
        return new Person()
        {
            Id = Id,
            Name = Name,
            Gender = Gender,
            Age = Age
        };
    }
}

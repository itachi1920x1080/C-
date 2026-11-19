namespace PersonEventHandling;

public class Person
{
    private Person() { }
    public string Name { get; set; } = default!;
    public string Gender { get;set; }= default!;
    public int Age { get; set;}= default!;

    public string Info => $"{Name}/{Gender}/{Age}";

    public delegate void PersonEventHandler(Person per);//Step 1
    public static event PersonEventHandler? Created;//Step 2
    public static void Create(string name, string gender, int age)
    {
        Person p = new() { Name = name, Gender = gender, Age = age };
        Created?.Invoke(p); //Step 3
        /*if (Created != null) Created.Invoke(p);*/
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace FileredPeopl;

public class Person
{
    //static members
    public static int NameFieldWidth { get; set; } = 30;
    public static int GenderFieldWidth { get; set; } = 6;
    public static int AgeFieldWidth { get; set; } = 4;
    
    public static string Heading
    {
        get
        {
            string nameText = string.Format($"{{0,{-NameFieldWidth}}}", "name");
            string genderText = string.Format($"{{0,{-GenderFieldWidth}}}", "gender");
            string ageText = string.Format($"{{0, {AgeFieldWidth}}}", "age");
            return $"{nameText} {genderText} {ageText}";
        }
    }
    public static string DataSeparator { get; set; } = "/";
    public static string GetBar(char c = '-')
    {
        return new string(c, NameFieldWidth + GenderFieldWidth + AgeFieldWidth + 2);
    }

    //instance fields
    protected string _name = "";
    protected string _gender = "";
    protected byte _age = 0;
    public Person() { }

    //instance properties
    public string Name => _name;
    public string Gender => _gender;
    public byte Age => _age;
    public string Info
    {
        get
        {
            string nameInfo = string.Format($"{{0,{-NameFieldWidth}}}", _name);
            string genderInfo = string.Format($"{{0,{-GenderFieldWidth}}}", _gender);
            string ageInfo = string.Format($"{{0, {AgeFieldWidth}}}", _age);
            return $"{nameInfo} {genderInfo} {ageInfo}";
        }
    }
    public string Data {  set { SetData(value); } }
    //instance methods
    public bool SetData(string data)
    {
        string[] arr = data.Split(Person.DataSeparator);
        if (arr.Length < 3) return false;
        string name = arr[0].Trim();
        string gender = arr[1].Trim();
        if (byte.TryParse(arr[2], out byte age) == false) return false;
        _name = name;
        _gender = gender;
        _age = age;
        return true;
    }
    
}
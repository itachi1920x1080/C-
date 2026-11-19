namespace ConsoleApp8;

public static class StringExtension
{
    public static Dictionary<string, object> ToDictionary(this string str, string fieldSep, string dataSep)
    {
        Dictionary<string, object> result = new();
        var arr = str.Split(fieldSep);
        foreach(var item in arr )
        {
            var pieces = item.Split(dataSep);
            if (pieces.Length < 2) continue;
            if (result.ContainsKey(pieces[0]) == false)
                result.Add(pieces[0].Trim(), pieces[1].Trim());
        }
        
        return result;
    }
}

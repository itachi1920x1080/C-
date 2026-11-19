namespace RecWinForm;
public class Rectangle
{
    static int Count = 0;
    public static event Action<Rectangle>? Created;
    public static Rectangle CreateInstance(double wd, double lng)
    {
        var newRec = new Rectangle()
        {
            Width = wd,
            Length = lng
        };
        Created?.Invoke(newRec);
        return newRec;
    }
    private int _no;
    public int No => _no;
    public double Width { get; set; } = 0;
    public double Length { get; set; } = 0;
    public double Area => Width * Length;
    private Rectangle() { _no = ++Count; }

}
using System.Drawing;
Triangle triangle = new("triangle_name", 5, 10, 15);
triangle.Print();
Console.WriteLine($"Area: {triangle.Area2}");
TriangleColor triangleColor = new("triangle_name 2", 3, 4, 5, Color.Transparent);
triangleColor.Print();
Console.WriteLine($"Area: {triangleColor.Area()}");
Console.ReadLine();
TriangleColor badTriangleColor = new("triangle_name bad", 3, 3, 8, Color.Khaki);

abstract class Figure
{
    private string _name;
    public string? Name
    {
        get { return _name; }
        set { _name = value ?? "[empty]"; }
    }
    public Figure(string name) => _name = name;
    public abstract float Area2 { get; }
    public abstract float Area();
    public virtual void Print()
    {
        Console.WriteLine("Figure");
    }
}
class Triangle : Figure
{
    int _a, _b, _c;
    public void SetABC(int a, int b, int c)
    {
        int max = a > b ? (a > c ? a : c) : (b > c ? b : c);
        if ((a + b + c - max) < max || a <= 0 || b <= 0 || c <= 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        _a = a;
        _b = b;
        _c = c;
    }
    public void GetABC(out int a, out int b, out int c)
    {
        a = _a;
        b = _b;
        c = _c;
    }
    public Triangle(string name, int a, int b, int c) : base(name)
    {
        SetABC(a, b, c);
    }
    public override float Area2
    {
        get 
        {
            return Area();
        }
    }
    public override float Area()
    {
        float halfPerimeter = (_a + _b + _c) / 2.0f;
        return MathF.Sqrt(halfPerimeter * (halfPerimeter - _a) * (halfPerimeter - _b) * (halfPerimeter - _c));
    }
    public override void Print()
    {
        Console.WriteLine($"Triangle {_a} {_b} {_c}");
    }
}
class TriangleColor : Triangle
{
    public Color Colour { get; set; }
    public TriangleColor(string name, int a, int b, int c, Color colour) : base(name, a, b, c)
    {
        Colour = colour;
    }
    public override void Print()
    {
        Console.Write($"Colour {Colour.R} {Colour.G} {Colour.B} ");
        base.Print();
    }
}
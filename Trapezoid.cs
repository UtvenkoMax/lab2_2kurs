using System;

// Варіант 6 — Трапеція
public class Trapezoid : IComparable<Trapezoid>
{
    public string FillColor { get; set; }
    public string ContourColor { get; set; }
    public double Base1 { get; set; }
    public double Base2 { get; set; }
    public double Height { get; set; }

    public Trapezoid(string fillColor, string contourColor, double base1, double base2, double height)
    {
        FillColor = fillColor;
        ContourColor = contourColor;
        Base1 = base1;
        Base2 = base2;
        Height = height;
    }

    // Площа трапеції: (a + b) / 2 * h
    public double GetArea()
    {
        return (Base1 + Base2) / 2.0 * Height;
    }

    // Периметр (рівнобічна трапеція): a + b + 2 * бічна сторона
    public double GetPerimeter()
    {
        double diff = Math.Abs(Base1 - Base2) / 2.0;
        double leg = Math.Sqrt(diff * diff + Height * Height);
        return Base1 + Base2 + 2 * leg;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Трапеція: заливка={FillColor}, контур={ContourColor}, " +
                          $"основи={Base1} і {Base2}, висота={Height}, " +
                          $"площа={GetArea():F2}, периметр={GetPerimeter():F2}");
    }

    // Порівняння за площею (для сортування і дерева)
    public int CompareTo(Trapezoid other)
    {
        if (other == null) return 1;
        return GetArea().CompareTo(other.GetArea());
    }

    public override string ToString()
    {
        return $"{FillColor}/{ContourColor} (S={GetArea():F2})";
    }
}

// Окремий компаратор — порівняння за периметром
public class TrapezoidPerimeterComparer : IComparer<Trapezoid>
{
    public int Compare(Trapezoid x, Trapezoid y)
    {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;
        return x.GetPerimeter().CompareTo(y.GetPerimeter());
    }
}

using System;
using System.Collections.Generic;

// Абстрактний клас GraphicPrimitive
public abstract class GraphicPrimitive
{
    public int X { get; set; }
    public int Y { get; set; }

    public abstract void Draw();
    public abstract void Move(int x, int y);

    // Метод для масштабування
    public abstract void Scale(float factor);
}

// Клас Circle який спадкований від GraphicPrimitive
public class Circle : GraphicPrimitive
{
    public int Radius { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Circle at ({X},{Y}) with Radius {Radius}");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        Radius = (int)(Radius * factor);
    }
}

// Клас Rectangle який спадкований від GraphicPrimitive
public class Rectangle : GraphicPrimitive
{
    public int Width { get; set; }
    public int Height { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Rectangle at ({X},{Y}) with Width {Width} and Height {Height}");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        Width = (int)(Width * factor);
        Height = (int)(Height * factor);
    }
}

// Клас Triangle який спадкований від GraphicPrimitive
public class Triangle : GraphicPrimitive
{
    public override void Draw()
    {
        Console.WriteLine($"Drawing Triangle at ({X},{Y})");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        // Логіка масштабування для трикутника
        Console.WriteLine("Scaling Triangle");
    }
}

// Клас Group який спадкований від GraphicPrimitive
public class Group : GraphicPrimitive
{
    private List<GraphicPrimitive> primitives = new List<GraphicPrimitive>();

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Group at ({X},{Y})");
        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;

        foreach (var primitive in primitives)
        {
            primitive.Move(x, y);
        }
    }

    public override void Scale(float factor)
    {
        foreach (var primitive in primitives)
        {
            primitive.Scale(factor);
        }
    }
}

// Клас GraphicsEditor
public class GraphicsEditor
{
    private List<GraphicPrimitive> primitives = new List<GraphicPrimitive>();

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    public void DrawAll()
    {
        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }

    public void MoveAll(int x, int y)
    {
        foreach (var primitive in primitives)
        {
            primitive.Move(x, y);
        }
    }

    public void ScaleAll(float factor)
    {
        foreach (var primitive in primitives)
        {
            primitive.Scale(factor);
        }
    }
}

class Program
{
    static void Main()
    {
        // Приклад використання
        GraphicsEditor editor = new GraphicsEditor();

        Circle circle = new Circle { X = 10, Y = 20, Radius = 5 };
        Rectangle rectangle = new Rectangle { X = 30, Y = 40, Width = 8, Height = 12 };
        Triangle triangle = new Triangle { X = 50, Y = 60 };

        editor.AddPrimitive(circle);
        editor.AddPrimitive(rectangle);
        editor.AddPrimitive(triangle);

        Console.WriteLine("Drawing all primitives:");
        editor.DrawAll();

        Console.WriteLine("\nMoving all primitives:");
        editor.MoveAll(5, 5);
        editor.DrawAll();

        Console.WriteLine("\nScaling all primitives:");
        editor.ScaleAll(2);
        editor.DrawAll();

        // Групування фігур
        Group group = new Group { X = 70, Y = 80 };
        group.AddPrimitive(circle);
        group.AddPrimitive(rectangle);
        group.AddPrimitive(triangle);

        editor.AddPrimitive(group);

        Console.WriteLine("\nDrawing all primitives including the group:");
        editor.DrawAll();
    }
}

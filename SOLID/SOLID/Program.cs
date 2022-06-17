using System;


public class Rectangle
{
    public double Height { get; set; }
    public double Width { get; set; }
}





public class Circle
{
    public double Radius { get; set; }
}
public class AreaCalculator
{
    public double TotalArea(object[] arrObjects)
    {
        double area = 0;
        Rectangle objRectangle;
        Circle objCircle;
        foreach (var obj in arrObjects)
        {
            if (obj is Rectangle)
            {   
                objRectangle = (Rectangle)obj;
                area += objRectangle.Height * objRectangle.Width;
            }
            else
            {
                objCircle = (Circle)obj;
                area += objCircle.Radius * objCircle.Radius * Math.PI;
            }
        }
        return area;
    }
}

public class Program
{
    static void Main(String[] args)
    {
        AreaCalculator areaCalculator = new AreaCalculator();
        Rectangle rec = new Rectangle();
        rec.Width = 10;
        rec.Height = 10;
        Circle circle = new Circle();
        circle.Radius = 4;

        Console.WriteLine(areaCalculator.TotalArea(new object[] { rec, circle }));
    }
}











//public abstract class Shape
//{
//    public abstract double Area();
//}

//public class Rectangle : Shape
//{
//    public double Height { get; set; }
//    public double Width { get; set; }
//    public override double Area()
//    {
//        return Height * Width;
//    }
//}
//public class Circle : Shape
//{
//    public double Radius { get; set; }
//    public override double Area()
//    {
//        return Radius * Radius * Math.PI;
//    }
//}



//public class AreaCalculator
//{
//    public double TotalArea(Shape[] arrShapes)
//    {
//        double area = 0;
//        foreach (var objShape in arrShapes)
//        {
//            area += objShape.Area();
//        }
//        return area;
//    }
//}


//public class Program
//{
//    static void Main(String[] args)
//    {
//        AreaCalculator areaCalculator = new AreaCalculator();
//        Rectangle rec=new Rectangle();
//        rec.Width = 10;
//        rec.Height = 10;
//        Circle circle=new Circle();
//        circle.Radius = 4;

//        Console.WriteLine(areaCalculator.TotalArea(new Shape[] { rec, circle }));
//    }
//}
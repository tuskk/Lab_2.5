using System;

namespace Lab_2._5
{
    public class Point<T>
    {
        private T x;
        private T y;

        public Point(T x, T y)
        {
            this.x = x;
            this.y = y;
        }

        public T X { get { return x; } }
        public T Y { get { return y; } }

        public void Move(T deltaX, T deltaY)
        {
            // Зміщуємо точку на вказану величину
            x = Add(x, deltaX);
            y = Add(y, deltaY);
        }

        private T Add(T a, T b)
        {
            // Реалізуємо додавання для числових типів
            if (typeof(T) == typeof(int))
                return (T)(object)((int)(object)a + (int)(object)b);
            if (typeof(T) == typeof(double))
                return (T)(object)((double)(object)a + (double)(object)b);

            throw new InvalidOperationException("Unsupported type");
        }
    }

    public class Trapezoid
    {
        private Point<double> vertexA;
        private Point<double> vertexB;
        private Point<double> vertexC;
        private double sideAB;
        private double sideCD;
        private double height;

        public double SideAB => sideAB;
        public double SideCD => sideCD;
        public double Height => height;

        public double Perimeter => sideAB + sideCD + CalculateBaseSum();
        public double Area => CalculateArea();

        public Trapezoid(Point<double> vertexA, Point<double> vertexB, Point<double> vertexC)
        {
            this.vertexA = vertexA;
            this.vertexB = vertexB;
            this.vertexC = vertexC;

            CalculateSides();
            CalculateHeight();
        }

        private void CalculateSides()
        {
            sideAB = CalculateDistance(vertexA, vertexB);
            sideCD = CalculateDistance(vertexC, vertexB);
        }

        private void CalculateHeight()
        {
            height = Math.Abs(vertexA.Y - vertexC.Y);
        }

        private int CalculateDistance(Point<double> point1, Point<double> point2)
        {
            double distanceX = Math.Abs(point1.X - point2.X);
            double distanceY = Math.Abs(point1.Y - point2.Y);
            return (int)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
        }

        private double CalculateBaseSum()
        {
            return Math.Abs(vertexA.X - vertexC.X);
        }

        private double CalculateArea()
        {
            return 0.5 * (sideAB + sideCD) * height;
        }

        public void ChangeShape(Point<double> newVertexA, Point<double> newVertexC)
        {
            vertexA = newVertexA;
            vertexC = newVertexC;

            CalculateSides();
            CalculateHeight();
        }
    }


    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter the coordinates of vertex A (x, y):");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            Point<double> vertexA = new Point<double>(x, y);

            Console.WriteLine("Enter the coordinates of vertex B (x, y):");
            x = double.Parse(Console.ReadLine());
            y = double.Parse(Console.ReadLine());
            Point<double> vertexB = new Point<double>(x, y);

            Console.WriteLine("Enter the coordinates of vertex C (x, y):");
            x = double.Parse(Console.ReadLine());
            y = double.Parse(Console.ReadLine());
            Point<double> vertexC = new Point<double>(x, y);

            Trapezoid trapezoid = new Trapezoid(vertexA, vertexB, vertexC);

            Console.WriteLine("The trapezoid is created:");
            Console.WriteLine("Height: " + trapezoid.Height);
            Console.WriteLine("Side AB: " + trapezoid.SideAB);
            Console.WriteLine("Side CD: " + trapezoid.SideCD);
            Console.WriteLine("Perimeter: " + trapezoid.Perimeter);
            Console.WriteLine("Area: " + trapezoid.Area);

            Console.WriteLine("Enter the new coordinates of vertex A (x, y):");
            x = double.Parse(Console.ReadLine());
            y = double.Parse(Console.ReadLine());
            Point<double> newVertexA = new Point<double>(x, y);

            Console.WriteLine("Enter the new coordinates of the vertex C (x, y):");
            x = double.Parse(Console.ReadLine());
            y = double.Parse(Console.ReadLine());
            Point<double> newVertexC = new Point<double>(x, y);

            trapezoid.ChangeShape(newVertexA, newVertexC);

            Console.WriteLine("The trapezoid has been updated:");
            Console.WriteLine("Height: " + trapezoid.Height);
            Console.WriteLine("Side AB: " + trapezoid.SideAB);
            Console.WriteLine("Side CD: " + trapezoid.SideCD);
            Console.WriteLine("Perimeter: " + trapezoid.Perimeter);
            Console.WriteLine("Area: " + trapezoid.Area);
        }
    }
}

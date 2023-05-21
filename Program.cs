using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

//Розробити абстрактний клас «Геометрична Фігура» з методами «Площа Фігури» та «Периметр Фігури».
//Розробити класи-спадкоємці: Трикутник, Квадрат, Ромб, Прямокутник, Паралелограм, Трапеція, Коло, Еліпс.
//Реалізувати конструктори, що є унікальними об'єктами класів.
//Реалізувати клас "Складова Фігура", який може складатися з будь-якої кількості "Геометричних Фігур".
//Для цього класу визначають метод знаходження площі фігури.


namespace GeometricFigure
{
    abstract internal class Figure
    {
        internal int xStartPoint { set; get; }
        internal int yStartPoint { set; get; }

        protected Figure(int x, int y) { xStartPoint = x; yStartPoint = y; }
        abstract internal double FigureArea();
        abstract internal double FigurePerimeter();
        abstract internal void FigurePrintData();
        protected internal void PrintBasePoint()
        {
            Console.Write($"Base point coordinates:");
            Console.SetCursorPosition(25, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"(X: {xStartPoint}");
            Console.SetCursorPosition(35, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Y: {yStartPoint})"); 
            Console.ResetColor();
        }

    }
    // ------------------------------------------  Triangle -----------------------------------------------
    internal class Triangle : Figure
    {
        private int SideA;
        private int SideB;
        private int SideC;

        internal Triangle(int x, int y, int a, int b, int c) : base(x, y)
        {
            this.SideA = a;
            this.SideB = b;
            this.SideC = c;
        }

        internal override double FigureArea() // Формула Герона
        {
            double p = (this.SideA + this.SideB + this.SideC) / 2;
            return Math.Sqrt(p * (p - this.SideA) * (p - this.SideB) * (p - this.SideC));
        }

        internal override double FigurePerimeter()
        {
            return this.SideA + this.SideB + this.SideC;
        }

        internal override void FigurePrintData()
        {
            Console.WriteLine($"Figure - Triangle:");
            Console.WriteLine($"Side A - {this.SideA}");
            Console.WriteLine($"Side B - {this.SideB}");
            Console.WriteLine($"Side C - {this.SideC}");
        }
    }

    // ------------------------------------------  Square -----------------------------------------------
    internal class Square : Figure
    {
        private int SideA;

        internal Square(int x, int y, int a) : base(x, y)
        {
            this.SideA = a;
        }

        internal override double FigureArea()
        {
            return (double)(this.SideA * this.SideA);
        }

        internal override double FigurePerimeter()
        {
            return (double)(this.SideA * 4);
        }

        internal override void FigurePrintData()
        {
            Console.WriteLine("Figure - Square: ");
            Console.WriteLine($"Side A - {this.SideA}");
        }
    }

    // ------------------------------------------  Rhombus -----------------------------------------------  
    internal class Rhombus : Figure
    {
        private int DiagonalA;
        private int DiagonalB;

        internal Rhombus(int x, int y, int diagonalA, int diagonalB) : base(x, y)
        {
            this.DiagonalA = diagonalA;
            this.DiagonalB = diagonalB;

        }

        internal override double FigureArea()
        {
            return (double)((this.DiagonalA * this.DiagonalB) / 2);
        }

        internal override double FigurePerimeter()
        {
            return (double)(4 * Math.Sqrt((this.DiagonalA * this.DiagonalA + this.DiagonalB * this.DiagonalB) / 4));
        }

        internal override void FigurePrintData()
        {
            Console.WriteLine("Figure - Rhombus: ");
            Console.WriteLine($"Diagonal A - {this.DiagonalA}");
            Console.WriteLine($"Diagonal B - {this.DiagonalB}");
        }
    }


    // ------------------------------------------  Rectangle -----------------------------------------------  
    internal class Rectangle : Figure
    {
        private int SideA;
        private int SideB;

        internal Rectangle(int x, int y, int a, int b) : base(x, y)
        {
            this.SideA = a;
            this.SideB = b;
        }

        internal override double FigureArea()
        {
            return (double)(this.SideA * this.SideB);
        }

        internal override double FigurePerimeter()
        {
            return (double)(this.SideA * 2 + this.SideB * 2);
        }

        internal override void FigurePrintData()
        {
            Console.WriteLine("Figure - Rectangle: ");
            Console.WriteLine($"Side A - {this.SideA}");
            Console.WriteLine($"Side B - {this.SideB}");
        }
    }


    // ------------------------------------------  Parallelogram -----------------------------------------------  
    internal class Parallelogram : Figure
    {
        private int SideA;
        private int SideB;
        private int AngleC;

        internal Parallelogram(int x, int y, int a, int b, int angleC) : base(x, y)
        {
            this.SideA = a;
            this.SideB = b;
            this.AngleC = angleC;
        }

        internal override double FigureArea() // рассчет площади через 2 стороны и угол между ними
        {
            return (double)(this.SideA * this.SideB * Math.Sin(this.AngleC));
        }

        internal override double FigurePerimeter()
        {
            return (double)(this.SideA * 2 + this.SideB * 2);
        }

        internal override void FigurePrintData()
        {
            Console.WriteLine("Figure - Parallelogram: ");
            Console.WriteLine($"Side A - {this.SideA}");
            Console.WriteLine($"Side B - {this.SideB}");
            Console.WriteLine($"Angle C - {this.AngleC}");
        }
    }


    // ------------------------------------------  Trapeze -----------------------------------------------  
    internal class Trapeze : Figure
    {
        private int SideA;
        private int SideB;
        private int Height;

        internal Trapeze(int x, int y, int a, int b, int h) : base(x, y)
        {
            this.SideA = a;
            this.SideB = b;
            this.Height = h;
        }

        internal override double FigureArea()
        {
            return (double)((this.SideA + this.SideB) * this.Height / 2);
        }

        internal override double FigurePerimeter()
        {
            double side = Math.Sqrt(Math.Pow((this.SideB - this.SideA) / 2, 2) + Math.Pow(this.Height, 2));
            return (double)(this.SideA + this.SideB + 2 * side);    
        }

        internal override void FigurePrintData()
        {
            Console.WriteLine("Figure - Trapeze: ");
            Console.WriteLine($"Side A - {this.SideA}");
            Console.WriteLine($"Side B - {this.SideB}");
            Console.WriteLine($"Height h - {this.Height}");
        }
    }


    // ------------------------------------------  Circle -----------------------------------------------  
    internal class Circle : Figure
    {
        private int Radius;

        internal Circle(int x, int y, int r) : base(x, y)
        {
            this.Radius = r;
        }

        internal override double FigureArea() 
        {
            return (double)(Math.PI * Math.Pow(this.Radius, 2));
        }

        internal override double FigurePerimeter()
        {
            return (double)(Math.PI * this.Radius * 2);
        }

        internal override void FigurePrintData()
        {
            Console.WriteLine("Figure - Circle: ");
            Console.WriteLine($"Radius r - {this.Radius}");
        }
    }


    // ------------------------------------------  Ellipse -----------------------------------------------  
    internal class Ellipse : Figure
    {
        private int RadiusA;
        private int RadiusB;

        internal Ellipse(int x, int y, int a, int b) : base(x, y)
        {
            this.RadiusA = a;
            this.RadiusB = b;
        }

        internal override double FigureArea()
        {
            return (double)(Math.PI * this.RadiusA * this.RadiusB);
        }

        internal override double FigurePerimeter()
        {
            return (double)(Math.PI * (3 * (this.RadiusA + this.RadiusB) - Math.Sqrt((3 * this.RadiusA + this.RadiusB) * (this.RadiusA + 3 * this.RadiusB))));
        }

        internal override void FigurePrintData()
        {
            Console.WriteLine("Figure - Ellipse: ");
            Console.WriteLine($"Radius r - {this.RadiusA}");
            Console.WriteLine($"Radius R - {this.RadiusB}");
        }
    }


    internal class CompositeFigure : Figure
    {
        private List<Figure> figures;

        internal CompositeFigure(int x, int y) : base(x, y)
        {
            figures = new List<Figure>();
        }

        internal void AddFigure(Figure figure)
        {
            figures.Add(figure);
        }

        internal void RemoveFigure(Figure figure)
        {
            figures.Remove(figure);
        }

        internal override double FigureArea()
        {
            double totalArea = 0;
            foreach (Figure figure in figures)
            {
                totalArea += figure.FigureArea();
            }
            return totalArea;
        }

        internal override double FigurePerimeter()
        {
            double totalPerimeter = 0;
            foreach (Figure figure in figures)
            {
                totalPerimeter += figure.FigurePerimeter();
            }
            return totalPerimeter;
        }

        internal override void FigurePrintData()
        {
            {
                Console.WriteLine("Figure - CompositeFigure: ");
                Console.WriteLine("figure consists of objects: ");
                int count = 0;
                foreach (Figure f in figures)
                {
                    count++;
                    Console.WriteLine($"{count} - {f.GetType()}") ;
                }
            }
        }
    }


    internal class PrintOut
    {

        internal void PrintFigureData(Figure obj)
        {
            Console.WriteLine("________________________________________________________________________");
            obj.FigurePrintData();
            obj.PrintBasePoint();
        }
        internal void PrintArea(Figure obj)
        {
            Console.Write($"Figure area is:");
            Console.SetCursorPosition(25, Console.CursorTop);
            Console.WriteLine($"{obj.FigureArea():F2}");
        }

        internal void PrintPerimeter(Figure obj)
        {
            Console.Write($"Figure perimeter is:");
            Console.SetCursorPosition(25, Console.CursorTop);
            Console.WriteLine($"{obj.FigurePerimeter():F2}");
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            PrintOut print = new PrintOut();// объект для вывода данных через ссылку на базовый класс

            CompositeFigure compositeFigure = new CompositeFigure(11, 22); // создание составной фигуры
            compositeFigure.AddFigure(new Circle(0, 0, 25));
            compositeFigure.AddFigure(new Ellipse(0, 0, 25, 35));
            compositeFigure.AddFigure(new Square(50, -50, 25));

            List<Figure> figures = new List<Figure> // список всех фигур
            { new Triangle(0, 0, 20, 20, 15),
             new Square(50, -50, 25),
             new Rhombus(0, 0, 25, 35),
             new Rectangle(0,0,30,20),
             new Parallelogram(0, 0, 25, 35, 70),
             new Trapeze(0, 0, 25, 30, 20),
             new Circle(100, 200, 25),
             new Ellipse(0, 0, 25, 35),
             compositeFigure
            };
 

            foreach (Figure figure in figures)
            {
                print.PrintFigureData(figure);
                print.PrintArea(figure);
                print.PrintPerimeter(figure);
            }
        }
    }
}

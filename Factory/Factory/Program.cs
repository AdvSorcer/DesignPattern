using Factory.Interface;
using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory shapeFactory = new ShapeFactory();

            IShape shape1 = shapeFactory.GetShape("Circle");
            shape1.Draw();

            IShape shape2 = shapeFactory.GetShape("Square");
            shape2.Draw();

            IShape shape3 = shapeFactory.GetShape("Rectangle");
            shape3.Draw();
            
        }
        public class Rectangle : IShape
        {
            public void Draw()
            {
                Console.WriteLine("Rectangle");
            }
        }
        class Circle : IShape
        {
            public void Draw()
            {
                Console.WriteLine("Circle");
            }
        }
        class Square : IShape
        {
            public void Draw()
            {
                Console.WriteLine("Square");
            }
        }
        class ShapeFactory
        {
            public IShape GetShape(string shapeType)
            {
                if(shapeType == null)
                {
                    return null;
                }
                if (shapeType.Equals("Circle"))
                {
                    return new Circle();
                }
                if (shapeType.Equals("Square"))
                {
                    return new Square();
                }
                if (shapeType.Equals("Rectangle"))
                {
                    return new Rectangle();
                }
                return null;

            }
        }
    }
}

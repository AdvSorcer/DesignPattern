using AbstractFactory.Interface;
using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractFactor shapeFactory = FactoryChoser.GetFactory("Shape");
            IShape shape1 = shapeFactory.GetShape("Circle");
            shape1.Draw();
            IShape shape2 = shapeFactory.GetShape("Rectangle");
            shape2.Draw();
            IShape shape3 = shapeFactory.GetShape("Circle");
            shape3.Draw();

            AbstractFactor colorFactory = FactoryChoser.GetFactory("Color");
            ICorlor corlor1 = colorFactory.GetCorlor("Blue");
            corlor1.Fill();
            ICorlor corlor2 = colorFactory.GetCorlor("Green");
            corlor2.Fill();

        }
        //形狀
        class Rectangle : IShape
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
        //顏料
        class Green : ICorlor
        {
            public void Fill()
            {
                Console.WriteLine("Green");
            }
        }
        class Blue : ICorlor
        {
            public void Fill()
            {
                Console.WriteLine("Blue");
            }
        }
        //定義基底抽象工廠
        public abstract class AbstractFactor
        {
            public abstract ICorlor GetCorlor(string color);
            public abstract IShape GetShape(string shape);
        }
        //擴建工廠 1
        class ShapeFactory : AbstractFactor
        {
            public override ICorlor GetCorlor(string color)
            {
                return null;
            }

            public override IShape GetShape(string shape)
            {
                if (shape == null)
                {
                    return null;
                }
                if (shape.Equals("Circle"))
                {
                    return new Circle();
                }
                if (shape.Equals("Square"))
                {
                    return new Square();
                }
                if (shape.Equals("Rectangle"))
                {
                    return new Rectangle();
                }
                return null;
            }
        }
        //擴建工廠 2
        class ColorFactory : AbstractFactor
        {
            public override ICorlor GetCorlor(string color)
            {
                if (color == null)
                {
                    return null;
                }
                if (color.Equals("Green"))
                {
                    return new Green();
                }
                if (color.Equals("Blue"))
                {
                    return new Blue();
                }
                return null;
            }

            public override IShape GetShape(string shape)
            {
                return null;
            }
        }
        /// <summary>
        /// Factory Manager
        /// </summary>
        public class FactoryChoser
        {
            public static AbstractFactor GetFactory(string factory)
            {
                if(factory == "Color")
                {
                    return new ColorFactory();
                }
                if(factory == "Shape")
                {
                    return new ShapeFactory();
                }
                return null;
            }
        }
    }
}

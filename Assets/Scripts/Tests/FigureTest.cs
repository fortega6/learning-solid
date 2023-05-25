using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.Experimental.GlobalIllumination;

namespace Tests
{
    public class FigureTest
    {
        [Test]
        public void GetRectangleArea()
        {
            var rectangle = new Rectangle();

            rectangle.SetHeight(2);
            rectangle.SetWidth(5);
            
            Assert.AreEqual(10, rectangle.GetArea());
        }
        
        [Test]
        public void GetSquareArea()
        {
            Rectangle rectangle = new Square();

            if (rectangle is Square)
            {
                var square = (Square) rectangle;
                square.SetSide(2);
            }
            else
            {
                rectangle.SetHeight(2);
                rectangle.SetWidth(5);
            }

            Assert.AreEqual(10, rectangle.GetArea());
        }

        [Test]
        public void GetAreas()
        {
            var figures = GetFigures();

            foreach (var figure in figures)
            {
                figure.SetHeight(2);
                figure.SetWidth(5);
                Assert.AreEqual(10, figure.GetArea());
            }
        }

        private List<Rectangle> GetFigures()
        {
            var result = new List<Rectangle>();
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    result.Add(new Rectangle());
                    continue;
                }
                result.Add(new Square());
            }

            return result;
        }
    }

    public class Square : Rectangle
    {
        public override double GetArea()
        {
            UnityEngine.Assertions.Assert.AreEqual(_height, _width);
            return base.GetArea();
        }

        public void SetSide(int side)
        {
            SetHeight(side);
            SetWidth(side);
        }
    }

    public class Rectangle
    {
        protected int _height;
        protected int _width;

        public void SetHeight(int height)
        {
            _height = height;
        }

        public void SetWidth(int width)
        {
            _width = width;
        }

        public virtual double GetArea()
        {
            return _height * _width;
        }
    }
}

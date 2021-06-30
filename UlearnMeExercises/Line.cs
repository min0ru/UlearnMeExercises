using System;
using System.Numerics;

namespace UlearnMeExercises
{
    public class Line
    {
        public double A;
        public double B;
        public double C;

        public double M => B != 0 ? -(A / B) : Double.PositiveInfinity;
        public double X0 => A != 0 ? -(C / A) : Double.PositiveInfinity;
        public double Y0 => B != 0 ? -(C / B) : Double.PositiveInfinity;

        public Line(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public Line(double m, double y0)
        {
            if (m == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(m));
            }

            A = m;
            B = -1;
            C = y0;
        }

        public Line(Vector2 pointA, Vector2 pointB)
        {
            if (pointA == pointB)
            {
                throw new ArgumentOutOfRangeException(nameof(pointB));
            }

            var (x1, y1) = (pointA.X, pointA.Y);
            var (x2, y2) = (pointB.X, pointB.Y);
            A = y1 - y2;
            B = x2 - x1;
            C = x1 * y2 - x2 * y1;
        }

        public double MeasureDistance(Vector2 toPoint)
        {
            return Math.Abs(A * toPoint.X + B * toPoint.Y + C) / Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2));
        }

        public Vector2 GetUnitNormal()
        {
            throw new NotImplementedException(nameof(GetUnitNormal));
            // return new Vector2();
        }

        public Vector2 GetUnitParallel()
        {
            throw new NotImplementedException(nameof(GetUnitParallel));
            // return new Vector2();
        }

        public override string ToString()
        {
            return $"{nameof(Line)}(A={A}, B={B}, C={C})";
        }
    }
}
using System;
using System.Numerics;

namespace UlearnMeExercises
{
    public class Line
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

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

        /// <summary>
        /// Measure distance from Line to Point 
        /// </summary>
        /// <returns>Distance to point</returns>
        public double MeasureDistance(Vector2 toPoint)
        {
            return Math.Abs(A * toPoint.X + B * toPoint.Y + C) /
                   Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2));
        }

        /// <summary>
        /// Get unit vector parallel to Line at point (0, 0).
        /// Vector is selected by building unit vector with slope M at zero point.
        /// If slope is infinite than vector lays on X axis.
        /// </summary>
        /// <returns>Radial unit vector</returns>
        public Vector2 FindParallelUnitVector()
        {
            if (double.IsInfinity(M))
            {
                return new Vector2(0, 1);
            }

            var x = 1 / (Math.Sqrt(1 + Math.Pow(M, 2)));
            var y = M * x;
            return new Vector2((float)x, (float)y);
        }

        /// <summary>
        /// Get unit normal for Line in point (0, 0).
        /// Vector is calculated by getting parallel unit vector at point (0, 0) and rotating it by 90 degrees.
        /// </summary>
        /// <returns>Radial unit vector</returns>
        public Vector2 FindNormalUnitVector()
        {
            var parallel = FindParallelUnitVector();
            return new Vector2(-parallel.Y, parallel.X);
        }

        /// <summary>
        /// Find intersection point of two lines.
        /// </summary>
        /// <param name="other">Second line to intersect with</param>
        /// <returns>Is intersecting flag, Intersection point (valid only if intersects)</returns>
        /// <exception cref="NotImplementedException"></exception>
        public (bool, Vector2) Intersect(Line other)
        {
            var (a1, b1, c1) = (A, B, C);
            var (a2, b2, c2) = (other.A, other.B, other.C);
            float xi = (float)Math.Round((b1 * c2 - b2 * c1) / (a1 * b2 - a2 * b1), 3);
            float yi = (float)Math.Round((c1 * a2 - c2 * a1) / (a1 * b2 - a2 * b1), 3);
            
            // Float values does not throws ZeroDevision exception and should be checked implicitly
            if (double.IsInfinity(xi) || double.IsInfinity(yi))
            {
                return (false, new Vector2(xi, yi));
            }
            return (true, new Vector2(xi, yi));
        }

        /// <summary>
        /// Find orthogonal projection of a point on this line.
        /// </summary>
        /// <param name="point">Point to project</param>
        /// <returns>Projection point on line</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Vector2 Project(Vector2 point)
        {
            throw new NotImplementedException(nameof(Project));
        }


        public override string ToString()
        {
            return $"{nameof(Line)}(A={A}, B={B}, C={C})";
        }
    }
}
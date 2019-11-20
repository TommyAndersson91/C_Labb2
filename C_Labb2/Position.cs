using System;

namespace C_Labb2
{
    internal class Position
    {
        public int x;
        public int y;

        public int X
        {
            get => x;
            set => x = Math.Abs(value);
        }

        public int Y
        {
            get => y;
            set => y = Math.Abs(value);
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y; 
        }

        public double Length()
        {
           var origoDistance = Math.Sqrt(x * x + y * y);
            return origoDistance;
        }

        public bool Equals(Position p)
        {
            if (p.x == p.y)
            {
                return true;
            }
            return false;
        }

        public Position Clone()
        {
            return new Position(x, y); 
        }

        public override string ToString()
        {
            return $"({x},{y})";
        }

        public static bool operator >(Position p1, Position p2)
        {
            if (p1.Length() > p2.Length())
            {
                return true;
            }
            if (p2.Length() > p1.Length())
            {
                return false; 
            }

            {
                if (p1.x > p2.x)
                {
                    return true; 
                }
                {
                    return false;
                }
            }
            
                    }

        public static bool operator <(Position p1, Position p2)
        {
            if (p1.Length() < p2.Length())
            {
                return true; 
            }
            if (p2.Length() < p1.Length())
            {
                return false;
            }
            if (p1.x < p2.x)
            {
                return true;
            }
            {
                return false;
            }

        }

        public static Position operator +(Position p1, Position p2)
        {
           
           var newX = p1.x + p2.x;
           var newY = p1.y + p2.y;
            return new Position(newX, newY);

        }

        public static Position operator -(Position p1, Position p2)
        {

            var newX = p1.x - p2.x;
            var newY = p1.y - p2.y;
            return new Position(newX, newY);

        }

        public static double operator %(Position p1, Position p2)
        {
            var x = Math.Pow(p1.x - p2.x, 2);
            var y = Math.Pow(p1.y - p2.y, 2);
            var distance = Math.Sqrt(x + y);
            return distance;
        }
    }
}
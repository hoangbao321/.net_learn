using System;

namespace cs24
{
    class Countnumber
    {
        public static int number = 0;
        public static void Info()
        {
            Console.WriteLine($"So lan truy cap: {number} ");
        }
        public void Count()
        {
            number++;
        }
    }
    class Student
    {
        public readonly string name; // chỉ đọc
        public Student(string name)
        {
            this.name = name;
        }
    }
    class Vector
    {
        double x;
        double y;
        public Vector(double _x, double _y)
        {
            x = _x;
            y = _y;
        }
        public void Info()
        {
            Console.WriteLine($"{x}, {y}");
        }
        // vector + vector -> vector
        public static Vector operator +(Vector v1, Vector v2)
        {
            double x = v1.x + v2.x;
            double y = v1.y + v2.y;
            Vector v3 = new Vector(x, y);
            return v3;
        }
        public static Vector operator ++(Vector v1)
        {
            double x = v1.x++;
            double y = v1.y++;
            Vector v3 = new Vector(x, y);
            return v3;
        }
    }
    class Vector_indexer
    {
        double x;
        double y;
        public Vector_indexer(double _x, double _y)
        {
            x = _x;
            y = _y;
        }
        public void Info()
        {
            Console.WriteLine($"{x}, {y}");
        }
        // vector + vector -> vector
        public static Vector_indexer operator +(Vector_indexer v1, Vector_indexer v2)
        {
            double x = v1.x + v2.x;
            double y = v1.y + v2.y;
            Vector_indexer v3 = new Vector_indexer(x, y);
            return v3;
        }
        public static Vector_indexer operator ++(Vector_indexer v1)
        {
            double x = v1.x++;
            double y = v1.y++;
            Vector_indexer v3 = new Vector_indexer(x, y);
            return v3;
        }
        //indexer [chỉ số]
        public int this[int i]
        {
            set
            {
                switch (i)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    default:
                        throw new("sai roi be oi");
                }
            }
            get
            {
                switch (i)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    default:
                        throw new("sai roi be oi");
                }
            }
        }
        public double this[string s]
        {
            set
            {
                switch (s.ToLower())
                {
                    case "toadox":
                        x = value;
                        break;
                    case "toadoy":
                        y = value;
                        break;
                    default:
                        throw new("sai roi be oi");
                }
            }
            get
            {
                switch (s.ToLower())
                {
                    case "toadox":
                        return x;
                    case "toadoy":
                        return y;
                    default:
                        throw new("sai roi be oi");
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Countnumber c1 = new Countnumber();
            Countnumber c2 = new Countnumber();
            c1.Count();
            c1.Count();
            Countnumber.Info();

            Student s = new("nguyen van A");
            Console.WriteLine(s.name);

            Vector v1 = new Vector(5, 7);
            Vector v2 = new Vector(7, 8);

            var v3 = v1 + new Vector(10, 10);
            v1.Info();
            v2.Info();
            v3.Info();

            //INDEXER
            Vector_indexer v4 = new Vector_indexer( 8, 9);
            // v4[0]~x
            // v4[1]~ y

            // v["toadox"] ~ x
            // v["toadoy"] ~ y

            v4[0] = 58;
            v4[3] = 6;
            v4.Info();


            v4["tOadoX"] = 7;
            v4["tOadoy"] = 8;
            v4.Info();

        }
    }
}

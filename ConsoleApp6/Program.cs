namespace rabota
{
    public class Program
    {
        struct BodyInformation
        {
            public double xMax;
            public double T;
            public double tx;
            public double X;
            public double S;
            public double A;
        }


        public static void Main()
        {
            Console.Write("Введите начальную скорость тела: ");
            double v = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите начальную высоту тела: ");
            double y0 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите угол: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите время полёта: ");
            double tx = Convert.ToDouble(Console.ReadLine());
            BodyInformation Body = FlyingAtAnAngle(y0, v, a, tx);
            Console.WriteLine("Дальность = " + Body.S + " метров");
            Console.WriteLine("За время =" + Body.tx + " секунд пройдёт =" + Body.X + " метров");
            Console.WriteLine("Максимальная дальность полёта = " + Body.xMax + " метров угол при этом = " + Body.A + " радиан");
        }

        static BodyInformation FlyingAtAnAngle(double y0, double v, double a, double tx)
        {
            BodyInformation Body = new BodyInformation();
            double g = 9.81;
            Body.T = (v * Math.Sin(a) + Math.Sqrt(Math.Pow(v, 2) * Math.Pow(Math.Sin(a), 2) + 2 * g * y0)) / g;
            Body.S = v * Math.Cos(a) * Body.T;
            Body.tx = tx;
            Body.X = v * Math.Cos(a) * Body.tx;
            Body.A = 0.01;
            Body.xMax = 0;
            double T;
            for (double i = 0.0001; i < 1.5; i += 0.000001)
            {
                T = (v * Math.Sin(i) + Math.Sqrt(Math.Pow(v, 2) * Math.Pow(Math.Sin(i), 2) + 2 * g * y0)) / g;
                if (v * Math.Cos(i) * T > Body.xMax)
                {
                    Body.xMax = v * Math.Cos(i) * T;
                    Body.A = i;
                }
            }
            return Body;
        }
    }
}
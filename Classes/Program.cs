using System;

namespace Classes
{
	class Program
	{
		static void Main(string[] args)
		{
			QuadraticFunction func = new QuadraticFunction();
			func.A = 1;
			func.B = 0;
			func.C = -4;
			func.CalculateDiscriminant();
			func.CalculateRoot2();
			func.CalculateRoot1();
			Console.WriteLine(func.Root1);
			Console.WriteLine(func.Discriminant);
			// Console.WriteLine(func.GetDiscriminant());
			// func.CalculateRoot1();
			// func.CalculateRoot2();
			// Console.WriteLine(func.GetRoot1());
			// Console.WriteLine(func.GetRoot2());
			
		}
	}

	class QuadraticFunction
	{
		private double? _a;
		private double? _b;
		private double? _c;
		private double? _d;
		private double? _x1;
		private double? _x2;

		public double A
		{
			get
			{
				if (_a ==  null) throw new Exception("Coefficient isn't initialized.");
				return _a ?? 0.0;
			}
			set
			{
				if (value ==  0) throw new ArgumentException("Invalid argument. 'a' can't be 0.");
				_a = value;
			}
		}
		
		public double B
		{
			get
			{
				if (_b ==  null) throw new Exception("Coefficient isn't initialized.");
				return _b ?? 0.0;
			}
			set
			{
				_b = value;
			}
		}
		
		public double C
		{
			get
			{
				if (_c ==  null) throw new Exception("Coefficient isn't initialized.");
				return _c ?? 0.0;
			}
			set
			{
				_c = value;
			}
		}

		public double Discriminant
		{
			get
			{
				if (_d == null) throw new Exception("discriminant isn't initialized.");
				return _d ?? 0.0;
			}
		}
		
		public void CalculateDiscriminant()
		{
			checked
			{
				_d = Math.Pow(B, 2) - (4 * A * C);
			}
		}

		public double Root1
		{
			get
			{
				if (_x1 == null) throw new Exception("root1 isn't initialized or does not exist.");
				return _x1 ?? 0.0;
			}
		}

		public double Root2
		{
			get
			{
				if (_x2 == null) throw new Exception("root2 isn't initialized or does not exist.");
				return _x2 ?? 0.0;
			}
		}

		public void CalculateRoot1()
		{
			if (Discriminant < 0)
			{
				_x1 = null;
				return;
			}
			checked
			{
				_x1 = (-B + Math.Sqrt(Discriminant)) / (2 * A);
			}
		}

		public void CalculateRoot2()
		{
			if (Discriminant < 0)
			{
				_x2 = null;
				return;
			}
			checked
			{
				_x2 = (-B - Math.Sqrt(Discriminant)) / (2 * A);
			}
		}
	}
}
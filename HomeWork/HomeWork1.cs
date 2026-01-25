namespace HomeWork {
    internal class HomeWork1 {
        public static void Main(string[] args) {
            // 10/23
            // int[] x = new int[5];
            // x[0] = Random.Shared.Next(1, 100);
            // x[1] = Random.Shared.Next(1, 100);
            // x[2] = Random.Shared.Next(1, 100);
            // x[3] = Random.Shared.Next(1, 100);
            // x[4] = Random.Shared.Next(1, 100);
            // Console.WriteLine($"x[0]: {x[0]}");
            // Console.WriteLine($"x[1]: {x[1]}");
            // Console.WriteLine($"x[2]: {x[2]}");
            // Console.WriteLine($"x[3]: {x[3]}");
            // Console.WriteLine($"x[4]: {x[4]}");
            //
            // // მომიძებნეთ მასივი ელემენტებს შორის მაქსიმალური მნიშვნელობა.
            // // იფიქრეთ თუ როგორ შეიძლება ამოცანის გადაჭრა ციკლის გამოყენების გარეშე.
            // // მხოლოდ პირობითი ოპერატორების გამოყენებაა ნებადართული.
            //
            // int max = x[0];
            //
            // if (max < x[1]) max = x[1];
            // if (max < x[2]) max = x[2];
            // if (max < x[3]) max = x[3];
            // if (max < x[4]) max = x[4];
            //
            // Console.WriteLine($"Max: {max}");
            
            // 10/26

            // int[] x = new int[10];
            // int index = 0;
            //
            // while (index < x.Length)
            // {
            //     x[index] = Random.Shared.Next(100);
            //     Console.WriteLine($"x[{index}] = {x[index]}");
            //     index++;
            // }
            //
            // // კოდი დაიწყეთ აქ...
            // // 1
            // index = 0;
            // int sum = 0;
            // while (index < x.Length)
            // {
            //     sum += x[index];
            //     index++;
            // }
            // Console.WriteLine($"sum: {sum}");
            //
            // // 2
            // Console.WriteLine($"Arithmetic mean:{(float)sum/x.Length)}";
            //
            // // 3
            // index = 0;
            // int max = x[0];
            // while (index < x.Length)
            // {
            //     if (max < x[index])
            //     {
            //         max = x[index];
            //     }
            //     index++;
            // }
            // Console.WriteLine($"max:{max}");
            //
            // // 4
            // index = 0;
            // int min = x[0];
            // while (index < x.Length)
            // {
            //     if (min > x[index])
            //     {
            //         min = x[index];
            //     }
            //     index++;
            // }
            // Console.WriteLine($"min:{min}");
            
            // მომიძებნეთ და დამიწერეთ ეკრანზე შემდეგი მნიშვნელობები:
            // 1. x მასივიდან რიცხვთა საერთო ჯამი.
            // 2. x მასივიდან რიცხვთა საშუალო არითმეტიკული.
            // 3. x მასივიდან მაქსიმალური რიცხვი.
            // 4. x მასივიდან მინიმალური რიცხვი.
            // არ გამოიყენოთ ინტერნეტი და ჩაშენებული ფუნქციები ამოცანის გადასაჭრელად.
            // ყოველი მნიშვნელობა მოძებნეთ ცალკე ციკლით.

            //int max = x.Max(); // ეს არ შეიძლება გამოყენებულ იქნას
            //Console.WriteLine($"Max  = {max}");
            
            // 10/30
            
            int[] x = new int[10];

            for (int i = 0; i < x.Length; i++)
            {
                x[i] = Random.Shared.Next(-30, 31);
                Console.WriteLine($"x[{i}] = {x[i]} {(x[i] % 2 == 0 ? "Even" : "Odd")}");
            }
            
            // ამოცანები: 
            // 1. ვისაც არ გქონდათ გაკეთებული, დაასრულეთ While ოპერატორით.
            // 2. იპოვეთ ეს მნიშვნელობები ერთ for ციკლში.
            // 3. გააკეთეთ იგივე ფუნქციონალობა ცალ-ცალკე ლუწებისთვის და კენტებისთვის..

            // 2

            int sum = x[0];
            int max = x[0];
            int min = x[0];
            
            for (int i = 1; i < x.Length; i++)
            {
                sum += x[i];
                if (x[i] > max) max = x[i];
                if (x[i] < min) min = x[i];
            }
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Avg: {(double)sum / x.Length}");
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Min: {min}");
            
            // 3
            
            /* აქ დავუშვი შესაძლებლობა რომ ყველა ელემენტი კენტი ან ლუწია.
            მაგალითად თუ ყველა კენტია მაქსიმალური და მინიმალური ლუწი არ იარსებებს.*/
            
            int even_sum = 0;
            int even_amount = 0;
            int? even_max = null; 
            int? even_min = null;
            
            int? odd_max = null;
            int? odd_min = null;
            
            for (int j = 0; j < x.Length; j++)
            {
                if (x[j] % 2 == 0)
                {
                    if (even_max == null || even_max < x[j]) even_max = x[j]; 
                    if (even_min == null || even_min > x[j]) even_min = x[j];
                    
                    even_sum += x[j];
                    even_amount++;
                }
                else
                {
                    if (odd_max == null || odd_max < x[j]) odd_max = x[j];
                    if (odd_min == null || odd_min > x[j]) odd_min = x[j];
                }
            }
            
            int odd_amount = x.Length - even_amount;
            int odd_sum = sum - even_sum;

            if (even_amount != 0)
            {
                Console.WriteLine($"Even Sum: {even_sum}");
                Console.WriteLine($"Even amount: {even_amount}");
                Console.WriteLine($"Even Avg: {(double)even_sum / even_amount}");
                Console.WriteLine($"Even Max: {even_max}");
                Console.WriteLine($"Even Min: {even_min}");
            }
            else Console.WriteLine("No even");

            if (odd_amount != 0)
            {
                Console.WriteLine($"Odd Sum: {odd_sum}");
                Console.WriteLine($"Odd amount: {odd_amount}");
                Console.WriteLine($"Odd Avg: {(double)odd_sum / odd_amount}");
                Console.WriteLine($"Odd Max: {odd_max}");
                Console.WriteLine($"Odd Min: {odd_min}");
            }
            else Console.WriteLine("No odd");
        }
    }
}
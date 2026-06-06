namespace Stream;

public class  Program
{
    public static void Main(string[] args)
    {
        StreamReader reader;
        StreamWriter writer;
        string inputPath = "D:\\input.txt";
        string outputPath = "D:\\output.txt";
        
        // 1

        // reader = new StreamReader(new FileStream("D:\\file.txt", FileMode.Open));
        // int sum = 0;
        // int number;
        // while (reader.Peek() != -1)
        // {
        //     if (int.TryParse(reader.ReadLine(), out number)) sum += number;
        // }
        // Console.WriteLine(sum);
        // reader.Close();
        
        // 2
        
        // reader = new StreamReader(new FileStream(inputPath, FileMode.Open));
        // writer = new StreamWriter(new FileStream(outputPath, FileMode.Create));
        // int count = 1;
        // while (reader.Peek() != -1)
        // {
        //     writer.WriteLine($"{count}. {reader.ReadLine()}");
        //     count++;
        // }
        // reader.Close();
        // writer.Close();
        
        // 3
        
        // int charCount = 0;
        // int wordCount = 0;
        // reader = new StreamReader(new FileStream(inputPath, FileMode.Open));
        // while (reader.Peek() != -1)
        // {
        //     string line = reader.ReadLine();
        //     if (line == null) continue;
        //     string[] words = line.Split(' ');
        //     wordCount += words.Length - words.Count("");
        //     line = line.Replace(" ", "");
        //     charCount += line.Length;
        // }
        // reader.Close();
        //
        // Console.WriteLine("Chars: "+charCount);
        // Console.WriteLine("Words: "+wordCount);
        
        // 4
        
        Dictionary<char, int> dict = new Dictionary<char, int>();
        reader = new StreamReader(new FileStream(inputPath, FileMode.Open));
        while (reader.Peek() != -1)
        {
            CountChar(dict, reader.ReadLine());
        }
        
        reader.Close();

        foreach (var item in dict)
        {
            Console.WriteLine(item.Key + ": " + item.Value);
        }
    }

    private static void CountChar(Dictionary<char, int> dict, string line)
    {
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == ' ') continue;
            if (dict.ContainsKey(line[i])) dict[line[i]]++;
            else dict.Add(line[i], 1);
        }
    }
}
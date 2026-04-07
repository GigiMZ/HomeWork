namespace Classes
{
    internal class Program
    {
        static void Main()
        {
            Book[] books = new Book[]
            {
                new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Year = 1925 },
                new Book { Title = "To Kill a Mockingbird 2", Author = "Harper Lee", Year = 1960 },
                new Book { Title = "1984", Author = "George Orwell", Year = 1949 },
                new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Year = 1813 },
                new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Year = 1960 }
            };

            ArrayHelper.Sort(books);

            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine(books[i]);
            }
        }
    }

    class Book : Sortable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Year: {Year}";
        }

        public override object? Compare(object object1)
        {
            if (object1 is Book book1)
            {
                Book? greaterBook = CompareYear(book1);
                if (greaterBook == null)
                {
                    greaterBook = CompareTitle(book1);
                }
                return greaterBook;
            }
            return null;
        }

        private Book? CompareYear(Book book1)
        {
            if (book1.Year == this.Year) return null;
            return book1.Year > this.Year ? book1 : this;
        }

        private Book CompareTitle(Book book1)
        {
            return book1.Title.Length > this.Title.Length ? book1 : this;
        }
    }

    abstract class Sortable
    {
        public abstract object? Compare(object object1);
    }

    // me ar vici ra tipis obieqts gadmomcemen sortiebistvis. 

    static class ArrayHelper
    {
        public static void Sort(object[] array)
        {
            if (array is not Sortable[] sortableArray)
            {
                return;
            }
            for (int i = 0; i < sortableArray.Length - 1; i++)
            {
                for (int j = 0; j < sortableArray.Length - i - 1; j++)
                {
                    var temp = sortableArray[j].Compare(array[j+1]);
                    if (temp == null) continue;
                    if (temp.Equals(sortableArray[j]))
                    {
                        sortableArray[j] = sortableArray[j + 1];
                        sortableArray[j + 1] = (Sortable)temp;
                    }
                }
            }
        }

        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
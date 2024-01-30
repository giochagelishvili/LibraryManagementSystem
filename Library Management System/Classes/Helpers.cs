namespace Library_Management_System.Classes
{
    public class Helpers
    {
        public static List<Book> GenerateBookList()
        {
            List<Book> list = new();

            string[] bookNames = { "The Great Gatsby", "To Kill a Mockingbird", "1984", "Pride and Prejudice", "The Catcher in the Rye", "Animal Farm", "Brave New World", "Fahrenheit 451", "The Hobbit", "The Lord of the Rings", "Harry Potter and the Sorcerer's Stone", "The Hunger Games", "The Da Vinci Code", "The Alchemist", "The Shining", "The Great Expectations", "Wuthering Heights", "Moby-Dick", "The Odyssey", "War and Peace" };

            string[] authors = { "F. Scott Fitzgerald", "Harper Lee", "George Orwell", "Jane Austen", "J.D. Salinger", "George Orwell", "Aldous Huxley", "Ray Bradbury", "J.R.R. Tolkien", "J.R.R. Tolkien", "J.K. Rowling", "Suzanne Collins", "Dan Brown", "Paulo Coelho", "Stephen King", "Charles Dickens", "Emily Brontë", "Herman Melville", "Homer", "Leo Tolstoy" };

            Random random = new();

            for (int i = 0; i < bookNames.Length; i++)
            {
                Book book = new(bookNames[i], authors[i], random.Next(1900, 2024));
                list.Add(book);
            }

            return list;
        }

        public static Dictionary<int, string> GenerateOperations() => new()
            {
                { 1, "Display available books" },
                { 2, "Check out book" },
                { 3, "Check in book" },
                { 4, "Exit"}
            };

        public static int ChooseOperation(Dictionary<int, string> operations)
        {
            Console.WriteLine("Please choose operation: ");

            foreach (var pair in operations)
                Console.WriteLine($"{pair.Key}) {pair.Value}");

            return GetIntInput(operations.Count);
        }

        public static int ChooseBook(Library library)
        {
            library.DisplayAvailableBooks();

            int bookIndex = GetIntInput(library.Books.Count);

            return bookIndex - 1;
        }

        public static int ChooseBook(User user)
        {
            user.DisplayCheckedOutBooks();

            int bookIndex = GetIntInput(user.CheckedOutBooks.Count);

            return bookIndex - 1;
        }

        public static int GetIntInput(int maxValue)
        {
            int num = 0;

            do
            {
                try
                {
                    bool userInput = int.TryParse(Console.ReadLine(), out num);

                    if (!userInput)
                        throw new Exception("Please enter a number.");

                    if (num < 1 || num > maxValue)
                        throw new Exception("Please choose one of the above.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (num < 1 || num > maxValue);

            return num;
        }
    }
}

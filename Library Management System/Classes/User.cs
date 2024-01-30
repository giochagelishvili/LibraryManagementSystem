namespace Library_Management_System.Classes
{
    public class User
    {
        public List<Book> CheckedOutBooks = new();

        public Book RemoveBook(int bookIndex)
        {
            if (CheckedOutBooks.Count <= 0)
                throw new Exception("This user has no books.");

            Book removedBook = CheckedOutBooks[bookIndex];
            CheckedOutBooks.RemoveAt(bookIndex);

            return removedBook;
        }

        public void DisplayCheckedOutBooks()
        {
            if (CheckedOutBooks.Count <= 0)
                throw new Exception("This user has no books.");

            int indexer = 1;

            foreach (Book book in CheckedOutBooks)
            {
                Console.WriteLine($"{indexer}) {book.Title}({book.ReleaseYear}) | {book.Author}");
                indexer++;
            }
        }
    }
}

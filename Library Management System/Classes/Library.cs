namespace Library_Management_System.Classes
{
    public class Library
    {
        public List<Book> Books { get; set; }

        public Library()
        {
            Books = Helpers.GenerateBookList();
        }

        public void DisplayAvailableBooks()
        {
            if (Books == null)
                return;

            int indexer = 1;

            foreach (Book book in Books)
            {
                if (book.IsAvailable)
                {
                    Console.WriteLine($"{indexer}) {book.Title}({book.ReleaseYear}) | {book.Author}");
                    indexer++;
                }
            }
        }

        public Book CheckOutBook(int bookIndex)
        {
            Books[bookIndex].IsAvailable = false;
            return Books[bookIndex];
        }

        public void CheckInBook(Book bookToCheckIn)
        {
            foreach(Book book in Books)
                if (bookToCheckIn == book)
                    book.IsAvailable = true;
        }
    }
}

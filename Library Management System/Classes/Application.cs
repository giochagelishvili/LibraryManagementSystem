namespace Library_Management_System.Classes
{
    public class Application
    {
        private Library Library {  get; set; }
        private User User {  get; set; }
        private bool ExitApp { get; set; } = false;
        private Dictionary<int, string> Operations { get; set; }

        public Application() 
        {
            Library = new Library();
            User = new User();
            Operations = Helpers.GenerateOperations();
        }
        
        public void Start()
        {
            do
            {
                int operationKey = Helpers.ChooseOperation(Operations);
                ExecuteOperation(operationKey);
            } while (!ExitApp);
        }

        private void ExecuteOperation(int operationKey)
        {
            string operation = Operations[operationKey];

            try
            {
                switch (operation)
                {
                    case "Display available books":
                        Library.DisplayAvailableBooks();
                        break;
                    case "Check out book":
                        Book book = Library.CheckOutBook(Helpers.ChooseBook(Library));
                        User.CheckedOutBooks.Add(book);
                        break;
                    case "Check in book":
                        Book bookToCheckIn = User.RemoveBook(Helpers.ChooseBook(User));
                        Library.CheckInBook(bookToCheckIn);
                        break;
                    case "Exit":
                        ExitApp = true;
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

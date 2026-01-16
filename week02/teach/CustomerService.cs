/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Create a CustomerService with invalid size (0).
        // Expected Result: Max Size should default to 10.
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(0);
        Console.WriteLine(cs1);

        // Defect(s) Found: 
        Console.WriteLine("Invalid Size");
        Console.WriteLine("=================");

        // Test 2
        // Scenario: Enqueue to full queue. Size = 1. Add 2 customers.
        // Expected Result: First add succeeds. Second add displays error.
        Console.WriteLine("Test 2: Queue Full");
        var cs2 = new CustomerService(1);
        Console.WriteLine("Adding Customer 1 (Should Succeed):");
        cs2.AddNewCustomer();
        Console.WriteLine("Adding Customer 2 (Should Fail):");
        cs2.AddNewCustomer();

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3
        // Scenario: Serve customers in correct order and serve from empty queue.
        // Expected Result: Serve Order: A, B. Error on 3rd serve.
        Console.WriteLine("Test 3: Order & Empty Queue");
        var cs3 = new CustomerService(2);
        Console.WriteLine("Adding Customer A:");
        cs3.AddNewCustomer(); // A
        Console.WriteLine("Adding Customer B:");
        cs3.AddNewCustomer(); // B
        
        Console.WriteLine("Serving Customer 1 (Expect A):");
        cs3.ServeCustomer(); 
        
        Console.WriteLine("Serving Customer 2 (Expect B):");
        cs3.ServeCustomer(); 
        
        Console.WriteLine("Serving Customer 3 (Expect Error):");
        cs3.ServeCustomer(); 
        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) { 
            // Fix: Changed > to >=
            // Defect I: Full queue Check is Off-by-One
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        // fix: Xheck if queue is empty first
        if (_queue.Count <= 0) {
            Console.WriteLine("The Queue is empty.");
            return;
        }

        // Fix: Read customer before removing them
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}
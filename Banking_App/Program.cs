
using Banking_App.Banners;
using System;
using System.Threading.Channels;

var accounts = new List<Account>
{
    new Account { Name = "francis", Balance = 100000 },
    new Account { Name = "doyin", Balance = 5000000 },
    new Account { Name = "brian", Balance = 250000 },
    new Account { Name = "nahimout", Balance = 7500000 }
};

Console.WriteLine("Enter the name on the account: ");
string userName = Console.ReadLine();
string userNameLower = userName.ToLower();

Account current = accounts.Find(a => a.Name == userNameLower);

if (current == null)
{
    Console.WriteLine("Account not found.");
    Console.WriteLine("Creating one for you...");
    current = new Account { Name = userNameLower, Balance = 1000m };
    accounts.Add(current);
    Console.WriteLine($"Account created for {userNameLower}.");
}

Console.WriteLine("What is the name of your branch City");
string branch = Console.ReadLine();

bool running  = true;


while (running)
{
    //Console.WriteLine("Welcome to TatumBank, whats your name");
    //string name = Console.ReadLine();
    Banner.Display($" Welcome to TatumBank {branch} branch {userName}");

    
    Console.WriteLine($"Welcome to tatumbank {branch} branch, {userName}");
    Console.WriteLine("\n1.Check balance\n2. Transfer\n3. Airtime\n4. Exit");
    string choice = Console.ReadLine();

    switch(choice)
    {
        case "1":
            Console.WriteLine("Balance : " + current.Balance);
            break;

        case "2":
            Console.WriteLine("Enter the account name you want to transfer to: (we curently do only transfers within our bank, we only have Francis, Doyin, Brian, Nahimout)");
            string transferTo = Console.ReadLine();
            Account transferNumber = accounts.Find(a => a.Name == transferTo.ToLower());
            if (transferNumber == null)
            {
                Console.WriteLine("Account not found.");
                break;
            }
            Console.WriteLine("Enter amount to transfer:");
            if(transferNumber == current)
            {
                Console.WriteLine("You cant transfer Money to yourself.");
                break;
            }
            decimal amount = decimal.Parse(Console.ReadLine());
            if(amount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive value.");
                break;
            }
            if (amount > current.Balance)
            {
                Console.WriteLine("Insufficient funds");
            }
            else
            {
                current.Balance -= amount;
                Console.WriteLine("Transfering.......");
                transferNumber.Balance += amount;
                Console.WriteLine($"Transfer successful. You successfully transferred {amount} to {transferTo}. Your new balance: {current.Balance}");
            }
            break;
        case "3":
            Console.WriteLine("Which network: MTN, Airtel, Glo, Etisalat");
            string network = Console.ReadLine();
            Console.WriteLine("Enter the phone number:");
            string phoneNumber =  Console.ReadLine();
            Console.WriteLine("Enter the amount:");
            decimal AirtimeAmount = decimal.Parse(Console.ReadLine());
            if (AirtimeAmount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive value.");
                break;
            }
            if (AirtimeAmount > current.Balance)
            {
                Console.WriteLine("Insufficient funds");
            }
            else
            {
                current.Balance -= AirtimeAmount;
                Console.WriteLine("Purchasing Airtime.......");
                Console.WriteLine($"Airtime Purchase successful for {phoneNumber}. New balance: " + current.Balance);
            }
            break ;

        case "4":
            Console.WriteLine("Thank you for using our bank.......");
            running = false;
            break;

        default: Console.WriteLine("Invalid Input");
            break;
    }

}





public class Account
{
    public string Name { get; set; }
    public decimal Balance { get; set; }
}

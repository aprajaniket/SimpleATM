using System;

public class CardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
    public String getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public String getFirstName()
    {
        return firstName;
    }
    public String getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }
    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please Choose from one of the following Options");
            Console.WriteLine("1.Deposit");
            Console.WriteLine("2.Withdraw");
            Console.WriteLine("3.Show Balance");
            Console.WriteLine("4.Exit");
        }
        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How Much Money Would you like to Deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank You for Money. Your New Balance is : " + currentUser.getBalance());
        }
        void withDraw(CardHolder currentUser)
        {
            Console.WriteLine("How Much Money Would you like to Withdraw: ");
            double withDrawel = Double.Parse(Console.ReadLine());
            // Check User as Enough Balance
            if (currentUser.getBalance() > withDrawel)
            {
                Console.WriteLine("Insuficient Balnce:(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withDrawel);
                Console.WriteLine(" You're Good to go ...Thak You!!!");
            }

        }
        void balance(CardHolder currentUser)
        {
            Console.WriteLine("Current Balance: " + currentUser.getBalance());
        }
        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("621658126927101", 2342, "Aniket", "Apraj", 452.26));
        cardHolders.Add(new CardHolder("721567686927101", 3242, "Vishal", "Sejpal", 500.26));
        cardHolders.Add(new CardHolder("226581216867101", 2354, "Divya", "Arora", 200.26));
        cardHolders.Add(new CardHolder("726581879812101", 2382, "Sonali", "Mishra", 740.26));
        cardHolders.Add(new CardHolder("516581269616581", 2332, "Anjali", "Chirmule", 146.26));

        Console.WriteLine("Welcome to AJA Bank ATM");
        Console.WriteLine("Please Insert Your Debit Card: ");
        String debitCardNUm = "";
        CardHolder currentUser;
        while (true)
        {
            try
            {
                debitCardNUm = Console.ReadLine();
                //Check from db List
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNUm);
                if (currentUser == null) { break; }
                else { Console.WriteLine("Card Not Recognized. Please try Again."); }
            }
            catch { Console.WriteLine("Card Not Recognized. Please try Again."); }
        }
        Console.WriteLine("Please Enter the Pin Number ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //Check from db List
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect Pin. Please try Again."); }
            }
            catch { Console.WriteLine("Incorrect Pin . Please try Again."); }
        }
        Console.WriteLine("Heyy Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withDraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank You! Have A Nice Day :) ");
    }
}

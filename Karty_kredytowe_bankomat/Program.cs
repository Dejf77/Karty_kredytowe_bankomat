using System;
public class Holder
{
    String cardNumber;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public Holder(string cardNumber, int pin, string firstName, string lastName, double balance)
    {
        this.cardNumber = cardNumber;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
    // get___________________________________
    public String getNum()
    {
        return cardNumber;
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
    // set___________________________________
    public void setNum(String newNum)
    {
        cardNumber = newNum;
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
            Console.WriteLine(" Prosze wybrać jedną z poniższych opcji");
            Console.WriteLine("1. Wpłata");
            Console.WriteLine("2. Wypłata");
            Console.WriteLine("3. Pokaż stan konta");
            Console.WriteLine("4. Wyjście");

        }
        void deposit(Holder currentUser)
        {
            Console.WriteLine("Ile pieniędzy chcesz wpłacić ? ");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Pieniuądze został wpłacone. Twój stan konta to " + currentUser.getBalance());

        }
        void withdraw(Holder currentUser)
        {
            Console.WriteLine("Ile pieniędzy chcesz wypłacić ? ");
            double withdraw = double.Parse(Console.ReadLine());
            if (currentUser.getBalance() < withdraw)
            {
                Console.WriteLine(" Niewystarczające środki na koncie. ");

            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("Dokonano wypłaty " + withdraw + " zł, ");
            }
        }
        void balance(Holder currentUser)
        {
            Console.WriteLine("Stan konta: " + currentUser.getBalance());
        }
        // Bliblioteka użytnowników 
        List<Holder> people = new List<Holder>();
        people.Add(new Holder("4772623897481013", 1540, "Bartek", "Jasin", 1200));
        people.Add(new Holder("4598111469626555", 3342, "Marek", "Kowalski", 800));
        people.Add(new Holder("4598112822615558", 2099, "Kasia", "Majeranek", 2000));
        people.Add(new Holder("4598111340914485", 9588, "Jola", "Kopiec", 300));
        people.Add(new Holder("4772625581686799", 5522, "Ania", "Sosna", 1500));

        //Wczytanie urzytkownika   
        Console.WriteLine("Cześć to ja, tówj bankowamt");
        Console.WriteLine("Prosze podaj numer swojej karty: ");
        Holder currentUser;

        while (true)
        {
            try
            {
                String debitCardNum = Console.ReadLine();
                //sprawdzanie poprawności z bazą danych 
                currentUser = people.FirstOrDefault(a => a.cardNumber == debitCardNum);
                if (currentUser != null) { break; }
                else
                {
                    Console.WriteLine("Karta nie rozpoznan. Spróbuj ponownie");
                }
            }
            catch
            {
                Console.WriteLine("Karta nie rozpoznan. Spróbuj ponownie");
            }
        }
        Console.WriteLine("Prosze podaj swoj pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());

                if (currentUser.getPin() == userPin) { break; }
                else
                {
                    Console.WriteLine("Wprowadzony pin do towjej karty jest błędny. Spróbuj ponownie");
                }
            }
            catch
            {
                Console.WriteLine("Wprowadzony pin do towjej karty jest błędny. Spróbuj ponownie");
            }
        }
        Console.WriteLine("Witaj " + currentUser.getFirstName());
        int option = 0;

        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }

            if (option == 1)
            {
                deposit(currentUser);
            }
            else if (option == 2)
            {
                withdraw(currentUser);
            }
            else if (option == 3)
            {
                balance(currentUser);
            }
            else if (option == 4)
            {
                break;
            }
            else
            {
                option = 0;
            }


        }
        while (option != 4);
    }
}




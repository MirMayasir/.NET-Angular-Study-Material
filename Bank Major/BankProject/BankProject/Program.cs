using BankLibrary;
using System.Security.Principal;
using System.Data.SqlClient;
using System.Security.Authentication.ExtendedProtection;
using Microsoft.EntityFrameworkCore;
using BankProject.Models;
using BankBackend;
namespace BankProject
{
    internal class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        private static Bank bk = new HDFCBank();
        static void Main(string[] args)
        {
            
            IBankRepository bankRepository = new BankRepository();
            /*Bank bk = new HDFCBank();*/
            Console.WriteLine("                     welcome to wipro bank limited");
            Console.WriteLine("                     Choose one option to get started");

            while (true)
            {
                Console.WriteLine("1. New Account");
                Console.WriteLine("2. Get All Accounts");
                Console.WriteLine("3. Get Account Details");
                Console.WriteLine("4. Deposit Amount");
                Console.WriteLine("5. Withdraw Amount");
                Console.WriteLine("6. Get Transactions");
                Console.WriteLine("7. CurrentBalance");
                Console.WriteLine("8. update account");
                Console.WriteLine("9. Delete Account");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateNewAccount(bankRepository);
                        break;
                    case "2":
                        DisplayAllAccounts(bankRepository);
                        break;
                    case "3":
                        DisplayAccountDetails(bankRepository);
                        break;
                    case "4":
                        DepositAmount(bankRepository);
                        break;
                    case "5":
                        WithdrawAmount(bankRepository);
                        break;
                    case "6":
                        DisplayTransactions(bankRepository);
                        break;
                    case "7":
                        CurrentBalance(bankRepository);
                        break;
                    case "8":
                        UpdateDetails();
                        break;
                    case "9":
                        DeleteAccount();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void DeleteAccount()
        {
            Console.WriteLine("enter the account number to be deleated");
            string number = Console.ReadLine();
            EntityFramework ef = new EntityFramework();
            ef.DeleteEntry(number);
        }

        private static void UpdateDetails()
        {
            Console.WriteLine("enter the account number ");
            string Anumber = Console.ReadLine();

            Console.WriteLine("enter the new name ");
            string Aname = Console.ReadLine();

            Console.WriteLine("enter new address");
            string Aaddress = Console.ReadLine();

            /*EntityFramework ef = new EntityFramework();*/
            bk.ChangeDetails(Anumber, Aname, Aaddress);
        }

        public static void CreateNewAccount(IBankRepository bankRepository)
        {
            Console.Write("Enter Customer Name: ");
            var customerName = Console.ReadLine();
            Console.Write("Enter Customer Address: ");
            var customerAddress = Console.ReadLine();
            Console.Write("Enter Initial Balance: ");
            var balance = decimal.Parse(Console.ReadLine());

            Console.WriteLine("enter mobile number");
            var mobile = Console.ReadLine();

            var account = new SBAccount(null, customerName, customerAddress, balance, mobile);
            bankRepository.NewAccount(account);
            Console.WriteLine($"Account created successfully {account.AccountNumber}");
            string accountNum = account.AccountNumber;
            /* Backend backend = new Backend();
             backend.InsertData(accountNum, customerName, customerAddress, balance);*/
            /*EntityFramework efb = new EntityFramework();*/
            bk.SaveAccountDetails(accountNum, customerName,customerAddress, balance);

        }

        static void DisplayAllAccounts(IBankRepository bankRepository)
        {
            var accounts = bankRepository.GetAllAccounts();
            foreach (var account in accounts)
            {
                Console.WriteLine($"Account Number: {account.AccountNumber}\n Name: {account.CustomerName}\n Balance: {account.CurrentBalance:C}\n Time: {DateTime.Now} \n Phone Number {account.PhoneNumber}");
            }
        }

        static void DisplayAccountDetails(IBankRepository bankRepository)
        {
            Console.Write("Enter Account Number: ");
            var accountNumber = Console.ReadLine();
            try
            {
                var account = bankRepository.GetAccountDetails(accountNumber);
                Console.WriteLine($"Account Number: {account.AccountNumber}, Name: {account.CustomerName}, Address: {account.CustomerAddress}, Balance: {account.CurrentBalance:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DepositAmount(IBankRepository bankRepository)
        {
            Console.Write("Enter Account Number: ");
            var accountNumber = Console.ReadLine();
            Console.Write("Enter Amount to Deposit: ");
            var amount = decimal.Parse(Console.ReadLine());

            try
            {
                bankRepository.DepositAmount(accountNumber, amount);
                Console.WriteLine("Amount deposited successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void WithdrawAmount(IBankRepository bankRepository)
        {

            Console.Write("Enter Account Number: ");
            var accountNumber = Console.ReadLine();
            Console.Write("Enter Amount to Withdraw: ");
            var amount = decimal.Parse(Console.ReadLine());

            try
            {
                bankRepository.WithdrawAmount(accountNumber, amount);
                Console.WriteLine("Amount withdrawn successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       public  static void DisplayTransactions(IBankRepository bankRepository)
        {
            Console.Write("Enter Account Number: ");
            var accountNumber = Console.ReadLine();
            var transactions = bankRepository.GetTransactions(accountNumber);
            /*EntityFramework ef = new EntityFramework();*/
            bk.GetTransactions(accountNumber);

            /*foreach (var transaction in transactions)
            {
                Console.WriteLine($"Transaction ID: {transaction.TransactionId}, Date: {transaction.TransactionDate}, Amount: {transaction.Amount:C}, Type: {transaction.TransactionType}");
                *//*Backend backend = new Backend();
                backend.TransactionTable(transaction.TransactionId, accountNumber, transaction.TransactionDate, transaction.Amount);*//*
            }*/
        }

        static void CurrentBalance(IBankRepository bankRepository)
        {
            Console.WriteLine("enter the account number");
            var accountNumber = Console.ReadLine();
            Console.WriteLine("current balance is " + bankRepository.GetCurrentBalance(accountNumber));
        }

        /*private static void GetCon()
        {
            con = new SqlConnection("Data Source = LAPTOP-EVDOJPLN\\SQLEXPRESS01; Initial Catalog = bankdatabase;" +
                "Integrated Security = true");
            con.Open();
        }*/


    }
}

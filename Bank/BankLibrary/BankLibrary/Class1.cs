using System.Transactions;
using System.Xml.Serialization;

namespace BankLibrary
{
    public class SBAccount
    {
        public string AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public decimal CurrentBalance { get; set; }
        public string PhoneNumber { get; set; }

        /*public SBAccount() { }*/

        public SBAccount(string accountNumber, string customerName, string customerAddress, decimal currentBalance, string phoneNumber)
        {
            AccountNumber = accountNumber;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CurrentBalance = currentBalance;
            PhoneNumber = phoneNumber;
        }

    }

    public class SBTransaction
    {
        public string TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }

        /*public SBTransaction() { }*/
        public SBTransaction(string transactionId, DateTime transactionDate, string accountNumber, decimal amount, string transactionType)
        {
            TransactionId = transactionId;
            TransactionDate = transactionDate;
            AccountNumber = accountNumber;
            Amount = amount;
            TransactionType = transactionType;
        }
    }

    public interface IBankRepository
    {
        void NewAccount(SBAccount account);
        List<SBAccount> GetAllAccounts();
        SBAccount GetAccountDetails(string accnoumber);
        void DepositAmount(string accno, decimal amount);
        void WithdrawAmount(string accno, decimal amount);
        List<SBTransaction> GetTransactions(string accnnumber);
        decimal GetCurrentBalance(string accno);


    }


    public class BankRepository : IBankRepository
    {
        private readonly List<SBAccount> Accounts = new List<SBAccount>();
        private readonly List<SBTransaction> Transactions = new List<SBTransaction>();
        private int nextAccountNumber = 1000;
        /*private readonly string filePath;*/

        /*public BankRepository(string filePath = "accounts.xml")
        {
            this.filePath = filePath;
            DeserializeAccounts(filePath); // Load existing accounts from file
        }*/


        private string GenerateAccountNumber()
        {
            /*return (nextAccountNumber++).ToString();*/
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            string randomNumberString = randomNumber.ToString();
            return randomNumberString;
        }

        public void NewAccount(SBAccount account)
        {
            account.AccountNumber = GenerateAccountNumber();
            Accounts.Add(account);
        }

        public List<SBAccount> GetAllAccounts()
        {
            return Accounts;
        }

        public SBAccount GetAccountDetails(string accnumber)
        {
            var account = Accounts.FirstOrDefault(a => a.AccountNumber == accnumber);
            if (account == null)
            {
                throw new Exception("Invalid account number");
            }
            return account;
        }

        public void DepositAmount(string accnumber, decimal amount)
        {
            var account = GetAccountDetails(accnumber);
            account.CurrentBalance += amount;
            Transactions.Add(new SBTransaction(Guid.NewGuid().ToString(), DateTime.Now, accnumber, amount, "Deposit"));
            Transactions.Add(new SBTransaction(Guid.NewGuid().ToString(), DateTime.Now, accnumber, amount, "Deposit"));
        }

        public void WithdrawAmount(string accnumber, decimal amount)
        {
            if(amount <= 0)
            {
                throw new Exception("negative ammount not allowed");
            }
            var account = GetAccountDetails(accnumber);
            if (account.CurrentBalance < amount)
            {
                throw new Exception("Insufficient balance.");
            }
            account.CurrentBalance -= amount;
            Transactions.Add(new SBTransaction(Guid.NewGuid().ToString(), DateTime.Now, accnumber, amount, "Withdraw"));
        }

        public List<SBTransaction> GetTransactions(string accnumber)
        {
            return Transactions.Where(t => t.AccountNumber == accnumber).ToList();
        }

        public decimal GetCurrentBalance(string accno)
        {
            var account = GetAccountDetails(accno);
            return account.CurrentBalance;
        }



        //serialization
        /*private void SerializeAccounts(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<SBAccount>));
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    serializer.Serialize(fs, Accounts);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error serializing accounts: {ex.Message}");
            }
        }

        private void DeserializeAccounts(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<SBAccount>));
                if (File.Exists(filePath))
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        Accounts.Clear();
                        var deserializedAccounts = (List<SBAccount>)serializer.Deserialize(fs);
                        Accounts.AddRange(deserializedAccounts);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing accounts: {ex.Message}");
            }
        }*/
    }
}
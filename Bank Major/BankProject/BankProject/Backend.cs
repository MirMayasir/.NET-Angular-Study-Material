using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Transactions;
namespace BankProject
{
    internal class Backend
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        private static void GetCon()
        {
            con = new SqlConnection("Data Source = LAPTOP-EVDOJPLN\\SQLEXPRESS01; Initial Catalog = bankdatabase;" +
                "Integrated Security = true");
            con.Open();
        }

        public void InsertData(string accountNum, string customerName, string customerAddress, decimal balance)
        {
            GetCon();
            cmd = new SqlCommand("insert into AccountDetails values(@AccountNumber, @AccountName, @AccountAddress, @AccountBalance)");
            cmd.Parameters.AddWithValue("AccountNumber", accountNum);
            cmd.Parameters.AddWithValue("AccountName", customerName);
            cmd.Parameters.AddWithValue("AccountAddress", customerAddress);
            cmd.Parameters.AddWithValue("AccountBalance", balance);
            cmd.Connection = con;
            int i = cmd.ExecuteNonQuery();
            Console.WriteLine(i + "Record(s) got inserted");
        }

        public void TransactionTable(string transactionId, string accountNumber, DateTime transDate, decimal Amount)
        {
            GetCon();
            cmd = new SqlCommand("insert into transactions values(@TransactioNumber,@TransactionANumber, @TransactionDate, @TransactionAmount)");
            cmd.Parameters.AddWithValue("TransactioNumber", transactionId);
            cmd.Parameters.AddWithValue("TransactionANumber", accountNumber);
            cmd.Parameters.AddWithValue("TransactionDate", transDate);
            cmd.Parameters.AddWithValue("TransactionAmount", Amount);
            cmd.Connection = con;
            int i = cmd.ExecuteNonQuery();
            Console.WriteLine(i + "Record(s) got inserted");
        }

        public void TransactionDetails(string accountNumber)
        {

        }
    }
}

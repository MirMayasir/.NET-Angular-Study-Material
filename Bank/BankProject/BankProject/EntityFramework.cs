using BankProject.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    internal class EntityFramework
    {
        public static BankdatabaseContext bk = new BankdatabaseContext();
        
        public void SaveAccountDetails(string accountId, string accountName, string address, decimal amount)
        {
            AccountDetail ad = new AccountDetail();
            ad.Anumber = accountId;
            ad.Aname = accountName;
            ad.Aaddress = address;
            ad.Abalance = amount;
            bk.AccountDetails.Add(ad);
            bk.SaveChanges();
            Console.WriteLine("entry added successfully");
        }

        public void GetTransactions(string accountNumber)
        {
            Console.WriteLine("account details are");
            foreach(var item in bk.Transactions)
            {
                Console.Write(item.Tanumber + " " + item.Tnumber + " " + item.Tdate + " " + item.Tammount);
            }
        }

        public void ChangeDetails(string account,  string accountName, string address)
        {
            AccountDetail ad = new AccountDetail();
            AccountDetail existingAccount = bk.AccountDetails.FirstOrDefault(x => x.Anumber == account);
            if (existingAccount != null)
            {
                existingAccount.Aname = accountName;
                existingAccount.Aaddress = address;
                bk.SaveChanges();

                Console.WriteLine("Account updated successfully.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
        public void DeleteEntry(string accountNumber)
        {
            AccountDetail accountDetail = bk.AccountDetails.FirstOrDefault(y => y.Anumber == accountNumber);
            if (accountDetail != null)
            {
                bk.AccountDetails.Remove(accountDetail);
                bk.SaveChanges();
                Console.WriteLine("account deleted");
            }
            else
            {
                Console.WriteLine("no account found");

            }
        }
    }
}

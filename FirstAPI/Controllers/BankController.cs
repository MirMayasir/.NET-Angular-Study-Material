using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankdatabaseContext _bank;

        public BankController(BankdatabaseContext bank)
        {
            _bank = bank;
        }

        [HttpGet]
        public async Task<ActionResult<List<AccountDetail>>> GetAccountDetails()
        {
            return Ok(await _bank.AccountDetails.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> AddBankDetails(AccountDetail a)
        {
            if (ModelState.IsValid)
            {
                _bank.AccountDetails.Add(a);
                _bank.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest("invalid course object");
            }
        }

        [HttpGet]
        [Route("GetAccountByID")]

        public async Task<ActionResult<AccountDetail>> GetAccountByID(string id)
        {
            var a = _bank.AccountDetails.Where(x =>x.Anumber == id).SingleOrDefault();
            return Ok(a);
        }

        [HttpPut]
        public async Task<ActionResult<AccountDetail>> UpdateAccountDetails(string id, AccountDetail a)
        {
            if (ModelState.IsValid)
            {
                _bank.AccountDetails.Update(a);
                await _bank.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAccount(string id)
        {
            if (ModelState.IsValid)
            {
                AccountDetail a = await _bank.AccountDetails.FindAsync(id);
                _bank.AccountDetails.Remove(a);
                await _bank.SaveChangesAsync();
                return Ok();

            }

            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetAccountByName")]

        public async Task<ActionResult<AccountDetail>> GetAccountByName(string name)
        {
            var a = _bank.AccountDetails.Where(x => x.Aname == name).SingleOrDefault();
            return Ok(a);
        }

        [HttpGet]
        [Route("GetAccountByAddress")]

        public async Task<ActionResult<AccountDetail>> GetAccountByAddress(string address)
        {
            var a = _bank.AccountDetails.Where(x => x.Aaddress == address).SingleOrDefault();
            return Ok(a);
        }

        /*FOR TRANSACTIONS */

        [HttpGet]
        [Route("GetTransactionByAmmount")]
        public async Task<ActionResult<List<Transaction>>> GetTransactionByAmmount(decimal ammount)
        {
            var a = _bank.Transactions.Where(x => x.Tammount == ammount).SingleOrDefault();
            return Ok(a);
        }

        [HttpGet]
        [Route("GetTransactionByID")]
        public async Task<ActionResult<List<Transaction>>> GetTransactionByID(string id)
        {
            var a = _bank.Transactions.Where(x => x.Tnumber == id).SingleOrDefault();
            return Ok(a);
        }

        /*[HttpGet]
        [Route("GetTransactionsByMonth")]
        public async Task<ActionResult<List<Transaction>>> GetTransactionsByMonth(string accountNumber, int month)
        {
            var transactions = await _bank.Transactions
                .Where(x => x.Tanumber == accountNumber &&
                            x.Tdate.Value.ToDateTime(new TimeOnly()).Month == month)
                .ToListAsync();

            return Ok(transactions);
        }*/
        [HttpGet]
        [Route("GetTransactionsByMonth")]
        public async Task<ActionResult<List<Transaction>>> GetTransactionsByMonth(string accountNumber, int month)
        {
            // Fetch all transactions for the given account number
            var transactions = await _bank.Transactions
                .Where(x => x.Tanumber == accountNumber)
                .ToListAsync();

            // Filter transactions by the specified month on the client side
            var filteredTransactions = transactions
                .Where(x => x.Tdate.HasValue &&
                            x.Tdate.Value.Month == month)
                .ToList();

            return Ok(filteredTransactions);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1Rebar.Models;
using MongoDB.Driver;
using System;

namespace Project1Rebar.Services
{
    public class BranchService: IBranchService
    {
        private readonly IMongoCollection<Account> _account;
        public BranchService(IRebarDatabaseSetting settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _account = database.GetCollection<Account>(settings.AccountCollection);
        }
        public Account CreateBranch(Account account)
        {
            Console.WriteLine("orders today:  " + account.Orders.Count);
            Console.WriteLine("Summary of money: " + account.TotalAmount);
            _account.InsertOne(account);
            Console.WriteLine("account numner:"+ account.Id );

            return account;
        }

        public List<Account> GetAccounts()
        {
            return _account.Find(accounts => true).ToList();
        }
    }
}

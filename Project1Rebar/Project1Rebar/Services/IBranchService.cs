using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1Rebar.Models;

namespace Project1Rebar.Services
{
    public interface IBranchService
    {
        List<Account> GetAccounts();
        Account CreateBranch(Account account);
    }
}

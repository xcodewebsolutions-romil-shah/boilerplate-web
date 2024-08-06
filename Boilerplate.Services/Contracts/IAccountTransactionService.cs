using Boilerplate.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.Services.Contracts
{
    public interface IAccountTransactionService
    {
        List<AccountTransactionListDto> GetData();
    }
}

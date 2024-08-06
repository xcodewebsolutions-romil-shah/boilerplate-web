using Boilerplate.Data.Contracts;
using Boilerplate.Infrastructure.Dtos;
using Boilerplate.Infrastructure.Mapping;
using Boilerplate.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boilerplate.Services.Services
{
    public class AccountTransactionService : IAccountTransactionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountTransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<AccountTransactionListDto> GetData()
        {
            try
            {
                var data = _unitOfWork.AccountTransactionRepository.Query().Where(w => w.IsDeleted == false).ToList();

                return Map.EntityToDto(data);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

using AutoMapper;
using Boilerplate.Data.Domains;
using Boilerplate.Infrastructure.Dtos;
using Boilerplate.Infrastructure.Enums;
using Boilerplate.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boilerplate.Infrastructure.Mapping
{
    public partial class Map
    {

        public static AccountTransactionBaseDto BaseEntityToDto(AccountTransaction accountTransaction)
        {
            return new AccountTransactionBaseDto
            {
                AccountNo = accountTransaction.AccountNo,
                AccountTransactionID = accountTransaction.AccountTransactionID,
                TransactionDate = accountTransaction.TransactionDate,
                Amount = accountTransaction.Amount,
                Notes = accountTransaction.Notes,
                TransactionTypeID = accountTransaction.TransactionTypeID
            };
        }

        public static List<AccountTransactionListDto> EntityToDto(List<AccountTransaction> accountTransactions)
        {
            var data = new List<AccountTransactionListDto>();

            foreach (var i in accountTransactions)
            {
                var obj = Shared.AutoMapperInstance<AccountTransaction, AccountTransactionListDto>().
                    Map<AccountTransaction, AccountTransactionListDto>(i);

                obj.TransactionTypeText = ((TransactionTypes)i.TransactionTypeID).ToString();

                data.Add(obj);
            }

            return data;
        }

        public static AccountTransactionCreateOrUpdateDto EntityToDto(AccountTransaction accountTransaction)
        {
            var obj = Shared.AutoMapperInstance<AccountTransaction, AccountTransactionListDto>().
                    Map<AccountTransaction, AccountTransactionCreateOrUpdateDto>(accountTransaction);

            obj.Audits = EntityToDto(accountTransaction.Audits.ToList());

            return obj;
        }

        //public static AccountTransaction DtoToEntity(AccountTransactionCreateOrUpdateDto dto)
        //{
        //    return new 
        //}
    }

}

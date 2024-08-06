using Boilerplate.Data.Domains;
using Boilerplate.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.Infrastructure.Mapping
{
    public partial class Map
    {
        public static List<AccountTransactionAuditDto> EntityToDto(List<AccountTransactionAudit> audits)
        {
            var data = new List<AccountTransactionAuditDto>();

            foreach (var i in audits)
            {
                data.Add(EntityToDto(i));
            }

            return data;
        }

        public static AccountTransactionAuditDto EntityToDto(AccountTransactionAudit audit)
        {
            return new AccountTransactionAuditDto
            {
                Action = audit.Action,
                PerformedBy = audit.PerformedBy,
                PerformedOn = audit.PerformedOn
            };
        }
    }
}

using Boilerplate.Infrastructure.AnnotationAttributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Boilerplate.Infrastructure.Dtos
{
    public class AccountTransactionBaseDto
    {
        [Required]
        [Key]
        public Guid? AccountTransactionID { get; set; }

        [Required]
        [DisplayName("Account No")]
        [DisplayOrder(1)]
        public string AccountNo { get; set; }

        [Required]
        [DisplayName("Transaction Date")]
        [DisplayOrder(2)]
        public DateTime? TransactionDate { get; set; }

        public int TransactionTypeID { get; set; }

        [Required]
        [DisplayName("Amount")]
        [DisplayOrder(3)]
        public decimal? Amount { get; set; }

        public string Notes { get; set; }

    }

    public class AccountTransactionListDto : AccountTransactionBaseDto
    {
        [DisplayName("Transaction Type")]
        [DisplayOrder(4)]
        public string TransactionTypeText { get; set; }
    }

    public class AccountTransactionCreateOrUpdateDto : AccountTransactionBaseDto
    {
        public AccountTransactionCreateOrUpdateDto()
        {
            if (Audits != null)
            {
                Audits = Audits.OrderByDescending(o => o.PerformedOn).ToList();
            }
        }


        [JsonExtensionData]
        public List<AccountTransactionAuditDto> Audits { get; set; }
    }

    public class AccountTransactionAuditDto
    {
        public string Action { get; set; }
        public DateTime PerformedOn { get; set; }
        public string PerformedBy { get; set; }

    }

}

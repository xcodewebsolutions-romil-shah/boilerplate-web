using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boilerplate.Data.Domains
{
    public class AccountTransaction
    {
        public AccountTransaction()
        {
            Audits = new HashSet<AccountTransactionAudit>();
        }

        [Key]
        public Guid? AccountTransactionID { get; set; }

        public string AccountNo { get; set; }

        public DateTime? TransactionDate { get; set; }

        public int TransactionTypeID { get; set; }

        public decimal? Amount { get; set; }

        public string Notes { get; set; }

        public bool IsDeleted { get; set; }

        public string LastActionPerformed { get; set; }
        public DateTime PerformedOn { get; set; }
        public string PerformedBy { get; set; }

        public ICollection<AccountTransactionAudit> Audits { get; set; }

    }

    public class AccountTransactionAudit
    {
        [Key]
        public Guid? AccountTransactionAuditID { get; set; }

        [ForeignKey("AccountTransaction")]
        public Guid AccountTransactionID { get; set; }
        public string Action { get; set; }
        public DateTime PerformedOn { get; set; }
        public string PerformedBy { get; set; }

        public virtual AccountTransaction AccountTransaction { get; set; }
    }
}

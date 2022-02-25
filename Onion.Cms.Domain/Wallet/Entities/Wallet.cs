using System;
using System.ComponentModel.DataAnnotations.Schema;
using Onion.Cms.Domain.User.Entities;
using Onion.Cms.Framework.Domain;

namespace Onion.Cms.Domain.Wallet.Entities
{
    public class Wallet : BaseEntity<long>
    {
        public long WalletTypeId { get; set; }
        public int ApplicationUserId { get; set; }
        public bool IsPay { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        #region Relations
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual WalletType WalletType { get; set; }
        #endregion

    }
}
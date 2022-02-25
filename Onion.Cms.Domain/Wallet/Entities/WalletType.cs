using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onion.Cms.Framework.Domain;

namespace Onion.Cms.Domain.Wallet.Entities
{
    public class WalletType : BaseHcEntity<long>
    {

        #region Relations
        public virtual List<Wallet> Wallets { get; set; }
        #endregion
    }
}

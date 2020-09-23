using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockTrader.Domain.Models
{
    public class Account: CurrentObject
    {
        [Key]
        public int AccountId { get; set; }
        public User WhichUser { get; set; }
        public double Balance { get; set; }
        public ICollection<AssetTransaction> AssetTransactions { get; set; }
    }
}

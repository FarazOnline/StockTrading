using System;
using System.ComponentModel.DataAnnotations;

namespace StockTrader.Domain.Models
{
    public class AssetTransaction: CurrentObject
    {
        //[Key]
        //public int TransactionId { get; set; }
        public Account WhichAccount { get; set; }
        public bool IsPurchase { get; set; }
        public Stock WhichStock { get; set; }
        public int Shares { get; set; }
        public DateTime DateProcessed { get; set; }
    }
}

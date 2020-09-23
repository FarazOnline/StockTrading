using System;
using System.ComponentModel.DataAnnotations;

namespace StockTrader.Domain.Models
{
    public class User: CurrentObject
    {
        //[Key]
        //public int UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateJoined { get; set; }
    }
}

using System;
using System.Runtime.Serialization;

namespace StockTrader.Domain.Exceptions
{
    public class InsufficientBalanceX : Exception
    {
        public double AccBal { get; set; }
        public double ReqBal { get; set; }

        public InsufficientBalanceX(double AB , double RB)
        {
            AccBal = AB;
            ReqBal = RB;
        }

        public InsufficientBalanceX(double AB, double RB, string message) : base(message)
        {
            AccBal = AB;
            ReqBal = RB;
        }

        public InsufficientBalanceX(double AB, double RB, string message, Exception innerException) : base(message, innerException)
        {
            AccBal = AB;
            ReqBal = RB;
        }

        //protected InsufficientBalanceX(SerializationInfo info, StreamingContext context) : base(info, context)
        //{
        //}
    }
}

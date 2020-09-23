using System;

namespace StockTrader.Domain.Exceptions
{
    public class InvalidSymbolX : Exception
    {
        public string Symb { get; set; }

        public InvalidSymbolX(string symb)
        {
            Symb = symb;
        }

        public InvalidSymbolX(string symb, string message) : base(message)
        {
            Symb = symb;
        }

        public InvalidSymbolX(string symb, string message, Exception innerException) : base(message, innerException)
        {
            Symb = symb;
        }

        //protected InvalidSymbolX(SerializationInfo info, StreamingContext context) : base(info, context)
        //{
        //}
    }
}

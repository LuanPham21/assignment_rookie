using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieShop.Utilities.Exeptions
{
    public class RookieShopException : Exception
    {
        public RookieShopException()
        {
        }

        public RookieShopException(string message)
            : base(message)
        {
        }

        public RookieShopException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
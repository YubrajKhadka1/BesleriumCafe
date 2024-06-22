using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bislerium
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }

        // GetUserId method
        public int GetUserId()
        {
            return int.Parse(Id);
        }
    }
}
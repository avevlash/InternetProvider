using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetProvider.Web.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string AccountNumber { get; set; }
        public string Email { get; set; }
        public string Tariffs { get; set; }
        public bool IsBlocked { get; set; }
    }

    public class UserListViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
    }
}
using System;
using System.Collections.Generic;

#nullable disable

namespace TransportationERP.dal.Model
{
    public partial class User
    {
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Salt { get; set; }
        public int? PasswordVersion { get; set; }
        public bool? AccountDisabled { get; set; }
        public string AccountId { get; set; }
    }
}

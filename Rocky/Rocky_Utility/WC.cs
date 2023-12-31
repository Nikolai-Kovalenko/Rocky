﻿using Mailjet.Client.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Rocky_Utility
{
    public static class WC
    {
        public const string ImagePath = @"\images\product\";
        public const string SessionCart = "ShopCartSession";
        public const string SessionInquiryId = "InquirySession";

        public const string AdminRole = "Admin";   
        public const string CustomerRole = "Customer";

        public const string EmailAdin = "DFprotonMAil@proton.me";

        public const string CategotyName = "Category";
        public const string ApplicationTypeName = "ApplicationType";

        public const string Success = "Success";
        public const string Error = "Error";

        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved;";
        public const string StatusInProcess = "Processing";
        public const string StatusShipped = "Shipped";
        public const string StatusConcelled = "Concelled";
        public const string StatusRefunded = "Refunded";

        public static readonly IEnumerable<string> ListStatus = new ReadOnlyCollection<string>(
            new List<string>
            {
                StatusApproved,
                StatusConcelled,
                StatusInProcess,
                StatusShipped,
                StatusConcelled,
                StatusRefunded,
            });
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace ecom
{
    class OrderDetails
    {
        internal readonly decimal UnitPrice;
        internal object[] ProductName;

        public int OrderDetailsId { get; set; }
        public int Customer_Id { get; set; }
        public int ProductId { get; set; }
        public int QuantityOrder { get; set; }
        public decimal TotalAmount { get; set; }
        public object ProductId2 { get; internal set; }
    }
    class OrderDetails2
    {
        internal readonly decimal UnitPrice2;
        internal object[] ProductName2;

        public int OrderDetailsId2 { get; set; }
        public int Customer_Id2 { get; set; }
        public int ProductId2 { get; set; }
        public int QuantityOrder2 { get; set; }
        public decimal TotalAmount2 { get; set; }
    }
    class OrderDetails3
    {
        internal readonly decimal UnitPrice3;
        internal object[] ProductName3;

        public int OrderDetailsId3 { get; set; }
        public int Customer_Id3 { get; set; }
        public int ProductId3 { get; set; }
        public int QuantityOrder3 { get; set; }
        public decimal TotalAmount3 { get; set; }
    }
}


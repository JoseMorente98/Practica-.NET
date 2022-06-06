using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class OrderDetail
    {
        private int docEntry;
        private int itemCode;
        private string itemName;
        private decimal lineTotal;
        private decimal vatSum;

        public int DocEntry { get => docEntry; set => docEntry = value; }
        public int ItemCode { get => itemCode; set => itemCode = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public decimal LineTotal { get => lineTotal; set => lineTotal = value; }
        public decimal VatSum { get => vatSum; set => vatSum = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Sale
{
    public class SaleEntity
    {
        public Int64 id { get; set; }
        public Int64 staff_id { get; set; }
        public string invoice_number { get; set; }
        public DateTime? sale_date { get; set; } = null;
        public string remark { get; set; }
        public decimal amount { get; set; }
        public decimal amount_tax { get; set; }
        public Int16 invoice_status { get; set; }
        public Int32 print_count { get; set; }
        public string reason { get; set; }
        public decimal paid_amount { get; set; }
        public decimal change_amount { get; set; }
        public Int32 created_user_id { get; set; }
        public Int32 updated_user_id { get; set; }
        public DateTime created_datetime { get; set; }
        public DateTime updated_datetime { get; set; }


        public SaleEntity()
        {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        public void InitializedObjectValue()
        {
            this.id = 0;
            this.staff_id = 0;
            this.invoice_number = string.Empty;
            this.sale_date = DateTime.Now;
            this.remark = string.Empty;
            this.amount = 0;
            this.amount_tax = 0;
            this.invoice_status = 0;
            this.print_count = 0;
            this.reason = string.Empty;
            this.paid_amount = 0;
            this.change_amount = 0;
            this.created_user_id = 0;
            this.created_datetime = DateTime.Now;
            this.updated_user_id = 0;
            this.updated_datetime = DateTime.Now;

        }
    }
}

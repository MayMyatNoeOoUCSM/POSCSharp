using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Payment
{
    public class PaymentEntity
    {
        public Int64 id { get; set; }
        public int? stock_id { get; set; }
        public int? sale_id { get; set; }
        // public DateTime? sale_date { get; set; } = null;
        public decimal paid_amount { get; set; }
        //public int payment_type { get; set; }
        public int? payment_type { get; set; } = 1;
        public DateTime payment_date { get; set; }
        public Int16 is_active { get; set; }
        public string remark { get; set; }  
        public Int32 created_user_id { get; set; }
        public Int32 updated_user_id { get; set; }
        public DateTime created_datetime { get; set; }
        public DateTime updated_datetime { get; set; }

        public PaymentEntity()
        {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        public void InitializedObjectValue()
        {
            this.id = 0;
            this.stock_id = 0;
            this.sale_id = 0;
            this.paid_amount = 0;
            this.payment_type = 1;
            this.payment_date = DateTime.Now;        
            this.is_active = 0;
            this.remark = string.Empty;
            this.created_user_id = 0;
            this.created_datetime = DateTime.Now;
            this.updated_user_id = 0;
            this.updated_datetime = DateTime.Now;

        }
    }
}

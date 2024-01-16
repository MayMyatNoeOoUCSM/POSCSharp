using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Stock
{
    public class StockEntity
    {
        public Int64 id { get; set; }
        public DateTime purchase_date { get; set; }

        public int total_amount { get; set; }

        public DateTime? payment_due_date { get; set; }

        public string remark { get; set; }

        public Int16 is_deleted { get; set; }
        public Int32 created_user_id { get; set; }
        public Int32 updated_user_id { get; set; }
        public DateTime created_datetime { get; set; }
        public DateTime updated_datetime { get; set; }
        public StockEntity()
        {
            InitializedObjectValue();
        }
        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        public void InitializedObjectValue()
        {
            this.id = 0;
            this.purchase_date= DateTime.Now;
            this.total_amount = 0;
            this.payment_due_date = DateTime.Now;
            this.remark = "";
            this.is_deleted = 0;
            this.created_user_id = 0;
            this.created_datetime = DateTime.Now;
            this.updated_user_id = 0;
            this.updated_datetime = DateTime.Now;

        }
    }
}

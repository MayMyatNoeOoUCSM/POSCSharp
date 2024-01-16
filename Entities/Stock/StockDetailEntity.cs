using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Stock
{
    public class StockDetailEntity
    {
        public Int64 id { get; set; }

        public Int64 stock_id { get; set; }
        public Int64 product_id { get; set; }
        public decimal purchase_price { get; set; }
        public int purchase_quantity { get; set; }
        public decimal selling_price { get; set; }
        public DateTime? mfd_date { get; set; } = null;
        public DateTime? expired_date { get; set; } = null;
        public Int16 is_active { get; set; }
        public Int16 is_deleted { get; set; }
        public Int32 created_user_id { get; set; }
        public Int32 updated_user_id { get; set; }
        public DateTime created_datetime { get; set; }
        public DateTime updated_datetime { get; set; }
        public string remark { get; set; }

        public StockDetailEntity()
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
            this.product_id = 0;
            this.purchase_price = 0;
            this.purchase_quantity = 0;
            this.selling_price = 0;
            this.mfd_date = DateTime.Now;
            this.expired_date = DateTime.Now;
            this.is_active = 0;
            this.is_deleted = 0;
            this.created_user_id = 0;
            this.created_datetime = DateTime.Now;
            this.updated_user_id = 0;
            this.updated_datetime = DateTime.Now;
            this.remark = string.Empty;
        }
    }
}

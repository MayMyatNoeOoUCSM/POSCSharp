using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Stock
{
    public class StockDiscountEntity
    {
        public Int64 id { get; set; }
        public Int64 product_id { get; set; }
        public int quantity { get; set; }
        public decimal selling_price { get; set; }
        public int discount_percent { get; set; } 
        public decimal discount_amount { get; set; }        
        public Int32 created_user_id { get; set; }
        public Int32 updated_user_id { get; set; }
        public DateTime created_datetime { get; set; }
        public DateTime updated_datetime { get; set; }
        public Int16 is_active { get; set; }
        public string remark { get; set; }

        public StockDiscountEntity()
        {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        public void InitializedObjectValue()
        {
            this.id = 0;
            this.product_id = 0;
            this.quantity = 0;
            this.selling_price = 0;
            this.discount_percent = 0;        
            this.discount_amount = 0;
            this.created_user_id = 0;
            this.created_datetime = DateTime.Now;
            this.updated_user_id = 0;
            this.updated_datetime = DateTime.Now;
            this.is_active = 1;
            this.remark = string.Empty;
        }
    }
}

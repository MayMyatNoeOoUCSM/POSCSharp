using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Stock
{
    public class StockSaleEntity
    {
        public Int64 id { get; set; }
        public Int64 product_id { get; set; }
        public decimal selling_price { get; set; }
        public int quantity { get; set; }
        public DateTime? expired_date { get; set; } = null;
        public Int16 is_active { get; set; }
        public StockSaleEntity()
        {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        internal void InitializedObjectValue()
        {
            this.id = 0;
            this.product_id = 0;
            this.selling_price = 0;
            this.quantity = 0;
            this.expired_date = DateTime.Now;
            this.is_active = 0;
        }
    }
}

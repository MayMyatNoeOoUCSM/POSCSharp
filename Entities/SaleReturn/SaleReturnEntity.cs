using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.SaleReturn
{
    /// <summary>
    /// Defines the <see cref="SaleReturnEntity" />.
    /// </summary>
    public class SaleReturnEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Int64 id { get; set; }

        /// <summary>
        /// Gets or sets the return_invoice_number.
        /// </summary>
        public string return_invoice_number { get; set; }

        /// <summary>
        /// Gets or sets the sale_id.
        /// </summary>
        public Int64 sale_id { get; set; }

        /// <summary>
        /// Gets or sets the return_date.
        /// </summary>
        public DateTime return_date { get; set; }

        /// <summary>
        /// Gets or sets the is_deleted.
        /// </summary>
        public Int16 is_deleted { get; set; }

        /// <summary>
        /// Gets or sets the remark.
        /// </summary>
        public String remark { get; set; }

        /// <summary>
        /// Gets or sets the create_user_id.
        /// </summary>
        public Int32 created_user_id { get; set; }

        /// <summary>
        /// Gets or sets the create_datetime.
        /// </summary>
        public DateTime created_datetime { get; set; }

        /// <summary>
        /// Gets or sets the update_user_id.
        /// </summary>
        public Int32 updated_user_id { get; set; }

        /// <summary>
        /// Gets or sets the update_datetime.
        /// </summary>
        public DateTime updated_datetime { get; set; }

        /// <summary>
        /// Gets or sets the SaleReturnDetails.
        /// </summary>
        public List<SaleReturnEntityDetails> SaleReturnDetails { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleReturnEntity"/> class.
        /// </summary>
        public SaleReturnEntity()
        {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        internal void InitializedObjectValue()
        {
            this.id = 0;
            this.return_invoice_number = String.Empty;
            this.sale_id = 0;
            this.return_date = DateTime.Now;
            this.is_deleted = 0;
            this.created_user_id = 0;
            this.created_datetime = DateTime.Now;
            this.updated_user_id = 0;
            this.updated_datetime = DateTime.Now;
            this.SaleReturnDetails = new List<SaleReturnEntityDetails>();
        }

        /// <summary>
        /// Defines the <see cref="SaleReturnEntityDetails" />.
        /// </summary>
        public class SaleReturnEntityDetails
        {
            /// <summary>
            /// Gets or sets the id.
            /// </summary>
            public Int64 id { get; set; }

            /// <summary>
            /// Gets or sets the return_id.
            /// </summary>
            public Int64 return_id { get; set; }

            /// <summary>
            /// Gets or sets the product_id.
            /// </summary>
            public Int64 product_id { get; set; }
            
            /// <summary>
            /// Gets or sets the product_id.
            /// </summary>
            public Int64 sale_id { get; set; }

            /// <summary>
            /// Gets or sets the price.
            /// </summary>
            public Decimal price { get; set; }

            /// <summary>
            /// Gets or sets the quantity.
            /// </summary>
            public Int32 quantity { get; set; }

            /// <summary>
            /// Gets or sets the remark.
            /// </summary>
            public String remark { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="SaleReturnEntityDetails"/> class.
            /// </summary>
            public SaleReturnEntityDetails()
            {
                InitializedObjectValue();
            }

            /// <summary>
            /// The InitializedObjectValue.
            /// </summary>
            internal void InitializedObjectValue()
            {
                this.id = 0;
                this.return_id = 0;
                this.product_id = 0;
                this.sale_id = 0;
                this.price = 0;
                this.quantity = 0;
                this.remark = String.Empty;
            }
        }
    }
}

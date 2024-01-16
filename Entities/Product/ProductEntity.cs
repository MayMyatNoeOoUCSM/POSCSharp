namespace Entities.Product
{
    using System;

    /// <summary>
    /// Defines the <see cref="ProductEntity" />.
    /// </summary>
    public class ProductEntity
    {
        /// <summary>
        /// Gets or sets the category_name.
        /// </summary>
        public string category_name { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int id { get; set; }
        public Int64 supplier_id { get; set; }
        public Int64 category_id { get; set; }
        public Int64 sub_category_id { get; set; }
        public string product_name { get; set; }

        /// <summary>
        /// Gets or sets the product_code.
        /// </summary>
        public string product_code { get; set; }

        /// <summary>
        /// Gets or sets the barcode.
        /// </summary>
        public string barcode { get; set; }

        public string product_description { get; set; }

        /// <summary>
        /// Gets or sets the product_image_path.
        /// </summary>
        public string product_image_path { get; set; }

        public Int16 is_deleted { get; set; }

        /// <summary>
        /// Gets or sets the create_user_id.
        /// </summary>
        public Int32 created_user_id { get; set; }

        /// <summary>
        /// Gets or sets the update_user_id.
        /// </summary>
        public Int32 updated_user_id { get; set; }

        /// <summary>
        /// Gets or sets the create_datetime.
        /// </summary>
        public DateTime created_datetime { get; set; }

        /// <summary>
        /// Gets or sets the update_datetime.
        /// </summary>
        public DateTime updated_datetime { get; set; }

        /// <summary>
        /// stock_level
        /// </summary>
        public int stock_level { get; set; }
        
        /// <summary>
        /// stock_level
        /// </summary>
        public Int32 brand_id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductEntity"/> class.
        /// </summary>
        public ProductEntity()
        {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        internal void InitializedObjectValue()
        {
            this.category_name = String.Empty;
            this.id = 0;
            this.supplier_id = 0;
            this.category_id = 0;
            this.sub_category_id = 0;
            this.product_code = String.Empty;
            this.barcode = String.Empty;
            this.product_name = String.Empty;
            this.product_description = String.Empty;
            this.product_image_path = String.Empty;
            this.is_deleted = 0;
            this.created_user_id = 0;
            this.created_datetime = DateTime.Now;
            this.updated_user_id = 0;
            this.updated_datetime = DateTime.Now;
            this.stock_level = 0;
            this.brand_id = 0;
        }
    }
}

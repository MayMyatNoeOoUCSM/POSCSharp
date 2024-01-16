namespace Entities.DamageLoss
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="DamageLossEntity" />.
    /// </summary>
    public class DamageLossEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Int64 id { get; set; }

        /// <summary>
        /// Gets or sets the product_id.
        /// </summary>
        public Int64? product_id { get; set; }
        
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public Int64? quantity { get; set; }
        
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public Decimal price { get; set; }
        
        /// <summary>
        /// Gets or sets the product_status.
        /// </summary>
        public Int64? product_status { get; set; }

        /// <summary>
        /// Gets or sets the damageloss_date.
        /// </summary>
        public DateTime damageloss_date { get; set; }

        /// <summary>
        /// Gets or sets the remark.
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// Gets or sets the is_deleted.
        /// </summary>
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
        /// Gets or sets the DamageLossDetails.
        /// </summary>
        //public List<DamageLossEntryDetails> DamageLossDetails { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DamageLossEntity"/> class.
        /// </summary>
        public DamageLossEntity()
        {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        public void InitializedObjectValue()
        {
            this.id = 0;
            this.product_id = null;
            this.quantity = null;
            this.price = 0;
            this.product_status = null;
            this.damageloss_date = DateTime.Now;
            this.remark = string.Empty;
            this.is_deleted = 0;
            this.created_user_id = 0;
            this.updated_user_id = 0;
            this.created_datetime = DateTime.Now;
            this.updated_datetime = DateTime.Now;
            //this.DamageLossDetails = new List<DamageLossEntryDetails>();
        }

        /// <summary>
        /// Defines the <see cref="DamageLossDetails" />.
        /// </summary>
        //public class DamageLossEntryDetails
        //{
        //    /// <summary>
        //    /// Gets or sets the id.
        //    /// </summary>
        //    public Int64 id { get; set; }

        //    /// <summary>
        //    /// Gets or sets the damage_loss_id.
        //    /// </summary>
        //    public Int64 damage_loss_id { get; set; }

        //    /// <summary>
        //    /// Gets or sets the product_id.
        //    /// </summary>
        //    public Int64 product_id { get; set; }

        //    /// <summary>
        //    /// Gets or sets the price.
        //    /// </summary>
        //    public Decimal price { get; set; }

        //    /// <summary>
        //    /// Gets or sets the quantity.
        //    /// </summary>
        //    public Int32 quantity { get; set; }

        //    /// <summary>
        //    /// Gets or sets the product_status.
        //    /// </summary>
        //    public Int32 product_status { get; set; }

        //    /// <summary>
        //    /// Gets or sets the remark.
        //    /// </summary>
        //    public string remark { get; set; }

        //    /// <summary>
        //    /// Initializes a new instance of the <see cref="DamageLossEntryDetails"/> class.
        //    /// </summary>
        //    public DamageLossEntryDetails()
        //    {
        //        InitializedObjectValue();
        //    }

        //    /// <summary>
        //    /// The InitializedObjectValue.
        //    /// </summary>
        //    public void InitializedObjectValue()
        //    {
        //        this.id = 0;
        //        this.damage_loss_id = 0;
        //        this.product_id = 0;
        //        this.price = 0;
        //        this.quantity = 0;
        //        this.product_status = 0;
        //        this.remark = String.Empty;
        //    }
        //}
    }
}

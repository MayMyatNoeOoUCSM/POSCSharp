using System;

namespace Entities.Customer
{
    public class CustomerEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Int64 id { get; set; }

        /// <summary>
        /// Gets or sets the customer_name.
        /// </summary>
        public string customer_name { get; set; }

        /// <summary>
        /// Gets or sets the customer_description.
        /// </summary>
        public string customer_description { get; set; }

        /// <summary>
        /// Gets or sets the phoneno.
        /// </summary>
        public string phone_no { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string address { get; set; }

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
        /// Initializes a new instance of the <see cref="CategoryEntity"/> class.
        /// </summary>
        public CustomerEntity()
        {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        internal void InitializedObjectValue()
        {
            this.id = 0;
            this.customer_name = String.Empty;
            this.customer_description = String.Empty;
            this.address = String.Empty;
            this.email = String.Empty;
            this.phone_no = String.Empty;
            this.remark = String.Empty;
            this.is_deleted = 0;
            this.created_user_id = 0;
            this.created_datetime = DateTime.Now;
            this.updated_user_id = 0;
            this.updated_datetime = DateTime.Now;
        }
    }
}

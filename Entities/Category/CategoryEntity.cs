namespace Entities.Category
{
    using System;

    /// <summary>
    /// Defines the <see cref="CategoryEntity" />.
    /// </summary>
    public class CategoryEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Int64 id { get; set; }

        /// <summary>
        /// Gets or sets the parent_category_id.
        /// </summary>
        public Int64 parent_category_id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string description { get; set; }

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
        public CategoryEntity()
        {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        internal void InitializedObjectValue()
        {
            this.id = 0;
            this.parent_category_id = 0;
            this.name = String.Empty;
            this.description = String.Empty;
            this.is_deleted = 0;
            this.created_user_id = 0;
            this.created_datetime = DateTime.Now;
            this.updated_user_id = 0;
            this.updated_datetime = DateTime.Now;
        }
    }
}

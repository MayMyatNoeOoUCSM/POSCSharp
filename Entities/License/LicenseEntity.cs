using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.License
{
    /// <summary>
    /// Defines the <see cref="LicenseEntity" />.
    /// </summary>
    public class LicenseEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Int64 id { get; set; }

        /// <summary>
        /// Gets or sets the license_key.
        /// </summary>
        public string license_key { get; set; }

        /// <summary>
        /// Gets or sets the created_date.
        /// </summary>
        public DateTime created_date { get; set; }

        /// <summary>
        /// Gets or sets the expired_date.
        /// </summary>
        public DateTime expired_date { get; set; }

        /// <summary>
        /// Gets or sets the is_expired.
        /// </summary>
        public Int16 is_expired { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LicenseEntity"/> class.
        /// </summary>
        public LicenseEntity()
        {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        internal void InitializedObjectValue()
        {
            this.id = 0;
            this.license_key = String.Empty;
            this.created_date = DateTime.Now;
            this.expired_date = DateTime.Now;
            this.is_expired = 0;
        }
    }
}

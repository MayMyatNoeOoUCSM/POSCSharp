namespace Entities.Staff
{
    using System;
    public class StaffEntity
    {
        public Int64 id { get; set; }
        public string staff_id { get; set; }
        public string password { get; set; }
        public Int16 role { get; set; }
        public Int16 staff_type { get; set; }
        public string bank_account_number { get; set; }
        public string education_level { get; set; }
        public string name { get; set; }
        public Int16 gender { get; set; }
        public string nrc_number { get; set; }
        public DateTime? dob { get; set; }
        public string address { get; set; }
        public string photo { get; set; }
        public string phone_no_1 { get; set; }
        public string phone_no_2 { get; set; }
        public DateTime? join_from { get; set; }
        public DateTime? join_to { get; set; }
        public Int16 active_status { get; set; }
        public string remark { get; set; }
        public Int16 is_deleted { get; set; }
        public Int32 created_user_id { get; set; }
        public Int32 updated_user_id { get; set; }
        public DateTime created_datetime { get; set; }
        public DateTime updated_datetime { get; set; }

        public StaffEntity()
        {
            InitializedObjectValue();
        }
        internal void InitializedObjectValue()
        {
            this.id = 0;
            this.staff_id = String.Empty;
            this.password = String.Empty;
            this.bank_account_number = String.Empty;
            this.education_level = String.Empty;
            this.name = String.Empty;
            this.gender = 0;
            this.nrc_number = String.Empty;
            this.dob = DateTime.Now;
            this.address = String.Empty;
            this.photo = String.Empty;
            this.phone_no_1 = String.Empty;
            this.phone_no_2 = String.Empty;
            this.join_from = DateTime.Now;
            this.join_to = DateTime.Now;
            this.active_status = 0;
            this.remark = String.Empty;
            this.is_deleted = 0;
            this.created_user_id = 0;
            this.created_datetime = DateTime.Now;
            this.updated_user_id = 0;
            this.updated_datetime = DateTime.Now;
        }
    }
}

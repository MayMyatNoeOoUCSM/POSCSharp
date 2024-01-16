using System.Data.SQLite;
using DAO.Common;
using Entities.Staff;
using System;
using System.Data;

namespace DAO.Staff
{
    public class StaffDao
    {
        private DataTable dtResult = new DataTable();

        private string strSql = String.Empty;

        private DbConnection connection = new DbConnection();

        public DataTable GetStaffList()
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER BY  id) AS sr, name, staff_id,'' AS role_name, '' AS staff_name, " +
                     "date(join_from) as join_from, role, staff_type, id " +
                     "FROM m_staff " +
                     "WHERE is_deleted <> 1 ORDER BY id; ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public DataTable GetStaff(Int64 staffId)
        {
            strSql = "SELECT * FROM m_staff " +
                     "WHERE is_deleted <> 1 AND id = " + staffId + "; ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public object GetStaffNumber(string staffType)
        {
            strSql = "SELECT staff_id FROM m_staff " +
                     "WHERE substring(staff_id, 1, 1) = '" + staffType + "' " +
                     "ORDER BY id DESC;";
            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }

        public void SaveStaffInformation(StaffEntity staff)
        {
            strSql = "INSERT INTO m_staff(staff_id, password, role, staff_type, bank_account_number, education_level, name, gender," +
                     " nrc_number, dob, address, photo ,phone_no_1,phone_no_2, join_from, join_to, active_status, remark, is_deleted,created_user_id, created_datetime," +
                     " updated_user_id, updated_datetime)  " +
                     " VALUES(@staff_id, @password, @role, @staff_type, @bank_account_number, @education_level, @name, @gender," +
                     " @nrc_number, @dob, @address, @photo, @phone_no_1, @phone_no_2,@join_from, @join_to, @active_status, @remark,@is_deleted, @created_user_id, @created_datetime, @updated_user_id," +
                     " @updated_datetime)";

            SQLiteParameter[] sqliteDetailParams = {
                                                new SQLiteParameter("@staff_id", staff.staff_id),
                                                new SQLiteParameter("@password", staff.password ),
                                                new SQLiteParameter ("@role", staff.role),
                                                new SQLiteParameter("@staff_type", staff.staff_type),
                                                new SQLiteParameter("@bank_account_number", staff.bank_account_number),
                                                new SQLiteParameter("@education_level", staff.education_level),
                                                new SQLiteParameter ("@name", staff.name),
                                                new SQLiteParameter("@gender", staff.gender ),
                                                new SQLiteParameter("@nrc_number", staff.nrc_number),
                                                new SQLiteParameter("@dob", staff.dob),
                                                new SQLiteParameter("@address", staff.address),
                                                new SQLiteParameter("@photo", staff.photo),
                                                new SQLiteParameter("@phone_no_1", staff.phone_no_1),
                                                new SQLiteParameter("@phone_no_2", staff.phone_no_2),
                                                new SQLiteParameter ("@join_from", staff.join_from),
                                                new SQLiteParameter("@join_to", staff.join_to),
                                                new SQLiteParameter("@active_status", staff.active_status),
                                                new SQLiteParameter("@remark", staff.remark),
                                                 new SQLiteParameter("@is_deleted", staff.is_deleted),
                                                new SQLiteParameter ("@created_user_id", staff.created_user_id),
                                                new SQLiteParameter ("@created_datetime", staff.created_datetime),
                                                new SQLiteParameter ("@updated_user_id", staff.updated_user_id),
                                                new SQLiteParameter ("@updated_datetime", staff.updated_datetime)
                                            };
            connection.ExecuteNonQuery(CommandType.Text, strSql, sqliteDetailParams);
            sqliteDetailParams = null;
        }

        public void UpdateStaffInformatin(StaffEntity staff)
        {
            strSql = "UPDATE m_staff SET staff_id = @staff_id,  role = @role, " +
                     "staff_type = @staff_type , bank_account_number = @bank_account_number, education_level = @education_level," +
                     "name = @name ,gender = @gender ,nrc_number = @nrc_number ,dob = @dob ,address = @address ," +
                     "photo = @photo ,phone_no_1 = @phone_no_1 ,phone_no_2 = @phone_no_2 ,join_from = @join_from ,join_to = @join_to ,active_status = @active_status , remark= @remark, " +
                     "is_deleted =@is_deleted,updated_user_id = @updated_user_id , updated_datetime = @updated_datetime where id = " + staff.id;

            SQLiteParameter[] sqliteParams = {
                                                new SQLiteParameter("@staff_id", staff.staff_id),
                                                new SQLiteParameter ("@role", staff.role),
                                                new SQLiteParameter("@staff_type", staff.staff_type),
                                                new SQLiteParameter("@bank_account_number", staff.bank_account_number),
                                                new SQLiteParameter("@education_level", staff.education_level),
                                                new SQLiteParameter ("@name", staff.name),
                                                new SQLiteParameter("@gender", staff.gender ),
                                                new SQLiteParameter("@nrc_number", staff.nrc_number),
                                                new SQLiteParameter("@dob", staff.dob),
                                                new SQLiteParameter("@address", staff.address),
                                                new SQLiteParameter("@photo", staff.photo),
                                                new SQLiteParameter("@phone_no_1", staff.phone_no_1),
                                                new SQLiteParameter("@phone_no_2", staff.phone_no_2),
                                                new SQLiteParameter ("@join_from", staff.join_from),
                                                new SQLiteParameter("@join_to", staff.join_to),
                                                new SQLiteParameter("@active_status", staff.active_status),
                                                new SQLiteParameter("@remark", staff.remark),
                                                 new SQLiteParameter("@is_deleted", staff.is_deleted),
                                                new SQLiteParameter ("@updated_user_id", staff.updated_user_id),
                                                new SQLiteParameter ("@updated_datetime", DateTime.Now)
                                                };
            connection.ExecuteNonQuery(CommandType.Text, strSql, sqliteParams);
            sqliteParams = null;
        }

        public DataTable GetJoinTo()
        {
            strSql = "SELECT join_to FROM m_staff WHERE active_status = 1;";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public DataTable GetSearchResult(
           string staffName,
           string staffNo,
           int role,
           int staffType,
           string staff_status,
           int isDateChange)
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER BY  id) AS sr, st.name, staff_id,'' AS role_name, " +
                     "date(st.join_from) as join_from, role, st.id " +
                     " FROM m_staff st " +
                     " WHERE is_deleted <> 1 AND (st.name LIKE '%" + staffName + "%' OR st.name = '' OR st.name IS NULL)" +
                     " AND (st.active_status LIKE '%" + staff_status + "%' OR st.active_status = '' OR st.active_status IS NULL)" +
                     " AND (st.staff_id LIKE '%" + staffNo + "%' OR st.staff_id = '' OR st.staff_id IS NULL)" +
                     " AND (st.role = " + role + " OR 0 = " + role + ")" +
                     " AND (st.staff_type = " + staffType + " OR 0 = " + staffType + ")";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public void DeleteStaff(Int64 staffId)
        {
            strSql = "UPDATE m_staff SET is_deleted = 1 WHERE id = " + staffId;
            connection.ExecuteNonQuery(CommandType.Text, strSql, null);
        }

        public DataTable GetStaffNumberList()
        {
            strSql = "SELECT id, staff_id FROM m_staff WHERE is_deleted <> 1; ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public object CheckExistNRC(string nrcno,string id)
        {
            strSql = "SELECT * FROM m_staff WHERE is_deleted = 0 AND (id != '" + id + "' OR id = '' OR id IS NULL) AND LOWER(nrc_number)= " + "LOWER('" + nrcno + "');";
            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }
    }
}

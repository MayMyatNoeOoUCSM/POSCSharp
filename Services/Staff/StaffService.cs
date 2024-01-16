using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Staff;
using Entities.Staff;
using System.Data;

namespace Services.Staff
{
    public class StaffService
    {
        private StaffDao staffDao = new StaffDao();

        public DataTable GetStaffList()
        {
            return staffDao.GetStaffList();
        }

        public DataTable GetStaff(Int64 staffId)
        {
            return staffDao.GetStaff(staffId);
        }

        public DataTable GetJoinTo()
        {
            return staffDao.GetJoinTo();
        }

        public DataTable GetStaffList(Int64 staffId)
        {
            return staffDao.GetStaff(staffId);
        }

        //public DataTable GetSearchResult(string staffName, string staffNo, int role, int staff_status)
        //{
        //    return staffDao.GetSearchResult(staffName, staffNo, role, staff_status);
        //}

        public DataTable GetSearchResult(string staffName, string staffNo, int role, int staffType, string staff_status, int isDateChange)
        {
            return staffDao.GetSearchResult(staffName, staffNo, role, staffType, staff_status, isDateChange);
        }

        public object GetStaffNumber(string staffType)
        {
            if (staffType == "Admin")
            {
                staffType = "A";
            }
            else if (staffType == "Staff")
            {
                staffType = "S";
            }
            else
            {
                staffType = String.Empty;
            }
            return staffDao.GetStaffNumber(staffType);
        }

        public void SaveStaffInformation(StaffEntity staff)
        {
            staffDao.SaveStaffInformation(staff);
        }

        public void UpdateStaffInformatin(StaffEntity staff)
        {
            staffDao.UpdateStaffInformatin(staff);
        }

        public void DeleteStaff(Int64 staffId)
        {
            staffDao.DeleteStaff(staffId);
        }

        public DataTable GetStaffNumberList()
        {
            return staffDao.GetStaffNumberList();
        }

        public object CheckExistNRC(string nrcno, string id)
        {
            return staffDao.CheckExistNRC(nrcno,id);
        }
    }
}

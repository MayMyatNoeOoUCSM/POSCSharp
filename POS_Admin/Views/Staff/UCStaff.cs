using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Views;
using DAO.Common;
using Entities.Staff;
using Services.Staff;
using POS_Admin.Utilities;
using POS_Admin.Views.Auth;
using System.IO;
using System.Text.RegularExpressions;
using POS_Admin.Properties;
using Messages = DAO.Common.Messages;

namespace POS_Admin.Views.Staff
{
    public partial class UCStaff : UserControl
    {
        #region==========Data Declaration==========
        /// <summary>
        /// Defines the localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        /// Defines the staff.
        /// </summary>
        private StaffEntity staff = new StaffEntity();

        /// <summary>
        /// Defines the staffService.
        /// </summary>
        private StaffService staffService = new StaffService();

        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines the mainForm.
        /// </summary>
        private MainForm mainForm = null;

        /// <summary>
        /// Defines the dtShop, dtStaff...........
        /// </summary>
        private DataTable dtShop = new DataTable(),
                          dtStaff = new DataTable();

        /// <summary>
        /// Defines the genderId, mstautusId,changeFromDate,changeToDate...........
        /// </summary>
        private Int16 genderId = 0,
                      mstautusId = 0,
                      changeFromDate = 0,
                      changeToDate = 0,
                      changeDob = 0;

        /// <summary>
        /// Gets or sets the joinFromDate.
        /// </summary>
        private DateTime? joinFromDate { get; set; }

        /// <summary>
        /// Gets or sets the joinToDate.
        /// </summary>
        private DateTime? joinToDate { get; set; }

        /// <summary>
        /// Gets or sets the dob.
        /// </summary>
        private DateTime? dob { get; set; }

        /// <summary>
        /// Defines the imagePath, password, extension, basePath, staffPath, imageName, saveDirectory...........
        /// </summary>
        private string imagePath = String.Empty,
                       password = String.Empty,
                       extension = String.Empty,
                       basePath = String.Empty,
                       staffPath = String.Empty,
                       imageName = String.Empty,
                       saveDirectory = String.Empty,
                       staffNumber = String.Empty;

        /// <summary>
        /// Defines the genderChange, mstatusChange...........
        /// </summary>
        private bool genderChange = false,
                     mstatusChange = false,
                     isValid = false;

        /// <summary>
        /// patternPassword
        /// </summary>
        private string patternPassword = @"^(?=.*\d)(?=.*[A-Z]).{8,15}$";

        // open file dialog
        /// <summary>
        /// Defines the open.
        /// </summary>
        OpenFileDialog open = new OpenFileDialog();
        #endregion

        #region==========Data Validation==========
        /// <summary>
        /// The Validation.
        /// </summary>
        private void Validation()
        {
            bool isExist = false;
            isExist = Convert.ToBoolean(staffService.CheckExistNRC(txtNrcNo.Text, lblId.Text));
            if (changeFromDate == 1)
            {
                joinFromDate = dtpJoinFrom.Value;
            }
            if (changeToDate == 1)
            {
                joinToDate = dtpJoinTo.Value;
            }
            if (changeDob == 1)
            {
                dob = dtpDob.Value;
            }
            if (isExist)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(DAO.Common.Messages.W0067, DAO.Common.Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0011, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
                txtNrcNo.Text = string.Empty;
                txtNrcNo.Focus();
                isValid = false;
            }
            if (String.IsNullOrEmpty(txtStaffName.Text))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0070, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0001, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                isValid = false;
            }
            else if (cboStaffRole.SelectedIndex == 0)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0072, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0002, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                    
                isValid = false;
            }
            else if (String.IsNullOrEmpty(txtPassword.Text) && txtPassword.Visible && !txtPassword.ReadOnly)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0011, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0004, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
                isValid = false;
            }
            else if (String.IsNullOrEmpty(txtConfirmedPassword.Text) && txtConfirmedPassword.Visible && !txtPassword.ReadOnly)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0009, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0005, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
                isValid = false;
            }
            else if (!String.Equals(txtPassword.Text, txtConfirmedPassword.Text) && txtPassword.Visible && !txtPassword.ReadOnly)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.E0001, Messages.T0003, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(Messages.B0059, Messages.F0003, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                isValid = false;
            }
            else if (String.IsNullOrEmpty(txtPassword.Text) && txtPassword.Visible && !txtPassword.ReadOnly)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0009, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0005, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                isValid = false;
            }
            else if (!Regex.IsMatch(txtPassword.Text, patternPassword) && txtPassword.Visible && !txtPassword.ReadOnly)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0065, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0006, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                isValid = false;
            }
            else if (cboStaffType.SelectedIndex == 0)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0073, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0003, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                isValid = false;
            }
            else if (String.IsNullOrEmpty(txtNrcNo.Text))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0071, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0007, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                isValid = false;
            }
            else if (!rdoFemale.Checked && !rdoMale.Checked && !rdoOther.Checked)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0006, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0008, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
                isValid = false;
            }
            else if (!joinFromDate.Equals(null) && !joinToDate.Equals(null))
            {
                if (joinToDate < joinFromDate)
                {
                    if (DAO.Common.Consts.LANGUAGEID == 1)
                    {
                        MessageBox.Show(Messages.W0016, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(Messages.B0009, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                    
                    isValid = false;
                    return;
                }
                else
                {
                    isValid = true;
                    return;
                }
            }
            else if (joinFromDate == null)
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0066, Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0010, Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
                isValid = false;
                return;
            }
            else
            {
                isValid = true;
            }
        }
        #endregion

        #region==========Data Clear==========
        /// <summary>
        /// The Clear.
        /// </summary>
        private void Clear()
        {
            txtStaffNo.Text = String.Empty;
            txtStaffName.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtConfirmedPassword.Text = String.Empty;
            txtBankAccountNo.Text = String.Empty;
            txtNrcNo.Text = String.Empty;
            txtPhoneNumber1.Text = String.Empty;
            txtPhoneNumber2.Text = String.Empty;
            txtEducation.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtRemark.Text = String.Empty;
            dtpJoinFrom.CustomFormat = " ";
            dtpJoinTo.CustomFormat = " ";
            dtpDob.CustomFormat = " ";
            rdoMale.Checked = false;
            rdoFemale.Checked = false;
            rdoOther.Checked = false;
            cboStaffRole.SelectedIndex = 0;
            cboStaffType.SelectedIndex = 0;
            picProfile.Image = null;
            chkActive.Checked = false;
            changeDob = 0;
            changeFromDate = 0;
            changeToDate = 0;
            txtStaffName.Focus();
        }
        #endregion

        #region==========Bind ComboData==========
        /// <summary>
        /// The BindCboStaffRole.
        /// </summary>
        private void BindCboStaffRole()
        {
            Dictionary<int, string> staffRole = new Dictionary<int, string>();
            if (DAO.Common.Consts.LANGUAGEID == 1)
            {
                staffRole.Add(0, "Select Role");
            }
            else
            {
                staffRole.Add(0, "အဆင့်ရွေးပါ");
                cboStaffRole.Font = new Font("Myanmar Text", 10);
            }           
            staffRole.Add(1, "Admin");
            staffRole.Add(2, "Staff");
            cboStaffRole.DataSource = new BindingSource(staffRole, null);
            cboStaffRole.DisplayMember = "Value";
            cboStaffRole.ValueMember = "Key";
            cboStaffRole.SelectedIndex = 0;
        }

        /// <summary>
        /// BindCboStaffType
        /// </summary>
        private void BindCboStaffType()
        {
            Dictionary<int, string> staffType = new Dictionary<int, string>();
            if (DAO.Common.Consts.LANGUAGEID == 1)
            {
                staffType.Add(0, "Select Type");
            }
            else
            {
                staffType.Add(0, "ရာထူးရွေးပါ");
                cboStaffType.Font = new Font("Myanmar Text", 10);
            }            
            staffType.Add(1, "Full Time");
            staffType.Add(2, "Part Time");
            cboStaffType.DataSource = new BindingSource(staffType, null);
            cboStaffType.DisplayMember = "Value";
            cboStaffType.ValueMember = "Key";
            cboStaffType.SelectedIndex = 0;
        }
        #endregion

        #region==========Fill Data==========
        /// <summary>
        /// ShowStaffListForm.
        /// </summary>
        private void ShowStaffListForm()
        {
            UCStaffList ucStaffList = new UCStaffList();
            this.Controls.Clear();
            this.Controls.Add(ucStaffList);
        }
      
        /// <summary>
        /// The GetStaffInfo.
        /// </summary>
        private void GetStaffInfo()
        {
            btnClear.Visible = false;
            txtPassword.ReadOnly = true;
            txtConfirmedPassword.ReadOnly = true;
            lblFromHeaderText.Visible = false;
            lblFromHeaderText.Text = "Edit Staff Form";
            cboStaffRole.SelectedItem = cboStaffRole.Items[Convert.ToInt16(dtStaff.Rows[0]["role"])];
            cboStaffType.SelectedItem = cboStaffType.Items[Convert.ToInt16(dtStaff.Rows[0]["staff_type"])];
            txtStaffNo.Text = dtStaff.Rows[0]["staff_id"].ToString();
            staffNumber = dtStaff.Rows[0]["staff_id"].ToString();
            txtStaffName.Text = dtStaff.Rows[0]["name"].ToString();
            txtPassword.Text = Encryption.PasswordEncrypt(dtStaff.Rows[0]["password"].ToString());
            txtConfirmedPassword.Text = txtPassword.Text;
            txtNrcNo.Text = dtStaff.Rows[0]["nrc_number"].ToString();
            txtEducation.Text = dtStaff.Rows[0]["education_level"].ToString();
            txtPhoneNumber1.Text = dtStaff.Rows[0]["phone_no_1"].ToString();
            txtPhoneNumber2.Text = dtStaff.Rows[0]["phone_no_2"].ToString();
            txtAddress.Text = dtStaff.Rows[0]["address"].ToString();
            txtBankAccountNo.Text = dtStaff.Rows[0]["bank_account_number"].ToString();
            txtRemark.Text = dtStaff.Rows[0]["remark"].ToString();
            if (staffNumber == "A001")
            {
                cboStaffRole.Enabled = false;
                txtPassword.ReadOnly = true;
                txtConfirmedPassword.ReadOnly = true;
            }
            if (dtStaff.Rows[0]["dob"] != DBNull.Value)
            {
                dtpDob.Value = Convert.ToDateTime(dtStaff.Rows[0]["dob"]);
            }
            dtpJoinFrom.Value = Convert.ToDateTime(dtStaff.Rows[0]["join_from"]);
            if (dtStaff.Rows[0]["join_to"] != DBNull.Value)
            {
                dtpJoinTo.Value = Convert.ToDateTime(dtStaff.Rows[0]["join_to"]);
            }
            if (!String.IsNullOrEmpty(dtStaff.Rows[0]["photo"].ToString()))
            {
                string imgPath = (dtStaff.Rows[0]["photo"].ToString());
                imgPath = basePath + imgPath;
                if (File.Exists(imgPath))
                {
                    picProfile.Image = Image.FromFile(imgPath);
                    picProfile.SizeMode = PictureBoxSizeMode.StretchImage; ;
                }
                else
                {
                    picProfile.Image = FormUtility.ScaleImage(Resources.no_product_image, 60, 60);
                }
            }
            rdoMale.Checked = Convert.ToInt16(dtStaff.Rows[0]["gender"]) == 1 ? true : false;
            rdoFemale.Checked = Convert.ToInt16(dtStaff.Rows[0]["gender"]) == 2 ? true : false;
            rdoOther.Checked = Convert.ToInt16(dtStaff.Rows[0]["gender"]) == 3 ? true : false;
            chkActive.Checked = Convert.ToInt16(dtStaff.Rows[0]["active_status"]) == 1 ? true : false;
        }

        /// <summary>
        /// The SaveStaffInfo.
        /// </summary>
        private void SaveStaffInfo()
        {
            staff.staff_id = txtStaffNo.Text;
            staff.role = Convert.ToInt16(cboStaffRole.SelectedValue);
            staff.staff_type = Convert.ToInt16(cboStaffType.SelectedValue);
            staff.bank_account_number = txtBankAccountNo.Text;
            staff.education_level = txtEducation.Text;
            staff.name = txtStaffName.Text;
            staff.gender = genderId;
            staff.nrc_number = txtNrcNo.Text;
            staff.dob = dob ;
            staff.address = txtAddress.Text;
            staff.remark = txtRemark.Text;
            staff.phone_no_1 = txtPhoneNumber1.Text;
            staff.phone_no_2 = txtPhoneNumber2.Text;
            staff.join_from = joinFromDate;
            staff.join_to = joinToDate;
            staff.active_status = Convert.ToInt16((chkActive.CheckState == CheckState.Checked) ? 1 : 2);
            staff.photo = imagePath;
            saveDirectory = Path.GetFullPath(basePath + staffPath);
            CreateDirectory(saveDirectory);
            //if new condition
            if (dtStaff.Rows.Count == 0)
            {
                staff.password = password;
                staff.created_user_id = Convert.ToInt32(Consts.STAFFID);
                staff.updated_user_id = Convert.ToInt32(Consts.STAFFID);
                staff.created_datetime = DateTime.Now;
                staff.updated_datetime = DateTime.Now;
                if (!String.IsNullOrEmpty(imagePath))
                {
                    this.SaveImage();
                }
                staffService.SaveStaffInformation(staff);
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(DAO.Common.Messages.I0001, DAO.Common.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(DAO.Common.Messages.B0037, DAO.Common.Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
                Clear();
            }
            else //Update Condition
            {
                if (String.IsNullOrEmpty(imagePath))
                {
                    staff.photo = dtStaff.Rows[0]["photo"].ToString();
                }
                else
                {
                    this.SaveImage();
                }
                staff.password = dtStaff.Rows[0]["password"].ToString();
                staff.created_user_id = Convert.ToInt32(dtStaff.Rows[0]["created_user_id"]);
                staff.updated_user_id = Convert.ToInt32(Consts.STAFFID);
                staff.created_datetime = Convert.ToDateTime(dtStaff.Rows[0]["created_datetime"]);
                staff.updated_datetime = DateTime.Now;
                staff.id = Convert.ToInt64(dtStaff.Rows[0]["id"]);
                staffService.UpdateStaffInformatin(staff);
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.I0002, Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Messages.B0040, Messages.F0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ShowStaffListForm();
            }
        }

        /// <summary>
        /// The SaveImage.
        /// </summary>
        private void SaveImage()
        {
            imageName = txtStaffNo.Text;
            string[] files = Directory.GetFiles(saveDirectory, imageName + "*");
            if (files.Length > 0)
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                File.Delete(files[0]);
            }
            imageName += extension;
            picProfile.Image.Save(saveDirectory + @"\" + imageName);
            imagePath = staffPath + "/" + imageName;
            staff.photo = imagePath;
        }

        /// <summary>
        /// The CreateDirectory.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        private void CreateDirectory(string path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
                Directory.CreateDirectory(path);
        }
        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            pnlHeader.BackColor = Properties.Settings.Default.BackColor;
            btnSubmit.BackColor = Properties.Settings.Default.BackColor;
            btnBack.BackColor = Properties.Settings.Default.BackColor;
            btnClear.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Initializes a new instance of the <see cref="StaffForm"/> class.
        /// </summary>
        public UCStaff()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }

        public UCStaff(Int64 staffId)
        {
            InitializeComponent();
            this.CustomizeThemes();
            dtStaff = staffService.GetStaff(staffId);
        }
        #endregion

        #region==========Design Generated Code==========  
        /// <summary>
        /// UCStaff_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCStaff_Load(object sender, EventArgs e)
        {
            UCStaff ucStaff = new UCStaff();
            txtStaffName.KeyPress += this.TextBox_KeyPress;
            txtEducation.KeyPress += this.TextBox_KeyPress;
            txtAddress.KeyPress += this.TextBox_KeyPress;
            txtBankAccountNo.KeyPress += this.TextBox_KeyPress;
            txtPhoneNumber1.KeyPress += this.TextBox_KeyPress;
            txtPhoneNumber2.KeyPress += this.TextBox_KeyPress;
            txtRemark.KeyPress += this.TextBox_KeyPress;
            basePath = connection.GetIniString("ImageFolder", "PRODUCT_IMAGE_PATH", Consts.FILEPATH);
            staffPath = connection.GetIniString("StaffImageFolder", "STAFF_PATH", Consts.FILEPATH);
            BindCboStaffRole();
            BindCboStaffType();
            if (dtStaff.Rows.Count > 0)
            {
                GetStaffInfo();
            }
            //txtStaffName.Focus();
            txtStaffName.KeyPress -= this.TextBox_KeyPress;
            txtEducation.KeyPress -= this.TextBox_KeyPress;
            txtAddress.KeyPress -= this.TextBox_KeyPress;
            txtBankAccountNo.KeyPress -= this.TextBox_KeyPress;
            txtPhoneNumber1.KeyPress -= this.TextBox_KeyPress;
            txtPhoneNumber2.KeyPress -= this.TextBox_KeyPress;
            txtRemark.KeyPress -= this.TextBox_KeyPress;
            localization.UCChangeLanguageText(DAO.Common.Consts.LANGUAGEID, this, ucStaff);
        }

        /// <summary>
        /// btnClear_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        /// <summary>
        /// The btnBrowse_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (open.ShowDialog() == DialogResult.OK)
            {
                picProfile.Image = new Bitmap(open.FileName);
                picProfile.SizeMode = PictureBoxSizeMode.StretchImage; ;
                imagePath = open.FileName;
                extension = Path.GetExtension(open.FileName);
            }
        }

        /// <summary>
        /// dtpDob_ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpDob_ValueChanged(object sender, EventArgs e)
        {
            changeDob = 1;
            dtpDob.CustomFormat = Consts.DATEFORMAT;
        }

        /// <summary>
        /// rdoOther_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoOther_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == rdoOther && rdoOther.Checked)
            {
                rdoMale.Checked = !rdoOther.Checked;
                rdoFemale.Checked = !rdoOther.Checked;
                genderId = 3;
            }
        }

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboStaffType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void lblStaffRole_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void txtStaffNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStaffName_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void lblFromHeaderText_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// rdoMale_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoMale_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == rdoMale && rdoMale.Checked)
            {
                rdoFemale.Checked = !rdoMale.Checked;
                rdoOther.Checked = !rdoMale.Checked;
                genderId = 1;
            }
        }

        /// <summary>
        /// rdoFemale_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == rdoFemale && rdoFemale.Checked)
            {
                rdoMale.Checked = !rdoFemale.Checked;
                rdoOther.Checked = !rdoFemale.Checked;
                genderId = 2;
            }
        }       

        /// <summary>
        /// The dtpJoinFrom_ValueChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void dtpJoinFrom_ValueChanged(object sender, EventArgs e)
        {
            changeFromDate = 1;
            dtpJoinFrom.CustomFormat = Consts.DATEFORMAT;
        }

        /// <summary>
        /// The dtpJoinTo_ValueChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void dtpJoinTo_ValueChanged(object sender, EventArgs e)
        {
            changeToDate = 1;
            dtpJoinTo.CustomFormat = Consts.DATEFORMAT;
        }

        /// <summary>
        /// btnSubmit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Validation();
            if (isValid)
            {
                SaveStaffInfo();
            }
        }

        /// <summary>
        /// btnBack_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.ShowStaffListForm();
        }

        /// <summary>
        /// The cboStaffRole_SelectedIndexChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void cboStaffRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtStaff.Rows.Count == 0 || (!String.IsNullOrEmpty(staffNumber) && Convert.ToInt32(dtStaff.Rows[0]["role"]) != Convert.ToInt32(cboStaffRole.SelectedValue)))
            {
                string result = String.Empty;
                int countNo = 0;
                txtStaffNo.Text = String.Empty;
                if (cboStaffRole.SelectedIndex == 1)
                {
                    result = Convert.ToString(staffService.GetStaffNumber(cboStaffRole.Text));
                    if (!String.IsNullOrEmpty(result))
                    {
                        result = result.Substring(1);
                        countNo = Convert.ToInt16(result);
                    }
                    if (countNo >= 99)
                    {
                        txtStaffNo.Text = "A" + (countNo + 1);
                    }
                    else if (countNo >= 9)
                    {
                        txtStaffNo.Text = "A0" + (countNo + 1);
                    }
                    else
                    {
                        txtStaffNo.Text = "A00" + (countNo + 1);
                    }
                }
                else if (cboStaffRole.SelectedIndex == 2)
                {
                    result = Convert.ToString(staffService.GetStaffNumber(cboStaffRole.Text));
                    if (!String.IsNullOrEmpty(result))
                    {
                        result = result.Substring(2);
                        countNo = Convert.ToInt16(result);
                    }

                    if (countNo >= 99)
                    {
                        txtStaffNo.Text = "S" + (countNo + 1);
                    }
                    else if (countNo >= 9)
                    {
                        txtStaffNo.Text = "S0" + (countNo + 1);
                    }
                    else
                    {
                        txtStaffNo.Text = "S00" + (countNo + 1);
                    }
                }
            }
            else
            {
                txtStaffNo.Text = staffNumber;
            }
        }

        /// The txtConfirmedPassword_Leave.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void txtConfirmedPassword_Leave(object sender, EventArgs e)
        {
            if (String.Equals(txtPassword.Text, txtConfirmedPassword.Text))
            {
                password = Encryption.PasswordEncrypt(txtPassword.Text);
            }
        }

        /// <summary>
        /// The btnClose_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        /// <summary>
        /// The TextBox_KeyPress.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/>.</param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && !string.Equals(txtbox.Name, txtStaffName.Name) && !string.Equals(txtbox.Name, txtAddress.Name) 
                && !string.Equals(txtbox.Name, txtRemark.Name) && !string.Equals(txtbox.Name, txtEducation.Name))
            {
                e.Handled = true;         //Just Digits
            }
            else if ((txtbox.Text.Length >= txtBankAccountNo.MaxLength) && !string.Equals(txtbox.Name, txtStaffName.Name) && !string.Equals(txtbox.Name, txtAddress.Name)
                && !string.Equals(txtbox.Name, txtRemark.Name) && !string.Equals(txtbox.Name, txtEducation.Name))
                {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtBankAccountNo.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtBankAccountNo.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                    e.Handled = true;
                }
             else if ((txtbox.Text.Length >= txtPhoneNumber1.MaxLength) && !string.Equals(txtbox.Name, txtStaffName.Name) && !string.Equals(txtbox.Name, txtAddress.Name)
                && !string.Equals(txtbox.Name, txtRemark.Name) && !string.Equals(txtbox.Name, txtEducation.Name))
                    {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtPhoneNumber1.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtPhoneNumber1.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                        e.Handled = true;
                    }
             else if ((txtbox.Text.Length >= txtPhoneNumber2.MaxLength) && !string.Equals(txtbox.Name, txtStaffName.Name) && !string.Equals(txtbox.Name, txtAddress.Name)
                && !string.Equals(txtbox.Name, txtRemark.Name) && !string.Equals(txtbox.Name, txtEducation.Name))
                    {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtPhoneNumber2.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtPhoneNumber2.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
                    }
            else if((txtbox.Text.Length >= txtStaffName.MaxLength) && !string.Equals(txtbox.Name, txtAddress.Name)
                && !string.Equals(txtbox.Name, txtRemark.Name) && !string.Equals(txtbox.Name, txtEducation.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtStaffName.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtStaffName.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            else if((txtbox.Text.Length >= txtEducation.MaxLength) && !string.Equals(txtbox.Name, txtStaffName.Name) && !string.Equals(txtbox.Name, txtAddress.Name)
                && !string.Equals(txtbox.Name, txtRemark.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtEducation.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtEducation.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            else if((txtbox.Text.Length >= txtAddress.MaxLength) && !string.Equals(txtbox.Name, txtStaffName.Name) && !string.Equals(txtbox.Name, txtRemark.Name) && !string.Equals(txtbox.Name, txtEducation.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtAddress.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtAddress.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            else if((txtbox.Text.Length >= txtRemark.MaxLength) && !string.Equals(txtbox.Name, txtStaffName.Name) && !string.Equals(txtbox.Name, txtAddress.Name) && !string.Equals(txtbox.Name, txtEducation.Name))
            {
                if (DAO.Common.Consts.LANGUAGEID == 1)
                {
                    MessageBox.Show(Messages.W0068 + txtRemark.MaxLength + ".", Messages.T0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Messages.B0013 + txtRemark.MaxLength + ".", Messages.F0002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }

            if (e.KeyChar == (char)8)
                e.Handled = false;   //Allow Backspace
        }

        /// <summary>
        /// The btnSubmit_MouseHover.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnSubmit_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// The btnSubmit_MouseLeave.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnSubmit_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// The btnBack_MouseHover.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnBack_MouseHover(object sender, EventArgs e)
        {
            //base.Label_MouseHover(sender, e);
            //base.ButtonColor_MouseHover(sender, e);
        }

        /// <summary>
        /// The btnBack_MouseLeave.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            //base.Label_MouseLeave(sender, e);
            //base.ButtonColor_MouseLeave(sender, e);
        }
        #endregion       
    }
}

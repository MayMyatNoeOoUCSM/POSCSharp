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
using Services.License;
using POS_Admin.Views.Staff;
using POS_Admin.Views.Category;
using POS_Admin.Views.Supplier;
using POS_Admin.Views.Product;
using POS_Admin.Views.Stock;
using POS_Admin.Views.DamageLoss;
using POS_Admin.Views.Sale;
using POS_Admin.Views.SaleReturn;
using POS_Admin.Views.Dashboard;
using POS_Admin.Views.Report;
using POS_Admin.Views.Customer;
using POS_Admin.Views.Brand;
using DAO.Common;
using POS_Admin.Functions;
using POS_Admin.Utilities;

namespace POS_Admin.Views.Auth
{
    public partial class MainForm : Form
    {
        #region==========Data Declaration==========
        private AppSettings appSettings = new AppSettings();

        private Localization localization = new Localization();

        private UCDashboard ucDashboard = new UCDashboard();

        string languageId,
               languageName;

        private int comboIndex = 0,
            count = 0;
        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {          
            panel2.BackColor = Properties.Settings.Default.BackColor;
            panel3.BackColor = Properties.Settings.Default.BackColor;
            label1.BackColor = Properties.Settings.Default.BackColor;
            picIcon.BackColor = Properties.Settings.Default.BackColor;
            panelLogo.BackColor = Properties.Settings.Default.BackColor;
            btnDashboard.FlatAppearance.MouseDownBackColor = Properties.Settings.Default.BackColor;
            btnStaff.FlatAppearance.MouseDownBackColor = Properties.Settings.Default.BackColor;
            btnSupplier.FlatAppearance.MouseDownBackColor = Properties.Settings.Default.BackColor;
            btnCategory.FlatAppearance.MouseDownBackColor = Properties.Settings.Default.BackColor;
            btnProduct.FlatAppearance.MouseDownBackColor = Properties.Settings.Default.BackColor;
            btnStock.FlatAppearance.MouseDownBackColor = Properties.Settings.Default.BackColor;
            btnPurchaseStock.FlatAppearance.MouseDownBackColor = Properties.Settings.Default.BackColor;
            btnSaleStock.FlatAppearance.MouseDownBackColor = Properties.Settings.Default.BackColor;
            btnSale.FlatAppearance.MouseDownBackColor = Properties.Settings.Default.BackColor;
            btnSalesReturn.FlatAppearance.MouseDownBackColor = Properties.Settings.Default.BackColor;
            btnDamageLoss.FlatAppearance.MouseDownBackColor = Properties.Settings.Default.BackColor;
            btnReport.FlatAppearance.MouseDownBackColor = Properties.Settings.Default.BackColor;
            btnSaleReport.FlatAppearance.MouseDownBackColor = Properties.Settings.Default.BackColor;
            btnTopTenSaleReport.FlatAppearance.MouseDownBackColor = Properties.Settings.Default.BackColor;
            btnStockReport.FlatAppearance.MouseDownBackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Initial
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Show/Hide SubMenu==========
        /// <summary>
        /// customizeDesign
        /// </summary>
        private void customizeDesign()
        {
            pnlSubMenu.Visible = false;
            pnlRptSubMenu.Visible = false;
        }

        /// <summary>
        /// hideSubMenu
        /// </summary>
        private void hideSubMenu()
        {
            if (pnlSubMenu.Visible == true)
            {
                pnlSubMenu.Visible = false;
            }
        }

        /// <summary>
        /// hideRptSubMenu
        /// </summary>
        private void hideRptSubMenu()
        {
            if (pnlRptSubMenu.Visible == true)
            {
                pnlRptSubMenu.Visible = false;
            }
        }      

        /// <summary>
        /// showSubMenu
        /// </summary>
        /// <param name="subMenu"></param>
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                this.hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        /// <summary>
        /// ChangeLanguage
        /// </summary>
        private void ChangeLanguage()
        {
            if (DAO.Common.Consts.LANGUAGEID == 1)
            {
                btnPurchaseStock.Text = "        Purchase Stock";
                btnSaleStock.Text = "        Sale Stock";            
                btnSaleReport.Text = "          Sale";
                btnTopTenSaleReport.Text = "        Top Ten Sale";
                btnStockReport.Text = "          Stock";
                btnProfitLoss.Text = "          Profit/Loss";
                btnSupplierPayment.Text = "          Supplier Payment";
                btnCustomerPayment.Text = "          Customer Payment";
                btnRptMonthly.Text = "          Monthly Sale";
                btnRptYearly.Text = "          Yearly Sale";
                btnPurchaseStock.Font = new Font("Myanmar Text", 12);
                btnSaleStock.Font = new Font("Myanmar Text", 12);
                btnSaleReport.Font = new Font("Myanmar Text", 12);
                btnTopTenSaleReport.Font = new Font("Myanmar Text", 12);
                btnStockReport.Font = new Font("Myanmar Text", 12);
                btnProfitLoss.Font = new Font("Myanmar Text", 12);
                btnSupplierPayment.Font = new Font("Myanmar Text", 12);
                btnCustomerPayment.Font = new Font("Myanmar Text", 12);
                btnRptMonthly.Font = new Font("Myanmar Text", 12);
                btnRptYearly.Font = new Font("Myanmar Text", 12);
            }
            else
            {
                btnPurchaseStock.Text = "        အဝယ်ကုန်ပစ္စည်း";
                btnSaleStock.Text = "        အရောင်းကုန်ပစ္စည်း";             
                btnSaleReport.Text = "        အရောင်း";
                btnTopTenSaleReport.Text = "      အရောင်းအများဆုံး";
                btnStockReport.Text = "        ကုန်ပစ္စည်း";
                btnProfitLoss.Text = "        အရှုံးအမြတ်";
                btnSupplierPayment.Text = "        ကုန်ပစ္စည်းပေးချေမှု";
                btnCustomerPayment.Text = "        အဝယ်ပေးချေမှု";
                btnRptMonthly.Text = "        လစဥ်အရောင်း";
                btnRptYearly.Text = "        နှစ်စဥ်အရောင်း";
                btnPurchaseStock.Font = new Font("Myanmar Text", 10);
                btnSaleStock.Font = new Font("Myanmar Text", 10);              
                btnSaleReport.Font = new Font("Myanmar Text", 10);
                btnTopTenSaleReport.Font = new Font("Myanmar Text", 10);
                btnStockReport.Font = new Font("Myanmar Text", 10);
                btnProfitLoss.Font = new Font("Myanmar Text", 10);
                btnSupplierPayment.Font = new Font("Myanmar Text", 10);
                btnCustomerPayment.Font = new Font("Myanmar Text", 10);
                btnRptMonthly.Font = new Font("Myanmar Text", 10);
                btnRptYearly.Font = new Font("Myanmar Text", 10);
            }
            DAO.Common.Consts.LANGUAGEID = Convert.ToInt16(appSettings.GetSetting("languageId"));
            localization.ChangeLanguageText(DAO.Common.Consts.LANGUAGEID, this, ucDashboard);
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// MainForm_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            label4.Visible = false;
            this.customizeDesign();
            int id = Consts.LANGUAGEID;
            UCDashboard ucDashboard = new UCDashboard();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucDashboard);
            Consts.LANGUAGEID = Convert.ToInt16(appSettings.GetSetting("languageId"));
            localization.ChangeLanguageText(DAO.Common.Consts.LANGUAGEID, this, ucDashboard);           
        }

        /// <summary>
        /// btnDashboard_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            UCDashboard ucDashboard = new UCDashboard();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucDashboard);
            lblCommonHeader.Text = Messages.DA001;
            this.ChangeLanguage();           
        }

        /// <summary>
        /// btnStaff_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStaff_Click(object sender, EventArgs e)
        {
            UCStaffList ucStaffList = new UCStaffList();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucStaffList);
            lblCommonHeader.Text = Messages.ST0001;
            this.ChangeLanguage();
        }

        /// <summary>
        /// btnSupplier_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>      
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            UCSupplierList ucSupplierList = new UCSupplierList();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucSupplierList);
            lblCommonHeader.Text = Messages.S0001;
            this.ChangeLanguage();
        }

        /// <summary>
        /// btnCategory_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCategory_Click(object sender, EventArgs e)
        {
            UCCategoryList ucCategoryList = new UCCategoryList();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucCategoryList);
            this.lblCommonHeader.Text = Messages.C0001;
            this.ChangeLanguage();
        }

        /// <summary>
        /// btnProduct_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProduct_Click(object sender, EventArgs e)
        {
            UCProductList ucProductList = new UCProductList();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucProductList);
            lblCommonHeader.Text = Messages.P0001;
            this.ChangeLanguage();
        }

        /// <summary>
        /// btnDamageLoss_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDamageLoss_Click(object sender, EventArgs e)
        {
            UCDamageLossList ucDamageLossList = new UCDamageLossList();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucDamageLossList);
            lblCommonHeader.Text = Messages.D0001;
            this.ChangeLanguage();
        }

        /// <summary>
        /// btnSale_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSale_Click(object sender, EventArgs e)
        {
            UCSaleList ucSaleList = new UCSaleList();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucSaleList);
            lblCommonHeader.Text = Messages.SA0001;
            this.ChangeLanguage();
        }

        /// <summary>
        /// btnSalesReturn_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalesReturn_Click(object sender, EventArgs e)
        {
            UCSaleReturnList ucSaleReturnList = new UCSaleReturnList();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucSaleReturnList);
            lblCommonHeader.Text = Messages.SAR0001;
            this.ChangeLanguage();
        }

        /// <summary>
        /// btnLogout_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            FrmLoginForm loginForm = new FrmLoginForm();
            loginForm.Show();
            this.Hide();
        }     

        /// <summary>
        /// lblMinnimize_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMinnimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// lblClose_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblClose_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        /// <summary>
        /// btnSaleReport_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaleReport_Click(object sender, EventArgs e)
        {
            UCSaleReport ucSaleReport = new UCSaleReport();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucSaleReport);
            lblCommonHeader.Text = Messages.R0001;
            this.hideSubMenu();
            this.ChangeLanguage();
        }

        /// <summary>
        /// btnRptYearly_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRptYearly_Click(object sender, EventArgs e)
        {
            UCYearlyReport ucYearlyReport = new UCYearlyReport();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucYearlyReport);
            lblCommonHeader.Text = Messages.R0001;
            this.hideSubMenu();
            this.ChangeLanguage();
        }

        /// <summary>
        /// btnTopTenSaleReport_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnTopTenSaleReport_Click(object sender, EventArgs e)
        //{
        //    UCTopTenSaleReport ucTopTenSaleReport = new UCTopTenSaleReport();
        //    this.panelAdd.Controls.Clear();
        //    this.panelAdd.Controls.Add(ucTopTenSaleReport);
        //    lblCommonHeader.Text = Messages.R0001;
        //    this.hideSubMenu();
        //    this.ChangeLanguage();
        //}

        private void btnTopTenSaleReport_Click(object sender, EventArgs e)
        {
            UCTopTenSaleReport ucTopTenSaleReport = new UCTopTenSaleReport();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucTopTenSaleReport);
            lblCommonHeader.Text = Messages.R0001;
            this.hideSubMenu();
            this.ChangeLanguage();
        }

        /// <summary>
        /// btnStockReport_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStockReport_Click(object sender, EventArgs e)
        {
            UCStockSaleReport ucStockSaleReport = new UCStockSaleReport();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucStockSaleReport);
            lblCommonHeader.Text = Messages.R0001;
            this.hideSubMenu();
            this.ChangeLanguage();
        }

        /// <summary>
        /// btnPurchaseStock_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPurchaseStock_Click(object sender, EventArgs e)
        {
            UCStockList ucStock = new UCStockList();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucStock);
            lblCommonHeader.Text = Messages.STT0001;
            this.hideRptSubMenu();
            this.ChangeLanguage();
        }

        /// <summary>
        /// btnSaleStock_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaleStock_Click(object sender, EventArgs e)
        {
            UCSaleStockList ucSaleStock = new UCSaleStockList();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucSaleStock);
            lblCommonHeader.Text = Messages.STT0001;
            this.hideRptSubMenu();
            this.ChangeLanguage();
        }

        /// <summary>
        /// btnDashboard_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDashboard_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnStaff_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStaff_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnSupplier_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupplier_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnCategory_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCategory_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnProduct_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProduct_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnStock_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStock_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnPurchaseStock_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPurchaseStock_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnSaleStock_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaleStock_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnSale_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSale_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnSalesReturn_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalesReturn_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnDamageLoss_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDamageLoss_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnReport_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnSaleReport_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaleReport_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnTopTenSaleReport_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTopTenSaleReport_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnRptYearly_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRptYearly_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// lblMY_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMY_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
       
        /// <summary>
        /// btnDashboard_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDashboard_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnStaff_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStaff_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnSupplier_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupplier_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnCategory_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCategory_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnProduct_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProduct_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnStock_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStock_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnPurchaseStock_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPurchaseStock_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnSaleStock_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaleStock_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnSale_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSale_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnSalesReturn_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalesReturn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnDamageLoss_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDamageLoss_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnLanguage_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLanguage_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnLanguage_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLanguage_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnMyanmar_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMyanmar_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnMyanmar_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMyanmar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnEnglish_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnglish_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnEnglish_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnglish_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_MouseHover_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnReport_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnSaleReport_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaleReport_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnTopTenSaleReport_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTopTenSaleReport_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnStockReport_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStockReport_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnLogout_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        private void MyanmarLanguageShow()
        {
            label2.Visible = true;
            label4.Visible = false;
        }

        private void EnglishLanguageShow()
        {
            label2.Visible = false;
            label4.Visible = true;
        }
        /// <summary>
        /// lblMyanmar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMyanmar_Click(object sender, EventArgs e)
        {
            languageId = "2";
            languageName = "Myanmar";
            appSettings.SetSetting("languageId", languageId);
            appSettings.SetSetting("languageName", languageName);
            DAO.Common.Consts.LANGUAGEID = Convert.ToInt16(appSettings.GetSetting("languageId"));
            MessageBox.Show(Messages.L0002, DAO.Common.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
            localization.ChangeLanguageText(DAO.Common.Consts.LANGUAGEID, this, ucDashboard);
            this.ChangeLanguage();
            //MyanmarLanguageShow();
            UCDashboard ucDashboards = new UCDashboard();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucDashboards);
        }

        /// <summary>
        /// lblEnglish_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblEnglish_Click(object sender, EventArgs e)
        {
            languageId = "1";
            languageName = "English";
            appSettings.SetSetting("languageId", languageId);
            appSettings.SetSetting("languageName", languageName);
            DAO.Common.Consts.LANGUAGEID = Convert.ToInt16(appSettings.GetSetting("languageId"));
            MessageBox.Show(Messages.L0001, DAO.Common.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
            localization.ChangeLanguageText(DAO.Common.Consts.LANGUAGEID, this, ucDashboard);
            this.ChangeLanguage();
            //EnglishLanguageShow();
            UCDashboard ucDashboarda = new UCDashboard();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucDashboarda);
        }

        /// <summary>
        /// lblMyanmar_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMyanmar_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// lblMyanmar_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMyanmar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// lblEnglish_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblEnglish_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// lblEnglish_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblEnglish_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// lblCommonHeader_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblCommonHeader_Click(object sender, EventArgs e)
        {
            languageId = "2";
            languageName = "Myanmar";
            appSettings.SetSetting("languageId", languageId);
            appSettings.SetSetting("languageName", languageName);
            DAO.Common.Consts.LANGUAGEID = Convert.ToInt16(appSettings.GetSetting("languageId"));
            MessageBox.Show(Messages.L0002, DAO.Common.Messages.T0001, MessageBoxButtons.OK, MessageBoxIcon.Information);
            localization.ChangeLanguageText(DAO.Common.Consts.LANGUAGEID, this, ucDashboard);
        }

        /// <summary>
        /// btnStock_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStock_Click(object sender, EventArgs e)
        {
            this.showSubMenu(pnlSubMenu);
            lblCommonHeader.Text = Messages.STT0001;
            this.ChangeLanguage();
        }

        /// <summary>
        /// btnReport_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_Click(object sender, EventArgs e)
        {
            this.showSubMenu(pnlRptSubMenu);
            lblCommonHeader.Text = Messages.R0001;
            this.ChangeLanguage();
        }

        /// <summary>
        /// lblMinnimize_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMinnimize_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// lblMinnimize_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMinnimize_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// lblClose_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblClose_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand ;
        }

        /// <summary>
        /// lblClose_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnStockReport_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStockReport_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }      

        /// <summary>
        /// btnProfitLoss_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProfitLoss_Click(object sender, EventArgs e)
        {
            UCProfitLossReport ucProfitLossReport = new UCProfitLossReport();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucProfitLossReport);
            lblCommonHeader.Text = Messages.R0001;
            this.hideSubMenu();
            this.ChangeLanguage();
        }

        /// <summary>
        /// btnProfitLoss_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProfitLoss_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnProfitLoss_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProfitLoss_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnCustomer_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCustomer_Click(object sender, EventArgs e)
        {        
            UCCustomerList ucCustomerList = new UCCustomerList();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucCustomerList);
            lblCommonHeader.Text = Messages.C0002;
            this.ChangeLanguage();
        }

        /// <summary>
        /// btnSupplierPayment_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupplierPayment_Click(object sender, EventArgs e)
        {
            UCSupplierPaymentReport ucCustPaymentReport = new UCSupplierPaymentReport();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucCustPaymentReport);
        }

        /// <summary>
        /// btnBrand_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrand_Click(object sender, EventArgs e)
        {
            UCBrandList ucBrnadList = new UCBrandList();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucBrnadList);
            lblCommonHeader.Text = Messages.B0090;
            this.ChangeLanguage();
        }

        /// <summary>
        /// btnCustomerPayment_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCustomerPayment_Click(object sender, EventArgs e)
        {
            UCCustomerPaymentReport ucCustPaymentReport = new UCCustomerPaymentReport();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucCustPaymentReport);
        }

        /// <summary>
        /// btnCustomer_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCustomer_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnCustomer_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCustomer_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnBrand_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrand_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnBrand_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrand_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnSupplierPayment_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupplierPayment_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnSupplierPayment_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupplierPayment_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnCustomerPayment_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCustomerPayment_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnCustomerPayment_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCustomerPayment_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnRptMonthly_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRptMonthly_Click(object sender, EventArgs e)
        {
            UCMonthlyReport ucMonthlyReport = new UCMonthlyReport();
            this.panelAdd.Controls.Clear();
            this.panelAdd.Controls.Add(ucMonthlyReport);
            lblCommonHeader.Text = Messages.R0001;
            this.ChangeLanguage();
        }

        /// <summary>
        /// btnLogout_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnRptMonthly_MouseHover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRptMonthly_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// btnRptMonthly_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRptMonthly_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// btnRptYearly_MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRptYearly_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// panel2_Paint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion
    }
}

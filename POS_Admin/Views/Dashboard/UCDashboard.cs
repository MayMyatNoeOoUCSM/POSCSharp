using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.Stock;
using System.IO;
using Services.Staff;
using DAO.Common;
using Services.Product;
using POS_Admin.Utilities;
using POS_Admin.Properties;
using Services.Sale;
using System.Globalization;
using POS_Admin.Views.Stock;
using POS_Admin.Views.DamageLoss;
using POS_Admin.Views.SaleReturn;
using POS_Admin.Views.Auth;

namespace POS_Admin.Views.Dashboard
{
    public partial class UCDashboard : UserControl
    {
        #region==========Data Declaration==========      
        /// <summary>
        /// Defines the stockService.
        /// </summary>
        private StockService stockService = new StockService();

        /// <summary>
        /// Defines the saleService.
        /// </summary>
        private SaleService saleService = new SaleService();

        System.Windows.Forms.ImageList myImageList = new ImageList();

        /// <summary>
        /// Defines the imagePath, password, extension, basePath, staffPath, imageName, saveDirectory...........
        /// </summary>
        private string imagePath = String.Empty,
                       basePath = String.Empty,
                       imageName = String.Empty;

        /// <summary>
        /// DataTable
        /// </summary>
        private DataTable dtLastData = new DataTable(),
                          dtProduct = new DataTable(),
                          dtCurrentData = new DataTable();
       
        /// <summary>
        /// Defines the staffService.
        /// </summary>
        private ProductService productService = new ProductService();

        /// <summary>
        /// Defines the Localization.
        /// </summary>
        private Localization localization = new Localization();

        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        decimal saleAmount = 0,
                   totalCurrentAmount = 0,
                   totalLastAmount = 0,
                   diffPercentage = 0;

        DateTime startDate,
                 endDate,
                 currentDate;
        
        /// <summary>
        /// Defines the currencyType.
        /// </summary>
        internal NumberFormatInfo currencyType = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
        
        #endregion

        #region==========Get Data==========  
        /// <summary>
        /// ShowData
        /// </summary>
        private void GetData()
        {
            label6.Text = stockService.GetMinStockCount().ToString();
            label8.Text = stockService.GetExpireStockCount().ToString();
            //Today Sale Amount
            saleAmount = Convert.ToDecimal(saleService.GetTodaySaleAmount() == DBNull.Value ?
                        0 : saleService.GetTodaySaleAmount());
            if (Consts.LANGUAGEID == 1)
            {
                lblTodaySale.Text = String.Format("{0:N0}", saleAmount) + " Ks";
            }
             else
            {
                lblTodaySale.Text = String.Format("{0:N0}", saleAmount) + " ကျပ်";
            }
            //Monthly Sale Amount
            currentDate = DateTime.Now;
            startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            endDate = startDate.AddMonths(1).AddDays(-1);
            saleAmount = Convert.ToDecimal(saleService.GetMonthlyYearlySaleAmount(startDate, endDate));
            if (Consts.LANGUAGEID == 1)
            {
                lblMonthSale.Text = string.Format("{0:N0} ", saleAmount) + " Ks";
            }
            else
            {
                lblMonthSale.Text = string.Format("{0:N0} ", saleAmount) + " ကျပ်";
            }            
            //Yearly Sale Amount
            int year = DateTime.Now.Year;
            startDate = new DateTime(year, 1, 1);
            endDate = startDate.AddYears(1).AddTicks(-1);
            saleAmount = Convert.ToDecimal(saleService.GetMonthlyYearlySaleAmount(startDate, endDate));
            if (Consts.LANGUAGEID == 1)
            {
                lblYearSale.Text = string.Format("{0:N0} ", saleAmount) + " Ks";
            }
            else
            {
                lblYearSale.Text = string.Format("{0:N0} ", saleAmount) + " ကျပ်";
            }            
            //Total All Sale Amount
            saleAmount = Convert.ToDecimal(saleService.GetTotallySaleAmount());
            if (Consts.LANGUAGEID == 1)
            {
                lblTotalSale.Text = string.Format("{0:N0} ", saleAmount) + " Ks";
            }
            else
            {
                lblTotalSale.Text = string.Format("{0:N0} ", saleAmount) + " ကျပ်";
            }                
            //Monthly Report Graph
            dtCurrentData = saleService.GetMonthlySaleReport(startDate, endDate);
            year = DateTime.Now.Year - 1;
            startDate = new DateTime(year, 1, 1);
            endDate = startDate.AddYears(1).AddTicks(-1);
            dtLastData = saleService.GetMonthlySaleReport(startDate, endDate);
            string currentMonth = DateTime.Now.ToString("MMM");
            string previousMonth = DateTime.Now.AddMonths(-1).ToString("MMM");
            if (dtCurrentData.Rows.Count > 0)
            {
                totalCurrentAmount = CalculateAmount(dtCurrentData, currentMonth);
                totalLastAmount = CalculateAmount(dtCurrentData, previousMonth);
                for (int i = 0; i < dtCurrentData.Rows.Count; i++)
                {
                    chtMonthlyRpt.Series["Current"].Points.AddXY(dtCurrentData.Rows[i].ItemArray[0], dtCurrentData.Rows[i].ItemArray[1]);                   
                }
                diffPercentage = CalculatePercentage(totalCurrentAmount, totalLastAmount);             
            }
        }

        /// <summary>
        /// ShowTopTenSaleStock
        /// </summary>
        private void ShowTopTenSaleStock()
        {          
            basePath = connection.GetIniString("ImageFolder", "PRODUCT_IMAGE_PATH", Consts.FILEPATH);          
            dtProduct = saleService.GetTopTenSaleProductList();
            if (dtProduct.Rows.Count > 0)
            {              
                for (int j = 0; j < dtProduct.Rows.Count; j++)
                {
                    string imgPath = (dtProduct.Rows[j]["product_image_path"].ToString());
                    imgPath = basePath + imgPath;                  
                    if (File.Exists(imgPath))
                    {
                        this.myImageList.Images.Add(FormUtility.ScaleImage(Image.FromFile(imgPath), 90, 60));
                    }
                    else
                    {
                        this.myImageList.Images.Add(FormUtility.ScaleImage(Resources.no_product_image, 90, 60));
                    }                 
                    this.lstTopTenView.Items.Add(dtProduct.Rows[j]["name"].ToString(), j);
                }
            }
            this.lstTopTenView.View = View.LargeIcon;
            this.myImageList.ImageSize = new Size(80, 60);
            this.lstTopTenView.LargeImageList = this.myImageList;
        }

        /// <summary>
        /// The CalculateAmount.
        /// </summary>
        /// <param name="dtResultData">The dtResultData<see cref="DataTable"/>.</param>
        /// <param name="month">The month<see cref="string"/>.</param>
        /// <returns>The <see cref="decimal"/>.</returns>
        private decimal CalculateAmount(DataTable dtResultData, string month)
        {
            var result = (from r in dtResultData.AsEnumerable()
                          where r.Field<string>("month") == month
                          select r).AsDataView();
            if (result.Count > 0)
                return Convert.ToDecimal(result[0]["amount"]);
            return 0;
        }

        /// <summary>
        /// The CalculatePercentage.
        /// </summary>
        /// <param name="currentAmount">The currentAmount<see cref="decimal"/>.</param>
        /// <param name="lastAmount">The lastAmount<see cref="decimal"/>.</param>
        /// <returns>The <see cref="decimal"/>.</returns>
        private decimal CalculatePercentage(decimal currentAmount, decimal lastAmount)
        {
            decimal percentChange = 0;
            percentChange = currentAmount > lastAmount ?
                            ((currentAmount - lastAmount) / (currentAmount == 0 ? 1 : currentAmount)) * 100 :
                            -((lastAmount - currentAmount) / (lastAmount == 0 ? 1 : lastAmount)) * 100;
            return Math.Round((percentChange));
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// pnlExpire_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlExpire_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            UCSaleStockList uCSaleStockList = new UCSaleStockList();
            this.Controls.Add(uCSaleStockList);
            uCSaleStockList.Show();
        }
        #endregion

        #region==========Customize Themes==========
        private void CustomizeThemes()
        {
            pnlTodaySale.BackColor = Properties.Settings.Default.BackColor;
            pnlMonthSale.BackColor = Properties.Settings.Default.BackColor;
            pnlRptMonthSale.BackColor = Properties.Settings.Default.BackColor;
            pnlRptTopTenSale.BackColor = Properties.Settings.Default.BackColor;
            pnlTotalSale.BackColor = Properties.Settings.Default.BackColor;
            pnlYearSale.BackColor = Properties.Settings.Default.BackColor;
            pnlMinimunStock.BackColor = Properties.Settings.Default.BackColor;
            pnlExpire.BackColor = Properties.Settings.Default.BackColor;
            chtMonthlyRpt.Series[0].Color = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region==========Initialization==========
        /// <summary>
        /// Initial
        /// </summary>
        public UCDashboard()
        {
            InitializeComponent();
            this.CustomizeThemes();
        }
        #endregion

        #region==========Design Generated Code==========
        /// <summary>
        /// UCDashboard_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCDashboard_Load(object sender, EventArgs e)
        {
            UCDashboard ucDashboard = new UCDashboard();
            this.GetData();
            this.ShowTopTenSaleStock();
            chtMonthlyRpt.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            chtMonthlyRpt.ChartAreas["ChartArea1"].AxisY.LabelStyle.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            MainForm frm = new MainForm();
            frm.lblCommonHeader.Text = "Dashboard";
            localization.UCChangeLanguageText(DAO.Common.Consts.LANGUAGEID, this, ucDashboard);
        }

        /// <summary>
        /// pnlSaleStock_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlSaleStock_DoubleClick(object sender, EventArgs e)
        {
            UCSaleStockList ucSaleStock = new UCSaleStockList();
            this.Controls.Clear();
            this.Controls.Add(ucSaleStock);
        }

        /// <summary>
        /// pnlUnavailable_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlUnavailable_DoubleClick(object sender, EventArgs e)
        {
            UCSaleStockList ucSaleStock = new UCSaleStockList();
            this.Controls.Clear();
            this.Controls.Add(ucSaleStock);
        }

        /// <summary>
        /// pnlDamageLoss_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlDamageLoss_DoubleClick(object sender, EventArgs e)
        {
            UCDamageLossList ucDamageLoss = new UCDamageLossList();
            this.Controls.Clear();
            this.Controls.Add(ucDamageLoss);
        }

        /// <summary>
        /// pnlReturn_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlReturn_DoubleClick(object sender, EventArgs e)
        {
            UCSaleReturnList ucSaleReturn = new UCSaleReturnList();
            this.Controls.Clear();
            this.Controls.Add(ucSaleReturn);
        }

        /// <summary>
        /// pnlMinimunStock_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlMinimunStock_DoubleClick(object sender, EventArgs e)
        {
            UCSaleStockList ucSaleStock = new UCSaleStockList();
            this.Controls.Clear();
            this.Controls.Add(ucSaleStock);
        }

        /// <summary>
        /// pnlAvailable_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlAvailable_DoubleClick(object sender, EventArgs e)
        {
            UCSaleStockList ucSaleStock = new UCSaleStockList();
            this.Controls.Clear();
            this.Controls.Add(ucSaleStock);
        }
        #endregion
    }
}

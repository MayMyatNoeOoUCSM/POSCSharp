using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Admin.Properties
{
    class LanguageSetting
    {
        public static List<Language> nameList()
        {
            List<Language> captionlist = new List<Language>();

            #region==========Common==========
            captionlist.Add(new Language() { English = "Submit", Myanmar = "ထည့်မည်" });
            captionlist.Add(new Language() { English = "Add", Myanmar = "ထည့်ပါ" });
            captionlist.Add(new Language() { English = "Search", Myanmar = "ရှာပါ" });        
            captionlist.Add(new Language() { English = "Back", Myanmar = "နောက်သို့" });
            captionlist.Add(new Language() { English = "From Date", Myanmar = "ရက်စွဲမှ" });
            captionlist.Add(new Language() { English = "To Date", Myanmar = "ရက်စွဲအထိ" });
            captionlist.Add(new Language() { English = "Search", Myanmar = "ရှာပါ" });
            captionlist.Add(new Language() { English = "Clear", Myanmar = "ရှင်းလင်း" });
            captionlist.Add(new Language() { English = "Show Items", Myanmar = "ပြသမည့်အရေအတွက်" });
            #endregion

            #region==========Main Form==========
            captionlist.Add(new Language() { English = "Staff Management", Myanmar = "ဝန်ထမ်းစီမံခန့်ခွဲမှု" });
            captionlist.Add(new Language() { English = "Supplier Management", Myanmar = "ပေးသွင်းသူစီမံခန့်ခွဲမှု" });
            captionlist.Add(new Language() { English = "Category Management", Myanmar = "အမျိုးအစားစီမံခန့်ခွဲမှု" });
            captionlist.Add(new Language() { English = "Product Management", Myanmar = "ထုတ်ကုန်စီမံခန့်ခွဲမှု" });
            captionlist.Add(new Language() { English = "Stock Management", Myanmar = "ကုန်ပစ္စည်းစီမံခန့်ခွဲမှု" });
            captionlist.Add(new Language() { English = "Sale Management", Myanmar = "အရောင်းစီမံခန့်ခွဲမှု" });
            captionlist.Add(new Language() { English = "Sale Return Management", Myanmar = "အရောင်းအ၀ယ်စီမံခန့်ခွဲမှု" });
            captionlist.Add(new Language() { English = "Damage/Loss Management", Myanmar = "ပျက်စီး/ဆုံးရှုံးမှုစီမံခန့်ခွဲမှု" });
            captionlist.Add(new Language() { English = "Report Management", Myanmar = "အစီရင်ခံစာစီမံခန့်ခွဲမှု" });
            captionlist.Add(new Language() { English = "Customer Management", Myanmar = "၀ယ်သူစီမံခန့်ခွဲမှု" });
            captionlist.Add(new Language() { English = "Brand Management", Myanmar = "အမှတ်တံဆိပ်စီမံခန့်ခွဲမှု" });
            #endregion

            #region==========Dashboard==========
            captionlist.Add(new Language() { English = "Total Stocks", Myanmar = "စုစုပေါင်းသိုလှောင်ကုန်ပစ္စည်း"});
            captionlist.Add(new Language() { English = "Today's Sale", Myanmar = "ယနေ့အရာင်း" });
            captionlist.Add(new Language() { English = "Month's Sale", Myanmar = "လအလိုက်အရောင်း" });
            captionlist.Add(new Language() { English = "Year's Sale", Myanmar = "နှစ်အလိုက်အရောင်း" });
            captionlist.Add(new Language() { English = "Total's Sale", Myanmar = "စုစုပေါင်းအရောင်း" });
            captionlist.Add(new Language() { English = "Today's Sale", Myanmar = "ယနေ့အရာင်း" });
            captionlist.Add(new Language() { English = "Monthly Sale Report", Myanmar = "လစဉ်အရောင်း" });
            captionlist.Add(new Language() { English = "Top Ten Sale Products", Myanmar = "ထိပ်တန်းအရောင်းအစီရင်ခံစာ" });
            captionlist.Add(new Language() { English = "Current", Myanmar = "လက်ရှိ" });
            captionlist.Add(new Language() { English = "Minimum Stocks", Myanmar = "အနည်းဆုံးကုန်ပစ္စည်း" });
            captionlist.Add(new Language() { English = "Expire", Myanmar = "သတ်တမ်းကုန်ဆုံး" });
            captionlist.Add(new Language() { English = "Dashboard", Myanmar = "ပင်မစာမျက်နှာ" });
            #endregion

            #region==========Staff==========
            captionlist.Add(new Language() { English = "Staff", Myanmar = "ဝန်ထမ်း" });
            captionlist.Add(new Language() { English = "Staff Name", Myanmar = "ဝန်ထမ်းအမည်" });
            captionlist.Add(new Language() { English = "Select Role", Myanmar = "အဆင့်ရွေးပါ" });
            captionlist.Add(new Language() { English = "Staff List", Myanmar = "ဝန်ထမ်းစာရင်း" });
            captionlist.Add(new Language() { English = "Sr", Myanmar = "နံပါတ်" });
            captionlist.Add(new Language() { English = "Staff No", Myanmar = "ဝန်ထမ်းနံပါတ်" });
            captionlist.Add(new Language() { English = "Role", Myanmar = "အဆင့်" });
            captionlist.Add(new Language() { English = "Join From", Myanmar = "စတင်ဝင်ရောက်သည့်နေ့" });
            captionlist.Add(new Language() { English = "Staff Role", Myanmar = "ဝန်ထမ်းအဆင့်" });
            captionlist.Add(new Language() { English = "Staff Type", Myanmar = "ဝန်ထမ်းအမျိုးအစား" });
            captionlist.Add(new Language() { English = "Password", Myanmar = "စကားဝှက်" });
            captionlist.Add(new Language() { English = "Confirmed Password", Myanmar = "အတည်ပြုထားသောစကားဝှက်" });
            captionlist.Add(new Language() { English = "Join To", Myanmar = "နောက်ဆုံးဝင်ရောက်သည့်နေ့" });
            captionlist.Add(new Language() { English = "NRC No", Myanmar = "မှတ်ပုံတင်နံပါတ်" });
            captionlist.Add(new Language() { English = "Gender", Myanmar = "ကျား/မ" });
            captionlist.Add(new Language() { English = "Education Level", Myanmar = "ပညာရေးအဆင့်" });
            captionlist.Add(new Language() { English = "Phone Number 1", Myanmar = "ပထမဦးစားပေးဖုန်း" });
            captionlist.Add(new Language() { English = "Phone Number 2", Myanmar = "ဒုတိယဦးစားပေးဖုန်း" });
            captionlist.Add(new Language() { English = "DOB", Myanmar = "ဖုန်းနံပါတ်" });
            captionlist.Add(new Language() { English = "Date Of Birth", Myanmar = "မွေးနေ့" });
            captionlist.Add(new Language() { English = "Profile Image", Myanmar = "ဓာတ်ပုံ" });
            captionlist.Add(new Language() { English = "Browse", Myanmar = "ဆွဲထုတ်" });
            captionlist.Add(new Language() { English = "Edit Staff", Myanmar = "ဝန်ထမ်းတည်းဖြတ်ခြင်:" });
            captionlist.Add(new Language() { English = "Create Staff", Myanmar = "ဝန်ထမ်းအသစ်ထည့်" });
            captionlist.Add(new Language() { English = "Edit Staff", Myanmar = "ဝန်ထမ်းတည်းဖြတ်ခြင်:" });
            captionlist.Add(new Language() { English = "Create Staff", Myanmar = "ဝန်ထမ်းအသစ်ထည့်" });
            captionlist.Add(new Language() { English = "Male", Myanmar = "ကျား" });
            captionlist.Add(new Language() { English = "Female", Myanmar = "မ" });
            captionlist.Add(new Language() { English = "Other", Myanmar = "အခြား" });
            captionlist.Add(new Language() { English = "Bank Account No", Myanmar = "ဘဏ်အကောင့်နံပါတ်" });
            captionlist.Add(new Language() { English = "Address", Myanmar = "လိပ်စာ" });
            captionlist.Add(new Language() { English = "Remark", Myanmar = "မှတ်ချက်" });
            captionlist.Add(new Language() { English = "Active", Myanmar = "စတင်အသုံးပြုနိုင်" });
            captionlist.Add(new Language() { English = "There is no staff records.", Myanmar = "ဝန်ထမ်း မှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "Add Staff", Myanmar = "ဝန်ထမ်းထည့်ပါ" });
            #endregion

            #region==========Customer==========
            captionlist.Add(new Language() { English = "Customer Name", Myanmar = "၀ယ်သူအမည်" });
            captionlist.Add(new Language() { English = "Customer", Myanmar = "၀ယ်သူ" });
            captionlist.Add(new Language() { English = "Customer List", Myanmar = "၀ယ်သူစာရင်း" });
            captionlist.Add(new Language() { English = "Description", Myanmar = "ရှင်းလင်းချက်" });
            captionlist.Add(new Language() { English = "Phone Number", Myanmar = "ဖုန်းနံပါတ်" });
            captionlist.Add(new Language() { English = "Email", Myanmar = "အီးမေးလ်" });
            captionlist.Add(new Language() { English = "Customer Create", Myanmar = "၀ယ်သူ အသစ်ထည့်" });
            captionlist.Add(new Language() { English = "Customer Edit", Myanmar = "၀ယ်သူ အချက်အလက်ပြင်" });
            captionlist.Add(new Language() { English = "There is no customer records.", Myanmar = "၀ယ်သူ မှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "Add Customer", Myanmar = "၀ယ်သူထည့်ပါ" });
            #endregion

            #region==========Supplier==========
            captionlist.Add(new Language() { English = "Supplier Name", Myanmar = "ကုန်သွင်းသူအမည်" });
            captionlist.Add(new Language() { English = "Supplier", Myanmar = "ကုန်သွင်း" });
            captionlist.Add(new Language() { English = "Supplier List", Myanmar = "ကုန်သွင်းသူစာရင်း" });
            captionlist.Add(new Language() { English = "Description", Myanmar = "ရှင်းလင်းချက်" });
            captionlist.Add(new Language() { English = "Phone Number", Myanmar = "ဖုန်းနံပါတ်" });
            captionlist.Add(new Language() { English = "Email", Myanmar = "အီးမေးလ်" });
            captionlist.Add(new Language() { English = "Supplier Create", Myanmar = "ကုန်သွင်းသူ အသစ်ထည့်" });
            captionlist.Add(new Language() { English = "Supplier Edit", Myanmar = "ကုန်သွင်းသူ  အချက်အလက်ပြင်" });
            captionlist.Add(new Language() { English = "There is no supplier records.", Myanmar = "ကုန်သွင်းသူ မှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "Add Supplier", Myanmar = "ကုန်သွင်းသူထည့်ပါ" });
            #endregion

            #region==========Category==========
            captionlist.Add(new Language() { English = "Category", Myanmar = "အမျိုးအစား" });
            captionlist.Add(new Language() { English = "Category Name", Myanmar = "အမျိုးအစားအမည်" });
            captionlist.Add(new Language() { English = "Select Parent Category", Myanmar = "ပထမအမျိုးအစားအမည်ကို ရွေးပါ" });
            captionlist.Add(new Language() { English = "Category List", Myanmar = "အမျိုးအစားစာရင်း" });
            captionlist.Add(new Language() { English = "Parent Category", Myanmar = "ပထမအမျိုးအစား" });
            captionlist.Add(new Language() { English = "Category Create", Myanmar = "အမျိုးအစားအသစ်ထည့်" });
            captionlist.Add(new Language() { English = "Category Edit", Myanmar = "အမျိုးအစား အချက်အလက်ပြင်" });
            captionlist.Add(new Language() { English = "Sub Category Name", Myanmar = "ဒုတိယအမျိုးအစားအမည်" });
            captionlist.Add(new Language() { English = "There is no category records.", Myanmar = "အမျိုးအစား မှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "Add Category", Myanmar = "အမျိုးအစားထည့်ပါ" });
            #endregion

            #region==========Brand==========
            captionlist.Add(new Language() { English = "Brand", Myanmar = "ကုန်ပစ္စည်းအမှတ်တံဆိပ်" });
            captionlist.Add(new Language() { English = "Brand Name", Myanmar = "အမှတ်တံဆိပ်အမည်" });
            captionlist.Add(new Language() { English = "Brand List", Myanmar = "အမှတ်တံဆိပ်စာရင်း" });
            captionlist.Add(new Language() { English = "Brand Description", Myanmar = "အမှတ်တံဆိပ်ရှင်းလင်းချက်" });
            captionlist.Add(new Language() { English = "Brand Create", Myanmar = "အမှတ်တံဆိပ်အသစ်ထည့်" });
            captionlist.Add(new Language() { English = "Brand Edit", Myanmar = "အမှတ်တံဆိပ်အချက်အလက်ပြင်" });
            captionlist.Add(new Language() { English = "There is no brand records.", Myanmar = "ကုန်ပစ္စည်းအမှတ်တံဆိပ်မှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "Add Brand", Myanmar = "အမှတ်တံဆိပ်ထည့်ပါ" });
            #endregion

            #region==========Product==========
            captionlist.Add(new Language() { English = "Product", Myanmar = "ကုန်ပစ္စည်း" });
            captionlist.Add(new Language() { English = "Product Code", Myanmar = "ကုန်ပစ္စည်းကုဒ်" });
            captionlist.Add(new Language() { English = "Product Name", Myanmar = "ကုန်ပစ္စည်းအမည်" });
            captionlist.Add(new Language() { English = "Product list", Myanmar = "ကုန်ပစ္စည်းစာရင်း" });
            captionlist.Add(new Language() { English = "Product Level", Myanmar = "ကုန်ပစ္စည်းအဆင့်" });
            captionlist.Add(new Language() { English = "Barcode", Myanmar = "ဘားကုတ်နံပါတ်" });
            captionlist.Add(new Language() { English = "Product Image", Myanmar = "ကုန်ပစ္စည်းဓာတ်ပုံ" });
            captionlist.Add(new Language() { English = "Choose", Myanmar = "နောက်" });
            captionlist.Add(new Language() { English = "Auto generated barcode", Myanmar = "အော်တိုထုတ်လုပ်ပြီးဘားကုဒ်" });
            captionlist.Add(new Language() { English = "Input Barcode manually", Myanmar = "ကိုယ်တိုင်ထည့်သွင်းဘားကုဒ်" });
            captionlist.Add(new Language() { English = "No File", Myanmar = "မရွှေးရသေး" });
            captionlist.Add(new Language() { English = "Product Create", Myanmar = "ကုန်ပစ္စည်းအသစ်ထည့်" });
            captionlist.Add(new Language() { English = "Product Edit", Myanmar = "ကုန်ပစ္စည်း အချက်အလက်ပြင်" });
            captionlist.Add(new Language() { English = "Choose", Myanmar = "ရွေးပါ" });
            captionlist.Add(new Language() { English = "There is no product records.", Myanmar = "ကုန်ပစ္စည်း မှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "Add Product", Myanmar = "ကုန်ပစ္စည်းထည့်ပါ" });
            #endregion

            #region==========Stock==========
            captionlist.Add(new Language() { English = "Stock", Myanmar = "သိုလှောင်ကုန်ပစ္စည်း" });
            captionlist.Add(new Language() { English = "Purchase Stock list", Myanmar = "သိုလှောင်ကုန်ပစ္စည်းစာရင်း" });        
            captionlist.Add(new Language() { English = "Purchase Stock", Myanmar = "အဝယ်သိုလှောင်ကုန်ပစ္စည်း" });
            captionlist.Add(new Language() { English = "Sale Stock", Myanmar = "အရောင်းသိုလှောင်ကုန်ပစ္စည်း" });     
            captionlist.Add(new Language() { English = "Qty", Myanmar = "အရေအတွက်" });
            captionlist.Add(new Language() { English = "Purchase Price", Myanmar = "၀ယ်စျေးနှုန်း" });
            captionlist.Add(new Language() { English = "Selling Price", Myanmar = "ရောင်းစျေးနှုန်း" });
            captionlist.Add(new Language() { English = "Mfd Date", Myanmar = "ထုတ်လုပ်သည့်သည့်ရက်စွဲ" });
            captionlist.Add(new Language() { English = "Exp Date", Myanmar = "ကုန်ဆုံးသည့်ရက်စွဲ" });
            captionlist.Add(new Language() { English = "Purchase Stock Create", Myanmar = "အဝယ်သိုလှောင်ကုန်ပစ္စည်းအသစ်ထည့်"});
            captionlist.Add(new Language() { English = "Purchase Price(PerQty)", Myanmar = "၀ယ်စျေးနှုန်း" + "\r\n" + "(အရေအတွက်တစ်ခုစီ)" });
            captionlist.Add(new Language() { English = "Selling Price(PerQty)", Myanmar = "ရောင်းစျေးနှုန်း" + "\r\n" + "(အရေအတွက်တစ်ခုစီ)" });
            captionlist.Add(new Language() { English = "Manufacture Date", Myanmar = "စထုတ်သည့်နေ့" });
            captionlist.Add(new Language() { English = "Selling Price", Myanmar = "ရောင်းစျေးနှုန်း" });
            captionlist.Add(new Language() { English = "Expired Date", Myanmar = "ကုန်ဆုံးမည့်နေ့" });
            captionlist.Add(new Language() { English = "Edit Purchase Stock", Myanmar = "အဝယ်သိုလှောင်ကုန်ပစ္စည်း တည်းဖြတ်ခြင်:" });
            captionlist.Add(new Language() { English = "Discount Percent", Myanmar = "လျှော့စျေး ရာခိုင်နှုန်း" });
            captionlist.Add(new Language() { English = "Discount Amount", Myanmar = "လျှော့စျေး" });
            captionlist.Add(new Language() { English = "Create Stock Discount", Myanmar = "ကုန်ပစ္စည်းလျှော့စျေးအသစ်ထည့်" });
            captionlist.Add(new Language() { English = "Exp From Date", Myanmar = "ကုန်ဆုံးရက်စွဲမှ" });
            captionlist.Add(new Language() { English = "Exp To Date", Myanmar = "ကုန်ဆုံးရက်စွဲအထိ" });
            captionlist.Add(new Language() { English = "There is no sale stock records.", Myanmar = "ရောင်းရန်ကုန်ပစ္စည်း မှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "There is no purchase stock records.", Myanmar = "အဝယ်ကုန်ပစ္စည်း မှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "Add Stock", Myanmar = "ကုန်ပစ္စည်းထည့်ပါ" });
            captionlist.Add(new Language() { English = "Payment Due Date", Myanmar = "သတ်မှတ်နေ့စွဲ" });
            captionlist.Add(new Language() { English = "Supplier Name", Myanmar = "ကုန်သွင်းသူအမည်" });
            captionlist.Add(new Language() { English = "Purchase Date", Myanmar = "၀ယ်ယူသည့်နေ့စွဲ" });
            captionlist.Add(new Language() { English = "Purchase Payment Detail", Myanmar = "ငွေပေးချေမှုအသေးစိတ်" });
            #endregion

            #region==========Sale Stock==========
            captionlist.Add(new Language() { English = "Sale Stock", Myanmar = "အရောင်းသိုလှောင်ကုန်ပစ္စည်း" });
            captionlist.Add(new Language() { English = "Sale Stock list", Myanmar = "အရောင်းသိုလှောင်ကုန်ပစ္စည်းစာရင်း" });
            captionlist.Add(new Language() { English = "Quantity", Myanmar = "အရေအတွက်" });
            captionlist.Add(new Language() { English = "Sale Invoice", Myanmar = "ရောင်းရန်ပြေစာ" });
            captionlist.Add(new Language() { English = "Cancel Invoice", Myanmar = "ပြေစာ ပယ်ဖျက်ပါ" });
            #endregion

            #region==========Sales==========
            captionlist.Add(new Language() { English = "Sales", Myanmar = "အရောင်း" });
            captionlist.Add(new Language() { English = "Invoice", Myanmar = "ငွေတောင်းခံလွှာ" });
            captionlist.Add(new Language() { English = "Status", Myanmar = "အခြေအနေ" });
            captionlist.Add(new Language() { English = "Download", Myanmar = "စက်ထဲတွင်သိမ်းရန်" });
            captionlist.Add(new Language() { English = "Reset", Myanmar = "ပြန်လည်စတင်" });
            captionlist.Add(new Language() { English = "Search By", Myanmar = "ရှာဖွေပါ" });
            captionlist.Add(new Language() { English = "Today", Myanmar = "ယနေ့" });
            captionlist.Add(new Language() { English = "Weekly", Myanmar = "ရက်သတ္တပတ်" });
            captionlist.Add(new Language() { English = "Monthly", Myanmar = "လအလိုက်" });
            captionlist.Add(new Language() { English = "Yearly", Myanmar = "နှစ်အလိုက်" });
            captionlist.Add(new Language() { English = "Sales List", Myanmar = "အရောင်းစာရင်း" });
            captionlist.Add(new Language() { English = "Date", Myanmar = "ရက်စွဲ" });
            captionlist.Add(new Language() { English = "Invoice Number", Myanmar = "အရောင်းနံပါတ်" });
            captionlist.Add(new Language() { English = "Amount Tax", Myanmar = "အခွန်ပမာဏ" });
            captionlist.Add(new Language() { English = "Amount", Myanmar = "ပမာဏ" });
            captionlist.Add(new Language() { English = "Total", Myanmar = "စုစုပေါင်း" });
            captionlist.Add(new Language() { English = "Paid Amount", Myanmar = "ပေးပြီးငွေ" });
            captionlist.Add(new Language() { English = "Left Amount", Myanmar = "ကျန်ငွေ" });
            captionlist.Add(new Language() { English = "Payment Date", Myanmar = "ငွေပေးချေသည့်နေ့" });
            captionlist.Add(new Language() { English = "Pay Amount", Myanmar = "ပေးငွေ" });
            captionlist.Add(new Language() { English = "Payment Type", Myanmar = "ငွေပေးချေမှုပုံစံ" });
            captionlist.Add(new Language() { English = "Reason", Myanmar = "အကြောင်းပြချက်" });
            captionlist.Add(new Language() { English = "Remark", Myanmar = "မှတ်ချက်" });
            captionlist.Add(new Language() { English = "Is_Active", Myanmar = "စတင်အသုံးပြုနိုင်" });
            captionlist.Add(new Language() { English = "Total Quantity", Myanmar = "စုစုပေါင်းအရေအတွက်" });
            captionlist.Add(new Language() { English = "There is no sale records.", Myanmar = "အရောင်းမှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "Payment Detail", Myanmar = "ငွေပေးချေမှုအသေးစိတ်" });
            #endregion

            #region==========Sales Return==========
            captionlist.Add(new Language() { English = "Sales Return", Myanmar = "အရောင်းပြန်လာမှု" });
            captionlist.Add(new Language() { English = "Invoice Number", Myanmar = "အရောင်းနံပါတ်" });
            captionlist.Add(new Language() { English = "Return Date From", Myanmar = "အရောင်းပြန်လာမှုရက်မှ" });
            captionlist.Add(new Language() { English = "Return Date To", Myanmar = "အရောင်းပြန်လာမှုရက်အတွင်း" });
            captionlist.Add(new Language() { English = "Sales Return List", Myanmar ="အရောင်းပြန်လာမှုစာရင်း" });
            captionlist.Add(new Language() { English = "Sr", Myanmar = "နံပါတ်" });
            captionlist.Add(new Language() { English = "Return Date", Myanmar = "အရောင်းပြန်လာမှုရက်" });
            captionlist.Add(new Language() { English = "Sale Staff Name", Myanmar = "အရောင်းဝန်ထမ်းအမည်" });
            captionlist.Add(new Language() { English = "Sub-Total Sale Quantity", Myanmar = "စုစုပေါင်းရောင်းအား" + "\r\n" + "အရေအတွက်" });
            captionlist.Add(new Language() { English = "Sub-Total Return Quantity", Myanmar = "စုစုပေါင်းပြန်လာ" + "\r\n" + "အရေအတွက်" });
            captionlist.Add(new Language() { English = "Sale Qty", Myanmar = "အရောင်း" + "\r\n" + "အရေအတွက်" });
            captionlist.Add(new Language() { English = "Total Return Qty", Myanmar = "စုစုပေါင်းပြန်လာ" + "\r\n" + "အရေအတွက်" });
            captionlist.Add(new Language() { English = "Has Damage", Myanmar = "ပျက်စီး?" });
            captionlist.Add(new Language() { English = "Damage Qty", Myanmar = "ပျက်စီး"+ "\r\n" + "အရေအတွက်" });
            captionlist.Add(new Language() { English = "Return Qty", Myanmar = "ပြန်လာ" + "\r\n" + "အရေအတွက်" });
            captionlist.Add(new Language() { English = "There is no sale return records.", Myanmar = "အရောင်းပြန်လာကုန်ပစ္စည်း မှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "Add Sale Return", Myanmar = "အရောင်းပြန်လာမှုထည့်ပါ" });
            #endregion

            #region==========Damage/Loss List==========
            captionlist.Add(new Language() { English = "Damage/Loss List", Myanmar = "ပျက်စီးဆုံးရှုံးမှု" });
            captionlist.Add(new Language() { English = "Price", Myanmar = "စျေးနှုန်း" });
            captionlist.Add(new Language() { English = "Damage/Loss", Myanmar = "ပျက်စီးဆုံးရှုံးမှု" });
            captionlist.Add(new Language() { English = "Damage/Loss Date", Myanmar = "ပျက်စီးဆုံးရှုံးမှုရက်စွဲ" });
            captionlist.Add(new Language() { English = "Damage/Loss Create", Myanmar = "ပျက်စီးဆုံးရှုံးမှုအသစ်ထည့်" });
            captionlist.Add(new Language() { English = "Add to List", Myanmar = "အသစ်ထည့်ပါ" });
            captionlist.Add(new Language() { English = "Choose Damage/Loss", Myanmar = "ပျက်စီး/ဆုံးရှုံး" });
            captionlist.Add(new Language() { English = "Damage/Loss Update", Myanmar = "ပျက်စီး/ဆုံးရှုံးမှု တည်းဖြတ်ခြင်:" });
            captionlist.Add(new Language() { English = "There is no damage/loss records.", Myanmar = "ပျက်စီးဆုံးရှုံးကုန်ပစ္စည်း မှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "Add Damage/Loss", Myanmar = "ပျက်စီးဆုံးရှုံးမှုထည့်ပါ" });
            captionlist.Add(new Language() { English = "Damage/Loss Edit", Myanmar = "ပျက်စီးဆုံးရှုံးမှုအချက်အလက်ပြင်" });
            #endregion

            #region============Sale Report=============
            captionlist.Add(new Language() { English = "Sale Report", Myanmar = "အရောင်းအစီရင်ခံစာ" });
            captionlist.Add(new Language() { English = "From", Myanmar = "မှ" });
            captionlist.Add(new Language() { English = "To", Myanmar = "အထိ" });
            captionlist.Add(new Language() { English = "Preview", Myanmar = "အစမ်းကြည့်" });
            captionlist.Add(new Language() { English = "Price", Myanmar = "စျေးနှုန်း" });
            captionlist.Add(new Language() { English = "Report", Myanmar = "အစီရင်ခံစာ" });
            captionlist.Add(new Language() { English = "Sale List", Myanmar = "အရောင်းစာရင်း" });
            captionlist.Add(new Language() { English = "Purchase Stock List", Myanmar = "အ၀ယ်သိုလှောင်ကုန်ပစ္စည်းစာရင်း" });
            captionlist.Add(new Language() { English = "Sale Return List", Myanmar = "အရောင်းပြန်လာမှုစာရင်း" });
            captionlist.Add(new Language() { English = "Sale Date", Myanmar = "ရောင်းရနေ့" });
            captionlist.Add(new Language() { English = "Total Amount", Myanmar = "စုစုပေါင်းတန်ဖိုး" });
            captionlist.Add(new Language() { English = "Sale Quantity", Myanmar = "အရောင်းအရေအတွက်" });
            captionlist.Add(new Language() { English = "Sale Return Quantity", Myanmar = "အရောင်းပြန်လာ" + "\r\n" + "အရေအတွက်	" });
            captionlist.Add(new Language() { English = "Sale Cancel Process", Myanmar = "အရောင်းပယ်ဖျက်ခြင်း" + "\r\n" + "လုပ်ငန်းစဉ်" });
            captionlist.Add(new Language() { English = "Sale Date From", Myanmar = "အရောင်းပြန်လာမှုရက်မှ" });
            captionlist.Add(new Language() { English = "Sale Date To", Myanmar = "အရောင်းပြန်လာမှုရက်အတွင်း" });
            captionlist.Add(new Language() { English = "Total Sale List", Myanmar = "စုစုပေါင်းအရောင်းစာရင်း" });
            captionlist.Add(new Language() { English = "Top Ten Sale Report", Myanmar = "ထိပ်တန်းရောင်းချမှုအစီရင်ခံစာ" });
            captionlist.Add(new Language() { English = "Stock Sale List", Myanmar = "သိုလှောင်ကုန်ပစ္စည်းအရောင်းစာရင်း" });
            captionlist.Add(new Language() { English = "  Profit/Loss Report", Myanmar = "အရှုံးအမြတ်အစီရင်ခံစာ" });
            captionlist.Add(new Language() { English = "Purchase Qty", Myanmar = "အ၀ယ်ကုန်အရေအတွက်" });
            captionlist.Add(new Language() { English = "Sale Price", Myanmar = "ရောင်းစျေးနှုန်း" });
            captionlist.Add(new Language() { English = "Profit/Loss", Myanmar = "အရှုံး/အမြတ်" });
            captionlist.Add(new Language() { English = "Year", Myanmar = "ခုနှစ်" });

            captionlist.Add(new Language() { English = "Sale Return Details List", Myanmar = "အရောင်းပြန်အမ်းအသေးစိတ်စာရင်း" });
            captionlist.Add(new Language() { English = "Sale Return Date", Myanmar = "ပြန်လည်ရောင်းချသည့်နေ့စွဲ" });
            //captionlist.Add(new Language() { English = "Sale Report", Myanmar = "အရောင်းအစီရင်ခံစာ" });
            captionlist.Add(new Language() { English = "Stock Sale Report", Myanmar = "စတော့ရှယ်ယာရောင်းချမှုအစီရင်ခံစာ" });
            captionlist.Add(new Language() { English = "There is no sale records.", Myanmar = "အရောင်းကုန်ပစ္စည်း မှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "There is no stock records.", Myanmar = "ရောင်းရန်ကုန်ပစ္စည်း မှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "There is no top ten sale records.", Myanmar = "Top Ten အရောင်းကုန်ပစ္စည်း မှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "There is no profit and loss records.", Myanmar = "အရှုံးအမြတ်စာရင်း မှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "There is no customer payment records.", Myanmar = "ဝယ်သူငွေလက်ကျန်စာရင်း မှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "There is no supplier payment records.", Myanmar = "ကုန်ပစ္စည်းအတွက်ပေးရန်လက်ကျန်ငွေ မှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "Due Date", Myanmar = "သတ်မှတ်နေ့စွဲ" });
            captionlist.Add(new Language() { English = "There is no monthly sale records.", Myanmar = "လစဥ်အရောင်းစာရင်း မှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "There is no yearly sale records.", Myanmar = "နှစ်စဥ်အရောင်းစာရင်း မှတ်တမ်းမရှိပါ။" });
            captionlist.Add(new Language() { English = "Jan", Myanmar = "ဇန်နဝါရီ" });
            captionlist.Add(new Language() { English = "Feb", Myanmar = "ဖေဖော်ဝါရီ" });
            captionlist.Add(new Language() { English = "Mar", Myanmar = "မတ်" });
            captionlist.Add(new Language() { English = "Apr", Myanmar = "ဧပရယ်" });
            captionlist.Add(new Language() { English = "May", Myanmar = "မေ" });
            captionlist.Add(new Language() { English = "Jun", Myanmar = "ဇွန်" });
            captionlist.Add(new Language() { English = "Jul", Myanmar = "ဇူလိုင်" });
            captionlist.Add(new Language() { English = "Aug", Myanmar = "ဩဂုတ်" });
            captionlist.Add(new Language() { English = "Sep", Myanmar = "စက်တင်ဘာ" });
            captionlist.Add(new Language() { English = "Oct", Myanmar = "အောက်တိုဘာ" });
            captionlist.Add(new Language() { English = "Nov", Myanmar = "နိုဝင်ဘာ" });
            captionlist.Add(new Language() { English = "Dec", Myanmar = "ဒီဇင်ဘာ" });
            captionlist.Add(new Language() { English = "Total Amount :   ", Myanmar = "စုစုပေါင်းပမာဏ : " });
            captionlist.Add(new Language() { English = "Monthly", Myanmar = "လစဥ်အရောင်းအစီရင်ခံစာ" });
            captionlist.Add(new Language() { English = "Yearly", Myanmar = "နှစ်စဥ်အရောင်းအစီရင်ခံစာ" });


            #endregion

            #region============Logout=============
            captionlist.Add(new Language() { English = "Logout", Myanmar = "ထွက်ရန်" });
            #endregion

            #region==========Login==========
            captionlist.Add(new Language() { English = "Login", Myanmar = "လော့အင်" });
            captionlist.Add(new Language() { English = "Close", Myanmar = "ပိတ်ရန်" });
            captionlist.Add(new Language() { English = "UserID", Myanmar = "အသုံးပြုသူ" });
            captionlist.Add(new Language() { English = "LOG IN", Myanmar = "လော့အင်" });
            #endregion

            #region==========Language==========
            captionlist.Add(new Language() { English = "Language", Myanmar = "ဘာသာစကား" });
            captionlist.Add(new Language() { English = "MY", Myanmar = "မြန်မာ" });
            captionlist.Add(new Language() { English = "EN", Myanmar = "အင်္ဂလိပ်" });
            #endregion

            return captionlist;
        }
    }
}

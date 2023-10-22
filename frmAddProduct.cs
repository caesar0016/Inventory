using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class frmAddProduct : Form
    {
        public frmAddProduct()
        {
            InitializeComponent();
        }

        class NumberFormatException : Exception { 
            public NumberFormatException(int num1) : base ($"Number format exception: {num1}") { }
        }

        class StringFormatException : Exception { 
        
            public StringFormatException(string str1) : base(str1) { }
        
        }

        class CurrencyFormatException : Exception {

            public CurrencyFormatException(String message) : base(message) { } 
        
        }



        private string _ProductName, _Category, _MfgDate, _ExpDate, _Description;

        private int _Quantity;
        private double _SellPrice;

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            _ProductName = Product_Name(txtProductName.Text);
            _Category = cbCategory.Text;
            _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
            _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
            _Description = richTxtDescription.Text;
            _Quantity = Quantity(txtQuantity.Text);
            _SellPrice = SellingPrice(txtSellPrice.Text);
            showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,
            _ExpDate, _SellPrice, _Quantity, _Description));
            gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridViewProductList.DataSource = showProductList;
        }

        BindingSource showProductList = new BindingSource();



        //this is the combo for category
        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            string[] ListofProductCategory = {"Beverages", "Bread/Bakery" , "Canned/Jarred Goods",
          
                "Dairy", "Frozen Goods", "Meat", "Personal Care", "Other"};

            foreach (string product01 in ListofProductCategory){

                cbCategory.Items.Add(product01);

            }

        }
        public string Product_Name(string name)
        {
            try {


                if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                    //Exception here
                    throw new StringFormatException("Error string input");
                

            }
            catch (StringFormatException ex) {

                Console.WriteLine(ex.Message);

            }
            finally {

                Console.WriteLine("Finally block executed: Resource cleanup completed.");

            }
                return name;



        }
        public int Quantity(string qty)
        {

            try
            {

            if (!Regex.IsMatch(qty, @"^[0-9]"))
                //Exception here

                throw new CurrencyFormatException("Invalid currency format");

            }
            catch (CurrencyFormatException ex)
            {

                Console.WriteLine(ex.Message);

            }
            finally
            {

                Console.WriteLine("Finally block executed: Resource cleanup completed.");

            }
                return Convert.ToInt32(qty);
        }
        public double SellingPrice(string price)
        {
                return Convert.ToDouble(price);

            try
            {
                if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                    //Exception here

                    throw new CurrencyFormatException("Input invalid in Price");



            }
            catch (CurrencyFormatException ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {

                Console.WriteLine("Finally block executed: Resource cleanup completed.");

            }
                throw new FormatException("Input mismatch in price");
        }





    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameWorkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dgwProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            dgwProducts.DataSource = _productDal.GetAll();

            

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = txtName.Text,
                UnitPrice = Convert.ToDecimal(txtUnitPrice.Text),
                StockAmount = Convert.ToInt32(txtStockAmount.Text),
            });
            MessageBox.Show("Added.");
            dgwProducts.DataSource = _productDal.GetAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(
                new Product
                {
                    Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                    Name = txtNameUpdate.Text,
                    UnitPrice = Convert.ToDecimal(txtUnitPriceUpdate.Text),
                    StockAmount = Convert.ToInt32(txtStockAmountUpdate.Text)
                });
            MessageBox.Show("Updated.");
            dgwProducts.DataSource = _productDal.GetAll();

        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            txtUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            txtStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
            });
            txtNameUpdate.Text = "";
            txtUnitPriceUpdate.Text= "";
            txtStockAmountUpdate.Text = "";
            MessageBox.Show("Deleted.");
            dgwProducts.DataSource = _productDal.GetAll();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgwProducts.DataSource = _productDal.GetByUnitPrice(Convert.ToDecimal(txtSearch.Text));
            #region 2.ürün arama yolu
            //dgwProducts.DataSource = _productDal.GetByName(txtSearch.Text); 
            //2.yol direk veri tabanı üzerinde arama yapar sonra listeler.
            #endregion


            //SearchProduct(txtSearch.Text); 1.yol
        }

        public void SearchProduct(string key) //Ürünlerin once listelenmesi sonra arama yapılması.
        {
            #region 1. ürün arama yolu
            //var search = _productDal.GetAll().Where(p => p.Name.ToLower().Contains(key)).ToList(); //koleksiyonlara sorgu yazabiliyoruz.
            //dgwProducts.DataSource = search;
            ////MessageBox.Show(txtSearch.Text);
            #endregion


        }

        private void btnGetId_Click(object sender, EventArgs e)
        {
           dgwProducts.DataSource= _productDal.GetById(30);

        }
    }
}

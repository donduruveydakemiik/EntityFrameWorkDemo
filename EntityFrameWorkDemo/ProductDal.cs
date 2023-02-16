using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms;

namespace EntityFrameWorkDemo
{
    public class ProductDal // Veri tabanıa direk uygulanan işlemlerin olduğu classdır.
    {
        public List<Product> GetAll()
        {
            using (ETradeContext Context = new ETradeContext())
            {
                return Context.Products.ToList();
            }
        }

        public void Add(Product product)
        {
            using (ETradeContext Context = new ETradeContext())
            {
                var entity = Context.Entry(product);
                entity.State = EntityState.Added;
                Context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (ETradeContext Context = new ETradeContext())
            {
                var entity = Context.Entry(product);
                entity.State = EntityState.Modified;
                Context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (ETradeContext Context = new ETradeContext())
            {
                var entity = Context.Entry(product);
                entity.State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }

        public List<Product> GetByName(string key)
        {
            using (ETradeContext Context = new ETradeContext())
            {
                return Context.Products.Where(p => p.Name.Contains(key)).ToList();
            }
        }

        public List<Product> GetByUnitPrice(decimal price)
        {
            using (ETradeContext Context = new ETradeContext())
            {
                return Context.Products.Where(p => p.UnitPrice>=price).ToList();
            }
        }

        public Product GetById(int id)
        {
            using (ETradeContext Context = new ETradeContext())
            {
                var result = Context.Products.FirstOrDefault(p => p.Id == id);
                return result;
            }
        }


    }
}
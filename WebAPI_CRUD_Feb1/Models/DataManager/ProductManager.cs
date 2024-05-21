using Microsoft.EntityFrameworkCore;
using WebAPI_CRUD_Feb1.Models.Repository;

namespace WebAPI_CRUD_Feb1.Models.DataManager
{
    public class ProductManager : IDataRepository<Product>
    {

        ProjectContext _db;
        public ProductManager(ProjectContext db)//CONSTRUCTOR INJECTION
        {
            _db = db;
        }

        public  IEnumerable<Product> GetAll()
        {
            var productList =  _db.tblProduct.ToList();
            return productList;
        }

        public Product GetById(int id)
        {
            var row = _db.tblProduct.Where(a => a.PId == id).FirstOrDefault();
            return row; ;
        }

        public IEnumerable<Product> GetByName(string name)
        {
            var productList = _db.tblProduct.Where(a => a.PName.Contains(name)).ToList();
            //Contains=>Select * From tblProduct where Pname like '%name%'
            //var productList = _db.tblProduct.Where(a => a.PName.StartsWith(name)).ToList();
            //StartsWith=>Select * From tblProduct where Pname like 'name%'
            //var productList = _db.tblProduct.Where(a => a.PName.EndsWith(name)).ToList();
            //EndsWith=>Select * From tblProduct where Pname like '%name'
            return productList;
        }

        public string Add(Product obj)
        {
            try
            {
                _db.tblProduct.Add(obj);
                _db.SaveChanges();
                return "Insert Success";
            }
            catch(Exception ex)
            {
               // return ex.Message;//for developer
                return "Insert Failure"; //for clients
            }
        }

        public bool Remove(Product obj)
        {
            try
            {
                _db.tblProduct.Remove(obj);
                _db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Update(Product obj_old,Product obj_new)
        {
            try
            {
                obj_old.PName = obj_new.PName;
                obj_old.Price= obj_new.Price;
                obj_old.DOP= obj_new.DOP;
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

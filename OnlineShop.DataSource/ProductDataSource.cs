using Newtonsoft.Json;
using OnlineShop.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataSource
{
    public class ProductDataSource : IDataSource<ProductDTO>
    {
        string path = @"C:\Users\Danis\source\repos\OnlineShop.UI\OnlineShop.DataSource\Product.JSON";

        public bool Delete(ProductDTO _object)
        {
            if (null != GetById(_object.ProductId))
            {
                ProductDTO newProduct = _object;
                List<ProductDTO> products = ShowAll().ToList();
                products.RemoveAll(oldProduct => oldProduct.ProductId == newProduct.ProductId);
                products.Sort();
                File.WriteAllText(path, JsonConvert.SerializeObject(products));
                return true;
            }
            else return false;
        }

        public ProductDTO GetById(int Id)
        {
        
            return JsonConvert.DeserializeObject<List<ProductDTO>>(File.ReadAllText(path)).Find(m => m.ProductId == Id);
            
        }

        public void Save(ProductDTO _object)
        {
            ProductDTO newProduct = _object;
            List<ProductDTO> products = ShowAll().ToList();
            int currentId = (products.Last().ProductId + 1);
            newProduct.ProductId = currentId;
            products.Add(newProduct);
            products.Sort();
            File.WriteAllText(path, JsonConvert.SerializeObject(products));
        }

        public IEnumerable<ProductDTO> ShowAll()
        {

            return JsonConvert.DeserializeObject<List<ProductDTO>>(File.ReadAllText(path));
        }

        public ProductDTO Update(ProductDTO currentobject)
        {
            ProductDTO newProduct = currentobject;
            List<ProductDTO> products = ShowAll().ToList();
            products.RemoveAll(oldProduct => oldProduct.ProductId == newProduct.ProductId);
            products.Add(newProduct);
            products.Sort();
            File.WriteAllText(path, JsonConvert.SerializeObject(products));
            return newProduct;
        }
    }
}

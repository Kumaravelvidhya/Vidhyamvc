using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public  interface IProduct
    {
        public List<Class1> select();
        public Class1 selectid(int id);
        public void insert(Class1 model);
        public void update(Class1 model);
        public void delete(int id);
    }
}

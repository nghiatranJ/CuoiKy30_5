using prjModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LoaiDAL
    {
        QLSachContext db;
        public LoaiDAL()
        {
            db = new QLSachContext();
        }
        public List<Loai> GetAll()
        {
            return db.Loais.ToList();
        }
    }
}

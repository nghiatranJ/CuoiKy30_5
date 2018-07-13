using prjModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SachDAL
    {
        QLSachContext db;
        public SachDAL()
        {
            db = new QLSachContext();
        }
        public List<Sach> GetAll()
        {
            return db.Sachs.ToList();
        }
        public Sach GetbyID(int id)
        {
            return db.Sachs.FirstOrDefault(x => x.MaSach == id);
        }
        public Boolean Add(Sach s)
        {
            try
            {
                db.Sachs.Add(s);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Boolean Update(Sach s)
        {
            try
            {
                Sach sach = db.Sachs.FirstOrDefault(x => x.MaSach == s.MaSach);
                if (sach == null) return false;
                db.Entry(sach).State = System.Data.Entity.EntityState.Modified;
                sach.TenSach = s.TenSach;
                sach.NamXB = s.NamXB;
                sach.NhaXB = s.NhaXB;
                sach.Email = s.Email;
                sach.MaLoai = s.MaLoai;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Boolean Delete(int id)
        {
            Sach sach = db.Sachs.FirstOrDefault(x => x.MaSach == id);
            if (sach == null) return false;
            db.Sachs.Remove(sach);
            db.SaveChanges();
            return true;
        }
    }
}

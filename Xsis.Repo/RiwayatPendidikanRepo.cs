using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xsis.Model;

namespace Xsis.Repo
{
    public class RiwayatPendidikanRepo
    {
        public static List<Riwayat_Pendidikan> GetAll()
        {
            List<Riwayat_Pendidikan> result = new List<Riwayat_Pendidikan>();
            using (DataContext db = new DataContext())
            {
                result = db.Riwayat_Pendidikan.ToList();
            }
            return result;
        }

        public static bool Tmbhpendidikan(Riwayat_Pendidikan pendidikan)
        {
            try
            {
               // Riwayat_Pendidikan pendidikanmdl = new Riwayat_Pendidikan();
                using (DataContext db = new DataContext())
                {
                    pendidikan.created_on = DateTime.Now.Date;
                    db.Riwayat_Pendidikan.Add(pendidikan);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static Boolean HapusPendidikan(int ID)
        {
            try
            {
                Riwayat_Pendidikan dep;
                using (DataContext db = new DataContext())
                {
                    dep = db.Riwayat_Pendidikan.Where(d => d.pendidikan_id == ID).First();
                    dep.is_delete = true;
                    dep.deleted_on = DateTime.Now.Date;
                    db.Entry(dep).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static Riwayat_Pendidikan GetByID(int ID)
        {
            Riwayat_Pendidikan pendidikan = new Riwayat_Pendidikan();
            using (DataContext db = new DataContext())
            {
                pendidikan = db.Riwayat_Pendidikan.Where(d => d.pendidikan_id == ID).First();
                return pendidikan;
            }
        }

        public static Boolean EditPendidikan(Riwayat_Pendidikan pendidikanMdl)
        {
            try
            {
                Riwayat_Pendidikan pend;
                using (DataContext db = new DataContext())
                {
                    pend = db.Riwayat_Pendidikan.Where(d => d.pendidikan_id == pendidikanMdl.pendidikan_id).First();
                    pend.modified_by = pendidikanMdl.modified_by;
                    pend.modified_on = DateTime.Now.Date;
                    pend.created_by = pendidikanMdl.created_by;
                    pend.pendidikan_id = pendidikanMdl.pendidikan_id;
                    pend.school_name = pendidikanMdl.school_name;
                    pend.major = pendidikanMdl.major;
                    pend.education_level_id = pendidikanMdl.education_level_id;
                    pend.entry_year = pendidikanMdl.entry_year;
                    pend.graduation_year = pendidikanMdl.graduation_year;
                    pend.notes = pendidikanMdl.notes;
                    pend.modified_on = DateTime.Now.Date;
                    db.Entry(pend).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}

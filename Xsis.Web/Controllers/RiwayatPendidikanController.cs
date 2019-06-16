﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xsis.Model;
using Xsis.Repo;

namespace Xsis.Web.Controllers
{
    public class RiwayatPendidikanController : Controller
    {
        // GET: RiwayatPendidikan
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Tampil()
        {
            return Json(RiwayatPendidikanRepo.GetAll(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Tambah()
        {
            return PartialView("_Tambah");
        }

        public ActionResult Save(Riwayat_Pendidikan pendidikan)
        {
            if (RiwayatPendidikanRepo.Tmbhpendidikan(pendidikan))
            {
                return Json(new { Simpan = "Berhasil" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Simpan = "Gagal" }, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        public ActionResult Hapus(int ID)
        {
            if (RiwayatPendidikanRepo.HapusPendidikan(ID)) //non static if ( barangRepo.Deletebarang(ID))
            {
                return Json(new { Hapus = "Berhasil" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Hapus = "Gagal" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Edit(int ID)
        {
            return PartialView("_Edit");
        }

        public ActionResult AmbilData(int ID)
        {
            return Json(RiwayatPendidikanRepo.GetByID(ID), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditSimpan(Riwayat_Pendidikan pendidikan)
        {
            if (RiwayatPendidikanRepo.EditPendidikan(pendidikan))
            {
                return Json(new { EditSimpan = "Berhasil" }, JsonRequestBehavior.AllowGet); //return json digunakan untuk memunculkan alert
            }
            else
            {
                return Json(new { EditSimpan = "Gagal" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
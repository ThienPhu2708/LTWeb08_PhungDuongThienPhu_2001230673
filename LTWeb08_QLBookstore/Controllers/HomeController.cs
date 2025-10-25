using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb08_QLBookstore.Models;


using System.IO;
using System.Web.UI.WebControls;


namespace LTWeb08_QLBookstore.Controllers
{
    public class HomeController : Controller
    {
        Bookstore data = new Bookstore();

        public ActionResult ListBook()
        {
            List<SACH> dsBook = data.SACH.ToList();
            return View(dsBook);
        }

        //them moi sach
        [HttpGet]
        public ActionResult Create_Book()
        {
            ViewBag.MaCD = new SelectList(data.CHUDE.ToList().OrderBy(n => n.TENCHUDE), "MACD", "TENCHUDE");


            ViewBag.MaNXB = new SelectList(data.NHAXUATBAN.ToList().OrderBy(n => n.TENNXB), "MANXB", "TENNXB");

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create_Book(SACH sach, HttpPostedFileBase fileupload)
        {
            ViewBag.MaCD = new SelectList(data.CHUDE.ToList().OrderBy(n => n.TENCHUDE), "MACD", "TENCHUDE");
            ViewBag.MaNXB = new SelectList(data.NHAXUATBAN.ToList().OrderBy(n => n.TENNXB), "MANXB", "TENNXB");

            if (fileupload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }

            if (ModelState.IsValid)
            {
                // Lưu ảnh
                var fileName = Path.GetFileName(fileupload.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                if (!System.IO.File.Exists(path))
                {
                    fileupload.SaveAs(path);
                }

                sach.ANHBIA = fileName;


                if (string.IsNullOrEmpty(sach.MASACH))
                {
                    sach.MASACH = "S" + DateTime.Now.ToString("yyyyMMddHHmmss");
                }

                try
                {
                    data.SACH.Add(sach);
                    data.SaveChanges();

                    return RedirectToAction("ListBook");
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Response.Write($"Lỗi cột {ve.PropertyName}: {ve.ErrorMessage}");
                        }
                    }
                    return View(sach);
                }
            }

            return View(sach);
        }




        public ActionResult Details_Book(string id) // Fix: Change return type from Action to ActionResult
        {
            SACH sach = data.SACH.SingleOrDefault(n => n.MASACH == id);
            ViewBag.MASACH = sach.MASACH;
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }

        //xóa sách
        [HttpGet]

        public ActionResult DeleteBook(string id)
        {
            SACH sach = data.SACH.SingleOrDefault(n => n.MASACH == id);
            ViewBag.MASACH = sach.MASACH;

            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(sach);
        }


        [HttpPost, ActionName("DeleteBook")]
        public ActionResult ConfirmDelete(string id)
        {
            SACH sach = data.SACH.SingleOrDefault(n => n.MASACH == id);
            ViewBag.MASACH = sach.MASACH;

            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            try
            {
                data.SACH.Remove(sach);
                data.SaveChanges();
                return RedirectToAction("ListBook");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                // Gửi thông báo lỗi sang View
                ViewBag.ErrorMessage = "Không thể xóa sách này vì đang có dữ liệu liên quan (ví dụ trong bảng VIETSACH).";
                return View(sach); // Hiển thị lại trang xác nhận xóa
            }
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            SACH sach = data.SACH.SingleOrDefault(n => n.MASACH == id);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            // Nạp dữ liệu cho dropdown
            ViewBag.MACHUDE = new SelectList(data.CHUDE.ToList().OrderBy(n => n.TENCHUDE), "MACD", "TENCHUDE", sach.MACHUDE);
            ViewBag.MANXB = new SelectList(data.NHAXUATBAN.ToList().OrderBy(n => n.TENNXB), "MANXB", "TENNXB", sach.MANXB);

            return View(sach);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SACH sach, HttpPostedFileBase fileupload)
        {
            // Nạp lại dropdown (phải có để tránh lỗi khi reload view)
            ViewBag.MACHUDE = new SelectList(data.CHUDE.ToList().OrderBy(n => n.TENCHUDE), "MACD", "TENCHUDE", sach.MACHUDE);
            ViewBag.MANXB = new SelectList(data.NHAXUATBAN.ToList().OrderBy(n => n.TENNXB), "MANXB", "TENNXB", sach.MANXB);

            if (ModelState.IsValid)
            {
                // Lưu ảnh
                if (fileupload != null)
                {
                    var fileName = Path.GetFileName(fileupload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                    if (!System.IO.File.Exists(path))
                    {
                        fileupload.SaveAs(path);
                    }

                    sach.ANHBIA = fileName;
                }

                    try
                    {
                        data.Entry(sach).State = System.Data.Entity.EntityState.Modified;
                        data.SaveChanges();
                        return RedirectToAction("ListBook");
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                    {
                        foreach (var eve in ex.EntityValidationErrors)
                        {
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Response.Write($"Lỗi cột {ve.PropertyName}: {ve.ErrorMessage}");
                            }
                        }
                        return View(sach);
                    }
            }

            return View(sach);
        }








    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_Employee.Models;

namespace QL_Employee.Controllers
{
    public class HomeController : Controller
    {

        Model1 data= new Model1();


        public ActionResult Index()
        {
            List<EMPLOYEE> dsEmp = data.EMPLOYEEs.ToList();
            return View(dsEmp);
        }

        [HttpGet]
        public ActionResult Create()
        {
            // Dropdown phòng ban
            ViewBag.DEPT_ID = new SelectList(data.DEPARTMENTs.ToList().OrderBy(n => n.NAME), "DEPT_ID", "NAME");
      
            // Dropdown giới tính
            var genders = data.EMPLOYEEs
                     .Select(n => n.GENDER)
                     .Distinct()
                     .OrderBy(n => n)
                     .ToList();

            ViewBag.GENDER = new SelectList(genders);

            return View();
        }

        // Nhận dữ liệu thêm mới
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(EMPLOYEE emp, HttpPostedFileBase fileupload)
        {
            // Gọi lại dropdown nếu có lỗi
            ViewBag.DEPT_ID = new SelectList(data.DEPARTMENTs.ToList().OrderBy(n => n.NAME), "DEPT_ID", "NAME", emp.DEPT_ID);
            ViewBag.GENDER = new SelectList(data.EMPLOYEEs.ToList().OrderBy(n => n.GENDER), "ID", "GENDER", emp.GENDER);

            // Kiểm tra ảnh
            if (fileupload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh nhân viên";
                return View(emp);
            }

            if (ModelState.IsValid)
            {
                // Lưu ảnh vào thư mục
                var fileName = Path.GetFileName(fileupload.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                if (!System.IO.File.Exists(path))
                {
                    fileupload.SaveAs(path);
                }

                emp.IMAGES_EMP = fileName;

         

                data.EMPLOYEEs.Add(emp);
                data.SaveChanges();

                // Quay lại danh sách nhân viên
                return RedirectToAction("Index");
            }

            return View(emp);
        }



        [HttpGet]
        public ActionResult Edit(string id)
        {
            EMPLOYEE emp=data.EMPLOYEEs.SingleOrDefault(n => n.ID == id);
            if (emp==null)
            {
                Response.StatusCode = 404;
                return null;
            }


            ViewBag.DEPT_ID = new SelectList(data.DEPARTMENTs.ToList().OrderBy(n => n.NAME), "DEPT_ID", "NAME", emp.DEPT_ID);
            var genders = data.EMPLOYEEs
                    .Select(n => n.GENDER)
                    .Distinct()
                    .OrderBy(n => n)
                    .ToList();

            ViewBag.GENDER = new SelectList(genders);

            return View(emp);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(EMPLOYEE emp, HttpPostedFileBase fileupload)
        {
            ViewBag.DEPT_ID = new SelectList(data.DEPARTMENTs.ToList().OrderBy(n => n.NAME), "DEPT_ID", "NAME", emp.DEPT_ID);
            ViewBag.GENDER = new SelectList(data.EMPLOYEEs.Select(g => g.GENDER).Distinct().ToList(), emp.GENDER);

            if (ModelState.IsValid)
            {
                var existingEmp = data.EMPLOYEEs.SingleOrDefault(e => e.ID == emp.ID);
                if (existingEmp == null)
                {
                    return HttpNotFound();
                }

                // Cập nhật ảnh nếu có upload
                if (fileupload != null)
                {
                    var fileName = Path.GetFileName(fileupload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                    if (!System.IO.File.Exists(path))
                    {
                        fileupload.SaveAs(path);
                    }

                    existingEmp.IMAGES_EMP = fileName;
                }

                // Cập nhật các thuộc tính khác
                existingEmp.NAME_EMP = emp.NAME_EMP;
                existingEmp.CITY = emp.CITY;
                existingEmp.GENDER = emp.GENDER;
                existingEmp.DEPT_ID = emp.DEPT_ID;

                data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        public ActionResult Details(string id) // Fix: Change return type from Action to ActionResult
        {
            EMPLOYEE employee = data.EMPLOYEEs.SingleOrDefault(n => n.ID == id);
            ViewBag.ID = employee.ID;
            if (employee == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(employee);
        }


        //xóa nhân viên
        [HttpGet]

        public ActionResult Delete(string id)
        {
            EMPLOYEE emp = data.EMPLOYEEs.SingleOrDefault(n => n.ID == id);
            ViewBag.ID = emp.ID;

            if (emp == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(emp);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            EMPLOYEE emp = data.EMPLOYEEs.SingleOrDefault(n => n.ID == id);
            ViewBag.ID = emp.ID;

            if (emp == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            try
            {
                data.EMPLOYEEs.Remove(emp);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                // Gửi thông báo lỗi sang View
                ViewBag.ErrorMessage = "Không thể xóa nhân viên này vì còn dữ liệu liên quan đến phòng ban.";
                return View(emp); // Hiển thị lại trang xác nhận xóa
            }
        }

        public ActionResult List_Dept()
        {
            // Lấy danh sách tất cả phòng ban
            var dsDept = data.DEPARTMENTs.ToList();
            return View(dsDept);
        }

        // Hiển thị nhân viên thuộc một phòng ban cụ thể
        public ActionResult EmployeeByDept(string id)
        {
            // Tìm phòng ban theo mã
            var dept = data.DEPARTMENTs.SingleOrDefault(d => d.DEPT_ID == id);
            if (dept == null)
            {
                return HttpNotFound();
            }

            // Lấy danh sách nhân viên thuộc phòng đó
            var employees = data.EMPLOYEEs.Where(e => e.DEPT_ID == id).ToList();

            // Gửi tên phòng ban sang View
            ViewBag.DeptName = dept.NAME;

            return View(employees);
        }









    }










}

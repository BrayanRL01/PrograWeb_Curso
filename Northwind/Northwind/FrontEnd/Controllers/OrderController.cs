using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class OrderController : Controller
    {
        OrderHelper orderHelper;
        EmployeeHelper employeeHelper;
        CustomerHelper customerHelper;

        public OrderController()
        {
            orderHelper = new OrderHelper();
            employeeHelper = new EmployeeHelper();
            customerHelper = new CustomerHelper();
        }

        public ActionResult Index()
        {
            orderHelper = new OrderHelper();
            List<OrderViewModel> list = orderHelper.GetAll();

            return View(list);
        }

        public ActionResult Details(int id)
        {
            orderHelper = new OrderHelper();
            OrderViewModel order = orderHelper.GetByID(id);
            return View(order);
        }

        public ActionResult Create()
        {
            OrderViewModel order = new OrderViewModel();
            order.Customer = customerHelper.GetAll();
            order.Employee = employeeHelper.GetAll();
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel order)
        {
            try
            {
                orderHelper = new OrderHelper();
                order = orderHelper.Add(order);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            orderHelper = new OrderHelper();
            OrderViewModel order = orderHelper.GetByID(id);
            order.Customer = customerHelper.GetAll();
            order.Employee = employeeHelper.GetAll();
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderViewModel order)
        {
            try
            {
                orderHelper = new OrderHelper();
                order = orderHelper.Edit(order);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            orderHelper = new OrderHelper();
            OrderViewModel order = orderHelper.GetByID(id);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(OrderViewModel order)
        {
            try
            {
                orderHelper = new OrderHelper();
                orderHelper.Delete(order.OrderId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

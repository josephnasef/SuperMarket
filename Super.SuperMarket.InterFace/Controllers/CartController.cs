using Rotativa;
using Super.SuperMarket.DAl.SQLServer.Model;
//using Super.SuperMarket.Domain.Entities;
using Super.SuperMarket.Domain.Mangers;
using Super.SuperMarket.InterFace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Super.SuperMarket.InterFace.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductManger _productManger;
        private readonly ShippingDetailsManger _shippingDetailsManger;
        private readonly OperationTypeManger _OperationTypeManger;
        private readonly PaymentMethodManger _PaymentMethodManger;
        private readonly BillManger _billmanger;
        private readonly OperationManger _Operationmanger;

        public CartController(ProductManger productMangerPram, ShippingDetailsManger shippingDetailsMangerPram , OperationTypeManger operationTypeMangerPram , PaymentMethodManger PaymentMethodMangerPram, BillManger billMangerPram, OperationManger operationMangerPram)
        {
            this._OperationTypeManger = operationTypeMangerPram;
            this._productManger = productMangerPram;
            this._shippingDetailsManger = shippingDetailsMangerPram;
            this._PaymentMethodManger = PaymentMethodMangerPram;
            this._billmanger = billMangerPram;
            this._Operationmanger = operationMangerPram;
        }
        public ViewResult Index(Cart cart, string returnUrl)
        {
            CartIndexViewModel mycart = new CartIndexViewModel()
            {
                ReturnUrl = returnUrl,
                Cart = cart
            };

            return View(mycart);
        }
        public RedirectToRouteResult AddToCart(int Id, string returnUrl)
        {
            Product product = _productManger.GettAll()
                .FirstOrDefault(p => p.Id == Id);
            if (product != null) 
            { 
                GetCart().AddItem(product, 1);
            } 
            return RedirectToAction("Index", new { returnUrl }); 
        }
        [HttpPost]
        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = _productManger.GettAll()
                .FirstOrDefault(p => p.Id == productId);
            if (product != null) { GetCart().Remove(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        [HttpGet]
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public RedirectToRouteResult Checkout(ShippingDetails shippingDetails)
        {
            _shippingDetailsManger.Add(shippingDetails);
            return RedirectToAction("List","Product");
        }       
        public ActionResult CachInvoice(Cart cart, string returnUrl)
        {
            InvoiceViewModel mycart = new InvoiceViewModel()
            {
                ReturnUrl = returnUrl,
                Cart = cart,
            };
            return View(mycart);
        }
        [HttpPost]
        public RedirectToRouteResult CachInvoice(Cart cart)
        {
            foreach (var item in cart.lines)
            {
                Product MyProduct = _productManger.GettAll().Where(c => c.Id == item.Product.Id).First();
                MyProduct.Quentity = MyProduct.Quentity - item.Quantity;
                _productManger.Save();
            }
            return RedirectToAction("List", "Product");
        }
        public ActionResult CachDone(Cart cart, string returnUrl)
        {
            InvoiceViewModel mycart = new InvoiceViewModel()
            {
                ReturnUrl = returnUrl,
                Cart = cart,
            };
            ViewBag.operationType = new SelectList(_OperationTypeManger.GettAll().Where(c => c.IsArchived == false), "Id", "Name");
            return View(mycart);
        }
        [HttpPost]
        public RedirectToRouteResult CachDone(Cart cart,OperationType operationType)
        {
            Bill bill = new Bill();
            bill.FullPrice = cart.ComputeTotalValue();
            bill.CreatedDate = DateTime.Now;
            DateTime dt = (DateTime)bill.CreatedDate;
            bill.DateOfExpire = dt.AddMonths(8);
            bill.OperationTypeId = _OperationTypeManger.GettAll().Where(c => c.Name == "Cach").First().Id;
            bill.OperationTypeId = operationType.Id;
            bill.paymentMethodId = _PaymentMethodManger.GettAll().Where(c => c.Name == "CachInvoice").First().Id;
            bill.UpdatedDate = DateTime.Now;
            bill.CreatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
            bill.UpdatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
            _billmanger.Add(bill);

            Operation operation = new Operation();
            foreach (var item in cart.lines)
            {
                operation.Bill_Id = bill.Id;
                operation.OperationTypeId= operationType.Id;
                operation.ProductId = item.Product.Id;
                operation.ItemNumber = item.Quantity;
                operation.Value = item.Product.SellingPrice* item.Quantity;
                operation.CreatedDate = DateTime.Now;
                operation.UpdatedDate = DateTime.Now;
                operation.CreatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                operation.UpdatedBy = HttpContext.Request.UserHostAddress + "/" + User.Identity.Name + "/" + Request.LogonUserIdentity.Name;
                _Operationmanger.Add(operation);
            }
           
            foreach (var item in cart.lines)
            {
                if (_OperationTypeManger.GetBy(operationType.Id).Name == "Discarded")
                {
                    Product MyProduct = _productManger.GettAll().Where(c => c.Id == item.Product.Id).First();
                    MyProduct.Quentity = MyProduct.Quentity + item.Quantity;
                    _productManger.Save();
                }
                else
                {
                    Product MyProduct = _productManger.GettAll().Where(c => c.Id == item.Product.Id).First();
                    MyProduct.Quentity = MyProduct.Quentity - item.Quantity;
                    _productManger.Save();
                }               
            }
            return RedirectToAction("List", "Product");
        }

        #region Help
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        #endregion
    }
}
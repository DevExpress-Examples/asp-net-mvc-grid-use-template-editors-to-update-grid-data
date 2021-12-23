using E3326.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace E3326.Controllers {
    public class HomeController : Controller {
        private String SessionKey = "Some key";

        public ActionResult Index() {
            ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!";

            return View();
        }

        public ActionResult GridViewPartial() {
            return PartialView("GridViewPartial", GetList);
        }

        public ActionResult UpdateValue(Int32 key, String field, String value) {
            /* some delay */
            System.Threading.Thread.Sleep(1000);

            MyItem item = GetList.First(i => i.Id == key);

            /* some way to set a propery */
            PropertyInfo info = item.GetType().GetProperty(field, BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);

            String status;

            if (info.CanWrite) {
                info.SetValue(item, TypeDescriptor.GetConverter(info.PropertyType).ConvertFromString(value), null);
                status = String.Format("Field: <b>{0}</b> is updated with the <i>{1}</i> value", field, value);
            }
            else
                status = "Updating cannot be performed over a readonly field";

            return Content(status);
        }

        public IList<MyItem> GetList {
            get {
                List<MyItem> itemList = null;

                if (Session[SessionKey] == null) {
                    itemList = new List<MyItem> {
                        new MyItem { Id = 1, Text = "Text1", Item = 1},
                        new MyItem { Id = 2, Text = "Text2", Item = 2},
                        new MyItem { Id = 3, Text = "Text3", Item = 1},
                        new MyItem { Id = 4, Text = "Text4", Item = 2}
                    };

                    Session[SessionKey] = itemList;
                }

                return (IList<MyItem>)Session[SessionKey];
            }
            set {
                Session[SessionKey] = value;
            }
        }
    }
}
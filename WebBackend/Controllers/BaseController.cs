using Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBackend.Helpers;

namespace WebBackend.Controllers
{
    public class BaseController : Controller
    {
        public void Success(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Success, message, dismissable);
        }

        public void Information(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Information, message, dismissable);
        }

        public void Warning(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Warning, message, dismissable);
        }

        public void Danger(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Danger, message, dismissable);
        }

        private void AddAlert(string alertStyle, string message, bool dismissable)
        {
            var alerts = TempData.ContainsKey(Alert.TempDataKey)
                ? (List<Alert>)TempData[Alert.TempDataKey]
                : new List<Alert>();

            alerts.Add(new Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable
            });

            TempData[Alert.TempDataKey] = alerts;
        }






        ///administración de usuario
        ///administración de usuario
        ///
        public string Usuario
        {
            get
            {
                if (!User.Identity.IsAuthenticated)
                    return string.Empty;

                FormsIdentity formsIdentity = User.Identity as FormsIdentity;
                if (formsIdentity != null)
                {
                    return formsIdentity.Ticket.UserData.Split('|')[1];
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Retorna el nombre de completo del usuario actual
        /// </summary>
        public string NombreCompletoUsuario
        {
            get
            {
                if (!User.Identity.IsAuthenticated)
                    return string.Empty;

                return User.Identity.Name;
            }
        }

        ///// <summary>
        ///// Retorna el Id del usuario
        ///// </summary>
        public string UsuaroId
        {
            get
            {
                if (!User.Identity.IsAuthenticated)
                    return string.Empty;

                FormsIdentity formsIdentity = User.Identity as FormsIdentity;
                if (formsIdentity != null)
                {
                    return formsIdentity.Ticket.UserData.Split('|')[0];
                }

                return string.Empty;
            }
        }

        ///// <summary>
        ///// Retorna el nombre completo del usuario autenticado
        ///// </summary>
        public string NombrePerfil
        {
            get
            {
                if (!User.Identity.IsAuthenticated)
                    return string.Empty;

                FormsIdentity formsIdentity = User.Identity as FormsIdentity;
                if (formsIdentity != null)
                {
                    return formsIdentity.Ticket.UserData.Split('|')[2];
                }

                return string.Empty;
            }
        }



        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;
            response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            response.Cache.SetValidUntilExpires(false);
            response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            response.Cache.SetCacheability(HttpCacheability.NoCache);
            response.Cache.SetNoStore();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            string ruta = "";
            ruta = Server.MapPath("/Log");
            Log.WriteLog(ruta, filterContext.Exception.ToString());

            Exception ex = filterContext.Exception;

            var model = new HandleErrorInfo(filterContext.Exception, "Cuenta", "Action");


            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}
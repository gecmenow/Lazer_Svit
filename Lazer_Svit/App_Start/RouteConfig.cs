using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lazer_Svit
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "admin",
               url: "admin",
               defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "admin/LogIn",
               url: "admin/LogIn",
               defaults: new { controller = "Admin", action = "LogIn", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "admin/account",
               url: "admin/account",
               defaults: new { controller = "Admin", action = "ChangeData", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "admin/ChangeLogin",
               url: "admin/ChangeLogin",
               defaults: new { controller = "Admin", action = "ChangeLogin", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "admin/ChangePassword",
               url: "admin/ChangePassword",
               defaults: new { controller = "Admin", action = "ChangePassword", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "admin/items",
               url: "admin/items",
               defaults: new { controller = "AdminItems", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "admin/items/edit",
               url: "admin/items/edit/{id}",
               defaults: new { controller = "AdminItems", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "admin/item/add",
               url: "admin/item/add/",
               defaults: new { controller = "AdminItems", action = "AddItem", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "admin/items/delete",
               url: "admin/items/delete/{id}",
               defaults: new { controller = "AdminItems", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "admin/feedbacks",
               url: "admin/feedbacks",
               defaults: new { controller = "AdminFeedbacks", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "admin/orders",
               url: "admin/orders",
               defaults: new { controller = "AdminOrders", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "admin/order",
              url: "admin/order/edit/{id}",
              defaults: new { controller = "AdminOrders", action = "EditOrder", id = UrlParameter.Optional }
           );

           routes.MapRoute(
              name: "admin/userWorks",
              url: "admin/userWorks",
              defaults: new { controller = "AdminUsersWorks", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "download",
                url: "download/{id}",
                defaults: new { controller = "AdminUsersWorks", action = "Download", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "admin/price",
              url: "admin/price",
              defaults: new { controller = "AdminPrice", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "admin/Price/Woods",
              url: "admin/Woods",
              defaults: new { controller = "AdminPrice", action = "Woods", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "admin/Price/Acrylic",
              url: "admin/Acrylic",
              defaults: new { controller = "AdminPrice", action = "Acrylic", id = UrlParameter.Optional }
           );

           routes.MapRoute(
              name: "admin/Price/Engraving",
              url: "admin/Engraving",
              defaults: new { controller = "AdminPrice", action = "Engraving", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "admin/Price/UV",
              url: "admin/UV",
              defaults: new { controller = "AdminPrice", action = "UV", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "category",
              url: "category/{urlName}",
              defaults: new { controller = "Category", action = "Index", urlName = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "products",
               url: "products/{urlName}",
               defaults: new { controller = "Products", action = "Index", urlName = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "products/popular",
               url: "products/{urlName}/popular",
               defaults: new { controller = "Products", action = "Popular", urlName = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "products/low",
               url: "products/{urlName}/low",
               defaults: new { controller = "Products", action = "Low", urlName = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "products/high",
               url: "products/{urlName}/high",
               defaults: new { controller = "Products", action = "High", urlName = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "item",
               url: "item/{id}",
               defaults: new { controller = "Item", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "materials",
                url: "materials",
                defaults: new { controller = "Info", action = "Materials", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "price",
                url: "price",
                defaults: new { controller = "Info", action = "Price", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "uvPrice",
                url: "uvprinting",
                defaults: new { controller = "Info", action = "UVPrinting", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "info",
                url: "info",
                defaults: new { controller = "Info", action = "OrderInfo", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "feedback",
                url: "feedback",
                defaults: new { controller = "Feedback", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "contacts",
                url: "contacts",
                defaults: new { controller = "Home", action = "Contacts", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "checkout",
                url: "checkout",
                defaults: new { controller = "Checkout", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "addToCart",
               url: "addToCart",
               defaults: new { controller = "Cart", action = "AddToCart", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "cart",
                url: "cart",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "removeItemFromCart",
                url: "deleteItem/{id}",
                defaults: new { controller = "Cart", action = "DeleteItem", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "language",
                url: "language/{lang}",
                defaults: new { controller = "Language", action = "ChangeCulture", lang = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "afterCardOrder",
                url: " ",
                defaults: new { controller = "ClearCookie", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "liqpayStatus",
               url: "liqPay/{liqPayId}",
               defaults: new { controller = "Checkout", action = "LiqPayStatus", liqPayId = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

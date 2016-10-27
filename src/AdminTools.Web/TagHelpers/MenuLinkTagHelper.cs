using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using AdminTools.Web.Navigation;
using System.Collections.Generic;
using System.Linq;

namespace AdminTools.Web.TagHelpers
{
    //[HtmlTargetElement("menulink", Attributes = "controller-name, action-name, menu-text")]
    //public class MenuLinkTagHelper : TagHelper
    //{
    //    public string ControllerName { get; set; }
    //    public string ActionName { get; set; }
    //    public string MenuText { get; set; }
    //    [ViewContext]
    //    public ViewContext ViewContext { get; set; }

    //    public override void Process(TagHelperContext context, TagHelperOutput output)
    //    {
    //        var urlHelper = new UrlHelper(ViewContext);

    //        string menuUrl = urlHelper.Action(ActionName, ControllerName);

    //        output.TagName = "li";

    //        var a = new TagBuilder("a");
    //        a.Attributes.Add("href", $"{menuUrl}");
    //        a.Attributes.Add("class", "nav-link");
    //        a.InnerHtml.Append(MenuText);

    //        var routeData = ViewContext.RouteData.Values;
    //        var currentController = routeData["controller"];
    //        var currentAction = routeData["action"];

    //        if (String.Equals(ActionName, currentAction as string, StringComparison.OrdinalIgnoreCase)
    //            && String.Equals(ControllerName, currentController as string, StringComparison.OrdinalIgnoreCase))
    //        {
    //            output.Attributes.SetAttribute("class", "active nav-item");
    //        }
    //        else
    //        {
    //            output.Attributes.SetAttribute("class", "nav-item");

    //        }

    //        output.Content.SetHtmlContent(a);

    //    }
    //}

    [HtmlTargetElement("menulink", Attributes = "controller-name, action-name, menu-text, menu-id")]
    public class MenuLinkTagHelper : TagHelper
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        public string MenuText { get; set; }
        public int MenuId { get; set; }

        public MenuDataRepository _navigationMenu { get; set; }

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public IUrlHelperFactory _urlHelper { get; set; }

        public MenuLinkTagHelper(MenuDataRepository navigationMenu, IUrlHelperFactory urlHelper)
        {
            _navigationMenu = navigationMenu;
            _urlHelper = urlHelper;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "li";

            var routeData = ViewContext.RouteData.Values;
            var currentController = routeData["controller"];
            var currentAction = routeData["action"];

            List<MenuItem> subMenus = _navigationMenu.GetMenu().Result.MenuItems.Where(m => m.ParentId == MenuId).ToList();

            if (subMenus.Count > 0)
            {
                string subMenuClass = "";

                var caretSpan = new TagBuilder("span");
                caretSpan.AddCssClass("fa fa-fw fa-angle-down");

                var dropdownMenu = new TagBuilder("a");
                dropdownMenu.MergeAttribute("href", "#");
                dropdownMenu.AddCssClass("nav-link");
                dropdownMenu.MergeAttribute("data-toggle", "dropdown");
                dropdownMenu.InnerHtml.Append(MenuText);
                dropdownMenu.InnerHtml.AppendHtml(caretSpan);

                var ul = new TagBuilder("ul");
                ul.AddCssClass("dropdown-menu");

                foreach (var subMenu in subMenus)
                {
                    var li = new TagBuilder("li");

                    var urlHelper = _urlHelper.GetUrlHelper(ViewContext);

                    string subMenuUrl = urlHelper.Action(subMenu.ActionName, subMenu.ControllerName);

                    var a = new TagBuilder("a");
                    a.MergeAttribute("href", $"{subMenuUrl}");
                    a.MergeAttribute("title", subMenu.Name);
                    a.InnerHtml.Append(subMenu.Name);
                    a.AddCssClass("dropdown-item");

                    li.InnerHtml.AppendHtml(a);

                    ul.InnerHtml.AppendHtml(li);
                }

                if (subMenus.Any(s => s.ActionName == currentAction.ToString()) && subMenus.Any(s => s.ControllerName == currentController.ToString()))
                {
                    subMenuClass = "nav-item dropdown active";
                }
                else
                {
                    subMenuClass = "nav-item dropdown";
                }

                output.Attributes.Add("class", subMenuClass);

                output.Content.AppendHtml(dropdownMenu);
                output.Content.AppendHtml(ul);

            }
            else
            {
                var urlHelper = _urlHelper.GetUrlHelper(ViewContext);

                string menuUrl = urlHelper.Action(ActionName, ControllerName);

                var a = new TagBuilder("a");
                a.MergeAttribute("href", $"{menuUrl}");
                a.MergeAttribute("title", MenuText);
                a.InnerHtml.Append(MenuText);
                a.AddCssClass("nav-link");

                if (String.Equals(ActionName, currentAction as string, StringComparison.OrdinalIgnoreCase)
                   && String.Equals(ControllerName, currentController as string, StringComparison.OrdinalIgnoreCase))
                {
                    output.Attributes.Add("class", "nav-item active");
                } else
                {
                    output.Attributes.Add("class", "nav-item");
                }

                output.Content.AppendHtml(a);
            }
        }
    }
}
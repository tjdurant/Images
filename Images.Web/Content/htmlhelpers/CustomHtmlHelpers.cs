using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// added this namespace to web.config
namespace Images.Web.Content.htmlhelpers
{
    public static class CustomHtmlHelpers
    {
        // https://www.youtube.com/watch?v=2mACi5D739g
        public static IHtmlString Image(this HtmlHelper helper, string src)
        {

            TagBuilder tb = new TagBuilder("img");

            // relative path to url conversion
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));

            // returns a string wrapped in html string; 
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }

    }
}
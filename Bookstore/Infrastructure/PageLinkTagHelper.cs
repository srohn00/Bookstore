using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//add in these
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Bookstore.Infrastructure
{
    //add this
    [HtmlTargetElement("div", Attributes ="page-model")]
    //inherit from tag helper class
    public class PageLinkTagHelper : TagHelper
    {
        //add in everything beneath here
        private IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper (IUrlHelperFactory hp)
        {
            urlHelperFactory = hp;
        }
    }
}

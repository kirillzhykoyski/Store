#pragma checksum "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\Order\Finish.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "97772596a4dfa7ecc87e6f318e5b4c928b2582c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Finish), @"mvc.1.0.view", @"/Views/Order/Finish.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\_ViewImports.cshtml"
using Store;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\_ViewImports.cshtml"
using Store.Contractors;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\_ViewImports.cshtml"
using Store.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\_ViewImports.cshtml"
using Store.Web.App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\_ViewImports.cshtml"
using Store.Web.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\_ViewImports.cshtml"
using Store.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97772596a4dfa7ecc87e6f318e5b4c928b2582c0", @"/Views/Order/Finish.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"761b1ac2c428e7077ca1a5d38b08d5acfed35ade", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Order_Finish : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\Order\Finish.cshtml"
  
    ViewData["Title"] = "Заказ оформлен";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<p>
    Заказ оформлен. Мы собираем его, чтобы передать в службу доставки.
    Ждите SMS.
</p>

<table class=""table table-sm table-striped"">
    <thead class=""thead-dark"">
        <tr>
            <th scope=""col"">№</th>
            <th scope=""col"">Автор</th>
            <th scope=""col"">Название</th>
            <th scope=""col"">Количество</th>
            <th scope=""col"">Цена</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 22 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\Order\Finish.cshtml"
         for (int i = 0; i < Model.Items.Length; i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td class=\"text-right\">");
#nullable restore
#line 25 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\Order\Finish.cshtml"
                                   Write(i + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\Order\Finish.cshtml"
               Write(Model.Items[i].Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\Order\Finish.cshtml"
               Write(Model.Items[i].Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"text-right\">");
#nullable restore
#line 28 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\Order\Finish.cshtml"
                                  Write(Model.Items[i].Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"text-right\">");
#nullable restore
#line 29 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\Order\Finish.cshtml"
                                  Write(Model.Items[i].Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 31 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\Order\Finish.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n    <tfoot>\r\n        <tr>\r\n            <td colspan=\"3\" class=\"text-right\">Итого</td>\r\n            <td class=\"text-right\">");
#nullable restore
#line 36 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\Order\Finish.cshtml"
                              Write(Model.TotalCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-right\">");
#nullable restore
#line 37 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\Order\Finish.cshtml"
                              Write(Model.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n    </tfoot>\r\n</table>\r\n\r\n<strong>Доставка</strong>\r\n<pre>\r\n");
#nullable restore
#line 44 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\Order\Finish.cshtml"
Write(Model.DeliveryDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</pre>\r\n\r\n<strong>Оплата</strong>\r\n<pre>\r\n");
#nullable restore
#line 49 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\Order\Finish.cshtml"
Write(Model.PaymentDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</pre>\r\n\r\n<p>\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 1319, "\"", 1354, 1);
#nullable restore
#line 53 "C:\Users\Kirillzykoyski\source\repos\store\presentation\Store.Web\Views\Order\Finish.cshtml"
WriteAttributeValue("", 1326, Url.Action("Index", "Home"), 1326, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Вернутся в магазин</a>.\r\n</p>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

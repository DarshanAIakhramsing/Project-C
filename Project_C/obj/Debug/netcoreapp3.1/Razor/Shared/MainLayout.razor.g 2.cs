#pragma checksum "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Shared/MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1bec7d12bc63a95289420a425a27fa4c7207cdbb"
// <auto-generated/>
#pragma warning disable 1591
namespace Project_C.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/_Imports.razor"
using Project_C;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/_Imports.razor"
using Project_C.Shared;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "sidebar");
            __builder.OpenComponent<Project_C.Shared.NavMenu>(2);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(3, "\n\n");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "main");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "top-row px-4 auth");
            __builder.OpenComponent<Project_C.Shared.LoginDisplay>(8);
            __builder.CloseComponent();
            __builder.AddMarkupContent(9, "\n        ");
            __builder.AddMarkupContent(10, "<a href=\"https://docs.microsoft.com/aspnet/\" target=\"_blank\">About</a>");
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\n\n    ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "content px-4");
            __builder.AddContent(14, 
#nullable restore
#line 14 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Shared/MainLayout.razor"
         Body

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591

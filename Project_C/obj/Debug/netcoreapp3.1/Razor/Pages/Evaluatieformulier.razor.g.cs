#pragma checksum "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Evaluatieformulier.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4e0aa494a8db61a9f805600a8352b8d9b9e7fccf"
// <auto-generated/>
#pragma warning disable 1591
namespace Project_C.Pages
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/evaluatieformulier")]
    public partial class Evaluatieformulier : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(2, "h1");
                __builder2.AddContent(3, "Hello, ");
                __builder2.AddContent(4, 
#nullable restore
#line 5 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Evaluatieformulier.razor"
                    context.User.Identity.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.AddContent(5, "!");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(6, "\n        You can only see this if you\'re authenticated.\n    ");
            }
            ));
            __builder.AddAttribute(7, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(8, "\n        You\'re not logged in.\n    ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(9, "\n\n");
            __builder.AddMarkupContent(10, "<h1>Evaluatie Formulier</h1>\n\nHier kan u een evaluatie formulier invullen van de laatste sessie die u heeft gevolgd.\n");
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591

#pragma checksum "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Aanmaken.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a758c487ef6a422db1344122873c8e80dc47b0c1"
// <auto-generated/>
#pragma warning disable 1591
namespace Project_C.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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
#nullable restore
#line 1 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Aanmaken.razor"
using Project_C.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Aanmaken.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/aanmaken")]
    public partial class Aanmaken : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h2>Employee Details</h2>\n");
            __builder.AddMarkupContent(1, "<div class=\"form-group\"><a class=\"btn btn-success\" href=\"/addsession\"><i class=\"oi oi-plus\"></i> Create New</a></div>\n<br>");
#nullable restore
#line 15 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Aanmaken.razor"
 if (sessions == null)
{
    

#line default
#line hidden
#nullable disable
            __builder.AddContent(2, "Loading...");
#nullable restore
#line 17 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Aanmaken.razor"
                           
}
else if (sessions.Length == 0)
{
    

#line default
#line hidden
#nullable disable
            __builder.AddContent(3, "No Records Found.");
#nullable restore
#line 21 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Aanmaken.razor"
                                  
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(4, "table");
            __builder.AddAttribute(5, "class", "table table-striped");
            __builder.AddMarkupContent(6, "<thead><tr><th>Id</th>\n                <th>Naam</th>\n                <th>Datum</th>\n                <th>Locatie</th>\n                <th></th></tr></thead>\n        ");
            __builder.OpenElement(7, "tbody");
#nullable restore
#line 36 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Aanmaken.razor"
             foreach (SessionInfo ses in sessions)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(8, "tr");
            __builder.OpenElement(9, "td");
            __builder.AddContent(10, 
#nullable restore
#line 39 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Aanmaken.razor"
                         ses.session_id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\n                    ");
            __builder.OpenElement(12, "td");
            __builder.AddContent(13, 
#nullable restore
#line 40 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Aanmaken.razor"
                         ses.session_name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\n                    ");
            __builder.OpenElement(15, "td");
            __builder.AddContent(16, 
#nullable restore
#line 41 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Aanmaken.razor"
                         ses.session_date

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\n                    ");
            __builder.OpenElement(18, "td");
            __builder.AddContent(19, 
#nullable restore
#line 42 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Aanmaken.razor"
                         ses.session_location

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\n                    ");
            __builder.OpenElement(21, "td");
            __builder.OpenElement(22, "a");
            __builder.AddAttribute(23, "class", "btn btn-success");
            __builder.AddAttribute(24, "href", "edit/" + (
#nullable restore
#line 44 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Aanmaken.razor"
                                                               ses.session_id

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(25, "Edit");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 48 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Aanmaken.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 51 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Aanmaken.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 53 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Aanmaken.razor"
       
    string baseUrl;
    SessionInfo[] sessions { get; set; }
    protected override async Task OnInitializedAsync()
    {
        baseUrl = AppSettingsService.GetBaseUrl();
        sessions = await client.GetJsonAsync<SessionInfo[]>("api/session");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AppSettingsService AppSettingsService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private CustomHttpClient Http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient client { get; set; }
    }
}
#pragma warning restore 1591

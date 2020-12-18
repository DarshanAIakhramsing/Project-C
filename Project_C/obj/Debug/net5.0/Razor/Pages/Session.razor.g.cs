#pragma checksum "F:\Projects\Project_C\Project_C\Pages\Session.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15c7ac47f13b245d305cec91f22df9fb84d6a335"
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
#line 1 "F:\Projects\Project_C\Project_C\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Projects\Project_C\Project_C\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\Projects\Project_C\Project_C\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\Projects\Project_C\Project_C\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\Projects\Project_C\Project_C\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\Projects\Project_C\Project_C\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\Projects\Project_C\Project_C\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\Projects\Project_C\Project_C\_Imports.razor"
using Project_C;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\Projects\Project_C\Project_C\_Imports.razor"
using Project_C.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
using Project_C.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
using Project_C.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
using Project_C.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
using System.ComponentModel.DataAnnotations;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/sessies")]
    public partial class Session : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "Roles", "Organisator, Admin");
            __builder.AddAttribute(2, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((Auth) => (__builder2) => {
#nullable restore
#line 13 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
         if (Sessions == null)
        {

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(3, "<p><em>Loading...</em></p>");
#nullable restore
#line 16 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(4, "table");
                __builder2.AddAttribute(5, "class", "table table-hover");
                __builder2.AddMarkupContent(6, "<thead><tr><th>Sessie naam</th>\r\n                        <th>Sessie locatie</th>\r\n                        <th>Datum</th></tr></thead>\r\n                ");
                __builder2.OpenElement(7, "tbody");
#nullable restore
#line 28 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
                     foreach (var item in Sessions)
                    {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(8, "tr");
                __builder2.AddAttribute(9, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 30 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
                                        () => SelectSession(item)

#line default
#line hidden
#nullable disable
                ));
                __builder2.OpenElement(10, "td");
                __builder2.AddContent(11, 
#nullable restore
#line 31 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
                                 item.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(12, "\r\n                            ");
                __builder2.OpenElement(13, "td");
                __builder2.AddContent(14, 
#nullable restore
#line 32 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
                                 item.Location

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(15, "\r\n                            ");
                __builder2.OpenElement(16, "td");
                __builder2.AddContent(17, 
#nullable restore
#line 33 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
                                 item.Date

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
#nullable restore
#line 35 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
                    }

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.CloseElement();
#nullable restore
#line 38 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
        }

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(18);
                __builder2.AddAttribute(19, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 40 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
                          EditModel

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(20, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 40 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
                                                     Submit

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(21, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder3) => {
                    __builder3.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(22);
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(23, "\r\n            ");
                    __builder3.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(24);
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(25, "\r\n\r\n            ");
                    __builder3.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(26);
                    __builder3.AddAttribute(27, "id", "Naam");
                    __builder3.AddAttribute(28, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 44 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
                                               EditModel.Name

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(29, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => EditModel.Name = __value, EditModel.Name))));
                    __builder3.AddAttribute(30, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => EditModel.Name));
                    __builder3.AddAttribute(31, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(32, "Naam: ");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(33, "\r\n            ");
                    __builder3.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(34);
                    __builder3.AddAttribute(35, "id", "Locatie");
                    __builder3.AddAttribute(36, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 45 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
                                                  EditModel.Location

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(37, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => EditModel.Location = __value, EditModel.Location))));
                    __builder3.AddAttribute(38, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => EditModel.Location));
                    __builder3.AddAttribute(39, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(40, "Locatie: ");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(41, "\r\n            ");
                    __Blazor.Project_C.Pages.Session.TypeInference.CreateInputDate_0(__builder3, 42, 43, "Datum", 44, 
#nullable restore
#line 46 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
                                                EditModel.Date

#line default
#line hidden
#nullable disable
                    , 45, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => EditModel.Date = __value, EditModel.Date)), 46, () => EditModel.Date, 47, (__builder4) => {
                        __builder4.AddContent(48, "Datum: ");
                    }
                    );
#nullable restore
#line 48 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
             switch (mode)
            {
                case MODE.None:

#line default
#line hidden
#nullable disable
                    __builder3.AddMarkupContent(49, "<button type=\"submit\">Insert</button>");
#nullable restore
#line 52 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
                    break;
                case MODE.EditDelete:

#line default
#line hidden
#nullable disable
                    __builder3.AddMarkupContent(50, "<button type=\"submit\">Edit</button>");
#nullable restore
#line 55 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
                    break;
            }

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
#nullable restore
#line 58 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
         if (mode == MODE.EditDelete)
        {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(51, "button");
                __builder2.AddAttribute(52, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 60 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
                              Delete

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(53, "Delete");
                __builder2.CloseElement();
#nullable restore
#line 61 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
        }

#line default
#line hidden
#nullable disable
            }
            ));
            __builder.AddAttribute(54, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(55, "\r\n        U bent niet geautoriseerd.\r\n    ");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 69 "F:\Projects\Project_C\Project_C\Pages\Session.razor"
       
    public class EditSessionModel
    {
        [Required, StringLength(255, MinimumLength = 1)]
        public string Name { get; set; }

        [Required, StringLength(255, MinimumLength = 1)]
        public string Location { get; set; }

        public DateTime Date { get; set; }
    }

    EditSessionModel EditModel { get; set; } = new();

    public System.Collections.Generic.IList<SessionInfo> Sessions { get; set; }

    private enum MODE { None, Add, EditDelete };

    public int SelectedSessionID = -1;

    MODE mode = MODE.None;

    public async void Submit()
    {
        var session = (from S in Sessions where S.Id == SelectedSessionID select S).FirstOrDefault() ?? new();
        session.Name = EditModel.Name;
        session.Location = EditModel.Location;
        session.Date = EditModel.Date;
        await sessionCRUD.UpdateSessionAsync(session);
        if (!Sessions.Contains(session)) Sessions.Add(session);
        StateHasChanged();
    }

    protected async override void OnInitialized()
    {
        Sessions = await sessionCRUD.GetSessionsAsync();
        StateHasChanged();
    }


    protected async Task Delete()
    {
        var toDelete = (from S in Sessions where S.Id == SelectedSessionID select S).First();
        Sessions.Remove(toDelete);
        await sessionCRUD.DeleteSessionAsync(toDelete);

        SelectedSessionID = -1;
        EditModel = new();
        StateHasChanged();
        mode = MODE.None;
    }

    protected void SelectSession(SessionInfo session)
    {
        mode = MODE.EditDelete;
        SelectedSessionID = session.Id;
        EditModel.Name = session.Name;
        EditModel.Location = session.Location;
        EditModel.Date = session.Date;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SessionCRUD sessionCRUD { get; set; }
    }
}
namespace __Blazor.Project_C.Pages.Session
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateInputDate_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, TValue __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg2, int __seq3, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg3, int __seq4, Microsoft.AspNetCore.Components.RenderFragment __arg4)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputDate<TValue>>(seq);
        __builder.AddAttribute(__seq0, "id", __arg0);
        __builder.AddAttribute(__seq1, "Value", __arg1);
        __builder.AddAttribute(__seq2, "ValueChanged", __arg2);
        __builder.AddAttribute(__seq3, "ValueExpression", __arg3);
        __builder.AddAttribute(__seq4, "ChildContent", __arg4);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591

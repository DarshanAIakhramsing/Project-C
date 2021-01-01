// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
#nullable restore
#line 3 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Session.razor"
using Project_C.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Session.razor"
using Project_C.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Session.razor"
using Project_C.Services;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/sessies")]
    public partial class Session : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 75 "/Users/ferdibilgic/Documents/GitHub/Project-C/Project_C/Pages/Session.razor"
       
    public System.Collections.Generic.IList<SessionInfo> Sessions { get; set; }

    SessionInfo CurrentSession { get; set; } = new();

    private enum MODE { None, Add, EditDelete };

    MODE mode = MODE.None;
    SessionInfo sessie;

    protected async override void OnInitialized()
    {
        await Load();
        StateHasChanged();
    }

    protected async Task Load()
    {
        Sessions = await sessionCRUD.GetSessionsAsync();
    }

    protected async Task Insert()
    {
        PrepareModel();

        await sessionCRUD.InsertSessionAsync(CurrentSession);
        Sessions.Add(CurrentSession);
        ClearFields();

        mode = MODE.None;
    }

    protected void Add()
    {
        ClearFields();
        mode = MODE.Add;
    }

    protected async Task Update()
    {
        PrepareModel();

        await sessionCRUD.UpdateSessionAsync(CurrentSession);
        ClearFields();
        mode = MODE.None;
    }

    protected async Task Delete()
    {
        await sessionCRUD.DeleteSessionAsync(CurrentSession);
        Sessions.Remove(CurrentSession);
        ClearFields();
        mode = MODE.None;
    }

    private void PrepareModel()
    {
        if (string.IsNullOrWhiteSpace(CurrentSession.Name))
            CurrentSession.Name = null;
        if (string.IsNullOrWhiteSpace(CurrentSession.Location))
            CurrentSession.Location = null;
    }

    protected void ClearFields()
    {
        CurrentSession = new();
    }

    protected void Show(SessionInfo session)
    {
        CurrentSession = session;
        mode = MODE.EditDelete;
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SessionCRUD sessionCRUD { get; set; }
    }
}
#pragma warning restore 1591

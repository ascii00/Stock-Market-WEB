#pragma checksum "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\Components\AutoComplete.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82c44f1e447e078ee8314efb3e949b209a927843"
// <auto-generated/>
#pragma warning disable 1591
namespace StockMarket.Client.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\_Imports.razor"
using StockMarket.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\_Imports.razor"
using StockMarket.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\_Imports.razor"
using StockMarket.Client.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\Components\AutoComplete.razor"
using Syncfusion.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\Components\AutoComplete.razor"
using Syncfusion.Blazor.DropDowns;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\Components\AutoComplete.razor"
using Syncfusion.Blazor.Data;

#line default
#line hidden
#nullable disable
    public partial class AutoComplete : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h2>AutoComplete</h2>\r\n<br>\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "id", "ControlRegion");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "col-lg-12 control-section");
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "class", "control_wrapper");
            __builder.OpenComponent<Syncfusion.Blazor.DropDowns.SfAutoComplete<string, GameFields>>(7);
            __builder.AddAttribute(8, "Placeholder", "e.g. Basketball");
            __builder.AddAttribute(9, "DataSource", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<GameFields>>(
#nullable restore
#line 10 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\Components\AutoComplete.razor"
                                                                                                       Games

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Syncfusion.Blazor.DropDowns.AutoCompleteFieldSettings>(11);
                __builder2.AddAttribute(12, "Value", "Text");
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n<br>\r\n");
            __builder.AddMarkupContent(14, "<div><h3>Selected Features:</h3>\r\n    <ul class=\"ulstyle\"><li class=\"list\"> AutoComplete Samples - Default</li>\r\n      <li class=\"list\"> Theme - Fluent</li></ul></div>\r\n<br>\r\n");
            __builder.AddMarkupContent(15, @"<style>
    .control_wrapper {
        width: 350px;
        margin: 0 auto;
        padding: 3%;
    }
    .ulstyle {
        margin: 0px;
        padding-left: 20px;
        display: inline-block;
    }
    .list {
    float: left;
    line-height: 20px;
    margin: 10px;
    min-width: 330px;
    }
</style>");
        }
        #pragma warning restore 1998
#nullable restore
#line 43 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\Components\AutoComplete.razor"
      
    public class GameFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }
    public List<GameFields> Games = new List<GameFields>()
{
        new GameFields(){ ID= "Game1", Text= "American Football" },
        new GameFields(){ ID= "Game2", Text= "Badminton" },
        new GameFields(){ ID= "Game3", Text= "Basketball" },
        new GameFields(){ ID= "Game4", Text= "Cricket" },
        new GameFields(){ ID= "Game5", Text= "Football" },
        new GameFields(){ ID= "Game6", Text= "Golf" },
        new GameFields(){ ID= "Game7", Text= "Hockey" },
        new GameFields(){ ID= "Game8", Text= "Rugby"},
        new GameFields(){ ID= "Game9", Text= "Snooker" },
        new GameFields(){ ID= "Game10",Text= "Tennis"},
    };

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591

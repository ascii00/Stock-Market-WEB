#pragma checksum "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\Pages\Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18068655065fb65845f1144d20ccb8e35a9bf3cf"
// <auto-generated/>
#pragma warning disable 1591
namespace StockMarket.Client.Pages
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
#line 11 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\_Imports.razor"
using Syncfusion.Blazor;

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
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(EmptyLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/login")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "login");
            __builder.AddAttribute(2, "b-5d5s82luv7");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "login__content");
            __builder.AddAttribute(5, "b-5d5s82luv7");
            __builder.AddMarkupContent(6, "<div class=\"login__img\" b-5d5s82luv7><img src=\"https://raw.githubusercontent.com/valekutce/form8-elements/488f8743c5f18b60595cae7843bcc00ada5f37a7/assets/img/img-login.svg\" alt b-5d5s82luv7></div>\r\n\r\n        ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "login__forms");
            __builder.AddAttribute(9, "b-5d5s82luv7");
            __builder.OpenElement(10, "form");
            __builder.AddAttribute(11, "action");
            __builder.AddAttribute(12, "class", 
#nullable restore
#line 12 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\Pages\Login.razor"
                                    loginClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(13, "id", "login-in");
            __builder.AddAttribute(14, "b-5d5s82luv7");
            __builder.AddMarkupContent(15, "<h1 class=\"login__title\" b-5d5s82luv7>Sign In</h1>\r\n\r\n                ");
            __builder.AddMarkupContent(16, "<div class=\"login__box\" b-5d5s82luv7><i class=\'bx bx-user login__icon\' b-5d5s82luv7></i>\r\n                    <input type=\"text\" placeholder=\"Username\" class=\"login__input\" b-5d5s82luv7></div>\r\n\r\n                ");
            __builder.AddMarkupContent(17, "<div class=\"login__box\" b-5d5s82luv7><i class=\'bx bx-lock-alt login__icon\' b-5d5s82luv7></i>\r\n                    <input type=\"password\" placeholder=\"Password\" class=\"login__input\" b-5d5s82luv7></div>\r\n\r\n                ");
            __builder.AddMarkupContent(18, "<a href=\"/\" class=\"login__button\" b-5d5s82luv7>Sign In</a>\r\n\r\n                ");
            __builder.OpenElement(19, "div");
            __builder.AddAttribute(20, "b-5d5s82luv7");
            __builder.AddMarkupContent(21, "<span class=\"login__account\" b-5d5s82luv7>Don\'t have an Account?</span>\r\n                    ");
            __builder.OpenElement(22, "button");
            __builder.AddAttribute(23, "type", "button");
            __builder.AddAttribute(24, "class", "login__signin");
            __builder.AddAttribute(25, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 29 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\Pages\Login.razor"
                                                                          ChangeLoginType

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(26, "b-5d5s82luv7");
            __builder.AddContent(27, "Sign Up");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n\r\n            ");
            __builder.OpenElement(29, "form");
            __builder.AddAttribute(30, "action");
            __builder.AddAttribute(31, "class", 
#nullable restore
#line 33 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\Pages\Login.razor"
                                    registerClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(32, "id", "login-up");
            __builder.AddAttribute(33, "b-5d5s82luv7");
            __builder.AddMarkupContent(34, "<h1 class=\"login__title\" b-5d5s82luv7>Create Account</h1>\r\n\r\n                ");
            __builder.AddMarkupContent(35, "<div class=\"login__box\" b-5d5s82luv7><i class=\'bx bx-user login__icon\' b-5d5s82luv7></i>\r\n                    <input type=\"text\" placeholder=\"Username\" class=\"login__input\" b-5d5s82luv7></div>\r\n\r\n                ");
            __builder.AddMarkupContent(36, "<div class=\"login__box\" b-5d5s82luv7><i class=\'bx bx-at login__icon\' b-5d5s82luv7></i>\r\n                    <input type=\"text\" placeholder=\"Email\" class=\"login__input\" b-5d5s82luv7></div>\r\n\r\n                ");
            __builder.AddMarkupContent(37, "<div class=\"login__box\" b-5d5s82luv7><i class=\'bx bx-lock-alt login__icon\' b-5d5s82luv7></i>\r\n                    <input type=\"password\" placeholder=\"Password\" class=\"login__input\" b-5d5s82luv7></div>\r\n\r\n                ");
            __builder.AddMarkupContent(38, "<a href=\"/\" class=\"login__button\" b-5d5s82luv7>Sign Up</a>\r\n\r\n                ");
            __builder.OpenElement(39, "div");
            __builder.AddAttribute(40, "b-5d5s82luv7");
            __builder.AddMarkupContent(41, "<span class=\"login__account\" b-5d5s82luv7>Already have an Account?</span>\r\n                    ");
            __builder.OpenElement(42, "button");
            __builder.AddAttribute(43, "type", "button");
            __builder.AddAttribute(44, "class", "login__signup");
            __builder.AddAttribute(45, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 55 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\Pages\Login.razor"
                                                                          ChangeLoginType

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(46, "b-5d5s82luv7");
            __builder.AddContent(47, "Sign In");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 62 "C:\Users\maxim\OneDrive - Polsko-Japońska Akademia Technik Komputerowych\Desktop\StockMarket\Client\Pages\Login.razor"
      

    private string registerClass = "login__create none";
    private string loginClass = "login__registre";
    private bool isLogin = true;
     

    private void ChangeLoginType()
    {
        if (isLogin)
        {
            registerClass = "login__create";
            loginClass = "login__registre none";
            isLogin = false;
        }
        else
        {
            registerClass = "login__create none";
            loginClass = "login__registre";
            isLogin = true;
        }
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591

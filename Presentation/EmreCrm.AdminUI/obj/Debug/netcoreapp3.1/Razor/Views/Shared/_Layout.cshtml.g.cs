#pragma checksum "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AdminUI\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01f87b4ec9b2bc8b52b5334f3ea4083caac43855"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
#line 1 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AdminUI\Views\_ViewImports.cshtml"
using EmreCrm.AdminUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AdminUI\Views\_ViewImports.cshtml"
using EmreCrm.Model.DbEntity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AdminUI\Views\_ViewImports.cshtml"
using EmreCrm.Model.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AdminUI\Views\_ViewImports.cshtml"
using NonFactors.Mvc.Grid;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01f87b4ec9b2bc8b52b5334f3ea4083caac43855", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85dd1bc91ff3d1b999c3035a3f180f70b3157034", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AdminUI\Views\Shared\_Layout.cshtml"
  
    string currentAction = ViewContext.RouteData.Values["Action"].ToString();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<!-- begin::Head -->\r\n<head>\r\n    <meta charset=\"utf-8\" />\r\n    <title>");
#nullable restore
#line 10 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AdminUI\Views\Shared\_Layout.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" - Emre Crm</title>
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1, shrink-to-fit=no"">
    <!--begin::Web font -->
    <script src=""https://ajax.googleapis.com/ajax/libs/webfont/1.6.16/webfont.js""></script>
    <script>
        WebFont.load({
            google: { ""families"": [""Poppins:300,400,500,600,700"", ""Roboto:300,400,500,600,700"", ""Asap+Condensed:500""] },
            active: function () {
                sessionStorage.fonts = true;
            }
        });
    </script>

    <!--end::Web font -->
    <!--begin::Global Theme Styles -->
    <link href=""/vendors/base/vendors.bundle.css"" rel=""stylesheet"" type=""text/css"" />

    <!--RTL version:<link href=""assets/vendors/base/vendors.bundle.rtl.css"" rel=""stylesheet"" type=""text/css"" />-->
    <link href=""/demo/demo8/base/style.bundle.css"" rel=""stylesheet"" type=""text/css"" />

    <!--RTL version:<link href=""assets/demo/demo8/base/style.bundle.rtl.css"" rel=""stylesheet"" type=""text/css"" />-->
    <!-");
            WriteLiteral(@"-end::Global Theme Styles -->
    <!--begin::Page Vendors Styles -->
    <link href=""/vendors/custom/fullcalendar/fullcalendar.bundle.css"" rel=""stylesheet"" type=""text/css"" />
    <link href=""/vendors/custom/mvc-grid/mvc-grid.css"" rel=""stylesheet"" type=""text/css"" />
    <link href=""/vendors/custom/file-uploader/css/fileinput.css?v=1"" rel=""stylesheet"">
    <link href=""/vendors/custom/file-uploader/themes/explorer-fas/theme.min.css?v=1"" rel=""stylesheet"">

    <!--RTL version:<link href=""assets/vendors/custom/fullcalendar/fullcalendar.bundle.rtl.css"" rel=""stylesheet"" type=""text/css"" />-->
    <!--end::Page Vendors Styles -->
    <link rel=""shortcut icon"" href=""/demo8/demo/media/img/logo/favicon.ico"" />
</head>

<!-- end::Head -->
<!-- begin::Body -->
<body style=""background-image: url(/app/media/img/bg/bg-7.jpg)"" class=""m-page--fluid m-page--loading-enabled m-page--loading m-header--fixed m-header--fixed-mobile m-footer--push m-aside--offcanvas-default"">

    <!-- begin::Page loader -->
    <div ");
            WriteLiteral(@"class=""m-page-loader m-page-loader--base"">
        <div class=""m-blockui"">
            <span>Lütfen bekleyin...</span>
            <span>
                <div class=""m-loader m-loader--brand""></div>
            </span>
        </div>
    </div>

    <!-- end::Page Loader -->
    <!-- begin:: Page -->
    <div class=""m-grid m-grid--hor m-grid--root m-page"">

        <!-- begin::Header -->
        <header id=""m_header"" class=""m-grid__item	m-header "" m-minimize=""minimize"" m-minimize-mobile=""minimize"" m-minimize-offset=""10"" m-minimize-mobile-offset=""10"">
            <div class=""m-header__top"">
                <div class=""m-container m-container--fluid m-container--full-height m-page__container"">
                    <div class=""m-stack m-stack--ver m-stack--desktop"">

                        <!-- begin::Brand -->
                        <div class=""m-stack__item m-brand m-stack__item--left"">
                            <div class=""m-stack m-stack--ver m-stack--general m-stack--inline"">
      ");
            WriteLiteral("                          <div class=\"m-stack__item m-stack__item--middle m-brand__logo\">\r\n                                    <a href=\"index.html\" class=\"m-brand__logo-wrapper\">\r\n                                        <img");
            BeginWriteAttribute("alt", " alt=\"", 3508, "\"", 3514, 0);
            EndWriteAttribute();
            WriteLiteral(" src=\"/demo/demo8/media/img/logo/logo.png\" class=\"m-brand__logo-default\" />\r\n                                        <img");
            BeginWriteAttribute("alt", " alt=\"", 3636, "\"", 3642, 0);
            EndWriteAttribute();
            WriteLiteral(@" src=""/demo/demo8/media/img/logo/logo_inverse.png"" class=""m-brand__logo-inverse"" />
                                    </a>
                                </div>
                                <div class=""m-stack__item m-stack__item--middle m-brand__tools"">

                                    <!-- begin::Responsive Header Menu Toggler-->
                                    <a id=""m_aside_header_menu_mobile_toggle"" href=""javascript:;"" class=""m-brand__icon m-brand__toggler m--visible-tablet-and-mobile-inline-block"">
                                        <span></span>
                                    </a>

                                    <!-- end::Responsive Header Menu Toggler-->
                                    <!-- begin::Topbar Toggler-->
                                    <a id=""m_aside_header_topbar_mobile_toggle"" href=""javascript:;"" class=""m-brand__icon m--visible-tablet-and-mobile-inline-block"">
                                        <i class=""flaticon-more""></i>
         ");
            WriteLiteral(@"                           </a>

                                    <!--end::Topbar Toggler-->
                                </div>
                            </div>
                        </div>

                        <!-- end::Brand -->
              
                    </div>
                </div>
            </div>
            <div class=""m-header__bottom"">
                <div class=""m-container m-container--fluid m-container--full-height m-page__container"">
                    <div class=""m-stack m-stack--ver m-stack--desktop"">

                        <!-- begin::Horizontal Menu -->
                        <div class=""m-stack__item m-stack__item--fluid m-header-menu-wrapper"">
                            <button class=""m-aside-header-menu-mobile-close  m-aside-header-menu-mobile-close--skin-light "" id=""m_aside_header_menu_mobile_close_btn""><i class=""la la-close""></i></button>
                            <div id=""m_header_menu"" class=""m-header-menu m-aside-header-menu-mobile m");
            WriteLiteral(@"-aside-header-menu-mobile--offcanvas  m-header-menu--skin-dark m-header-menu--submenu-skin-light m-aside-header-menu-mobile--skin-light m-aside-header-menu-mobile--submenu-skin-light "">
                                <ul class=""m-menu__nav  m-menu__nav--submenu-arrow "">
                                    <li class=""m-menu__item  m-menu__item--active  m-menu__item--active-tab  m-menu__item--submenu m-menu__item--tabs"" m-menu-submenu-toggle=""tab"" aria-haspopup=""true"">
                                        <a href=""index.html"" class=""m-menu__link m-menu__toggle"">
                                            <span class=""m-menu__link-text"">Emre Crm</span><i class=""m-menu__hor-arrow la la-angle-down""></i><i class=""m-menu__ver-arrow la la-angle-right""></i>
                                        </a>
                                        <div class=""m-menu__submenu m-menu__submenu--classic m-menu__submenu--left m-menu__submenu--tabs"">
                                            <span class=""m-menu__arro");
            WriteLiteral("w m-menu__arrow--adjust\"></span>\r\n                                            <ul class=\"m-menu__subnav\">\r\n                                                <li");
            BeginWriteAttribute("class", " class=\"", 6873, "\"", 6965, 2);
            WriteAttributeValue("", 6881, "m-menu__item", 6881, 12, true);
#nullable restore
#line 115 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AdminUI\Views\Shared\_Layout.cshtml"
WriteAttributeValue(" ", 6893, currentAction.Equals("Index") ? "m-menu__item--active": string.Empty, 6894, 71, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" m-menu-link-redirect=""1"" aria-haspopup=""true""><a href=""/kullanicilar"" class=""m-menu__link ""><i class=""m-menu__link-icon flaticon-list""></i><span class=""m-menu__link-text"">Kullanıcı Listesi</span></a></li>
                                                <li");
            BeginWriteAttribute("class", " class=\"", 7224, "\"", 7319, 2);
            WriteAttributeValue("", 7232, "m-menu__item", 7232, 12, true);
#nullable restore
#line 116 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AdminUI\Views\Shared\_Layout.cshtml"
WriteAttributeValue(" ", 7244, currentAction.Equals("AddAgent") ? "m-menu__item--active": string.Empty, 7245, 74, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" aria-haspopup=""true""><a href=""/kullanici-ekle"" class=""m-menu__link ""><i class=""m-menu__link-icon flaticon-plus""></i><span class=""m-menu__link-text"">Yeni Ekle</span></a></li>
                                            </ul>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>

                        <!-- end::Horizontal Menu -->
                    </div>
                </div>
            </div>
        </header>

        <!-- end::Header -->
        <!-- begin::Body -->
        ");
#nullable restore
#line 132 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AdminUI\Views\Shared\_Layout.cshtml"
   Write(RenderBody());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

        <!-- end::Body -->

    </div>

    <!-- end:: Page -->
    <!-- begin::Scroll Top -->
    <div id=""m_scroll_top"" class=""m-scroll-top"">
        <i class=""la la-arrow-up""></i>
    </div>

    <!-- end::Scroll Top -->
    <!--begin::Global Theme Bundle -->
    <script src=""/vendors/base/vendors.bundle.js"" type=""text/javascript""></script>
    <script src=""/demo/demo8/base/scripts.bundle.js"" type=""text/javascript""></script>

    <!--end::Global Theme Bundle -->
    <!--begin::Page Vendors -->
    <script src=""/vendors/custom/fullcalendar/fullcalendar.bundle.js"" type=""text/javascript""></script>
    <script src=""/vendors/custom/mvc-grid/mvc-grid.js"" type=""text/javascript""></script>
    <script src=""/vendors/custom/file-uploader/js/fileinput.js"" type=""text/javascript""></script>
    <script src=""/vendors/custom/file-uploader/js/plugins/purify.js"" type=""text/javascript""></script>
    <script src=""/vendors/custom/file-uploader/js/plugins/sortable.js"" type=""text/javascript""></script>
  ");
            WriteLiteral(@"  <script src=""/vendors/custom/file-uploader/js/plugins/piexif.js"" type=""text/javascript""></script>
    <script src=""/vendors/custom/file-uploader/js/locales/tr.js"" type=""text/javascript""></script>
    <script src=""/vendors/custom/file-uploader/themes/explorer-fas/theme.js"" type=""text/javascript""></script>
    <script src=""/vendors/custom/jquery-validation/dist/jquery.validate.js"" type=""text/javascript""></script>
    <script src=""/vendors/custom/jquery-validation/dist/additional-methods.js"" type=""text/javascript""></script>
    <script src=""/vendors/custom/jquery-validation/dist/jquery.validate.unobtrusive.min.js"" type=""text/javascript""></script>

    <!--end::Page Vendors -->
    <!--begin::Page Scripts -->
    <script src=""/app/js/dashboard.js"" type=""text/javascript""></script>
    <script src=""/app/js/app.js"" type=""text/javascript""></script>
    ");
#nullable restore
#line 167 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AdminUI\Views\Shared\_Layout.cshtml"
Write(RenderSection("FooterScripts", false));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <!--end::Page Scripts -->
    <!-- begin::Page Loader -->
    <script>
        $(window).on('load', function () {
            $('body').removeClass('m-page--loading');
        });
    </script>

    <!-- end::Page Loader -->
</body>

<!-- end::Body -->
</html>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.Extensions.Options.IOptions<EmreCrm.Core.Models.AppSettings> _appSettings { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
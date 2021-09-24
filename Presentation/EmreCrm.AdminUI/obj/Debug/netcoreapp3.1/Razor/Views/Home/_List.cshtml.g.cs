#pragma checksum "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AdminUI\Views\Home\_List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2279db99287b78382f8de99211ebbd222c7376d7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__List), @"mvc.1.0.view", @"/Views/Home/_List.cshtml")]
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
#nullable restore
#line 2 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AdminUI\Views\Home\_List.cshtml"
using EmreCrm.Core.Helper;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2279db99287b78382f8de99211ebbd222c7376d7", @"/Views/Home/_List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85dd1bc91ff3d1b999c3035a3f180f70b3157034", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UserModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AdminUI\Views\Home\_List.cshtml"
Write(Html
    .Grid(Model)
    .Build(columns =>
    {
        columns.Add(model => model.Name).Css("align-middle");
        columns.Add(model => model.Surname).Css("align-middle");
        columns.Add(model => model.Email).Css("align-middle");
        columns.Add(model => model.Telephone).Css("align-middle");
        columns.Add().Titled("İşlem").Css("align-middle").Encoded(false).RenderedAs(model => GridHelper.HtmlGridActionsBuilder(id: model.Id, edit: true, editUrl: "/kullanici", delete: true, deleteUrl: "/kullanici-sil", deleteRedirectUrl: "", detail: false, detailUrl: ""));
    })
    .Id("UserList")
    .Empty("Sistemde kullanıcı bulunamadı")
    .Css("table table-striped- table-bordered table-hover table-checkable")
    .Sortable()
    .UsingProcessingMode(GridProcessingMode.Manual)
    .Pageable(pager =>
    {
        pager.RowsPerPage = 20;
        pager.ProcessorType = GridProcessorType.Pre;
        pager.TotalRows = ViewBag.TotalRows;
    })
);

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UserModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591

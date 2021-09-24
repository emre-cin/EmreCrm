#pragma checksum "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AgentUI\Views\Home\_List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "671243359ddc414914b36b2e4d6ed757d458356f"
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
#line 1 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AgentUI\Views\_ViewImports.cshtml"
using EmreCrm.AgentUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AgentUI\Views\_ViewImports.cshtml"
using EmreCrm.Model.DbEntity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AgentUI\Views\_ViewImports.cshtml"
using EmreCrm.Model.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AgentUI\Views\_ViewImports.cshtml"
using EmreCrm.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AgentUI\Views\_ViewImports.cshtml"
using NonFactors.Mvc.Grid;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AgentUI\Views\_ViewImports.cshtml"
using EmreCrm.AgentUI.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AgentUI\Views\Home\_List.cshtml"
using EmreCrm.Core.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AgentUI\Views\Home\_List.cshtml"
using EmreCrm.Model.Enum;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AgentUI\Views\Home\_List.cshtml"
using EmreCrm.Core.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"671243359ddc414914b36b2e4d6ed757d458356f", @"/Views/Home/_List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ccae07b7bbcb8fd95232c8010ee95ec58f85bf69", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AdvertisementModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\Emre\Desktop\Emre Crm\Presentation\EmreCrm.AgentUI\Views\Home\_List.cshtml"
Write(Html
    .Grid(Model)
    .Build(columns =>
    {
        columns.Add(model => model.NumberOfRooms).Css("align-middle");
        columns.Add(model => model.FloorNumber).Css("align-middle");
        columns.Add(model => model.HouseAge).Css("align-middle");
        columns.Add(model => model.Type).Css("align-middle").RenderedAs(model => ((HouseType)model.Type).GetEnumDescription());
        columns.Add(model => model.SquareMeters).Css("align-middle");
        columns.Add(model => model.Adress).Css("align-middle");
        columns.Add().Titled("İşlem").Css("align-middle").Encoded(false).RenderedAs(model => GridHelper.HtmlGridActionsBuilder(id: model.Id, edit: true, editUrl: "/ilan", delete: true, deleteUrl: "/ilan-sil", deleteRedirectUrl: "", detail: false, detailUrl: ""));
    })
    .Id("AdvertisementList")
    .Empty("Sistemde ilan bulunamadı")
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
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AdvertisementModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591

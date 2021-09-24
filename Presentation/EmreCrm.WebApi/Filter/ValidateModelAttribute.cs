using EmreCrm.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmreCrm.WebApi.Filter
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid == false)
            {
                ReturnModel<object> returnModel = new ReturnModel<object>()
                {
                    IsSuccess = false,
                    Message = "Model doğrulanamadı. Lütfen zorunlu alanları uygun şekilde doldurunuz",
                    Data = new BadRequestObjectResult(context.ModelState).Value,
                };

                context.Result = new BadRequestObjectResult(returnModel);
            };
        }
    }
}

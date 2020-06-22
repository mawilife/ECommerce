using ECommerce.Global;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Market.Api.Controllers
{
    public static class ControllerExtensions
    {

        public static ActionResult ToActionResult(this ControllerBase controller, Result<bool> result, ILogger logger)
        {
            if (result.Success)
                return controller.Ok();
            return ErrorResult(controller, result, logger);
        }

        public static ActionResult<T> ToActionResult<T>(this ControllerBase controller, Result<T> result, ILogger logger)
        {
            if (result.Success)
                return controller.Ok(result.Data);
            return ErrorResult(controller, result, logger);
        }

        private static ActionResult ErrorResult<T>(this ControllerBase controller, Result<T> result, ILogger logger)
        {
            if (result.FirstError?.Exception != null)
            {
                logger.LogError(result.FirstError.Exception, controller.RouteData.Values["Action"].ToString());
                return controller.StatusCode(500,result.FirstError.Exception.Message);
            }

            if (result.FirstError == Global.Error.NotFound)
                return controller.NotFound();

            return controller.StatusCode(401, result.FirstError);
        }
    }
}

using Api.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.CodeAnalysis;

namespace Api.DTOs
{
    /// <summary>
    /// Validate Model Filter
    /// </summary>
    /// <seealso cref="IActionFilter" />
    [ExcludeFromCodeCoverage]
    public class ValidateModelFilter : IActionFilter
    {
        /// <summary>
        /// Called before the action executes, after model binding is complete.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext" />.</param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.ToDictionary(
                    e => e.Key,
                    e => string.Join(", ", e.Value.Errors.Select(err => err.ErrorMessage))
                );

                var response = new CustomResponse<object>
                {
                    Status = "Error",
                    NotificationError = errors
                };

                context.Result = new ObjectResult(response)
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        /// <summary>
        /// Called after the action executes, before the action result.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext" />.</param>
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}

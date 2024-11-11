using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics.CodeAnalysis;

namespace Api.Extentions
{
    /// <summary>
    /// Classe responsavel por padronizar o response dos endpoints
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ResponsesExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controller"></param>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static IActionResult Success<T>(this ControllerBase controller, T data, int code = 200)
        {
            var response = new CustomResponse<T>
            {
                Status = "Success",
                Data = data,
                NotificationError = null
            };
            return controller.StatusCode(code, response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="modelStateDictionary"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static IActionResult Error(this ControllerBase controller, ModelStateDictionary modelStateDictionary, int code = 400)
        {
            var errors = modelStateDictionary.ToDictionary(
                e => e.Key,
                e => string.Join(", ", e.Value.Errors.Select(err => err.ErrorMessage))
            );

            var response = new CustomResponse<object>
            {
                Status = "Error",
                Data = null,
                NotificationError = errors
            };
            return controller.StatusCode(code, response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="messageError"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static IActionResult Error(this ControllerBase controller, Dictionary<string, string> messageError, int code = 400)
        {
            var response = new CustomResponse<object>
            {
                Status = "Error",
                Data = null,
                NotificationError = messageError
            };
            return controller.StatusCode(code, response);
        }
    }

    /// <summary>
    /// Classe responsavel por personalizar os atributos de response
    /// </summary>
    /// <typeparam name="T">Define a saida</typeparam>
    public class CustomResponse<T>
    {
        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Dados de saída
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Notificacao de Error
        /// </summary>
        public Dictionary<string, string> NotificationError { get; set; }
    }
}

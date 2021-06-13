using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Hamporsesh.Web.Extensions
{
    public static class Utilities
    {

        public static string GetModelStateErrors(ModelStateDictionary modelState)
        {
            var errors = "";
            foreach (var item in modelState.Values)
            {
                foreach (var error in item.Errors)
                {
                    errors = errors + "</br>" + error.ErrorMessage;
                }
            }

            return errors;
        }



        public static string GetIdentityErrors(IdentityResult result)
        {
            var errors = "";
            foreach (var error in result.Errors)
            {
                errors = errors + "</br>" + error.Description;
            }

            return errors;

        }


        public static void AddIdentityErrorsToModelState(ModelStateDictionary modelState, IdentityResult result)
        {
            foreach (var error in result.Errors)
            {

                modelState.AddModelError("", error.Description);
            }

        }
    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace EmployeeServer.Extensions{
public static class ModelStateExtensions
{
    public static Dictionary<string, string[]> ToValidationErrors(this ModelStateDictionary modelState)
    {
        return modelState
            .Where(kvp => {
                var errors = kvp.Value?.Errors;
                if(errors == null) return false;
                if(errors.Count > 0) return true;
                return false;
            })
            .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray() ?? []
            );
    }
}
}
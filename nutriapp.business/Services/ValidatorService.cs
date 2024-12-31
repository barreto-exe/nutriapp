using nutriapp.business.Base;

namespace nutriapp.business.Services;

public static class ValidatorService
{
    public static void AddValidationMessages<T>(this T response, List<(bool, string)> validationsWithMessage) where T : BaseCommandResponse
    {
        var messages = new List<string>();

        foreach (var (isFailed, message) in validationsWithMessage)
        {
            if (isFailed)
            {
                response.Success = false;
                messages.Add(message);
            }
        }

        if (!response.Success)
        {
            response.Message = string.Join("; ", messages);
        }
    }
}
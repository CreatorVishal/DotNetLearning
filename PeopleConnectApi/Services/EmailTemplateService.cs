using PeopleConnectApi.Interface;
using Razor.Templating.Core;

namespace PeopleConnectApi.Services
{
    public class EmailTemplateService : IEmailTemplateService
    {
        public async Task<string> RenderTemplateAsync<TModel>(TModel model)
        {
            var templatePath = "EmailTemplates/EmailConfirmation.cshtml";

            return await RazorTemplateEngine.RenderAsync(templatePath,model);
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;

using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using PeopleConnectApi.Interface;
namespace PeopleConnectApi.Services
{
    public class EmailTemplateService : IEmailTemplateService
    {
        private readonly IRazorViewEngine _viewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IServiceProvider _serviceProvider;
        private readonly IWebHostEnvironment _environment;

        public EmailTemplateService(
            IRazorViewEngine viewEngine,
            ITempDataProvider tempDataProvider,
            IServiceProvider serviceProvider,
            IWebHostEnvironment environment)
        {
            _viewEngine = viewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
            _environment = environment;
        }

        public async Task<string> RenderTemplateAsync<TModel>(
            string templateName,
            TModel model)
        {
            var templatePath = Path.Combine(
                _environment.ContentRootPath,
                "EmailTemplates",
                $"{templateName}.cshtml");

            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException(
                    $"Email template not found: {templatePath}");
            }

            var httpContext =
                new DefaultHttpContext
                {
                    RequestServices = _serviceProvider
                };

            var actionContext = new ActionContext(
                httpContext,
                new RouteData(),
                new ActionDescriptor());

            await using var sw = new StringWriter();

            var viewResult = _viewEngine.GetView(
                executingFilePath: null,
                viewPath: $"/EmailTemplates/{templateName}.cshtml",
                isMainPage: true);

            if (!viewResult.Success)
            {
                throw new InvalidOperationException(
                    $"Could not find email template: {templateName}");
            }

            var viewDictionary = new ViewDataDictionary<TModel>(
                new EmptyModelMetadataProvider(),
                new ModelStateDictionary())
            {
                Model = model
            };

            var viewContext = new Microsoft.AspNetCore.Mvc.Rendering.ViewContext(
                actionContext,
                viewResult.View,
                viewDictionary,
                new TempDataDictionary(
                    httpContext,
                    _tempDataProvider),
                sw,
                new HtmlHelperOptions());

            await viewResult.View.RenderAsync(viewContext);

            return sw.ToString();
        }
    }
}
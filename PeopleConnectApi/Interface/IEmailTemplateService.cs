namespace PeopleConnectApi.Interface
{
    public interface IEmailTemplateService
    {
        Task<string> RenderTemplateAsync<TModel>(string templateName,TModel model);
    }
}
namespace PeopleConnectApi.Interface
{
    public interface IEmailTemplateService
    {
        Task<string> RenderTemplateAsync<TModel>(TModel model);
    }
}
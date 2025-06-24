namespace Task.Services.Abstracts
{
    public interface IUserServices
    {
        System.Threading.Tasks.Task<string> GetEmailByIdAsync(string id);
    }
}

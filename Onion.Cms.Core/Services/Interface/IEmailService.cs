using System.Threading.Tasks;

namespace Onion.Cms.ApplicationServices.Services.Interface
{
    public interface IEmailService
    {
        Task Execute(string userEmail, string body, string subject);
    }
}
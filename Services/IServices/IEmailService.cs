using SKL.Models;
using SKL.Services;

namespace SKL.Services.IServices
{
    public interface IEmailService
    {
        Task SendEmailAsync(Mailrequest mailrequest);

    }
}

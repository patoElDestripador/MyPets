using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace MyPets.Services.ExternalApis
{
    public class MailSenderApiService : IMailSenderApiService
    {
        private readonly HttpClient _client;
        private readonly string _urlExternalApi;
        private readonly string _tokenExternalApi;

        public MailSenderApiService(HttpClient client)
        {
            _client = client;
            _urlExternalApi = "https://api.mailersend.com/v1/email";
            _tokenExternalApi = "mlsn.93ffba79a025be9c7aee7116b896c10df1b008637112aaa0a0e870a4ac31a0c8";

        }

        public async Task<bool> SendMailAsync(string toemail, int quoteId, string ownerName, string dateAssgined, string hourAssigned)
        {

            try
            {
                var body = new
                {
                    from = new { email = "MS_qbbOfv@trial-yzkq340okp04d796.mlsender.net" },
                    to = new[] { new { email = toemail } },
                    subject = "Nueva Cita asignada",
                    variables = new[] { new { email = toemail,substitutions = new[] {
                        new { var = "Id", value = $"{quoteId}" },
                        new { var = "OwnerName", value = ownerName },
                        new { var = "AssignedDate", value = dateAssgined },
                        new { var = "AssignedHour", value = hourAssigned }
                    }}},
                    template_id = "0r83ql3x0yzlzw1j"
                };
                var jsonBody = System.Text.Json.JsonSerializer.Serialize(body);

                var request = new HttpRequestMessage(HttpMethod.Post, _urlExternalApi)
                {
                    Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
                };
                request.Headers.Add("Authorization", $"Bearer {_tokenExternalApi}");

                HttpResponseMessage response = await _client.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException(e.Message);
            }
        }
    }
}
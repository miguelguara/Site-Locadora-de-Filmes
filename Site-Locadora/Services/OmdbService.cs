using Site_Locadora.Models;

namespace Site_Locadora.Services
{
    public class OmdbService
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public OmdbService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _apiKey = config["OMDb:ApiKey"];      // pegar do appsettings.json
            _baseUrl = config["OMDb:BaseUrl"];    // normalmente http://www.omdbapi.com/
        }

        public async Task<Filme?> GetFilmeByTitleAsync(string titulo)
        {
            if (string.IsNullOrEmpty(titulo))
                return null;

            var url = $"{_baseUrl}?t={Uri.EscapeDataString(titulo)}&apikey={_apiKey}";
            try
            {
                var response = await _http.GetFromJsonAsync<OmdbResponse>(url);

                if (response == null || response.Response == "False")
                    return null;

                // Mapear para nosso modelo Filme
                return new Filme
                {
                    Titulo = response.Title,
                    Ano = response.Year,
                    Diretor = response.Director,
                    Genero = response.Genre,
                    Poster = response.Poster,
                    ImdbID = response.ImdbID
                };
            }
            catch
            {
                return null;
            }
        }

        // Classe interna para receber resposta da OMDb
        private class OmdbResponse
        {
            public string Title { get; set; }
            public string Year { get; set; }
            public string Director { get; set; }
            public string Genre { get; set; }
            public string Poster { get; set; }
            public string ImdbID { get; set; }
            public string Response { get; set; }
        }
    }
}

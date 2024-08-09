using Desafio_Blip.Repositories.Interfaces;
using static System.Reflection.Metadata.BlobBuilder;
using System.Text.Json;
using Desafio_Blip.Models;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json.Serialization;

namespace Desafio_Blip.Repositories
{
    public class RepositoryRepository: IRepositoryRepository
    {
        private readonly HttpClient HttpClient;
        private const string gitURL = "https://api.github.com/orgs/takenet/repos?language=c#";
        private readonly string token = "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";
        public async Task<List<Repository>> FindRepository() {
            List<Repository> repositorylist = new List<Repository>();
            var request = new HttpRequestMessage(HttpMethod.Get, gitURL);
          
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await HttpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStreamAsync();
            var responseDeserialized = await JsonSerializer.DeserializeAsync<Repository>(content);
            repositorylist.Add(responseDeserialized);
            return repositorylist;
        }
    }
}

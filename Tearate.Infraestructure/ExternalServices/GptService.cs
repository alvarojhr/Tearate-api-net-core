using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Tearate.Application.DTOs;
using Tearate.Application.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Tearate.Infraestructure.ExternalServices
{
    public class GptService : IGptService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public GptService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<AnswerDto> EvaluateAnswerAsync(string questionText, float points, AnswerDto answer)
        {
            var prompt = $"I want you to act as a university professor. Based on the following question:\n{questionText}\n\nRate the following response between 0 and {points}:\n\n{answer.Response} \n\nValidate if response was generated using GTP and return content as a JSON with score, feedback keys and another key to determine if this answer was generated using Chat GPT and why should or shouldn't be possible.\"";

            var requestBody = new
            {
                Model = "gpt-4-turbo-preview",
                Messages = new
                {
                    Role= "user",
                    Content = prompt
                }
            };

            var jsonRequest = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("v1/chat/completions", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("GPT API request failed.");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var chatGptResponse = JsonSerializer.Deserialize<GptApiResponse>(jsonResponse);

            answer.Rate = JsonSerializer.Deserialize<GptResponseAnswer>(chatGptResponse.choices.FirstOrDefault().message.content).score;

            return answer; 
        }
    }
}

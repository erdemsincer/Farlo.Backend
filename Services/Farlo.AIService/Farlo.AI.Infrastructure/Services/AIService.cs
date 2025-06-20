﻿using Farlo.AI.Application.Interfaces;
using Farlo.AI.Infrastructure.Settings;
using Farlo.EventContracts.Geo;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Farlo.AI.Infrastructure.Services;

public class AIService : IAIService
{
    private readonly HttpClient _httpClient;
    private readonly OpenAISettings _settings;

    public AIService(IOptions<OpenAISettings> options)
    {
        _httpClient = new HttpClient();
        _settings = options.Value;
    }

    public async Task<string> GenerateInsightAsync(GeoQueryCompletedEvent data)
    {
        var prompt = $"""
        Aşağıdaki bilgiler bir bölgeye aittir:
        - İklim: {data.Climate}
        - Bitki örtüsü: {data.Vegetation}
        - Yükseklik: {data.Elevation}

        Bu verilere dayanarak, bu bölge hakkında 1 paragraf anlamlı, açıklayıcı ve bilgilendirici bir coğrafi analiz oluştur.
        """;

        return await SendToOpenAIAsync(prompt);
    }

    public async Task<string> GenerateCultureInsightAsync(GeoQueryCompletedEvent data)
    {
        var prompt = $"""
    Aşağıdaki veriler bir bölgeye aittir:
    - İklim: {data.Climate}
    - Bitki örtüsü: {data.Vegetation}
    - Rakım: {data.Elevation}
    - Koordinatlar: ({data.Latitude}, {data.Longitude})

    Bu koordinatlara en yakın şehri belirt. 
    Ardından bu şehrin veya bölgenin kültürel özelliklerini anlatan, özgün ve açıklayıcı bir metin oluştur. 
    Metin şu unsurları içermeli:
    - Yerleşim tipi (köy, kasaba, şehir vb.)
    - Yaşam tarzı ve gelenekler
    - Mimarî özellikler (ev tipi, yapı malzemesi vs.)
    - Yerel festivaller, halk oyunları, geleneksel etkinlikler
    - Öne çıkan kültürel miraslar veya tarihsel izler
    - Gezilecek yerler ve doğal güzellikler

    İçerik Türkçe olmalı ve akıcı bir anlatıma sahip olmalı. 
    Paragrafın sonunda bir cümleyle bu bölgenin kültürel olarak neden önemli olduğunu özetle.
    """;

        return await SendToOpenAIAsync(prompt);
    }


    private async Task<string> SendToOpenAIAsync(string prompt)
    {
        var requestBody = new
        {
            model = _settings.Model,
            messages = new[]
            {
                new { role = "system", content = "Sen uzman bir coğrafya ve kültür danışmanı bir AI'sın." },
                new { role = "user", content = prompt }
            }
        };

        var json = JsonSerializer.Serialize(requestBody);
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _settings.ApiKey);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        using var responseStream = await response.Content.ReadAsStreamAsync();
        using var doc = await JsonDocument.ParseAsync(responseStream);

        var content = doc.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        return content ?? "AI yanıtı boş döndü.";
    }
}

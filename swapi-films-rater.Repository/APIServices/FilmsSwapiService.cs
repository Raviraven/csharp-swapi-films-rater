﻿using swapi_films_rater.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace swapi_films_rater.Repository.APIServices
{
    public class FilmsSwapiService : IFilmsSwapiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FilmsSwapiService(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public async Task<FilmsContainer> Get()
        {
            try
            {
                using (var client = _httpClientFactory.CreateClient("swapi"))
                {
                    string path = $"{client.BaseAddress.AbsoluteUri}/films/";
                    using (var response = await client.GetAsync(path))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (var stream = await response.Content.ReadAsStreamAsync())
                            {
                                return await System.Text.Json.JsonSerializer.DeserializeAsync<FilmsContainer>
                                    (stream, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true, IgnoreNullValues = true });
                            }
                        }
                        else
                        {
                            return new FilmsContainer();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Film> Get(int Id)
        {
            string url = $"https://swapi.dev/api/films/{Id}/";
            return await getByUrl(url);
        }

        private async Task<Film> getByUrl(string url)
        {
            try
            {
                using (var client = _httpClientFactory.CreateClient())
                {
                    using (var response = await client.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (var stream = await response.Content.ReadAsStreamAsync())
                            {
                                return await System.Text.Json.JsonSerializer.DeserializeAsync<Film>
                                    (stream, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true, IgnoreNullValues = true });
                            }
                        }
                        else
                        {
                            return new Film();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

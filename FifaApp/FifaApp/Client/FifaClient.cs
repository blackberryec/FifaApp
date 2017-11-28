﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FifaApp.Models;

namespace FifaApp.Client
{
    public class FifaClient
    {
        //Ap dung mvvm dang ki ben App.xaml.cs
        //private static FifaClient _current;

        //public static FifaClient Current => _current ?? (_current = new FifaClient());

        private RESTfulService _restfulService;

        public RESTfulService RESTfulService => _restfulService ?? (_restfulService = new RESTfulService());


        private const string Host = "http://live.mobileapp.fifa.com/api/";

        public Task<ApiResponse<Index>> CurrentAsync()
        {
            var api = Host + $"mc/current";
            return RESTfulService.GetAsync<Index>(api);
        }

        public Task<ApiResponse<Index>> CurrentAsync(int page, int limit)
        {
            var api = Host + $"mc/current?page={page}&limit={limit}";
            return RESTfulService.GetAsync<Index>(api);
        }
        public Task<ApiResponse<CompetitionDetail>> CompetitionAsync(string id)
        {
            var api = Host + "mc/competition/" + id;
            return RESTfulService.GetAsync<CompetitionDetail>(api);
        }
        public Task<ApiResponse<MatchDetail>> MatchAsync(string id)
        {
            var api = Host + "mc/match/" + id;
            return RESTfulService.GetAsync<MatchDetail>(api);
        }
        public Task<ApiResponse<TeamDetail>> TeamAsync(string id)
        {
            var api = Host + "mc/team/" + id;
            return RESTfulService.GetAsync<TeamDetail>(api);
        }
    }
}

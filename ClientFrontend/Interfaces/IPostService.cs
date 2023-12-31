﻿using APIClient.Models;

namespace ClientFrontend.Interfaces;

public interface IPostService
{
    Task<HttpResponseMessage> CreatePost(CreatePost dto);
}
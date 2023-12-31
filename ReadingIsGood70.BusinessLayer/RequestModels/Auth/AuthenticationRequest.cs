﻿using System;
using System.Text.Json.Serialization;
using ReadingIsGood70.BusinessLayer.RequestModels.Base;
using ReadingIsGood70.BusinessLayer.Exceptions;

namespace ReadingIsGood70.BusinessLayer.RequestModels.Auth
{
    public class AuthenticationRequest : Request
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        public override void ValidateAndThrow()
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                throw new RequestParameterException("email");
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                throw new RequestParameterException("password");
            }
        }
    }
}
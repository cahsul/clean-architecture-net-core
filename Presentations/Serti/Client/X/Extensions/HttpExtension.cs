using Microsoft.AspNetCore.Components;
using Shared.Identity.Commands.RefreshToken;
using Shared.Identity.Queries.GetToken;
using Shared.Identity.Resources;
using Shared.X.Enums;
using Shared.X.Extensions;
using Shared.X.Requests;
using Shared.X.Responses;
using Toastr;

namespace Serti.Client.X.Extensions
{
    public static class HttpExtension
    {

        private static ToastrService _toastrService;
        private static HttpClient _client;
        private static Appsettings _appsettings;
        private static NavigationManager _navigationManager;

        public static void HttpExtensionConfigure(ToastrService toastrService, HttpClient client, Appsettings appsettings, NavigationManager navigationManager)
        {
            _toastrService = toastrService;
            _client = client;
            _appsettings = appsettings;
            _navigationManager = navigationManager;
        }

        public static async Task<ResponseBuilder<T>> PostAsync<T>(this BaseRequest dataToSend, string url)
        {
            return await SendAsync<T>(dataToSend, url, HttpMethod.Post);
        }

        public static async Task<ResponseBuilder<T>> PutAsync<T>(this BaseRequest dataToSend, string url)
        {
            return await SendAsync<T>(dataToSend, url, HttpMethod.Put);
        }

        public static async Task<ResponseBuilder<T>> PutWithFile<T>(this BaseRequest dataToSend, string url, MultipartFormDataContent multipartForm)
        {
            return await SendWithFile<T>(dataToSend, url, HttpMethod.Put, multipartForm);
        }

        public static async Task<ResponseBuilder<T>> GetAsync<T>(this BaseRequest dataToSend, string url)
        {
            var result = new ResponseBuilder<T>();
            var token = await GetToken();

            try
            { // first trial. 
                result = await SendAsync<T>(dataToSend, url, HttpMethod.Get, token: token);
                return result;
            }
            catch (UnauthorizedAccessException ex)
            { // second trial : if the previouse failed, refresh token and try again
                await RefreshToken(token);
                token = await GetToken();
                result = await SendAsync<T>(dataToSend, url, HttpMethod.Get, false, token);
                return result;
            }

        }


        public static async Task<ResponseBuilder<T>> DeleteAsync<T>(this BaseRequest dataToSend, string url)
        {
            return await SendAsync<T>(dataToSend, url, HttpMethod.Delete);
        }

        private static async Task<ResponseBuilder<T>> SendAsync<T>(BaseRequest dataToSend, string url, HttpMethod httpMethod, bool firstTry = true, GetTokenResponse token = null)
        {
            var toastrOptions = new ToastrOptions
            {
                CloseButton = true,
                ShowDuration = 0,
                HideDuration = 500,
                TimeOut = 5000,
                ExtendedTimeOut = 1000,
                HideMethod = ToastrHideMethod.SlideUp,
                ShowMethod = ToastrShowMethod.SlideDown,
                Position = ToastrPosition.TopRight,
                ShowProgressBar = true,
            };

            HttpContent httpContent = dataToSend.ToJson().HttpStringContentJson();

            try
            {
                var request = new HttpRequestMessage(httpMethod, url);
                //request.Headers.Add("Accept-Language", "id-ID");
                //request.Headers.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJFbWFpbCI6ImFAYS5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjE4MGM2M2UxLTY3ZTAtNGRhNS1hM2UyLTk1MDczM2ZlOTllYiIsIk1lbnVBY2Nlc3MiOlsiVG9kby5MaXN0IiwiVG9kby5DcmVhdGUiLCJUb2RvLkRlbGV0ZSJdLCJleHAiOjE2MzYyOTgzMzYsImlzcyI6Imlzc3VlciIsImF1ZCI6ImF1ZGllbmNlIn0.e9H_6WzjS9wpI8fLiq7sgf2LlMqll8JfWtU2AZiqXik");
                //if (token != null)
                //{
                //    request.Headers.Add("Authorization", @$"Bearer {token.JwtToken}");
                //}

                if (httpMethod != HttpMethod.Get)
                {
                    request.Content = httpContent;
                }

                var response = await _client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                var contentObject = content.ToJsonDeserialize<ResponseBuilder<T>>();

                // belum login
                if (contentObject?.IsError == true && contentObject?.ErrorType == ErrorType.Unauthenticated.GetDescription())
                {
                    _navigationManager.NavigateTo("/login");
                }

                // Unauthorized
                if (contentObject?.IsError == true && contentObject?.ErrorType == ErrorType.UnauthorizedAccess.GetDescription() && contentObject?.ErrorsMessage?.Count > 0)
                {
                    // if not login, throw error 
                    if (contentObject.ErrorsMessage.Contains("Current User is not authenticated.") && firstTry == true)
                    {
                        throw new UnauthorizedAccessException("Current User is not authenticated."); // TODO : hardcode
                    }

                    // show error message
                    toastrOptions.Position = ToastrPosition.TopFullWidth;
                    toastrOptions.TimeOut = 0;
                    toastrOptions.ExtendedTimeOut = 0;
                    await _toastrService.Error(contentObject.ErrorsMessage.ToString("<br/><br/>"), toastrOptions);
                    return contentObject;
                }

                // return error karena validation
                if (contentObject?.IsError == true && contentObject?.ErrorType == ErrorType.Validation.GetDescription() && contentObject?.ErrorsMessage?.Count > 0)
                {
                    await _toastrService.Error(contentObject.ErrorsMessage.ToString("<br/>"), toastrOptions);
                    return contentObject;
                }

                // return error because bad request
                if (contentObject?.IsError == true && contentObject?.ErrorType == ErrorType.BadRequest.GetDescription() && contentObject?.ErrorsMessage?.Count > 0)
                {
                    await _toastrService.Error(contentObject.ErrorsMessage.ToString("<br/>"), toastrOptions);
                    return contentObject;
                }


                // return error tidak diketahui
                if (contentObject?.IsError == true && contentObject?.ErrorType == ErrorType.Unknown.GetDescription())
                {
                    toastrOptions.Position = ToastrPosition.TopFullWidth;
                    await _toastrService.Error(contentObject.ErrorsMessage.ToString("<br/><br/>"), toastrOptions);
                    return contentObject;
                }




                //if (!response.IsSuccessStatusCode)
                //{
                //    await _toastrService.Error("Gagal Menyimpan Data..", toastrOptions);
                //    return contentObject;
                //}

                return contentObject;
            }
            catch (UnauthorizedAccessException exUn)
            {
                throw exUn;
            }
            catch (Exception ex)
            {
                toastrOptions.Position = ToastrPosition.TopFullWidth;
                await _toastrService.Error(ex.Message.Trim().Count() == 0 ? "" : ex.Message, toastrOptions);
                return default;
            }

        }


        private static async Task<ResponseBuilder<T>> SendWithFile<T>(BaseRequest dataToSend, string url, HttpMethod httpMethod, MultipartFormDataContent multipartForm)
        {
            var toastrOptions = new ToastrOptions
            {
                CloseButton = true,
                ShowDuration = 0,
                HideDuration = 0,
                TimeOut = 0,
                ExtendedTimeOut = 0,
                HideMethod = ToastrHideMethod.SlideUp,
                ShowMethod = ToastrShowMethod.SlideDown,
                Position = ToastrPosition.TopRight
            };

            try
            {
                using var formData = new MultipartFormDataContent();
                var request = new HttpRequestMessage(httpMethod, url);


                request.Headers.Add("Accept-Language", "id-ID");
                if (httpMethod != HttpMethod.Get)
                {
                    request.Content = multipartForm;
                }

                var response = await _client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                var contentObject = content.ToJsonDeserialize<ResponseBuilder<T>>();


                // return error karena validation
                if (contentObject?.IsError == true && contentObject?.ErrorType == ErrorType.Validation.GetDescription() && contentObject?.ErrorsMessage?.Count > 0)
                {
                    await _toastrService.Error(contentObject.ErrorsMessage.ToString("<br/>"), toastrOptions);
                    return contentObject;
                }

                // return error tidak diketahui
                if (contentObject?.IsError == true && contentObject?.ErrorType == ErrorType.Unknown.GetDescription())
                {
                    toastrOptions.Position = ToastrPosition.TopFullWidth;
                    await _toastrService.Error(contentObject.ErrorsMessage.ToString("<br/><br/>"), toastrOptions);
                    return contentObject;
                }


                return contentObject;
            }
            catch (Exception ex)
            {
                toastrOptions.Position = ToastrPosition.TopFullWidth;
                await _toastrService.Error(ex.Message, toastrOptions);
                return default;
            }

        }

        private static async Task RefreshToken(GetTokenResponse token)
        {

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"{IdentityEndpoint.Identity.RefreshToken}")
                {
                    Content = new RefreshTokenRequest
                    {
                        UserId = "180c63e1-67e0-4da5-a3e2-950733fe99eb",
                        JwtToken = token.JwtToken,
                        RefreshToken = token.RefreshToken,
                    }.ToJson().HttpStringContentJson()
                };
                var response = await _client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                var contentObject = content.ToJsonDeserialize<ResponseBuilder<RefreshTokenResponse>>();

                if (contentObject.IsError)
                {
                    //RedirectTo("/FetchData");
                    _navigationManager.NavigateTo("/login");
                }


            }
            catch (Exception ex)
            {

            }
        }

        private static async Task<GetTokenResponse> GetToken()
        {

            var request = new HttpRequestMessage(HttpMethod.Post, $"{IdentityEndpoint.Identity.GetToken}")
            { };
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var contentObject = content.ToJsonDeserialize<ResponseBuilder<GetTokenResponse>>();
            return contentObject.Data;
        }
    }
}

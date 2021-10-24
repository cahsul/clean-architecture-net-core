using Shared.X.Enums;
using Shared.X.Extensions;
using Shared.X.Requests;
using Shared.X.Responses;
using Toastr;

namespace Client.X.Extensions
{
    public static class HttpExtension
    {

        private static ToastrService _toastrService;
        private static HttpClient _client;
        public static void HttpExtensionConfigure(ToastrService toastrService, HttpClient client)
        {
            _toastrService = toastrService;
            _client = client;
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
            return await SendAsync<T>(dataToSend, url, HttpMethod.Get);
        }


        public static async Task<ResponseBuilder<T>> DeleteAsync<T>(this BaseRequest dataToSend, string url)
        {
            return await SendAsync<T>(dataToSend, url, HttpMethod.Delete);
        }

        private static async Task<ResponseBuilder<T>> SendAsync<T>(BaseRequest dataToSend, string url, HttpMethod httpMethod)
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

            HttpContent httpContent = dataToSend.JsonSerialize().HttpStringContentJson();

            try
            {
                var request = new HttpRequestMessage(httpMethod, url);
                request.Headers.Add("Accept-Language", "id-ID");
                if (httpMethod != HttpMethod.Get)
                {
                    request.Content = httpContent;
                }

                var response = await _client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                var contentObject = content.JsonDeserialize<ResponseBuilder<T>>();


                // return error karena validation
                if (contentObject?.IsError == true && contentObject?.ErrorType == ErrorType.Validation && contentObject?.ErrorsMessage?.Count > 0)
                {
                    await _toastrService.Error(contentObject.ErrorsMessage.ToString("<br/>"), toastrOptions);
                    return contentObject;
                }

                // return error tidak diketahui
                if (contentObject?.IsError == true && contentObject?.ErrorType == ErrorType.Unknown)
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
            catch (Exception ex)
            {
                toastrOptions.Position = ToastrPosition.TopFullWidth;
                await _toastrService.Error(ex.Message, toastrOptions);
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
                var contentObject = content.JsonDeserialize<ResponseBuilder<T>>();


                // return error karena validation
                if (contentObject?.IsError == true && contentObject?.ErrorType == ErrorType.Validation && contentObject?.ErrorsMessage?.Count > 0)
                {
                    await _toastrService.Error(contentObject.ErrorsMessage.ToString("<br/>"), toastrOptions);
                    return contentObject;
                }

                // return error tidak diketahui
                if (contentObject?.IsError == true && contentObject?.ErrorType == ErrorType.Unknown)
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

    }
}

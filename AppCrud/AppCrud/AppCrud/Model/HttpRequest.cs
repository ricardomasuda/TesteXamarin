using AppCrud.View.PopUp;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static AppCrud.Model.Request;

namespace AppCrud.Model
{
    class HttpRequest<Request>
    {
        public class ApiResponse
        {
            public string Status { get; set; }
            public List<Object> Conteudo { get; set; }
        }

        const string URL = "https://localhost:44381/api/";
        public static async Task<ApiResponse> PostAsync(Request _requisicao, Page _page = null)
        {
            var _load = new LoadPage();
            ApiResponse _return;
            if (_page != null)
                await _page.Navigation.PushPopupAsync(_load);
            try
            {
                var _json = JsonConvert.SerializeObject(_requisicao);
                var _url = URL + ((IRequest)_requisicao).Action;

                HttpClient _client = new HttpClient();
                _client.Timeout = new TimeSpan(0, 0, 15);

                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applcation/json"));

                HttpResponseMessage _result = null;
                if (_requisicao != null)
                {
                    var _content = new StringContent(_json, Encoding.UTF8, "application/json");
                    Debug.WriteLine("--------INICIO-----------");

                    Debug.WriteLine(_json);
                    _result = await _client.PostAsync(_url, _content);
                }

                //var _content = new StringContent(_json, Encoding.UTF8, "application/json");
                //var _result = await _client.PostAsync(_url, _content);

                var _jsonResposta = _result.Content.ReadAsStringAsync().Result;

                Debug.WriteLine("--------fim-----------");
                Debug.WriteLine(_jsonResposta);

                _return = JsonConvert.DeserializeObject<ApiResponse>(_jsonResposta);
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp);
                _return = default(ApiResponse);
            }
            if (_page != null)
                _load.Close();
            return _return;
        }
        public static async Task<ApiResponse> GetAsync(Request _requisicao, Page _page = null)
        {
            ApiResponse _return;
            var _load = new LoadPage();
            if (_page != null)
                await _page.Navigation.PushPopupAsync(_load);
            try
            {
                var _url = URL + ((IRequest)_requisicao).Action;

                HttpClient _client = new HttpClient();
                _client.Timeout = new TimeSpan(0, 0, 15);

                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applcation/json"));

                HttpResponseMessage _result = null;
                if (_requisicao != null)
                {
                    // var _content = new StringContent( Encoding.UTF8, "application/json");
                    //  Debug.WriteLine("--------INICIO-----------");
                    _result = await _client.GetAsync(_url);
                }
                var _jsonResposta = _result.Content.ReadAsStringAsync().Result;

                Debug.WriteLine("--------fim-----------");
                Debug.WriteLine(_jsonResposta);

                _return = JsonConvert.DeserializeObject<ApiResponse>(_jsonResposta);
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp);
                _return = default(ApiResponse);
            }
            if (_page != null)
                _load.Close();
            return _return;
        }

    }
}

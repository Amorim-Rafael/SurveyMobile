using Newtonsoft.Json;
using SurveyMobile.PCL.BusinessLayer.Model;
using SurveyMobile.PCL.ServiceAccessLayer.Interface;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace SurveyMobile.PCL.ServiceAccessLayer
{
    public class ServiceWrapper : IServiceWrapper
    {
        public async Task<TokenModel> GetAuthorizationTokenTask(UserLoginModel loginModel)
        {
            using (var client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", loginModel.Username),
                    new KeyValuePair<string, string>("password", loginModel.Password)
                });

                var postResponse = await client.PostAsync("http://surveyonline.azurewebsites.net/webapi/servicos/token", formContent);
                postResponse.EnsureSuccessStatusCode();

                string response = await postResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TokenModel>(response);
            }
        }

        public TokenModel GetAuthorizationToken(UserLoginModel loginModel)
        {
            HttpClient client = new HttpClient();
            var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", loginModel.Username),
                    new KeyValuePair<string, string>("password", loginModel.Password)
                });
            var postResponde = client.PostAsync("http://surveyonline.azurewebsites.net/webapi/servicos/token", formContent).Result;
            
            string response = postResponde.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TokenModel>(response);
        }

        public async Task<bool> ValidateUser(UserLoginModel loginModel, string authenticationToken)
        {
            if (!loginModel.IsValid())
            {
                return false;
            }

            using (var client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Username", loginModel.Username),
                    new KeyValuePair<string, string>("Password", loginModel.Password)
                });

                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + authenticationToken);
                var postResponse = await client.PostAsync("http://resz.azurewebsites.net/User/ValidateUser", formContent);
                postResponse.EnsureSuccessStatusCode();

                string response = await postResponse.Content.ReadAsStringAsync();
                return response.Equals("true");
            }
        }

        public async Task<string> RegisterUser(UserLoginModel loginModel, string authenticationToken)
        {
            if (!loginModel.IsValid())
            {
                return "invalid_model";
            }

            using (var client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Username", loginModel.Username),
                    new KeyValuePair<string, string>("Password", loginModel.Password)
                });

                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + authenticationToken);
                var postResponse = await client.PostAsync("http://resz.azurewebsites.net/User/createUser", formContent);
                postResponse.EnsureSuccessStatusCode();

                return await postResponse.Content.ReadAsStringAsync();
            }
        }

        public async Task<List<Pesquisa>> DespesasPorPesquisaAsync()
        {
            using (var client = new HttpClient())
            {
                var getResponse = await client.GetAsync("http://surveyonline.azurewebsites.net/webapi/servicos/DespesasPorPesquisa");
                getResponse.EnsureSuccessStatusCode();

                string response = await getResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Pesquisa>>(response);
            }
        }

        public List<Pesquisa> DespesasPorPesquisa()
        {
            HttpClient client = new HttpClient();

            var getResponse = client.GetAsync("http://surveyonline.azurewebsites.net/webapi/servicos/DespesasPorPesquisa").Result;

            string response = getResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<Pesquisa>>(response);
        }
    }
}

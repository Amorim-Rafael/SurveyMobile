using SurveyMobile.PCL.BusinessLayer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyMobile.PCL.ServiceAccessLayer.Interface
{
    public interface IServiceWrapper
    {
        Task<TokenModel> GetAuthorizationTokenTask(UserLoginModel loginModel);
        TokenModel GetAuthorizationToken(UserLoginModel loginModel);
        Task<bool> ValidateUser(UserLoginModel loginModel, string authenticationToken);
        Task<string> RegisterUser(UserLoginModel loginModel, string authenticationToken);
        Task<List<Pesquisa>> DespesasPorPesquisaAsync();
        List<Pesquisa> DespesasPorPesquisa();
    }
}

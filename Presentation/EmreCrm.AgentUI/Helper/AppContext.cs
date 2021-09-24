using EmreCrm.Core.Extensions;
using EmreCrm.Model.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace EmreCrm.AgentUI.Helper
{
    public interface IAppContext
    {
        UserModel Agent { get;}
    }

    public class AppContext : IAppContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public AppContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserModel Agent
        {
            get
            {
                try
                {
                    string claimsData = _httpContextAccessor.HttpContext.GetClaimsValue("Agent");

                    if (!string.IsNullOrEmpty(claimsData))
                        return JsonConvert.DeserializeObject<UserModel>(claimsData);
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}

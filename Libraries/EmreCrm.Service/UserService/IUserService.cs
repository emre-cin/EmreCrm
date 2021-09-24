using EmreCrm.Core.Models;
using EmreCrm.Model.DbEntity;
using EmreCrm.Model.Model;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmreCrm.Service.UserService
{
    public interface IUserService 
    {
        #region Methods
        ReturnModel<UserModel> Add(UserModel userModel);

        List<UserModel> GetPagedList(int? page, int? rows);

        UserModel GetById(int id);

        ReturnModel Update(UserModel userModel);

        ReturnModel Delete(int id);

        void ClearMemory();

        #endregion
    }
}

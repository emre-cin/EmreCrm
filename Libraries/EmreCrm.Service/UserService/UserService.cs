using EmreCrm.Core.Extensions;
using EmreCrm.Core.Helper;
using EmreCrm.Core.Models;
using EmreCrm.Core.UnitOfWork;
using EmreCrm.Model.DbEntity;
using EmreCrm.Model.Model;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using System.Linq;
using EmreCrm.Core.Caching;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace EmreCrm.Service.UserService
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _repository;
        private readonly RedisCacheService _redisCacheService;
        #endregion

        #region Ctor
        public UserService(IUnitOfWork unitOfWork, RedisCacheService redisCacheService)
        {
            _unitOfWork = unitOfWork;
            _redisCacheService = redisCacheService;
            _repository ??= _unitOfWork.GetRepository<User>();

        }
        #endregion

        #region Methods
        public ReturnModel<UserModel> Add(UserModel userModel)
        {
            ReturnModel<UserModel> returnModel = new ReturnModel<UserModel>();

            try
            {
                User user = userModel.MapTo<User>();

                _repository.Insert(user);
                _unitOfWork.SaveChanges();

                _redisCacheService.Clear();

                returnModel.IsSuccess = true;
                returnModel.Message = "Kullanıcı başarıyla eklendi.";
                returnModel.Redirect = $"/kullanicilar";
                returnModel.Data = user.MapTo<UserModel>();
            }
            catch (Exception)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = "Kullanıcı ekleme işlemi bir hatadan dolayı gerçekleştirilemedi.";
            }

            return returnModel;
        }

        public ReturnModel Delete(int id)
        {
            ReturnModel returnModel = new ReturnModel();

            try
            {
                User user = _repository.GetById(id);

                _repository.Delete(user);
                _unitOfWork.SaveChanges();

                string cacheKey = $"user-{user.Name}-{user.Surname}-{user.Id}";

                _redisCacheService.Remove(cacheKey);
                _redisCacheService.Clear();

                returnModel.IsSuccess = true;
                returnModel.Message = "Kullanıcı başarıyla silindi.";
                returnModel.Redirect = "/kullanicilar";
            }
            catch (Exception ex)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = "Kullanıcı silinirken bir hata oluştu.";
            }

            return returnModel;
        }

        public UserModel GetById(int id)
        {
            try
            {
                string cacheKey = $"user-id-{id}";

                UserModel user = _redisCacheService.Get<UserModel>(cacheKey);

                if (user != null)
                    return user;

                user = _repository.GetById(id).MapTo<UserModel>();

                _redisCacheService.Set(cacheKey, user);

                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<UserModel> GetPagedList(int? page, int? rows)
        {
            try
            {
                string cacheKey = $"users-{page ?? 0}-{rows ?? 0}";

                List<UserModel> users = _redisCacheService.Get<List<UserModel>>(cacheKey);

                if (users != null && users.Any())
                    return users;

                users = _repository.GetAll().Skip((page - 1 ?? 0) * (rows ?? 20)).Take(rows ?? 20).MapTo<List<UserModel>>();

                if (users != null && users.Any())
                    _redisCacheService.Set(cacheKey, users);

                return users;
            }
            catch (Exception ex)
            {
                return new List<UserModel>();
            }
        }

        //public UserModel Login(LoginModel loginModel)
        //{
        //    try
        //    {
        //        loginModel.Password = loginModel.Password.ToSHAHash();

        //        UserModel UserModel = _repository.Get(predicate: x => x.UserName == loginModel.UserName && x.Password == loginModel.Password).MapTo<UserModel>();

        //        return UserModel;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        public ReturnModel Update(UserModel userModel)
        {
            ReturnModel returnModel = new ReturnModel();

            try
            {
                User user = _repository.GetById(userModel.Id);

                if (user != null)
                {
                    user.Name = userModel.Name;
                    user.Surname = userModel.Surname;
                    user.Email = userModel.Email;
                    user.Telephone = userModel.Telephone;

                    _repository.Update(user);
                    _unitOfWork.SaveChanges();

                    _redisCacheService.Clear();

                    string cacheKey = $"user-id-{user.Id}";
                    _redisCacheService.Set(cacheKey, user.MapTo<UserModel>());

                    returnModel.IsSuccess = true;
                    returnModel.Message = "Kullanıcı başarıyla düzenlendi.";
                    returnModel.Redirect = $"/kullanicilar";
                }
                else
                {
                    returnModel.IsSuccess = false;
                    returnModel.Message = "Düzenlemek istediğiniz kullanıcı sistemde bulunamadı";
                }
            }
            catch (Exception)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = "Kullanıcı düzenleme işlemi bir hatadan dolayı gerçekleştirilemedi.";
            }

            return returnModel;
        }

        public void ClearMemory()
        {
            _redisCacheService.Clear();
        }
        #endregion
    }
}

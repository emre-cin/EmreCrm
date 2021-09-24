using AutoMapper;
using EmreCrm.Model.DbEntity;
using EmreCrm.Model.Model;

namespace EmreCrm.Model.Mapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}

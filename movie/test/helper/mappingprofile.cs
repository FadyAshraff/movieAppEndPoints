using AutoMapper;
using test.dto;
using test.model;
using test.NewFolder;

namespace test.helper
{
    public class mappingprofile:Profile
    {
        public mappingprofile()
        {
            CreateMap<movie, genmovdto>();
            CreateMap<moviedto, movie>().ForMember(src => src.poster, opt => opt.Ignore());
        }
    }
}

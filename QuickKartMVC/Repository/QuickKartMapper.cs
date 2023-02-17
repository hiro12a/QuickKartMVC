using AutoMapper;
using QuickKartDataAccessLayer.Models;

namespace QuickKartMVC.Repository
{
    public class QuickKartMapper : Profile
    {
        public QuickKartMapper()
        {
            CreateMap<Products, Models.Products>();
            CreateMap<Models.Products, Products>();
            CreateMap<Categories, Categories>();
            CreateMap<Categories, Categories>();
        }
    }
}

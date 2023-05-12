using AutoMapper;
using PharmaCare.Models;
using PharmaCare.Models.DTO;

namespace PharmaCare
{
    public class MappingConfig : Profile
    {


        public MappingConfig()
        {

            CreateMap<Drug, DrugDTO>();
            CreateMap<DrugDTO, Drug>();
            CreateMap<Supplier, SupplierDTO>();
            CreateMap<SupplierDTO, Supplier>(); 
        }
    }
}

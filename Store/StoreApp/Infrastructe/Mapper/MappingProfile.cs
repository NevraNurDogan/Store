using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace StoreApp.Infrastructe.Mapper
{
    public class MappingProfile:Profile{
        /*MappingProfile sınıfında, AutoMapper'ın ProductDtoForInsertion türündeki nesneleri
         Product türündeki nesnelere nasıl dönüştüreceğini tanımlarsınız.
        CreateMap<TSource, TDestination>() metodu, kaynak tür ve hedef tür arasındaki dönüşüm kurallarını belirler.
        Bu yapı, veri transferi ve işleme süreçlerini daha verimli ve temiz bir şekilde yönetmenizi sağlar.*/
        public MappingProfile(){
            CreateMap<ProductDtoForInsertion,Product>();
            CreateMap<ProductDtoForUpdate,Product>().ReverseMap();// yani iki değer de birbirine dönüşebilir.
        }
    }
}
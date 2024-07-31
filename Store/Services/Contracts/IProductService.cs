using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService
    {
        //okuma işlemleri
        /*Bu metod, tüm Product nesnelerini döndürür. 
        IEnumerable<Product>, Product türünde bir koleksiyon döndürür.*/
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        /*Bu metod, belirli bir id'ye sahip Product nesnesini döndürür. 
        Eğer belirtilen id'ye sahip bir ürün bulunamazsa, null dönebilir.*/
        Product? GetOneProduct(int id, bool trackChanges);//ürün getirebilecek
        /*Bu metod, yeni bir ürün oluşturur. ProductDtoForInsertion türündeki parametre, yeni ürünün bilgilerini içerir.
        ProductDtoForInsertion: Bu DTO (Data Transfer Object), genellikle yeni ürün oluşturmak için gerekli tüm bilgileri içerir. 
        DTO kullanımı, veri transferi ve işleme sürecini daha düzenli ve anlaşılır hale getirir.*/
        void CreateProduct(ProductDtoForInsertion product);
        void UpdateOneProduct(ProductDtoForUpdate productDto);
        void DeleteOneProduct(int id);
        ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
    }
}
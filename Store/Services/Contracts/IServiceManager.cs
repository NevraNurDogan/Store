namespace Services.Contracts{
    public interface IServiceManager{//servisleri yönettiğim yer
        IProductService ProductService { get; } 
        ICategoryService CategoryService { get; }
        IOrderService OrderService { get; }
    }


}
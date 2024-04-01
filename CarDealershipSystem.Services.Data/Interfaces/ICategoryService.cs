namespace CarDealershipSystem.Services.Data.Interfaces
{
    using Web.ViewModels.Category;
    public interface ICategoryService
    {
        Task<IEnumerable<CarSelectCategoryFormModel>> AllCategoriesAsync();
    }
}

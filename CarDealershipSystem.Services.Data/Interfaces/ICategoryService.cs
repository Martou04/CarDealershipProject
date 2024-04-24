namespace CarDealershipSystem.Services.Data.Interfaces
{
    using Web.ViewModels.Category;

    public interface ICategoryService
    {
        Task<IEnumerable<CarSelectCategoryFormModel>> AllCategoriesAsync();

        Task<bool> ExistsByIdAsync(int id);

        Task<IEnumerable<string>> AllCategoryNamesAsync();

        Task AddCategoryAsync(CategoryFormModel formModel);

        Task<bool> ExistsByNameAsync(string name);

        Task<IEnumerable<CategoryAllViewModel>> AllCategoriesNamesAsync();

        Task<CategoryFormModel> GetCategoryForEditByIdAsync(int Id);

        Task EditAsync(int Id,  CategoryFormModel model);
    }
}

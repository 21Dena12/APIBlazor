using APIBlazor.Model;

namespace APIBlazor.Interfaces
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> GetAllMenus();
        Task<Menu> GetMenuById(int id);
        Task CreateMenu(Menu menu);
        Task UpdateMenu(Menu menu);
        Task DeleteMenu(int id);
    }
}

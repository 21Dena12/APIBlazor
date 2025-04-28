using APIBlazor.Model;
using Microsoft.AspNetCore.Mvc;
using APIBlazor.Interfaces;
namespace APIBlazor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
        {
            return Ok(await _menuService.GetAllMenus());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            var menu = await _menuService.GetMenuById(id);
            if (menu == null) return NotFound();
            return Ok(menu);
        }

        [HttpPost]
        public async Task<ActionResult<Menu>> CreateMenu(Menu menu)
        {
            await _menuService.CreateMenu(menu);
            return CreatedAtAction(nameof(GetMenu), new { id = menu.Id }, menu);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu(int id, Menu menu)
        {
            if (id != menu.Id) return BadRequest();
            await _menuService.UpdateMenu(menu);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            await _menuService.DeleteMenu(id);
            return NoContent();
        }
    }
}

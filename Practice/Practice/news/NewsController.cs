using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Practice.news
{
    [Route("api/[controller]")]
    [ApiController]
    [Route("news")]
    public class NewsController : Controller
    {
        private readonly DatabaseContext _context;
        public NewsController(DatabaseContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Выводит список новостей
        /// </summary>
        /// <returns>Список новостей</returns>
        /// <response code="200">Список новостей.</response>
        /// <response code="404">Ничего нет.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<NewsEntity>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Index()
        {
            return _context.News !=
            ? Ok(await _context.News.Include(n => n.Author).OrderByDescending(n =>
            n.CreatedAt).Take(100).ToListAsync())
            : NotFound();
        }
        /// <summary>
        /// Выводит новость по id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Новость по id</response>
        /// <response code="404">Ничего нет.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(NewsEntity), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == || _context.News == null)
            {
                return NotFound();
            }
            var item = await _context.News.Include(n => n.Author).FirstOrDefaultAsync(n => n.Id == id);
            return item != ? Ok(item) : NotFound();
        }
        /// <summary>
        /// Добавление новости
        /// </summary>
        /// <param name="item">Публикуемая статья</param>
        /// <response code="201">Новость опубликована</response>
        /// <response code="400">Некорректный запрос</response>
        [HttpPost]
        [ProducesResponseType(typeof(NewsEntity), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] NewsCreateDTO item)
        {
            if (ModelState.IsValid)
            {
                var created = new NewsEntity
                {
                    Title = item.Title,
                    Content = item.Content,
                    AuthorId = 1 //временное решение для указания авторства
                };
            }

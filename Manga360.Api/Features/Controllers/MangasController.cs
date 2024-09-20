namespace Manga360.Api.Features.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class MangasController : ControllerBase
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IMapper _mapper;
        public MangasController(IMangaRepository mangaRepository, IMapper mapper)
        {
            _mangaRepository = mangaRepository;
            _mapper = mapper;
        }

        #region GetAllAsync
        [HttpGet("getAll"), EndpointSummary("Obter todos os mangas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var mangas = await _mangaRepository.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<MangaDTO>>(mangas));
        }
        #endregion

        #region GetByIdAsync
        [HttpGet("{id:int}"), EndpointSummary("Obter manga por Id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var manga = await _mangaRepository.GetByIdAsync(id);

            if (manga is null) return NotFound($"Manga com {id} não encontrado");

            return Ok(_mapper.Map<MangaDTO>(manga));
        }
        #endregion

        #region GetMangasByCategory
        [HttpGet,EndpointSummary("Obter mangas por ID da categoria")]
        [Route("get-mangas-by-category/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMangasByCategory(int categoryId)
        {
            var mangas = await _mangaRepository.GetMangasPorCategoriaAsync(categoryId);

            if (!mangas.Any()) return NotFound();

            return Ok(_mapper.Map<IEnumerable<MangaDTO>>(mangas));
        }
        #endregion
    
        #region AddAsync
        [HttpPost("Create"), EndpointSummary("Criar novo manga")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(MangaDTO mangaDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var manga = _mapper.Map<MangaEntity>(mangaDto);
            await _mangaRepository.AddAsync(manga);

            return Ok(_mapper.Map<MangaDTO>(manga));
        }
        #endregion

        #region UpdateAsync
        [HttpPut("{id:int}"), EndpointSummary("Alterar um manga")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, MangaDTO mangaDto)
        {
            if (id != mangaDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _mangaRepository.UpdateAsync(_mapper.Map<MangaEntity>(mangaDto));

            return Ok(mangaDto);
        }
        #endregion

        #region RemoveAsync
        [HttpDelete("{id:int}"),EndpointSummary("Excluir um manga")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(int id)
        {
            var manga = await _mangaRepository.GetByIdAsync(id);
            if (manga is null) return NotFound();
            await _mangaRepository.RemoveAsync(manga.Id);
            return Ok();
        }
        #endregion

        #region SearchAsync
        [HttpGet, EndpointSummary("Pesquisar um manga")]
        [Route("search/{mangaTitulo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<MangaDTO>>> Search(string mangaTitulo)
        {
            var mangas = await _mangaRepository.SearchAsync(m => m.Titulo.Contains(mangaTitulo));

            if (mangas is null)
                return NotFound("Nenhum mangá foi encontrado");

            return Ok(_mapper.Map<IEnumerable<MangaDTO>>(mangas));
        }
        #endregion

        #region SearchMangaWithCategoryAsync
        [HttpGet, EndpointSummary("Pesquisar manga com categoria")]
        [Route("search-manga-with-category/{criterio}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<MangaCategoriaDTO>>> SearchMangaWithCategory(string criterio)
        {
            var mangas = _mapper.Map<List<MangaEntity>>(await _mangaRepository.LocalizaMangaComCategoriaAsync(criterio));

            if (!mangas.Any())
                return NotFound("Nenhum mangá foi encontrado");

            return Ok(_mapper.Map<IEnumerable<MangaCategoriaDTO>>(mangas));
        }
        #endregion
    }
}
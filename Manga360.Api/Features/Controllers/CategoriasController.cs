namespace Manga360.Api.Features.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        public CategoriasController(ICategoriaRepository categoryRepository, IMapper mapper)
        {
            _categoriaRepository = categoryRepository;
            _mapper = mapper;
        }

        #region GetAllAsync
        [HttpGet("getAll"), EndpointSummary("Obter todas as categorias")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categorias = await _categoriaRepository.GetAllAsync();
            if (categorias is null)
            {
                return NotFound("Categorias não existem");
            }
            var categoriasDto = _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
            return Ok(categoriasDto);
        }
        #endregion

        #region GetByIdAsync
        [HttpGet("{id:int}", Name = "GetCategoria"), EndpointSummary("Obter categoria por ID")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            if (categoria is null)
            {
                return NotFound("Categoria não encontrada");
            }

            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);
            return Ok(categoriaDto);
        }
        #endregion
        
        #region PostAsync
        [HttpPost("create"), EndpointSummary("Criar uma categoria")]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDto)
        {
            if (categoriaDto == null)
                return BadRequest("Dados inválidos");

            var categoria = _mapper.Map<CategoriaEntity>(categoriaDto);

            await _categoriaRepository.AddAsync(categoria);

            return new CreatedAtRouteResult("GetCategoria", new { id = categoriaDto.Id },
                categoriaDto);
        }
        #endregion

        #region PutAsync
        [HttpPut("update"), EndpointSummary("alterar uma categoria")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoriaDto)
        {
            if (id != categoriaDto.Id)
                return BadRequest();

            if (categoriaDto == null)
                return BadRequest();

            var categoria = _mapper.Map<CategoriaEntity>(categoriaDto);

            await _categoriaRepository.UpdateAsync(categoria);

            return Ok(categoriaDto);
        }
        #endregion

        #region DeleteAsync
        [HttpDelete("{id:int}"), EndpointSummary("excluir uma categoria")]
        public async Task<ActionResult> Delete(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada");
            }

            await _categoriaRepository.RemoveAsync(id);

            return Ok(categoria);
        }
        #endregion
    }
}
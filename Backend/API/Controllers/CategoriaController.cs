using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CategoriaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public CategoriaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> Get()
        {
            var categoria = await _unitOfWork.Categorias.GetAllAsync();
            return _mapper.Map<List<CategoriaDto>>(categoria);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaDto>> Get(string id)
        {
            var categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
            if (categoria == null) return NotFound();
            return _mapper.Map<CategoriaDto>(categoria);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Categoria>> Post(CategoriaDto categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);
            _unitOfWork.Categorias.Add(categoria);
            await _unitOfWork.SaveAsync();
            if (categoria == null) return BadRequest();
            categoriaDto.Id = categoria.Id;
            return CreatedAtAction(nameof(Post), new { id = categoriaDto.Id }, categoriaDto);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaDto>> Put(string id, [FromBody] CategoriaDto categoriaDto)
        {
            if (categoriaDto == null) return NotFound();
            if (categoriaDto.Id == "") categoriaDto.Id = id;
            if (categoriaDto.Id != id) return BadRequest();
            var categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
            _mapper.Map(categoriaDto, categoria);
            //categoria.FechaModificacion = DateTime.Now;
            _unitOfWork.Categorias.Update(categoria);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<CategoriaDto>(categoria);
        
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
            if (categoria == null) return NotFound();
            _unitOfWork.Categorias.Remove(categoria);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
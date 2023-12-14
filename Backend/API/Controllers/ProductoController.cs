using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public ProductoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> Get()
        {
            var producto = await _unitOfWork.Productos.GetAllAsync();
            return _mapper.Map<List<ProductoDto>>(producto);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductoDto>> Get(string id)
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(id);
            if (producto == null) return NotFound();
            return _mapper.Map<ProductoDto>(producto);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Producto>> Post(ProductoDto productoDto)
        {
            var producto = _mapper.Map<Producto>(productoDto);
            _unitOfWork.Productos.Add(producto);
            await _unitOfWork.SaveAsync();
            if (producto == null) return BadRequest();
            productoDto.Id = producto.Id;
            return CreatedAtAction(nameof(Post), new { id = productoDto.Id }, productoDto);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductoDto>> Put(string id, [FromBody] ProductoDto productoDto)
        {
            if (productoDto == null) return NotFound();
            if (productoDto.Id == "") productoDto.Id = id;
            if (productoDto.Id != id) return BadRequest();
            var producto = await _unitOfWork.Productos.GetByIdAsync(id);
            _mapper.Map(productoDto, producto);
            //producto.FechaModificacion = DateTime.Now;
            _unitOfWork.Productos.Update(producto);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ProductoDto>(producto);
        
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(id);
            if (producto == null) return NotFound();
            _unitOfWork.Productos.Remove(producto);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
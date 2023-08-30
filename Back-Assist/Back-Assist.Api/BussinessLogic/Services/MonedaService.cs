using Back_Assist.Api.BussinessLogic.Dto;
using Back_Assist.Api.BussinessLogic.Interfaces;
using Back_Assist.Data.Data;
using Back_Assist.Data.Domain;
using Back_Assist.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Assist.Api.BussinessLogic.Services
{
    public class MonedaService : IMonedaService
    {
        private readonly IGeneric<Moneda> _igMoneda;
        private readonly Context _context;

        public MonedaService(Context context, IGeneric<Moneda> igMoneda)
        {
            _context = context;
            _igMoneda = igMoneda;
        }

        public async Task<List<MonedaDto>> ListaMonedas()
        {
            var listaArticulos = await (from a in _context.Monedas
                                        select new MonedaDto
                                        {
                                            Id = a.Id,
                                            Descripcion = a.Descripcion
                                        }).ToListAsync();
            return listaArticulos;
        }

        public async Task<bool> RegistrarMonedas(MonedaCreateDto dto)
        {
            try
            {
                var saveData = new Moneda()
                {
                    Descripcion = dto.Descripcion
                };

                var exitoso = await _igMoneda.CreateAsync(saveData);

                if (exitoso != null)
                    return true;
                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> EliminarMonedas(int id)
        {
            try
            {
                var currentMoneda = _igMoneda.Search(x => x.Id == id);

                await _igMoneda.RemoveAsync(currentMoneda);
                return true;

            }
            catch (Exception ex) { throw ex; }
        }
    }
}

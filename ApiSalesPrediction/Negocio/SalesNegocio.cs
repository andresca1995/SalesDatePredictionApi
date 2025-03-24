using ApiSalesPrediction.model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using models.dbcontext;
using models.models;

namespace ApiSalesPrediction.Negocio
{
    public class SalesNegocio
    {
        private readonly AppDbContext _dbContext;

        public SalesNegocio(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<response> ventasporcliente(int CustomerID)
        {
            response res = new response();
            
            List<sp_get_Orders_for_client> result = _dbContext.Set<sp_get_Orders_for_client>().FromSqlRaw("EXEC sp_get_Orders_for_client @p0", CustomerID).ToList();

            res.exito = result.Count > 0 ? true : false;
            res.Mensaje = res.exito ? "Resulado con exito" : "No se encontro información";
            res.data = result;

            return res;
        }
      
 
        public async Task<List<Dictionary<string, object>>> ObtenerDatosDinamicos(string spNombre, Dictionary<string, object> parametros)
        {
            return await _dbContext.EjecutarSPDinamico(spNombre, parametros);
        }
    }

}





using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
namespace models.dbcontext
{


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public async Task<List<Dictionary<string, object>>> EjecutarSPDinamico(string storedProcedure, Dictionary<string, object> parametros)
    {
        var listaResultados = new List<Dictionary<string, object>>();

        using (var command = Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = storedProcedure;
            command.CommandType = CommandType.StoredProcedure;

                // Agregar parámetros si existen
                if (parametros != null)
                {
                    SqlParameter[] sqlParameters = parametros.Select(kvp =>
                new SqlParameter($"@{kvp.Key}", ConvertirValorSQL(kvp.Value))
            ).ToArray();
                    command.Parameters.AddRange(sqlParameters);
                }
            

            await Database.OpenConnectionAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var fila = new Dictionary<string, object>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        fila[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                    }

                    listaResultados.Add(fila);
                }
            }
        }

        return listaResultados;
    }
        private object ConvertirValorSQL(object valor)
        {
            if (valor == null) return DBNull.Value;

            return valor switch
            {
                int or long or float or double or decimal or bool or DateTime => valor,
                string => valor.ToString(),
                _ => System.Text.Json.JsonSerializer.Serialize(valor) // Convertir objetos a JSON
            };
        }
    }
    }
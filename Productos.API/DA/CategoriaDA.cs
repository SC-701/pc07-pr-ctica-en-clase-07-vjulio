using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Microsoft.Data.SqlClient;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DA
{
    public class CategoriaDA : ICategoriaDA
    {
        private readonly IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public CategoriaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        public async Task<Guid> Agregar(CategoriaRequest categoria)
        {
            string query = @"TcategoriaAgregar";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                Nombre = categoria.Nombre
            });

            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, CategoriaRequest categoria)
        {
            await verificarCategoriaExiste(Id);

            string query = @"TcategoriaEditar";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                Nombre = categoria.Nombre
            });

            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await verificarCategoriaExiste(Id);

            string query = @"TcategoriaEliminar";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id
            });

            return resultadoConsulta;
        }

        public async Task<IEnumerable<CategoriaResponse>> Obtener()
        {
            string query = @"TcategoriaObtener";

            var resultadoConsulta = await _sqlConnection.QueryAsync<CategoriaResponse>(query);

            return resultadoConsulta;
        }

        public async Task<CategoriaResponse> ObtenerId(Guid Id)
        {
            string query = @"TcategoriaObtenerId";

            var resultadoConsulta = await _sqlConnection.QueryAsync<CategoriaResponse>(query,
                new { Id = Id });

            return resultadoConsulta.FirstOrDefault();
        }

        private async Task verificarCategoriaExiste(Guid Id)
        {
            var resultado = await ObtenerId(Id);
            if (resultado == null)
                throw new Exception("No se encontró la categoría");
        }
    }
}
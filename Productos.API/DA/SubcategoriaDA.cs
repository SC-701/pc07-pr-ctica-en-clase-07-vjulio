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
    public class SubCategoriaDA : ISubCategoriaDA
    {
        private readonly IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public SubCategoriaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        public async Task<Guid> Agregar(SubCategoriaRequest subcategoria)
        {
            string query = @"SubcategoriaAgregar";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                IdCategoria = subcategoria.IdCategoria,
                Nombre = subcategoria.Nombre
            });

            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, SubCategoriaRequest subcategoria)
        {
            await verificarSubCategoriaExiste(Id);

            string query = @"SubcategoriaEditar";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                IdCategoria = subcategoria.IdCategoria,
                Nombre = subcategoria.Nombre
            });

            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await verificarSubCategoriaExiste(Id);

            string query = @"SubcategoriaEliminar";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id
            });

            return resultadoConsulta;
        }

        public async Task<IEnumerable<SubCategoriaResponse>> Obtener()
        {
            string query = @"SubcategoriaObtener";

            var resultadoConsulta = await _sqlConnection.QueryAsync<SubCategoriaResponse>(query);

            return resultadoConsulta;
        }

        public async Task<SubCategoriaResponse> ObtenerId(Guid Id)
        {
            string query = @"SubcategoriaObtenerId";

            var resultadoConsulta = await _sqlConnection.QueryAsync<SubCategoriaResponse>(query,
                new { Id = Id });

            return resultadoConsulta.FirstOrDefault();
        }

        private async Task verificarSubCategoriaExiste(Guid Id)
        {
            var resultado = await ObtenerId(Id);
            if (resultado == null)
                throw new Exception("No se encontró la subcategoría");
        }
    }
}
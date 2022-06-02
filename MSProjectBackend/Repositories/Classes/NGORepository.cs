using MSProjectBackend.Models.DomainModels;
using MSProjectBackend.Repositories.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MSProjectBackend.Repositories.Classes
{
    public class NGORepository : BaseRepository, INGORepository
    {
        public NGORepository(IConfiguration configuration) : base(configuration)
        { }

        public async Task<List<NGO>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM NGO";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<NGO>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<NGO> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM NGO WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<NGO>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> CreateAsync(NGO entity)
        {
            try
            {
                var query = "INSERT INTO NGO (Name) VALUES (@Name)";

                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name, DbType.String);
                
                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(NGO entity)
        {
            try
            {
                var query = "UPDATE NGO SET Name = @Name WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name, DbType.String);
                
                parameters.Add("Id", entity.Id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> DeleteAsync(dynamic id)
        {
            try
            {
                var query = "DELETE FROM NGO WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", Convert.ToInt32(id), DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

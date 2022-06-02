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
    public class NGOAppealRepository : BaseRepository, INGOAppealRepository
    {
        public NGOAppealRepository(IConfiguration configuration) : base(configuration)
        { }

        public async Task<List<NGOAppeal>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM NGOAppeal";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<NGOAppeal>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<NGOAppeal> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM NGOAppeal WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<NGOAppeal>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> CreateAsync(NGOAppeal entity)
        {
            try
            {
                var query = "INSERT INTO NGOAppeal (Name) VALUES (@Name)";

                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.About, DbType.String);
                
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

        public async Task<int> UpdateAsync(NGOAppeal entity)
        {
            try
            {
                var query = "UPDATE NGOAppeal SET Name = @Name WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.About, DbType.String);
                
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
                var query = "DELETE FROM NGOAppeal WHERE Id = @Id";

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

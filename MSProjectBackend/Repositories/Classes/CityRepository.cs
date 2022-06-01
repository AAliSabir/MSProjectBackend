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
    public class CityRepository : BaseRepository, ICityRepository
    {
        public CityRepository(IConfiguration configuration) : base(configuration)
        { }

        public async Task<List<City>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM City";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<City>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<City>> GetByProvince(int provinceId)
        {
            try
            {
                var query = "SELECT * FROM City where ProvinceId = @ProvinceId";
                
                var parameters = new DynamicParameters();
                parameters.Add("ProvinceId", provinceId, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<City>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<City> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM City WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<City>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> CreateAsync(City entity)
        {
            try
            {
                var query = @"INSERT INTO City(Name, ProvinceId) VALUES (@Name, @ProvinceId)";
                           
                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name, DbType.String);
                parameters.Add("ProvinceId", entity.ProvinceId, DbType.Int32);

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

        public async Task<int> UpdateAsync(City entity)
        {
            try
            {
                var query = @"UPDATE City SET Name = @Name WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", entity.Id, DbType.Int32);
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

        public async Task<int> DeleteAsync(dynamic id)
        {
            try
            {
                var query = "DELETE FROM City WHERE Id = @Id";

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

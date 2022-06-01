﻿using MSProjectBackend.Models.DomainModels;
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
    public class ProvinceRepository : BaseRepository, IProvinceRepository
    {
        public ProvinceRepository(IConfiguration configuration) : base(configuration)
        { }

        public async Task<List<Province>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM Province";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Province>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Province> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM Province WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Province>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> CreateAsync(Province entity)
        {
            try
            {
                var query = @"INSERT INTO Province(Name) VALUES (@Name)";
                           
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

        public async Task<int> UpdateAsync(Province entity)
        {
            try
            {
                var query = @"UPDATE Province SET Name = @Name WHERE Id = @Id";

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
                var query = "DELETE FROM Province WHERE Id = @Id";

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

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

        public async Task<NGO> GetByRegistrationIdAsync(string id)
        {
            try
            {
                var query = "SELECT * FROM NGO WHERE RegistrationId = @RegistrationId";

                var parameters = new DynamicParameters();
                parameters.Add("RegistrationId", id, DbType.String);

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
                var query = "INSERT INTO NGO (RegistrationId, Name) VALUES (@RegistrationId, @Name)";

                var parameters = new DynamicParameters();
                parameters.Add("RegistrationId", entity.RegistrationId, DbType.String);
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
                var query = "UPDATE NGO SET ";

                var parameters = new DynamicParameters();
                string queryParams = string.Empty;
                
                parameters.Add("Id", entity.Id, DbType.Int32);

                if (!string.IsNullOrEmpty(entity.Name))
                {
                    queryParams = "Name = @Name, ";
                    parameters.Add("Name", entity.Name, DbType.String);
                }

                if (!string.IsNullOrEmpty(entity.Email))
                {
                    queryParams += "Email = @Email, ";
                    parameters.Add("Email", entity.Email, DbType.String);
                }

                if (!string.IsNullOrEmpty(entity.RegistrationNumber))
                {
                    queryParams += "RegistrationNumber = @RegistrationNumber, ";
                    parameters.Add("RegistrationNumber", entity.RegistrationNumber, DbType.String);
                }

                if (entity.RegistrationDate != null)
                {
                    queryParams += "RegistrationDate = @RegistrationDate, ";
                    parameters.Add("RegistrationDate", entity.RegistrationDate, DbType.DateTime);
                }

                if (!string.IsNullOrEmpty(entity.About))
                {
                    queryParams += "About = @About, ";
                    parameters.Add("About", entity.About, DbType.String);
                }

                if (!string.IsNullOrEmpty(entity.Address))
                {
                    queryParams += "Address = @Address, ";
                    parameters.Add("Address", entity.Address, DbType.String);
                }

                if (entity.ProvinceId != null)
                {
                    queryParams += "ProvinceId = @ProvinceId, ";
                    parameters.Add("ProvinceId", entity.ProvinceId, DbType.Int32);
                }

                if (entity.CityId != null)
                {
                    queryParams += "CityId = @CityId, ";
                    parameters.Add("CityId", entity.CityId, DbType.Int32);
                }

                if (!string.IsNullOrEmpty(entity.AreasOfWork))
                {
                    queryParams += "AreasOfWork = @AreasOfWork, ";
                    parameters.Add("AreasOfWork", entity.AreasOfWork, DbType.String);
                }

                if (queryParams.Substring(queryParams.Length - 2).Contains(","))
                {
                    queryParams = queryParams.Substring(0, queryParams.Length - 2);
                }

                query += queryParams + " WHERE Id = @Id";

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

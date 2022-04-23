using Backend.Models.DomainModels;
using Backend.Repositories.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories.Classes
{
    public class VolunteerRepository : BaseRepository, IVolunteerRepository
    {
        public VolunteerRepository(IConfiguration configuration) : base(configuration)
        { }

        public async Task<List<Volunteer>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM Volunteer";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Volunteer>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Volunteer> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM Volunteer WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Volunteer>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> CreateAsync(Volunteer entity)
        {
            try
            {
                var query = "INSERT INTO Volunteer (Name, Price, Quantity) VALUES (@Name, @Price, @Quantity)";

                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name, DbType.String);
                //parameters.Add("Price", entity.Price, DbType.Decimal);
                //parameters.Add("Quantity", entity.Quantity, DbType.Int32);

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

        public async Task<int> UpdateAsync(Volunteer entity)
        {
            try
            {
                var query = "UPDATE Volunteer SET Name = @Name, Price = @Price, Quantity = @Quantity WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name, DbType.String);
                //parameters.Add("Price", entity.Price, DbType.Decimal);
                //parameters.Add("Quantity", entity.Quantity, DbType.Int32);
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

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                var query = "DELETE FROM Volunteer WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

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

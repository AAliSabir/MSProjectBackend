using Dapper;
using MSProjectBackend.Models.DomainModels;
using MSProjectBackend.Repositories.Interfaces;
using System.Data;

namespace MSProjectBackend.Repositories.Classes
{
    public class RegistrationRepository : BaseRepository, IRegistrationRepository
    {
        public RegistrationRepository(IConfiguration configuration) : base(configuration)
        { }

        public async Task<int> CreateAsync(Registration entity)
        {
            try
            {
                var query = @"INSERT INTO Registration (Id, Password, RegistrationType) 
                                VALUES (@Id, @Password, @RegistrationType)";

                var parameters = new DynamicParameters();
                parameters.Add("Id", entity.Id, DbType.String);
                parameters.Add("Password", entity.Password, DbType.String);
                parameters.Add("RegistrationType", entity.RegistrationType, DbType.Int32);

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

        public async Task<Registration> SignIn(string id)
        {
            try
            {
                var query = "SELECT * FROM Registration WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Registration>(query, parameters));
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
                var query = "DELETE FROM Registration WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", Convert.ToString(id), DbType.String);

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

        public Task<List<Registration>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Registration> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Registration entity)
        {
            throw new NotImplementedException();
        }
    }
}

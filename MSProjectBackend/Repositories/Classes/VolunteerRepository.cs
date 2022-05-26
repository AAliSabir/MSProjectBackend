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

        public async Task<int> SignUpAsync(Volunteer entity)
        {
            try
            {
                var query = @"INSERT INTO Volunteer (Name, Email, Password) 
                                VALUES (@Name, @Email, @Password)";

                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name, DbType.String);
                parameters.Add("Email", entity.Email, DbType.String);
                parameters.Add("Password", entity.Password, DbType.String);

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

        public async Task<int> CreateAsync(Volunteer entity)
        {
            try
            {
                var query = @"INSERT INTO Volunteer (Name, DateOfBirth, CNIC, ContactNo, Email, Gender, IsIndependent, NGOId) 
                                VALUES (@Name, @DateOfBirth, @CNIC, @ContactNo, @Email, @Gender, @IsIndependent, @NGOId)";
                           
                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name, DbType.String);
                parameters.Add("DateOfBirth", entity.DateOfBirth, DbType.DateTime);
                parameters.Add("CNIC", entity.CNIC, DbType.String);
                parameters.Add("ContactNo", entity.ContactNo, DbType.String);
                parameters.Add("Email", entity.Email, DbType.String);
                parameters.Add("Gender", entity.Gender, DbType.Int64);
                parameters.Add("Address", entity.Address, DbType.String);
                parameters.Add("ProvinceId", entity.ProvinceId, DbType.Int32);
                parameters.Add("CityId", entity.CityId, DbType.Int32);
                parameters.Add("EducationId", entity.EducationId, DbType.Int32);
                parameters.Add("About", entity.About, DbType.String);
                parameters.Add("Skills", entity.Skills, DbType.String);
                parameters.Add("AreasOfInterest", entity.AreasOfInterest, DbType.String);
                parameters.Add("Availability", entity.Availability, DbType.String);
                parameters.Add("IsIndependent", entity.IsIndependent, DbType.Byte);
                parameters.Add("NGOId", entity.NGOId, DbType.Int64);

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
                var query = @"UPDATE Volunteer SET ";

                var parameters = new DynamicParameters();
                string queryParams = string.Empty;

                parameters.Add("Id", entity.Id, DbType.Int32);

                if (!string.IsNullOrEmpty(entity.Name))
                {
                    queryParams = "Name = @Name, ";
                    parameters.Add("Name", entity.Name, DbType.String);
                }

                if (entity.DateOfBirth != null)
                {
                    queryParams += "DateOfBirth = @DateOfBirth, ";
                    parameters.Add("DateOfBirth", entity.DateOfBirth, DbType.DateTime);
                }

                if (!string.IsNullOrEmpty(entity.CNIC))
                {
                    queryParams += "CNIC = @CNIC, ";
                    parameters.Add("CNIC", entity.CNIC, DbType.String);
                }

                if (!string.IsNullOrEmpty(entity.ContactNo))
                {
                    queryParams += "ContactNo = @ContactNo, ";
                    parameters.Add("ContactNo", entity.ContactNo, DbType.String);
                }

                if (!string.IsNullOrEmpty(entity.Email))
                {
                    queryParams += "Email = @Email, ";
                    parameters.Add("Email", entity.Email, DbType.String);
                }

                if (entity.Gender != null)
                {
                    queryParams += "Gender = @Gender, ";
                    parameters.Add("Gender", entity.Gender, DbType.Int32);
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
                
                if (entity.EducationId != null)
                {
                    queryParams += "EducationId = @EducationId, ";
                    parameters.Add("EducationId", entity.EducationId, DbType.Int32);
                }
                
                if (!string.IsNullOrEmpty(entity.About))
                {
                    queryParams += "About = @About, ";
                    parameters.Add("About", entity.About, DbType.String);
                }
                
                if (!string.IsNullOrEmpty(entity.Skills))
                {
                    queryParams += "Skills = @Skills, ";
                    parameters.Add("Skills", entity.Skills, DbType.String);
                }
                
                if (!string.IsNullOrEmpty(entity.AreasOfInterest))
                {
                    queryParams += "AreasOfInterest = @AreasOfInterest, ";
                    parameters.Add("AreasOfInterest", entity.AreasOfInterest, DbType.String);
                }
                
                if (!string.IsNullOrEmpty(entity.Availability))
                {
                    queryParams += "Availability = @Availability, ";
                    parameters.Add("Availability", entity.Availability, DbType.String);
                }
                
                if (entity.IsIndependent != null)
                {
                    queryParams += "IsIndependent = @IsIndependent, ";
                    parameters.Add("IsIndependent", entity.IsIndependent, DbType.Byte);
                }

                if (entity.NGOId != null)
                {
                    queryParams += "NGOId = @NGOId";
                    parameters.Add("NGOId", entity.NGOId, DbType.Int64);
                }
                
                if(queryParams.Substring(queryParams.Length - 2).Contains(","))
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
                var query = "DELETE FROM Volunteer WHERE Id = @Id";

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

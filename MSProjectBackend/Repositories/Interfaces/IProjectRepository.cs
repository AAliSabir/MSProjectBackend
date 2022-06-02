using MSProjectBackend.Models.DomainModels;
using MSProjectBackend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSProjectBackend.Repositories.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
    }
}

using AutoMapper;
using AutoMapper.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using MachineCartSystem.Entity;
using MachineCartSystem.Entity.DomainModel;
using MachineCartSystem.Entity.UserInfo;
using MachineCartSystem.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MachineCartSystem.Service.Services
{
    public class UserService : IUserService
    {
        private readonly MachineCartSystemDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(MachineCartSystemDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task AddUserDetailAsync(UserDetailVM userDetailVM)
        {
            try
            {
                await _dbContext.UserDetail.Persist(_mapper).InsertOrUpdateAsync(userDetailVM);
                await _dbContext.SaveChangesAsync();
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw ex;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (DBConcurrencyException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }


        }

        public async Task UpdateUserDetailAsync(UserDetailVM userDetailVM)
        {
            try
            {
                await _dbContext.UserDetail.Persist(_mapper).InsertOrUpdateAsync(userDetailVM);
                await _dbContext.SaveChangesAsync();
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw ex;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (DBConcurrencyException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<UserDetailVM>> GetAllUserDetailAsync()
        {
            var data = await _dbContext.UserDetail.AsNoTracking().ProjectTo<UserDetailVM>(_mapper.ConfigurationProvider).ToListAsync();
            return data;
        }
    }
}

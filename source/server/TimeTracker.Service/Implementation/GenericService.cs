﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TimeTracker.Domain.Common;
using TimeTracker.Persistence;
using TimeTracker.Service.Contract;

namespace TimeTracker.Service.Implementation
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly ApplicationDbContext _applicationDbContext;

        public GenericService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ApplicationException(nameof(applicationDbContext));
        }

        public async Task<Response<bool>> Add(T entity)
        {
            try
            {
                _applicationDbContext.Set<T>().Add(entity);
                return new Response<bool>
                {
                    Message = "Object saved successfully!",
                    Succeeded = await _applicationDbContext.SaveChangesAsync() > 0
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Succeeded = false,
                    Message = "Object wasn't saved due to the following reason \n" + ex.Message
                };
            }
        }


        public async Task<Response<bool>> AddRange(IEnumerable<T> entities)
        {
            try
            {
                _applicationDbContext.Set<T>().AddRange(entities);
                return new Response<bool>
                {
                    Message = "Objects were saved successfully!",
                    Succeeded = await _applicationDbContext.SaveChangesAsync() > 0
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Succeeded = false,
                    Message = "Something went wrong due to the following reason \n" + ex.Message
                };
            }
        }

        public async Task<Response<IEnumerable<T>>> Find(Expression<Func<T, bool>> expression)
        {
            try
            {
                var response = await _applicationDbContext.Set<T>().Where(expression).ToListAsync();
                return new Response<IEnumerable<T>>
                {
                    Data = response,
                    Succeeded = true,
                    Message = "Objects were retrieved successfully!"
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<T>>
                {
                    Succeeded = false,
                    Message = "Something went wrong due to the following reason \n" + ex.Message
                };
            }
        }

        public async Task<Response<IEnumerable<T>>> GetAll()
        {
            try
            {
                var response = await _applicationDbContext.Set<T>().ToListAsync();
                return new Response<IEnumerable<T>>
                {
                    Data = response,
                    Succeeded = true,
                    Message = "Objects were retrieved successfully!"
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<T>>
                {
                    Succeeded = false,
                    Message = "Something went wrong due to the following reason \n" + ex.Message
                };
            }
        }

        public async Task<Response<T>> GetById(Guid Id)
        {
            try
            {
                var response = await _applicationDbContext.Set<T>().FindAsync(Id);
                return new Response<T>
                {
                    Data = response,
                    Succeeded = true,
                    Message = "Objects was retrieved successfully!"
                };
            }
            catch (Exception ex)
            {
                return new Response<T>
                {
                    Succeeded = false,
                    Message = "Something went wrong due to the following reason \n" + ex.Message
                };
            }
        }

        public async Task<Response<bool>> Remove(T entity)
        {
            try
            {
                _applicationDbContext.Set<T>().Remove(entity);
                return new Response<bool>
                {
                    Message = "Objects was deleted successfully!",
                    Succeeded = await _applicationDbContext.SaveChangesAsync() > 0
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Succeeded = false,
                    Message = "Something went wrong due to the following reason \n" + ex.Message
                };
            }
        }

        public async Task<Response<bool>> RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                _applicationDbContext.Set<T>().RemoveRange(entities);
                return new Response<bool>
                {
                    Message = "Objects were deleted successfully!",
                    Succeeded = await _applicationDbContext.SaveChangesAsync() > 0
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Succeeded = false,
                    Message = "Something went wrong due to the following reason \n" + ex.Message
                };
            }
        }

        public async Task<Response<bool>> Update(T entity)
        {
            try
            {
                _applicationDbContext.Set<T>().Update(entity);
                return new Response<bool>
                {
                    Message = "Objects were deleted successfully!",
                    Succeeded = await _applicationDbContext.SaveChangesAsync() > 0
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Succeeded = false,
                    Message = "Something went wrong due to the following reason \n" + ex.Message
                };
            }
        }
    }
}

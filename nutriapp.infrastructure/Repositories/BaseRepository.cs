﻿using Microsoft.EntityFrameworkCore;
using nutriapp.core.Entities;
using nutriapp.infrastructure.Data;
using nutriapp.infrastructure.Interfaces;
using System.Linq.Expressions;

namespace nutriapp.infrastructure.Repositories;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> entities;
    public BaseRepository(NutriAppContext dbContext)
    {
        this.entities = dbContext.Set<T>();
    }

    public IQueryable<T> GetAll()
    {
        return entities;
    }
    public IQueryable<T> GetAllIncluding(Expression<Func<T, object>> includeProperty)
    {
        return entities.Include(includeProperty);
    }
    public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] navigationProperties)
    {
        IQueryable<T> query = entities;

        foreach (var navigationProperty in navigationProperties)
        {
            query = query.Include(navigationProperty);
        }

        return query;
    }
    public IQueryable<T> GetAllIncluding(params string[] navigationProperties)
    {
        IQueryable<T> query = entities;

        foreach (string navigationProperty in navigationProperties)
        {
            query = query.Include(navigationProperty);
        }

        return query;
    }
    public async Task<T> GetByIdAsync(object id)
    {
        return await entities.FindAsync(id);
    }
    public async Task AddAsync(T item)
    {
        await entities.AddAsync(item);
    }
    public void Update(T item)
    {
        entities.Update(item);
    }
    public async Task DeleteAsync(object id)
    {
        var currentEntity = await GetByIdAsync(id);
        entities.Remove(currentEntity);
    }
}
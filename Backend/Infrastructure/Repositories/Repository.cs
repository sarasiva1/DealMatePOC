using System.Linq.Expressions;
using System.Reflection;
using DealMate.Backend.Infrastructure.DB;
using DealMate.Backend.Infrastructure.Interfaces;
using DealMate.Backend.Service;
using Microsoft.EntityFrameworkCore;

namespace DealMate.Backend.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    private IQueryable<T> _query;

    public Repository(ApplicationDbContext context)
    {
        _context = context;

        _query = _context.Set<T>();
        var includeProperties = GetIncludeProperties(typeof(T));

        foreach (var includeProperty in includeProperties)
        {
            _query = _query.Include(includeProperty);
        }
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _query.ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _query.Where(predicate).ToListAsync();
    }

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await _query.Where(predicate).FirstOrDefaultAsync();
    }


    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        await _context.Set<T>().AddRangeAsync(entities);
        await _context.SaveChangesAsync();
        return entities;
    }

    public async Task<T> Update(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<T>> RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
        await _context.SaveChangesAsync();
        return entities;
    }

    #region Methods
    private IEnumerable<string> GetIncludeProperties(Type type)
    {
        var includeProperties = new List<string>();

        var properties = type.GetProperties()
            .Where(p => p.GetCustomAttribute<IncludeAttribute>() != null);

        foreach (var property in properties)
        {
            includeProperties.Add(property.Name);
            var propertyType = property.PropertyType;

            // Handle nested properties
            if (propertyType.IsClass && propertyType != typeof(string))
            {
                // Recursively get nested includes
                includeProperties.AddRange(GetNestedIncludes(propertyType, property.Name));
            }
        }

        return includeProperties;
    }

    private IEnumerable<string> GetNestedIncludes(Type type, string parentProperty)
    {
        var nestedIncludes = new List<string>();
        var properties = type.GetProperties()
            .Where(p => p.GetCustomAttribute<IncludeAttribute>() != null);

        foreach (var property in properties)
        {
            var propertyName = property.Name;
            nestedIncludes.Add($"{parentProperty}.{propertyName}");

            var propertyType = property.PropertyType;

            // Handle further nesting
            if (propertyType.IsClass && propertyType != typeof(string))
            {
                nestedIncludes.AddRange(GetNestedIncludes(propertyType, $"{parentProperty}.{propertyName}"));
            }
        }

        return nestedIncludes;
    }
    #endregion

}

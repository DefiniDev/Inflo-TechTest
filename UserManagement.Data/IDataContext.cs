using System.Linq;

namespace UserManagement.Data;

public interface IDataContext
{
    /// <summary>
    /// Get a list of items
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;

    /// <summary>
    /// Create a new item
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="entity"></param>
    /// <returns></returns>
    void Create<TEntity>(TEntity entity) where TEntity : class;

    /// <summary>
    /// Uodate an existing item matching the ID
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="entity"></param>
    /// <returns></returns>
    void Update<TEntity>(TEntity entity) where TEntity : class;

    /// <summary>
    /// Deletes the specified entity of type <typeparamref name="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to be deleted. Must be a reference type.</typeparam>
    /// <param name="entity">The entity to be deleted.</param>
    /// <remarks>
    /// This method removes the specified entity from the data store.
    /// </remarks>
    void Delete<TEntity>(TEntity entity) where TEntity : class;

    /// <summary>
    /// Retrieves an entity of type <typeparamref name="TEntity"/> based on the provided identifier.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to retrieve. Must be a reference type.</typeparam>
    /// <param name="id">The identifier of the entity to retrieve.</param>
    /// <returns>The entity with the specified identifier, or null if not found.</returns>
    /// <remarks>
    /// This method fetches the entity from the data store using its unique identifier.
    /// </remarks>
    TEntity GetById<TEntity>(long id) where TEntity : class;
}

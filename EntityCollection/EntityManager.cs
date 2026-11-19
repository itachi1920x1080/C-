using System.Reflection;
using System.Reflection.Extensions;

namespace EntityCollection
{
    /// <summary>
    /// Class represents a management on enities
    /// </summary>
    /// <typeparam name="TKey">Parameter defines type of entity's key</typeparam>
    /// <typeparam name="TEntity">Parameter defines type of entities</typeparam>
    public class EntityManager<TKey,TEntity>
        where TKey: notnull 
        where TEntity:notnull, Entity<TKey>
    {
        #region Static Members
        /// <summary>
        /// Property gets or sets an entry assembly
        /// </summary>
        public static Assembly? EntryAssembly { get; set; } = Assembly.GetEntryAssembly();
        /// <summary>
        /// Method creates an entity for a given type with given data
        /// </summary>
        /// <param name="typeName">Represents type name of entity to be created</param>
        /// <param name="data">Represents data of created entity</param>
        /// <returns></returns>
        public static TEntity? CreateEntity(string typeName, string data)
        {
            var instance = EntryAssembly?.CreateObject(typeName, true);
            if (instance is TEntity entity)
            {
                if (entity.SetTextData(data) /*polymorphism*/ == true)
                {
                    return entity;
                }
            }
            return null;
        }

        #endregion

        #region Instance Members
        /// <summary>
        /// List of entities
        /// </summary>
        private List<TEntity> _entities = new();

        /// <summary>
        /// Event will be raised when an entity added
        /// </summary>
        public event EntityEventHandler<TKey, TEntity>? EntityAdded;
        /// <summary>
        /// Event will be raised when an entity removed
        /// </summary>
        public event EntityEventHandler<TKey, TEntity>? EntityRemoved;
        /// <summary>
        /// Event will be raised when entity's data was modified
        /// </summary>
        public event EntityEventHandler<TKey, TEntity>? EntityDataModified;

        /// <summary>
        /// Property gets a list of entities
        /// </summary>
        public List<TEntity> Entities => _entities;

        /// <summary>
        /// Method checks for an entity with given key
        /// </summary>
        /// <param name="key">Defines a key of entity to be checked</param>
        /// <returns>True when entity was found</returns>
        public bool Exist(TKey key) => _entities.Any(e => e.Key.Equals(key));

        /// <summary>
        /// Method checks for a given entity
        /// </summary>
        /// <param name="entity">Defines an entity to be checked</param>
        /// <returns></returns>
        public bool Exist(TEntity entity) => _entities.Contains(entity) || Exist(entity.Key);

        /// <summary>
        /// Method adds an entity into a list of entities
        /// </summary>
        /// <param name="entity">Defines an entity to be added</param>
        /// <returns>True when succeded</returns>
        public bool Add(TEntity entity)
        {
            if (!Exist(entity))
            {
                _entities.Add(entity);
                EntityAdded?.Invoke(this, entity);
                entity.DataModified += OnEntityDataModified;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method adds a newly created entity with given type name and data
        /// </summary>
        /// <param name="typeName">Defines type of entity to be created</param>
        /// <param name="data">Defines data to entity to be created</param>
        /// <returns></returns>
        public bool Add(string typeName, string data)
        {
            var sh = CreateEntity(typeName, data);
            if (sh != null) return Add(sh);
            return false;
        }

        /// <summary>
        /// Method modifies an entity of given key for given data into a list of entities
        /// </summary>
        /// <param name="key">Defines a key of entity to be modified</param>
        /// <param name="data">Defines data to be set to found entity</param>
        /// <returns>True when succeded</returns>
        public bool Modify(TKey key, string data)
        {
            var found = _entities.FirstOrDefault(e => e.Key.Equals(key));
            if (found != null)
            {
                return found.SetTextData(data); /*Performing polymorphism process*/
            }
            return false;
        }

        /// <summary>
        /// Method removes a given entity from a list of entities
        /// </summary>
        /// <param name="entity">Defines entity to be removed</param>
        /// <returns>True when succeded</returns>
        public bool Remove(TEntity entity)
        {
            var result = _entities.Remove(entity);
            if (result == true)
            {
                EntityRemoved?.Invoke(this, entity);
                entity.DataModified -= OnEntityDataModified;
            }
            return result;
        }

        /// <summary>
        /// Method get entities of given type from a list of entities 
        /// </summary>
        /// <param name="type">Define a type of entities</param>
        /// <returns>A list of entities</returns>
        public List<TEntity> GetEntitiesFor(Type? type)
        {
            if (type == null) return Entities;
            return _entities.Where(e => e.GetType() == type).ToList();
        }

        /// <summary>
        /// Indexer gets an entity for a given key
        /// </summary>
        /// <param name="key">A key of entity to return</param>
        /// <returns>Found entity</returns>
        public TEntity? this[TKey key]//indexer
            => _entities.FirstOrDefault(e => e.Key.Equals(key));

 
        /// <summary>
        /// Property gets or set the acting entity type
        /// </summary>
        public Type? ActingEntityType { get; set; } = default;

        /// <summary>
        /// Property gets  a list of entities for acting entity type
        /// </summary>
        public List<TEntity> ActingEntities => GetEntitiesFor(ActingEntityType);

        /// <summary>
        /// Event handler for the event: ShapeDataModified
        /// </summary>
        /// <param name="sender">a sender raised the event</param>
        /// <param name="e">Argument when the event raised</param>
        private void OnEntityDataModified(object? sender, EventArgs e)
        {
            if (sender is TEntity entity) EntityDataModified?.Invoke(this, entity);
        }
        #endregion
    }
}

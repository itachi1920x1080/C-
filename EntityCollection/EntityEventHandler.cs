using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCollection;

/// <summary>
/// Delegate type
/// </summary>
/// <typeparam name="TKey">Key of entity</typeparam>
/// <typeparam name="TEntity">Type of entity</typeparam>
/// <param name="sender">Sender</param>
/// <param name="entity">Entity</param>
public delegate void EntityEventHandler<TKey, TEntity>(object? sender, TEntity? entity)
    where TKey: notnull     
    where TEntity :notnull, Entity<TKey>;

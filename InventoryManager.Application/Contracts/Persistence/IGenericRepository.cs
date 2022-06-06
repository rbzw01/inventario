using System;

namespace InventoryManager.Application.Contracts.Persistence
{
    /// <summary>
    /// Interfaz Generica para ser utilizada como base de los repositorios a crear
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Obtener un entidad a partir del id
        /// </summary>
        /// <param name="id">Identificador de la entidad</param>
        /// <returns>Entidad en caso de ser encontrada</returns>
        Task<T> Get(int id);

        /// <summary>
        /// Obtener los entidad existentes
        /// </summary>
        /// <returns>Lista de entidades existentes</returns>
        Task<IReadOnlyList<T>> GetAll();

        /// <summary>
        /// Adicionar un nuevo entidad
        /// </summary>
        /// <param name="entity">Entidad que se desea adicionar</param>
        /// <returns>entidad adicionada y actualizada</returns>
        Task<T> Add(T entity);

        /// <summary>
        /// Actualizar un entidad existente
        /// </summary>
        /// <param name="entity">Entidad que se desea actualizar</param>
        /// <returns></returns>
        Task Update(T entity);

        /// <summary>
        /// Eliminar una entidad existente
        /// </summary>
        /// <param name="entity">Entidad a eliminar </param>
        /// <returns></returns>
        Task Delete(T entity);

        /// <summary>
        /// Verificar si una entidad existe
        /// </summary>
        /// <param name="id">Identificador de la entidad</param>
        /// <returns>True en caso de que exista</returns>
        Task<bool> Exists(int id);
    }
}


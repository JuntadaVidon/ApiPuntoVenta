namespace M4Facturation.Application.Contracts;

public interface ICacheService
{
    /// <summary>
    /// Obtiene un objeto de la caché utilizando la clave especificada.
    /// </summary>
    /// <param name="key">Clave de la caché.</param>
    /// <returns>El objeto almacenado en la caché.</returns>
    OperationResponse<object?> GetCache(string key);

    /// <summary>
    /// Almacena un objeto en la caché utilizando la clave y los datos especificados.
    /// </summary>
    /// <typeparam name="T">Tipo de datos del objeto.</typeparam>
    /// <param name="key">Clave de la caché.</param>
    /// <param name="data">Datos a almacenar en la caché.</param>
    OperationResponse<T> SetCache<T>(string key, T data);

    /// <summary>
    /// Almacena un objeto en la caché utilizando la clave y los datos especificados durante un largo período de tiempo.
    /// </summary>
    /// <typeparam name="T">Tipo de datos del objeto.</typeparam>
    /// <param name="key">Clave de la caché.</param>
    /// <param name="data">Datos a almacenar en la caché.</param>
    OperationResponse<T> SetLongCache<T>(string key, T data);

    /// <summary>
    /// Obtiene todas las claves que se encuentran actualmente en la caché.
    /// </summary>
    /// <returns>Una colección de todas las claves en la caché.</returns>
    OperationResponse<ICollection<string>> GetAllKeysCache();

    /// <summary>
    /// Elimina todas las entradas de la caché utilizando las claves almacenadas.
    /// </summary>
    /// <returns>Verdadero si todas las entradas fueron eliminadas con éxito y la caché está vacía, falso en caso contrario.</returns>
    OperationResponse<bool> RemoveAllKeysCache();

    /// <summary>
    /// Elimina un objeto de la caché utilizando la clave especificada.
    /// </summary>
    /// <param name="key">Clave de la caché.</param>
    /// <returns>Retorna un valor booleano segun el resultado.</returns>
    OperationResponse<bool> RemoveKeyCache(string key);

    /// <summary>
    /// Obtiene los datos del usuario logueado.
    /// </summary>
    /// <returns>Devuelve el dni del usuario logueado.</returns>
    OperationResponse<string> GetUserCache();
}
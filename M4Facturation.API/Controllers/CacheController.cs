namespace M4Facturation.API.Controllers;

/// <summary>
/// Controlador para gestionar las operaciones relacionadas con la caché.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CacheController(ICacheService cacheService) : BaseController
{
    private readonly ICacheService _cacheService = cacheService;

    /// <summary>
    /// Elimina todas las claves de la caché.
    /// </summary>
    /// <returns>Retorna un operation response con un booleano.</returns>
    [HttpDelete]
    [ProducesResponseType(typeof(OperationResponseSwagger<bool>), StatusCodes.Status200OK)]
    public IActionResult ClearCache()
        => Return(_cacheService.RemoveAllKeysCache());

    /// <summary>
    /// Elimina una clave de la caché.
    /// </summary>
    /// <param name="key">clave a ser eliminada.</param>
    /// <returns>Retorna un operation response con un booleano.</returns>
    [HttpDelete("{key}")]
    [ProducesResponseType(typeof(OperationResponseSwagger<bool>), StatusCodes.Status200OK)]
    public IActionResult ClearKeyCache(string key) => Return(_cacheService.RemoveKeyCache(key));


    /// <summary>
    /// Obtiene una clave de la caché.
    /// </summary>
    /// <param name="key">clave a ser obtenida.</param>
    /// <returns>Retorna un operation response con un booleano.</returns>
    [HttpGet("{key}")]
    [ProducesResponseType(typeof(OperationResponseSwagger<bool>), StatusCodes.Status200OK)]
    public IActionResult GetKeyCache(string key)
        => Return(_cacheService.GetCache(key));


    /// <summary>
    /// Recupera todas las claves de la caché.
    /// </summary>
    /// <returns>Retorna la clase operation response con una lista de string.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(OperationResponseSwagger<bool>), StatusCodes.Status200OK)]
    public IActionResult GetCacheKeys()
        => Return(_cacheService.GetAllKeysCache());
}
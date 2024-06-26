namespace M4Facturation.Application.Services;

public abstract class BaseService
{
    protected readonly IMapper _mapper;
    protected readonly IMemoryCache _cache;
    protected readonly IHttpContextAccessor _httpContextAccessor;
    protected readonly ICacheService _cacheService;


    /// <summary>
    /// Constructor de la clase BaseService.
    /// </summary>
    protected BaseService() { }

    protected BaseService(ICacheService cacheService, IMapper mapper)
    {
        _cacheService = cacheService;
        _mapper = mapper;
    }

    protected BaseService(IMapper mapper, IHttpContextAccessor httpContextAccessor, IMemoryCache cache)
    {
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
        _cache = cache;
    }

    protected BaseService(IMapper mapper)
    {
        _mapper = mapper;
    }


    /// <summary>
    /// Crea una respuesta de operación con un código de estado 400 (BadRequest).
    /// </summary>
    /// <typeparam name="T">Tipo de datos del objeto.</typeparam>
    /// <param name="message">Mensaje de error a incluir en la respuesta.</param>
    /// <param name="data">Datos de la operación.</param>
    /// <returns>Una respuesta de operación con un código de estado 400 y el mensaje proporcionado.</returns>
    protected static OperationResponse<T> BadRequest<T>(string message, T? data = default)
        => OperationResponse<T>.CustomErrorResponse(400, message, data);


    /// <summary>
    /// Crea una respuesta de operación con un código de estado 200 (OK).
    /// </summary>
    /// <typeparam name="T">Tipo de datos del objeto.</typeparam>
    /// <param name="data">Datos a incluir en la respuesta.</param>
    /// <param name="total">La cantidad de filas afectadas.</param>
    /// <returns>Una respuesta de operación con un código de estado 200, los datos proporcionados y el mensaje proporcionado.</returns>
    protected static OperationResponse<T> Ok<T>(T data, int total = default)
        => OperationResponse<T>.SuccessResponse(data, total);


    /// <summary>
    /// Crea una respuesta de operación con un código de estado 404 (NotFound).
    /// </summary>
    /// <typeparam name="T">Tipo de datos del objeto.</typeparam>
    /// <returns>Una respuesta de operación con un código de estado 404.</returns>
    protected static OperationResponse<T> NotFound<T>()
        => OperationResponse<T>.NotFoundResponse();


    /// <summary>
    /// Crea una respuesta de operación con un código de estado 500 (InternalServerError).
    /// </summary>
    /// <typeparam name="T">Tipo de datos del objeto.</typeparam>
    /// <param name="exception">Información de la excepción a incluir en la respuesta.</param>
    /// <returns>Una respuesta de operación con un código de estado 500, el mensaje proporcionado y la información de la excepción proporcionada.</returns>
    protected static OperationResponse<T> ServerErrorFile<T>(string exception)
        => OperationResponse<T>.ErrorFileResponse(exception);

    /// <summary>
    /// Crea una respuesta de operación con un código de estado 500 (InternalServerError).
    /// </summary>
    /// <typeparam name="T">Tipo de datos del objeto.</typeparam>
    /// <param name="exception">Información de la excepción a incluir en la respuesta.</param>
    /// <returns>Una respuesta de operación con un código de estado 500, el mensaje proporcionado y la información de la excepción proporcionada.</returns>
    protected static OperationResponse<T> InternalServerError<T>(string exception)
        => OperationResponse<T>.ErrorResponse(exception);
}
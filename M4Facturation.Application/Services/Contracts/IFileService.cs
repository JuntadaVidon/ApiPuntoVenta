namespace M4Facturation.Application.Contracts;
    /// <summary>
    /// Interfaz para el servicio de manejo de archivos con Amazon S3.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Sube un archivo al bucket S3 de Amazon.
        /// </summary>
        /// <param name="file">El archivo a subir.</param>
        /// <returns>Una respuesta de operación con el archivo subido.</returns>
        Task<OperationResponse<File>> Post(File file);

        /// <summary>
        /// Lee un archivo del bucket S3 de Amazon.
        /// </summary>
        /// <param name="nameFile">El archivo a leer.</param>
        /// <returns>Una respuesta de operación con el contenido del archivo en formato base64.</returns>
        Task<OperationResponse<string>> Get(string nameFile);
    }

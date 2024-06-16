namespace M4Facturation.Application.ResponseDto.Common;

public abstract class File
{
    [Base64String] public string? Base64 { get; set; }

    public string? NameFile { get; set; }

    [JsonIgnore] protected internal string Ruta { get; private set; }

    protected File() => SetRuta();

    /// <summary>
    /// Metodo para setear las rutas donde van a guardar los archivos en S3.
    /// </summary>
    private void SetRuta()
    {
        Ruta = this switch
        {
            //TODO: agregar las ruta cuando este creado toda la configuración para subir y descargar archivos.
            ExampleDtoFile => AppSettings.RutaS3.RutaExample,
            _ => throw new NotImplementedException()
        };
    }
}

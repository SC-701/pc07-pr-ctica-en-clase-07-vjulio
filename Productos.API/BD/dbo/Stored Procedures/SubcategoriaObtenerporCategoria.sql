
CREATE PROCEDURE SubcategoriaObtenerporCategoria
(
    @IdCategoria UNIQUEIDENTIFIER
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        s.*,
        c.Nombre AS NombreCategoria
    FROM dbo.SubCategorias s
    INNER JOIN dbo.Categorias c
        ON s.IdCategoria = c.Id
    WHERE s.IdCategoria = @IdCategoria;
END
GO
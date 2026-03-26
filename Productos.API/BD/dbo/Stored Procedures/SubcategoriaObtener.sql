
CREATE PROCEDURE SubcategoriaObtener
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        s.*,
        c.Nombre AS NombreCategoria
    FROM dbo.SubCategorias s
    LEFT JOIN dbo.Categorias c
        ON s.IdCategoria = c.Id;
END
GO
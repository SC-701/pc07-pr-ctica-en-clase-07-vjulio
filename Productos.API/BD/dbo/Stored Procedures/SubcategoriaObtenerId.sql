-- =============================================
-- Author:		
-- Create date: 
-- Description:	Obtener subcategoría por Id con categoría
-- =============================================
CREATE PROCEDURE SubcategoriaObtenerId
(
    @Id UNIQUEIDENTIFIER
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        s.Id,
        s.IdCategoria,
        s.Nombre,
        c.Nombre AS NombreCategoria
    FROM dbo.SubCategorias s
    LEFT JOIN dbo.Categorias c
        ON s.IdCategoria = c.Id
    WHERE s.Id = @Id;
END
GO
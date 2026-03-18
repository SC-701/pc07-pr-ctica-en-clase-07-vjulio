-- =============================================
    -- Author:		<Author,,Name>
    -- Create date: <Create Date,,>
    -- Description:	<Description,,>
    -- =============================================
    --CREATE   PROCEDURE Obtener
    --AS
    --BEGIN
    --    SET NOCOUNT ON;
    --SELECT Categorias.*, Producto.*, SubCategorias.*
    --FROM   Categorias INNER JOIN
    --             Producto ON Categorias.Id = Producto.Id INNER JOIN
    --             SubCategorias ON Categorias.Id = SubCategorias.IdCategoria AND Producto.IdSubCategoria = SubCategorias.Id

    --END

    CREATE PROCEDURE Obtener
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        p.*,
        c.Nombre as NombreCategoria,
        s.Nombre as NombreSubCategoria
    FROM Producto p
    LEFT JOIN Categorias c
        ON p.Id = c.Id
    LEFT JOIN SubCategorias s
        ON p.IdSubCategoria = s.Id;
END;
GO

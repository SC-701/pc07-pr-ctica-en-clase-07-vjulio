-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE Obtener1
AS
BEGIN
    SET NOCOUNT ON;
SELECT Producto.*
FROM   Categorias INNER JOIN
             Producto ON Categorias.Id = Producto.Id INNER JOIN
             SubCategorias ON Categorias.Id = SubCategorias.IdCategoria AND Producto.IdSubCategoria = SubCategorias.Id
END
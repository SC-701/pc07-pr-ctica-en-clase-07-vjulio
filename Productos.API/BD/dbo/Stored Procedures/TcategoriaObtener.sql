
CREATE PROCEDURE TcategoriaObtener
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        c.*
    FROM dbo.Categorias c;
END
GO

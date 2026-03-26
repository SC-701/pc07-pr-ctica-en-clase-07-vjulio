
CREATE PROCEDURE TcategoriaObtenerId
(
    @Id UNIQUEIDENTIFIER
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        c.Id,
        c.Nombre
    FROM dbo.Categorias c
    WHERE c.Id = @Id;
END
GO
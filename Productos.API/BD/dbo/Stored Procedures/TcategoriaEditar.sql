
CREATE PROCEDURE TcategoriaEditar
(
    @Id UNIQUEIDENTIFIER,
    @Nombre VARCHAR(MAX)
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION

    UPDATE dbo.Categorias
    SET Nombre = @Nombre
    WHERE Id = @Id;

    SELECT @Id

    COMMIT TRANSACTION
END
GO

CREATE PROCEDURE SubcategoriaEditar
(
    @Id UNIQUEIDENTIFIER,
    @IdCategoria UNIQUEIDENTIFIER,
    @Nombre VARCHAR(MAX)
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION

    UPDATE dbo.SubCategorias
    SET IdCategoria = @IdCategoria,
        Nombre = @Nombre
    WHERE Id = @Id;

    SELECT @Id

    COMMIT TRANSACTION
END
GO
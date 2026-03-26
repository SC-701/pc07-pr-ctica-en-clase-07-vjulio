
CREATE PROCEDURE SubcategoriaAgregar
(
    @Id UNIQUEIDENTIFIER,
    @IdCategoria UNIQUEIDENTIFIER,
    @Nombre VARCHAR(MAX)
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION

    INSERT INTO dbo.SubCategorias
    (
        Id,
        IdCategoria,
        Nombre
    )
    VALUES
    (
        @Id,
        @IdCategoria,
        @Nombre
    );

    SELECT @Id

    COMMIT TRANSACTION
END
GO
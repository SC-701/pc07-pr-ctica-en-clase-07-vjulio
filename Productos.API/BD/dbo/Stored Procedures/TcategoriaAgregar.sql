
CREATE PROCEDURE TcategoriaAgregar
(
    @Id UNIQUEIDENTIFIER,
    @Nombre VARCHAR(MAX)
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION

    INSERT INTO dbo.Categorias
    (
        Id,
        Nombre
    )
    VALUES
    (
        @Id,
        @Nombre
    );

    SELECT @Id

    COMMIT TRANSACTION
END
GO
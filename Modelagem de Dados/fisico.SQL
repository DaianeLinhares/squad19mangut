IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Categoria] (
    [IdCategoria] int NOT NULL IDENTITY,
    [Tipo] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Categoria] PRIMARY KEY ([IdCategoria])
);
GO

CREATE TABLE [Cliente] (
    [IdCliente] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [CPF] nvarchar(max) NOT NULL,
    [Telefone] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Senha] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([IdCliente])
);
GO

CREATE TABLE [Vendedor] (
    [IdVendedor] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [CPF] nvarchar(max) NOT NULL,
    [Endereco] nvarchar(max) NOT NULL,
    [Telefone] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Senha] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Vendedor] PRIMARY KEY ([IdVendedor])
);
GO

CREATE TABLE [Produto] (
    [IdProduto] int NOT NULL IDENTITY,
    [IdVendedor] int NOT NULL,
    [IdCategoria] int NOT NULL,
    [Nome] nvarchar(max) NOT NULL,
    [Preco] nvarchar(max) NOT NULL,
    [Quantidade] int NOT NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY ([IdProduto]),
    CONSTRAINT [FK_Produto_Categoria_IdCategoria] FOREIGN KEY ([IdCategoria]) REFERENCES [Categoria] ([IdCategoria]) ON DELETE CASCADE,
    CONSTRAINT [FK_Produto_Vendedor_IdVendedor] FOREIGN KEY ([IdVendedor]) REFERENCES [Vendedor] ([IdVendedor]) ON DELETE CASCADE
);
GO

CREATE TABLE [Compra] (
    [IdCompra] int NOT NULL IDENTITY,
    [DataCompra] datetime2 NOT NULL,
    [IdCliente] int NOT NULL,
    [IdProduto] int NOT NULL,
    CONSTRAINT [PK_Compra] PRIMARY KEY ([IdCompra]),
    CONSTRAINT [FK_Compra_Cliente_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [Cliente] ([IdCliente]) ON DELETE CASCADE,
    CONSTRAINT [FK_Compra_Produto_IdProduto] FOREIGN KEY ([IdProduto]) REFERENCES [Produto] ([IdProduto]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Compra_IdCliente] ON [Compra] ([IdCliente]);
GO

CREATE INDEX [IX_Compra_IdProduto] ON [Compra] ([IdProduto]);
GO

CREATE INDEX [IX_Produto_IdCategoria] ON [Produto] ([IdCategoria]);
GO

CREATE INDEX [IX_Produto_IdVendedor] ON [Produto] ([IdVendedor]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220109182001_mangut', N'6.0.1');
GO

COMMIT;
GO


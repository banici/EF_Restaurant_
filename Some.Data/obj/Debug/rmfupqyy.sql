IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Chefs] (
    [Id] int NOT NULL IDENTITY,
    [Birthday] datetime2 NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Chefs] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Restaurants] (
    [Id] int NOT NULL IDENTITY,
    [Adress] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Restaurants] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [SignatureDishes] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_SignatureDishes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ChefSignatureDishes] (
    [ChefId] int NOT NULL,
    [SignatureDishId] int NOT NULL,
    CONSTRAINT [PK_ChefSignatureDishes] PRIMARY KEY ([ChefId], [SignatureDishId]),
    CONSTRAINT [FK_ChefSignatureDishes_Chefs_ChefId] FOREIGN KEY ([ChefId]) REFERENCES [Chefs] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ChefSignatureDishes_SignatureDishes_SignatureDishId] FOREIGN KEY ([SignatureDishId]) REFERENCES [SignatureDishes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Ratings] (
    [Id] int NOT NULL IDENTITY,
    [GuestReview] nvarchar(max) NULL,
    [MichelinStar] int NOT NULL,
    [OrdinaryStar] int NOT NULL,
    [RestaurantId] int NOT NULL,
    [SignatureDishId] int NOT NULL,
    CONSTRAINT [PK_Ratings] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Ratings_Restaurants_RestaurantId] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurants] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Ratings_SignatureDishes_SignatureDishId] FOREIGN KEY ([SignatureDishId]) REFERENCES [SignatureDishes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [RestaurantSignatureDishes] (
    [RestaurantId] int NOT NULL,
    [SignatureDishId] int NOT NULL,
    CONSTRAINT [PK_RestaurantSignatureDishes] PRIMARY KEY ([RestaurantId], [SignatureDishId]),
    CONSTRAINT [FK_RestaurantSignatureDishes_Restaurants_RestaurantId] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurants] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_RestaurantSignatureDishes_SignatureDishes_SignatureDishId] FOREIGN KEY ([SignatureDishId]) REFERENCES [SignatureDishes] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_ChefSignatureDishes_SignatureDishId] ON [ChefSignatureDishes] ([SignatureDishId]);

GO

CREATE UNIQUE INDEX [IX_Ratings_RestaurantId] ON [Ratings] ([RestaurantId]);

GO

CREATE UNIQUE INDEX [IX_Ratings_SignatureDishId] ON [Ratings] ([SignatureDishId]);

GO

CREATE INDEX [IX_RestaurantSignatureDishes_SignatureDishId] ON [RestaurantSignatureDishes] ([SignatureDishId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180410113513_init', N'2.0.2-rtm-10011');

GO


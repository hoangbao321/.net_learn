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

CREATE TABLE [Articles] (
    [AritcleID] int NOT NULL IDENTITY,
    [Title] nvarchar(50) NULL,
    CONSTRAINT [PK_Articles] PRIMARY KEY ([AritcleID])
);
GO

CREATE TABLE [Tags] (
    [TagID] nvarchar(20) NOT NULL,
    [Content] ntext NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY ([TagID])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220412095922_V0', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Articles].[Title]', N'Name', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220412123110_V1', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Articles] ADD [Content] ntext NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220412132124_V2', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Tags] DROP CONSTRAINT [PK_Tags];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tags]') AND [c].[name] = N'TagID');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Tags] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Tags] DROP COLUMN [TagID];
GO

ALTER TABLE [Tags] ADD [TagIdnew] int NOT NULL IDENTITY;
GO

ALTER TABLE [Tags] ADD CONSTRAINT [PK_Tags] PRIMARY KEY ([TagIdnew]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220412133212_V3-RemoveTagID', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Tags].[TagIdnew]', N'TagId', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220412133451_V3-RenameTagID', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [ArticleTags] (
    [ArticleTagId] int NOT NULL IDENTITY,
    [TagId] int NOT NULL,
    [ArticleId] int NOT NULL,
    CONSTRAINT [PK_ArticleTags] PRIMARY KEY ([ArticleTagId]),
    CONSTRAINT [FK_ArticleTags_Articles_ArticleId] FOREIGN KEY ([ArticleId]) REFERENCES [Articles] ([AritcleID]) ON DELETE CASCADE,
    CONSTRAINT [FK_ArticleTags_Tags_TagId] FOREIGN KEY ([TagId]) REFERENCES [Tags] ([TagId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ArticleTags_ArticleId] ON [ArticleTags] ([ArticleId]);
GO

CREATE UNIQUE INDEX [IX_ArticleTags_ArticleTagId_TagId] ON [ArticleTags] ([ArticleTagId], [TagId]);
GO

CREATE INDEX [IX_ArticleTags_TagId] ON [ArticleTags] ([TagId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220412152052_V4', N'5.0.15');
GO

COMMIT;
GO


﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
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

CREATE TABLE [TB_BRINDE] (
    [IdBrinde] int NOT NULL IDENTITY,
    [DescricaoBrinde] nvarchar(max) NOT NULL,
    [NomeBrinde] nvarchar(max) NOT NULL,
    [Cadastro] nvarchar(1) NOT NULL,
    [Validade] datetime2 NOT NULL,
    [Quantidade] int NOT NULL,
    [Saldo] int NOT NULL,
    [ValorEcopoints] int NOT NULL,
    CONSTRAINT [PK_TB_BRINDE] PRIMARY KEY ([IdBrinde])
);
GO

CREATE TABLE [TB_COLETA] (
    [IdColeta] int NOT NULL IDENTITY,
    [IdEcoponto] int NOT NULL,
    [CodigoEcoponto] int NOT NULL,
    [IdUtilizador] int NOT NULL,
    [CodigoUltilizador] int NOT NULL,
    [DataColeta] datetime2 NOT NULL,
    [TotalEcopoints] real NOT NULL,
    [Peso] float NOT NULL,
    [SituacaoColeta] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TB_COLETA] PRIMARY KEY ([IdColeta])
);
GO

CREATE TABLE [TB_ECOPOINTS] (
    [IdMaterial] int NOT NULL IDENTITY,
    [OrdemGrandeza] nvarchar(1) NOT NULL,
    [Quantidade] int NOT NULL,
    [EcoPointsTotais] int NOT NULL,
    CONSTRAINT [PK_TB_ECOPOINTS] PRIMARY KEY ([IdMaterial])
);
GO

CREATE TABLE [TB_ECOPONTO] (
    [IdEcoponto] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [CNPJ] int NOT NULL,
    [RazaoSocial] nvarchar(max) NOT NULL,
    [Logradouro] nvarchar(max) NOT NULL,
    [Endereco] nvarchar(max) NOT NULL,
    [Complemento] nvarchar(max) NOT NULL,
    [Bairro] nvarchar(max) NOT NULL,
    [Cidade] nvarchar(max) NOT NULL,
    [UF] nvarchar(max) NOT NULL,
    [CEP] int NOT NULL,
    [Latitude] int NOT NULL,
    [Longitude] int NOT NULL,
    CONSTRAINT [PK_TB_ECOPONTO] PRIMARY KEY ([IdEcoponto])
);
GO

CREATE TABLE [TB_MATERIAIS] (
    [IdMaterial] int NOT NULL IDENTITY,
    [DescricaoMaterial] nvarchar(max) NOT NULL,
    [Classe] int NOT NULL,
    CONSTRAINT [PK_TB_MATERIAIS] PRIMARY KEY ([IdMaterial])
);
GO

CREATE TABLE [TB_UTILIZADOR] (
    [IdUtilizador] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [SituacaoEmail] bit NOT NULL,
    CONSTRAINT [PK_TB_UTILIZADOR] PRIMARY KEY ([IdUtilizador])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdEcoponto', N'Bairro', N'CEP', N'CNPJ', N'Cidade', N'Complemento', N'Endereco', N'Latitude', N'Logradouro', N'Longitude', N'Nome', N'RazaoSocial', N'UF') AND [object_id] = OBJECT_ID(N'[TB_ECOPONTO]'))
    SET IDENTITY_INSERT [TB_ECOPONTO] ON;
INSERT INTO [TB_ECOPONTO] ([IdEcoponto], [Bairro], [CEP], [CNPJ], [Cidade], [Complemento], [Endereco], [Latitude], [Logradouro], [Longitude], [Nome], [RazaoSocial], [UF])
VALUES (1, N'sla4', 3081010, 12345678, N'sla5', N'sla3', N'sla2', 192, N'sla', 193, N'Ecoponto1', N'Paz Mundial', N'sl'),
(2, N'sla4', 3081010, 12345678, N'sla5', N'sla3', N'sla2', 192, N'sla', 193, N'Ecoponto2', N'Paz Mundial', N'sl');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdEcoponto', N'Bairro', N'CEP', N'CNPJ', N'Cidade', N'Complemento', N'Endereco', N'Latitude', N'Logradouro', N'Longitude', N'Nome', N'RazaoSocial', N'UF') AND [object_id] = OBJECT_ID(N'[TB_ECOPONTO]'))
    SET IDENTITY_INSERT [TB_ECOPONTO] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdUtilizador', N'Email', N'Nome', N'SituacaoEmail') AND [object_id] = OBJECT_ID(N'[TB_UTILIZADOR]'))
    SET IDENTITY_INSERT [TB_UTILIZADOR] ON;
INSERT INTO [TB_UTILIZADOR] ([IdUtilizador], [Email], [Nome], [SituacaoEmail])
VALUES (1, N'joao123@gmail.com', N'João', CAST(1 AS bit)),
(2, N'maria123@gmail.com', N'Maria', CAST(1 AS bit));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdUtilizador', N'Email', N'Nome', N'SituacaoEmail') AND [object_id] = OBJECT_ID(N'[TB_UTILIZADOR]'))
    SET IDENTITY_INSERT [TB_UTILIZADOR] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240420183120_InitialCreat', N'8.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[TB_COLETA].[CodigoUltilizador]', N'CodigoUtilizador', N'COLUMN';
GO

ALTER TABLE [TB_UTILIZADOR] ADD [DataAcesso] datetime2 NULL;
GO

ALTER TABLE [TB_UTILIZADOR] ADD [PasswordHash] varbinary(max) NULL;
GO

ALTER TABLE [TB_UTILIZADOR] ADD [PasswordSalt] varbinary(max) NULL;
GO

ALTER TABLE [TB_UTILIZADOR] ADD [Username] nvarchar(max) NOT NULL DEFAULT N'';
GO

ALTER TABLE [TB_ECOPONTO] ADD [Email] nvarchar(max) NOT NULL DEFAULT N'';
GO

ALTER TABLE [TB_ECOPONTO] ADD [PasswordHash] varbinary(max) NOT NULL DEFAULT 0x;
GO

ALTER TABLE [TB_ECOPONTO] ADD [PasswordSalt] varbinary(max) NOT NULL DEFAULT 0x;
GO

ALTER TABLE [TB_ECOPONTO] ADD [Username] nvarchar(max) NOT NULL DEFAULT N'';
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdBrinde', N'Cadastro', N'DescricaoBrinde', N'NomeBrinde', N'Quantidade', N'Saldo', N'Validade', N'ValorEcopoints') AND [object_id] = OBJECT_ID(N'[TB_BRINDE]'))
    SET IDENTITY_INSERT [TB_BRINDE] ON;
INSERT INTO [TB_BRINDE] ([IdBrinde], [Cadastro], [DescricaoBrinde], [NomeBrinde], [Quantidade], [Saldo], [Validade], [ValorEcopoints])
VALUES (1, N'S', N'Caneca Ecológica', N'Caneca', 100, 100, '2025-05-19T16:21:16.8373051-03:00', 150),
(2, N'S', N'Camiseta Reciclada', N'Camiseta', 50, 50, '2025-05-19T16:21:16.8373061-03:00', 200);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdBrinde', N'Cadastro', N'DescricaoBrinde', N'NomeBrinde', N'Quantidade', N'Saldo', N'Validade', N'ValorEcopoints') AND [object_id] = OBJECT_ID(N'[TB_BRINDE]'))
    SET IDENTITY_INSERT [TB_BRINDE] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdColeta', N'CodigoEcoponto', N'CodigoUtilizador', N'DataColeta', N'IdEcoponto', N'IdUtilizador', N'Peso', N'SituacaoColeta', N'TotalEcopoints') AND [object_id] = OBJECT_ID(N'[TB_COLETA]'))
    SET IDENTITY_INSERT [TB_COLETA] ON;
INSERT INTO [TB_COLETA] ([IdColeta], [CodigoEcoponto], [CodigoUtilizador], [DataColeta], [IdEcoponto], [IdUtilizador], [Peso], [SituacaoColeta], [TotalEcopoints])
VALUES (1, 1001, 2001, '2024-05-19T16:21:16.8372989-03:00', 1, 1, 15.5E0, N'Completa', CAST(50 AS real)),
(2, 1002, 2002, '2024-05-19T16:21:16.8373006-03:00', 2, 2, 20.0E0, N'Pendente', CAST(75 AS real));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdColeta', N'CodigoEcoponto', N'CodigoUtilizador', N'DataColeta', N'IdEcoponto', N'IdUtilizador', N'Peso', N'SituacaoColeta', N'TotalEcopoints') AND [object_id] = OBJECT_ID(N'[TB_COLETA]'))
    SET IDENTITY_INSERT [TB_COLETA] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdMaterial', N'EcoPointsTotais', N'OrdemGrandeza', N'Quantidade') AND [object_id] = OBJECT_ID(N'[TB_ECOPOINTS]'))
    SET IDENTITY_INSERT [TB_ECOPOINTS] ON;
INSERT INTO [TB_ECOPOINTS] ([IdMaterial], [EcoPointsTotais], [OrdemGrandeza], [Quantidade])
VALUES (1, 100, N'A', 10),
(2, 200, N'B', 20);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdMaterial', N'EcoPointsTotais', N'OrdemGrandeza', N'Quantidade') AND [object_id] = OBJECT_ID(N'[TB_ECOPOINTS]'))
    SET IDENTITY_INSERT [TB_ECOPOINTS] OFF;
GO

UPDATE [TB_ECOPONTO] SET [Email] = N'ecoponto1@example.com', [PasswordHash] = 0xFA571767E02A7F0211EA56AB9A25B613D93F7124B39951BA6C60256798DAF08532AF6725554035D7B69B4DD51613CFECA9634B671C011C267A1EAE0973166159, [PasswordSalt] = 0x4ABF8A19CB4A516DF08D22B3350B376BCABABEE86E00D238FC331819219E7EEA1E2DBF8D791FFDA7D8A5094140D50862239F93471D597A0924B76A895D16B67181F7FA959F536B64B2C19834BE78DDE8F6496542B6202D872A9AEED4FF91886D5FC31EA82F8D7ECDA4F37430BECF06802B2123DFBAB428FBE1A01842BA696EC0, [Username] = N'Ecoponto1'
WHERE [IdEcoponto] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_ECOPONTO] SET [Email] = N'ecoponto2@example.com', [PasswordHash] = 0xFA571767E02A7F0211EA56AB9A25B613D93F7124B39951BA6C60256798DAF08532AF6725554035D7B69B4DD51613CFECA9634B671C011C267A1EAE0973166159, [PasswordSalt] = 0x4ABF8A19CB4A516DF08D22B3350B376BCABABEE86E00D238FC331819219E7EEA1E2DBF8D791FFDA7D8A5094140D50862239F93471D597A0924B76A895D16B67181F7FA959F536B64B2C19834BE78DDE8F6496542B6202D872A9AEED4FF91886D5FC31EA82F8D7ECDA4F37430BECF06802B2123DFBAB428FBE1A01842BA696EC0, [Username] = N'Ecoponto2'
WHERE [IdEcoponto] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_UTILIZADOR] SET [DataAcesso] = NULL, [PasswordHash] = 0xFA571767E02A7F0211EA56AB9A25B613D93F7124B39951BA6C60256798DAF08532AF6725554035D7B69B4DD51613CFECA9634B671C011C267A1EAE0973166159, [PasswordSalt] = 0x4ABF8A19CB4A516DF08D22B3350B376BCABABEE86E00D238FC331819219E7EEA1E2DBF8D791FFDA7D8A5094140D50862239F93471D597A0924B76A895D16B67181F7FA959F536B64B2C19834BE78DDE8F6496542B6202D872A9AEED4FF91886D5FC31EA82F8D7ECDA4F37430BECF06802B2123DFBAB428FBE1A01842BA696EC0, [Username] = N'UsuarioJoao'
WHERE [IdUtilizador] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_UTILIZADOR] SET [DataAcesso] = NULL, [PasswordHash] = 0xFA571767E02A7F0211EA56AB9A25B613D93F7124B39951BA6C60256798DAF08532AF6725554035D7B69B4DD51613CFECA9634B671C011C267A1EAE0973166159, [PasswordSalt] = 0x4ABF8A19CB4A516DF08D22B3350B376BCABABEE86E00D238FC331819219E7EEA1E2DBF8D791FFDA7D8A5094140D50862239F93471D597A0924B76A895D16B67181F7FA959F536B64B2C19834BE78DDE8F6496542B6202D872A9AEED4FF91886D5FC31EA82F8D7ECDA4F37430BECF06802B2123DFBAB428FBE1A01842BA696EC0, [Username] = N'UsuarioMaria'
WHERE [IdUtilizador] = 2;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdUtilizador', N'DataAcesso', N'Email', N'Nome', N'PasswordHash', N'PasswordSalt', N'SituacaoEmail', N'Username') AND [object_id] = OBJECT_ID(N'[TB_UTILIZADOR]'))
    SET IDENTITY_INSERT [TB_UTILIZADOR] ON;
INSERT INTO [TB_UTILIZADOR] ([IdUtilizador], [DataAcesso], [Email], [Nome], [PasswordHash], [PasswordSalt], [SituacaoEmail], [Username])
VALUES (3, '2024-05-19T16:21:16.8373072-03:00', N'admin@example.com', N'Admin', 0xFA571767E02A7F0211EA56AB9A25B613D93F7124B39951BA6C60256798DAF08532AF6725554035D7B69B4DD51613CFECA9634B671C011C267A1EAE0973166159, 0x4ABF8A19CB4A516DF08D22B3350B376BCABABEE86E00D238FC331819219E7EEA1E2DBF8D791FFDA7D8A5094140D50862239F93471D597A0924B76A895D16B67181F7FA959F536B64B2C19834BE78DDE8F6496542B6202D872A9AEED4FF91886D5FC31EA82F8D7ECDA4F37430BECF06802B2123DFBAB428FBE1A01842BA696EC0, CAST(1 AS bit), N'Admin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdUtilizador', N'DataAcesso', N'Email', N'Nome', N'PasswordHash', N'PasswordSalt', N'SituacaoEmail', N'Username') AND [object_id] = OBJECT_ID(N'[TB_UTILIZADOR]'))
    SET IDENTITY_INSERT [TB_UTILIZADOR] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240519192117_AddNewModelsWithSeedData', N'8.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [TB_BRINDE] SET [Validade] = '2025-05-19T16:51:58.9501543-03:00'
WHERE [IdBrinde] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_BRINDE] SET [Validade] = '2025-05-19T16:51:58.9501553-03:00'
WHERE [IdBrinde] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETA] SET [DataColeta] = '2024-05-19T16:51:58.9501505-03:00'
WHERE [IdColeta] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETA] SET [DataColeta] = '2024-05-19T16:51:58.9501519-03:00'
WHERE [IdColeta] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_ECOPONTO] SET [PasswordHash] = 0x4CBA2AF988B53B72C57D3C73ECB54DF687D4392A46A3F9CA4A755E65F88D2012804BBAF77D94FE53406BD3C790A6BE608CE7060A8EEF4E2A33F50BB183676E38, [PasswordSalt] = 0xA1333C455DC182ECC0A1B348D7D968B4A2FA5A21767CCFD4B6677A7DE98F12D5954EF1677EC91DAF3B5F648EF5560E74FEEFBA79C26213144B0B39F9193EE801F6547405FEF11A0460D36D5BF21BBB6150972D4ECBE79AD12B9AD99308EF560279B0C2C404F21577FE6923480C466BB9BEA89C329C25CFDE38F8A610DD48539E
WHERE [IdEcoponto] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_ECOPONTO] SET [PasswordHash] = 0x4CBA2AF988B53B72C57D3C73ECB54DF687D4392A46A3F9CA4A755E65F88D2012804BBAF77D94FE53406BD3C790A6BE608CE7060A8EEF4E2A33F50BB183676E38, [PasswordSalt] = 0xA1333C455DC182ECC0A1B348D7D968B4A2FA5A21767CCFD4B6677A7DE98F12D5954EF1677EC91DAF3B5F648EF5560E74FEEFBA79C26213144B0B39F9193EE801F6547405FEF11A0460D36D5BF21BBB6150972D4ECBE79AD12B9AD99308EF560279B0C2C404F21577FE6923480C466BB9BEA89C329C25CFDE38F8A610DD48539E
WHERE [IdEcoponto] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_UTILIZADOR] SET [PasswordHash] = 0x4CBA2AF988B53B72C57D3C73ECB54DF687D4392A46A3F9CA4A755E65F88D2012804BBAF77D94FE53406BD3C790A6BE608CE7060A8EEF4E2A33F50BB183676E38, [PasswordSalt] = 0xA1333C455DC182ECC0A1B348D7D968B4A2FA5A21767CCFD4B6677A7DE98F12D5954EF1677EC91DAF3B5F648EF5560E74FEEFBA79C26213144B0B39F9193EE801F6547405FEF11A0460D36D5BF21BBB6150972D4ECBE79AD12B9AD99308EF560279B0C2C404F21577FE6923480C466BB9BEA89C329C25CFDE38F8A610DD48539E
WHERE [IdUtilizador] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_UTILIZADOR] SET [PasswordHash] = 0x4CBA2AF988B53B72C57D3C73ECB54DF687D4392A46A3F9CA4A755E65F88D2012804BBAF77D94FE53406BD3C790A6BE608CE7060A8EEF4E2A33F50BB183676E38, [PasswordSalt] = 0xA1333C455DC182ECC0A1B348D7D968B4A2FA5A21767CCFD4B6677A7DE98F12D5954EF1677EC91DAF3B5F648EF5560E74FEEFBA79C26213144B0B39F9193EE801F6547405FEF11A0460D36D5BF21BBB6150972D4ECBE79AD12B9AD99308EF560279B0C2C404F21577FE6923480C466BB9BEA89C329C25CFDE38F8A610DD48539E
WHERE [IdUtilizador] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_UTILIZADOR] SET [DataAcesso] = '2024-05-19T16:51:58.9501560-03:00', [PasswordHash] = 0x4CBA2AF988B53B72C57D3C73ECB54DF687D4392A46A3F9CA4A755E65F88D2012804BBAF77D94FE53406BD3C790A6BE608CE7060A8EEF4E2A33F50BB183676E38, [PasswordSalt] = 0xA1333C455DC182ECC0A1B348D7D968B4A2FA5A21767CCFD4B6677A7DE98F12D5954EF1677EC91DAF3B5F648EF5560E74FEEFBA79C26213144B0B39F9193EE801F6547405FEF11A0460D36D5BF21BBB6150972D4ECBE79AD12B9AD99308EF560279B0C2C404F21577FE6923480C466BB9BEA89C329C25CFDE38F8A610DD48539E
WHERE [IdUtilizador] = 3;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240519195159_recreate', N'8.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[TB_ECOPOINTS].[EcoPointsTotais]', N'UtilizadorId', N'COLUMN';
GO

ALTER TABLE [TB_UTILIZADOR] ADD [TotalEcoPoints] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [TB_ECOPOINTS] ADD [TotalEcoPoints] int NOT NULL DEFAULT 0;
GO

UPDATE [TB_BRINDE] SET [Validade] = '2025-05-25T14:35:05.0119226-03:00'
WHERE [IdBrinde] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_BRINDE] SET [Validade] = '2025-05-25T14:35:05.0119239-03:00'
WHERE [IdBrinde] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETA] SET [DataColeta] = '2024-05-25T14:35:05.0119176-03:00'
WHERE [IdColeta] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETA] SET [DataColeta] = '2024-05-25T14:35:05.0119194-03:00'
WHERE [IdColeta] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_ECOPOINTS] SET [TotalEcoPoints] = 0, [UtilizadorId] = 0
WHERE [IdMaterial] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_ECOPOINTS] SET [TotalEcoPoints] = 0, [UtilizadorId] = 0
WHERE [IdMaterial] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_ECOPONTO] SET [PasswordHash] = 0xD9B31D8C2F3F66801B1AC00BC41A75ED5459F17A2500AB13085DC75968D433472435BF9F4E4398A8180D2FDC4AEE4CBD5A060D56A42E8EF1F1CAA9062B702923, [PasswordSalt] = 0xDC08A55856CA539BEB5B19787AFB6D3BB1020B11E5C5BC7E7FF107236245395A21814C1AB4AE334F98EE40C12108E5B9CC08EFB558A5356D7832A04068828F51E9BB7AFC841A5BAAF75DAE2D50079D80EA733673378E3BD7D97A9AF5973E813993813C6751D3E43A03EF5090D25A07121B56248BCE4B11B58BE2030FE27F280E
WHERE [IdEcoponto] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_ECOPONTO] SET [PasswordHash] = 0xD9B31D8C2F3F66801B1AC00BC41A75ED5459F17A2500AB13085DC75968D433472435BF9F4E4398A8180D2FDC4AEE4CBD5A060D56A42E8EF1F1CAA9062B702923, [PasswordSalt] = 0xDC08A55856CA539BEB5B19787AFB6D3BB1020B11E5C5BC7E7FF107236245395A21814C1AB4AE334F98EE40C12108E5B9CC08EFB558A5356D7832A04068828F51E9BB7AFC841A5BAAF75DAE2D50079D80EA733673378E3BD7D97A9AF5973E813993813C6751D3E43A03EF5090D25A07121B56248BCE4B11B58BE2030FE27F280E
WHERE [IdEcoponto] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_UTILIZADOR] SET [PasswordHash] = 0xD9B31D8C2F3F66801B1AC00BC41A75ED5459F17A2500AB13085DC75968D433472435BF9F4E4398A8180D2FDC4AEE4CBD5A060D56A42E8EF1F1CAA9062B702923, [PasswordSalt] = 0xDC08A55856CA539BEB5B19787AFB6D3BB1020B11E5C5BC7E7FF107236245395A21814C1AB4AE334F98EE40C12108E5B9CC08EFB558A5356D7832A04068828F51E9BB7AFC841A5BAAF75DAE2D50079D80EA733673378E3BD7D97A9AF5973E813993813C6751D3E43A03EF5090D25A07121B56248BCE4B11B58BE2030FE27F280E, [TotalEcoPoints] = 0
WHERE [IdUtilizador] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_UTILIZADOR] SET [PasswordHash] = 0xD9B31D8C2F3F66801B1AC00BC41A75ED5459F17A2500AB13085DC75968D433472435BF9F4E4398A8180D2FDC4AEE4CBD5A060D56A42E8EF1F1CAA9062B702923, [PasswordSalt] = 0xDC08A55856CA539BEB5B19787AFB6D3BB1020B11E5C5BC7E7FF107236245395A21814C1AB4AE334F98EE40C12108E5B9CC08EFB558A5356D7832A04068828F51E9BB7AFC841A5BAAF75DAE2D50079D80EA733673378E3BD7D97A9AF5973E813993813C6751D3E43A03EF5090D25A07121B56248BCE4B11B58BE2030FE27F280E, [TotalEcoPoints] = 0
WHERE [IdUtilizador] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_UTILIZADOR] SET [DataAcesso] = '2024-05-25T14:35:05.0119249-03:00', [PasswordHash] = 0xD9B31D8C2F3F66801B1AC00BC41A75ED5459F17A2500AB13085DC75968D433472435BF9F4E4398A8180D2FDC4AEE4CBD5A060D56A42E8EF1F1CAA9062B702923, [PasswordSalt] = 0xDC08A55856CA539BEB5B19787AFB6D3BB1020B11E5C5BC7E7FF107236245395A21814C1AB4AE334F98EE40C12108E5B9CC08EFB558A5356D7832A04068828F51E9BB7AFC841A5BAAF75DAE2D50079D80EA733673378E3BD7D97A9AF5973E813993813C6751D3E43A03EF5090D25A07121B56248BCE4B11B58BE2030FE27F280E, [TotalEcoPoints] = 0
WHERE [IdUtilizador] = 3;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_TB_ECOPOINTS_UtilizadorId] ON [TB_ECOPOINTS] ([UtilizadorId]);
GO

ALTER TABLE [TB_ECOPOINTS] ADD CONSTRAINT [FK_TB_ECOPOINTS_TB_UTILIZADOR_UtilizadorId] FOREIGN KEY ([UtilizadorId]) REFERENCES [TB_UTILIZADOR] ([IdUtilizador]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240525173505_RelacaoUtilizadores', N'8.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [TB_ECOPOINTS] DROP CONSTRAINT [FK_TB_ECOPOINTS_TB_UTILIZADOR_UtilizadorId];
GO

DROP INDEX [IX_TB_ECOPOINTS_UtilizadorId] ON [TB_ECOPOINTS];
GO

EXEC sp_rename N'[TB_ECOPOINTS].[UtilizadorId]', N'IdUtilizador', N'COLUMN';
GO

ALTER TABLE [TB_UTILIZADOR] ADD [Latitude] float NOT NULL DEFAULT 0.0E0;
GO

ALTER TABLE [TB_UTILIZADOR] ADD [Longitude] float NOT NULL DEFAULT 0.0E0;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_ECOPONTO]') AND [c].[name] = N'Longitude');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TB_ECOPONTO] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [TB_ECOPONTO] ALTER COLUMN [Longitude] float NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_ECOPONTO]') AND [c].[name] = N'Latitude');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [TB_ECOPONTO] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [TB_ECOPONTO] ALTER COLUMN [Latitude] float NULL;
GO

UPDATE [TB_BRINDE] SET [Validade] = '2025-06-13T15:28:27.4039196-03:00'
WHERE [IdBrinde] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_BRINDE] SET [Validade] = '2025-06-13T15:28:27.4039208-03:00'
WHERE [IdBrinde] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETA] SET [DataColeta] = '2024-06-13T15:28:27.4039040-03:00'
WHERE [IdColeta] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETA] SET [DataColeta] = '2024-06-13T15:28:27.4039058-03:00'
WHERE [IdColeta] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_ECOPOINTS] SET [IdUtilizador] = 1
WHERE [IdMaterial] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_ECOPOINTS] SET [IdUtilizador] = 2
WHERE [IdMaterial] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_ECOPONTO] SET [Latitude] = 192.0E0, [Longitude] = 193.0E0, [PasswordHash] = 0xAD2BAE8DDB923B921AD93AFD35B44F3B1A91D1A639C3E24B2B7366D915087967C4BBA23938D56F586DE27CE7896CD424DE76AC41442F22ACF1A4129B76B20B52, [PasswordSalt] = 0x752BF2ECE17F7263FD092B044FEA146688A21F4B24AA7D00D1CD424215AA620F980F32815A640404E8EC15FDE87A92C7310967C3DE174362E7600221B30482E65B7BE91C763C62967C55565B7A42F2C9B5C2D99D4AE8706E01CF44D1214001F2CAF55342ED21A571434F7FA7FDBA55430750BC581859900B44FC974B0A2F0E5E
WHERE [IdEcoponto] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_ECOPONTO] SET [Latitude] = 192.0E0, [Longitude] = 193.0E0, [PasswordHash] = 0xAD2BAE8DDB923B921AD93AFD35B44F3B1A91D1A639C3E24B2B7366D915087967C4BBA23938D56F586DE27CE7896CD424DE76AC41442F22ACF1A4129B76B20B52, [PasswordSalt] = 0x752BF2ECE17F7263FD092B044FEA146688A21F4B24AA7D00D1CD424215AA620F980F32815A640404E8EC15FDE87A92C7310967C3DE174362E7600221B30482E65B7BE91C763C62967C55565B7A42F2C9B5C2D99D4AE8706E01CF44D1214001F2CAF55342ED21A571434F7FA7FDBA55430750BC581859900B44FC974B0A2F0E5E
WHERE [IdEcoponto] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_UTILIZADOR] SET [Latitude] = 0.0E0, [Longitude] = 0.0E0, [PasswordHash] = 0xAD2BAE8DDB923B921AD93AFD35B44F3B1A91D1A639C3E24B2B7366D915087967C4BBA23938D56F586DE27CE7896CD424DE76AC41442F22ACF1A4129B76B20B52, [PasswordSalt] = 0x752BF2ECE17F7263FD092B044FEA146688A21F4B24AA7D00D1CD424215AA620F980F32815A640404E8EC15FDE87A92C7310967C3DE174362E7600221B30482E65B7BE91C763C62967C55565B7A42F2C9B5C2D99D4AE8706E01CF44D1214001F2CAF55342ED21A571434F7FA7FDBA55430750BC581859900B44FC974B0A2F0E5E, [TotalEcoPoints] = 100
WHERE [IdUtilizador] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_UTILIZADOR] SET [Latitude] = 0.0E0, [Longitude] = 0.0E0, [PasswordHash] = 0xAD2BAE8DDB923B921AD93AFD35B44F3B1A91D1A639C3E24B2B7366D915087967C4BBA23938D56F586DE27CE7896CD424DE76AC41442F22ACF1A4129B76B20B52, [PasswordSalt] = 0x752BF2ECE17F7263FD092B044FEA146688A21F4B24AA7D00D1CD424215AA620F980F32815A640404E8EC15FDE87A92C7310967C3DE174362E7600221B30482E65B7BE91C763C62967C55565B7A42F2C9B5C2D99D4AE8706E01CF44D1214001F2CAF55342ED21A571434F7FA7FDBA55430750BC581859900B44FC974B0A2F0E5E, [TotalEcoPoints] = 100
WHERE [IdUtilizador] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_UTILIZADOR] SET [DataAcesso] = '2024-06-13T15:28:27.4039231-03:00', [Latitude] = 0.0E0, [Longitude] = 0.0E0, [PasswordHash] = 0xAD2BAE8DDB923B921AD93AFD35B44F3B1A91D1A639C3E24B2B7366D915087967C4BBA23938D56F586DE27CE7896CD424DE76AC41442F22ACF1A4129B76B20B52, [PasswordSalt] = 0x752BF2ECE17F7263FD092B044FEA146688A21F4B24AA7D00D1CD424215AA620F980F32815A640404E8EC15FDE87A92C7310967C3DE174362E7600221B30482E65B7BE91C763C62967C55565B7A42F2C9B5C2D99D4AE8706E01CF44D1214001F2CAF55342ED21A571434F7FA7FDBA55430750BC581859900B44FC974B0A2F0E5E
WHERE [IdUtilizador] = 3;
SELECT @@ROWCOUNT;

GO

CREATE UNIQUE INDEX [IX_TB_UTILIZADOR_TotalEcoPoints] ON [TB_UTILIZADOR] ([TotalEcoPoints]);
GO

ALTER TABLE [TB_UTILIZADOR] ADD CONSTRAINT [FK_TB_UTILIZADOR_TB_ECOPOINTS_TotalEcoPoints] FOREIGN KEY ([TotalEcoPoints]) REFERENCES [TB_ECOPOINTS] ([IdMaterial]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240613182828_NewDataBase', N'8.0.4');
GO

COMMIT;
GO

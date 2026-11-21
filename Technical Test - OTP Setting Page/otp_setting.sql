SET NOCOUNT ON;
GO

IF OBJECT_ID(N'dbo.OtpSettings', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.OtpSettings
    (
        Id INT IDENTITY(1,1) NOT NULL,
        ActionCode NVARCHAR(50) NOT NULL,
        ActionName NVARCHAR(100) NOT NULL,
        IsEmailEnabled BIT NOT NULL CONSTRAINT DF_OtpSettings_IsEmailEnabled DEFAULT (0),
        IsWhatsappEnabled BIT NOT NULL CONSTRAINT DF_OtpSettings_IsWhatsappEnabled DEFAULT (0),
        UpdatedAt DATETIME2(7) NOT NULL CONSTRAINT DF_OtpSettings_UpdatedAt DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT PK_OtpSettings PRIMARY KEY CLUSTERED (Id ASC),
        CONSTRAINT UQ_OtpSettings_ActionCode UNIQUE NONCLUSTERED (ActionCode ASC)
    );
END;
GO

MERGE dbo.OtpSettings AS target
USING (
    VALUES
        (N'WITHDRAWAL', N'Withdrawal', 0, 0),
        (N'FORGOT_PASSWORD', N'Forgot Password', 0, 0),
        (N'RESET_PASSWORD', N'Reset Password', 0, 0)
) AS source (ActionCode, ActionName, IsEmailEnabled, IsWhatsappEnabled)
ON (target.ActionCode = source.ActionCode)
WHEN MATCHED THEN
    UPDATE SET
        target.ActionName = source.ActionName
WHEN NOT MATCHED BY TARGET THEN
    INSERT (ActionCode, ActionName, IsEmailEnabled, IsWhatsappEnabled, UpdatedAt)
    VALUES (source.ActionCode, source.ActionName, source.IsEmailEnabled, source.IsWhatsappEnabled, SYSUTCDATETIME());
GO

CREATE OR ALTER PROCEDURE dbo.usp_UpdateOtpSetting
    @Id INT,
    @IsEmailEnabled BIT,
    @IsWhatsappEnabled BIT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.OtpSettings
    SET
        IsEmailEnabled = @IsEmailEnabled,
        IsWhatsappEnabled = @IsWhatsappEnabled,
        UpdatedAt = SYSUTCDATETIME()
    WHERE Id = @Id;

    RETURN @@ROWCOUNT;
END;
GO

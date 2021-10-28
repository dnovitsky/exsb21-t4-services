DROP TABLE IF EXISTS GoogleUserAccessTokens;
create table GoogleUserAccessTokens(
        Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
        Expires_in BIGINT,
        Created_in BIGINT,
        Email VARCHAR(255) UNIQUE,
        Access_token VARCHAR(255) UNIQUE,
        Refresh_token VARCHAR(255) UNIQUE,
        Scope VARCHAR(255),
        Token_type VARCHAR(255)
);

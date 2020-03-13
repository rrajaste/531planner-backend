------------------------------------------------------------------------------------------------------------------------

-- Set up Database

IF db_id('raraja_softdelete') IS NOT NULL BEGIN
    USE master
    DROP DATABASE "raraja_softdelete"
END
GO

CREATE DATABASE "raraja_softdelete"
GO

USE "raraja_softdelete"
GO

------------------------------------------------------------------------------------------------------------------------

-- Create tables

CREATE TABLE AppUser(
    AppUserId INT NOT NULL IDENTITY(1,1),
    UserName VARCHAR(255),
    created_at DATETIME NOT NULL,
    deleted_at DATETIME NOT NULL,
    comment TEXT,
    PRIMARY KEY (AppUserId, deleted_at)
)

CREATE TABLE DailyNutritionIntake(
    DailyNutritionIntakeId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    AppUserId INT NOT NULL,
    AppUserDeletedAt DATETIME NOT NULL,
    Calories INT NOT NULL,
    Protein INT,
    Carbohydrates INT,
    Fats INT,
    created_at DATETIME NOT NULL,
    deleted_at DATETIME NOT NULL,
    comment TEXT,
    FOREIGN KEY (AppUserId, AppUserDeletedAt) REFERENCES AppUser(AppUserId, deleted_at)
    ON UPDATE CASCADE,
)

CREATE TABLE UserPhoto(
    UserPhotoId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    AppUserId INT NOT NULL,
    AppUserDeletedAt DATETIME NOT NULL,
    PhotoSerialized TEXT,
    created_at DATETIME NOT NULL,
    deleted_at DATETIME NOT NULL,
    comment TEXT,
    FOREIGN KEY (AppUserId, AppUserDeletedAt) REFERENCES AppUser(AppUserId, deleted_at)
    ON UPDATE CASCADE,
    UNIQUE (AppUserId, AppUserDeletedAt, deleted_at)
)


------------------------------------------------------------------------------------------------------------------------


-- Insert test data

INSERT INTO AppUser (UserName, created_at, deleted_at) values ('John', CURRENT_TIMESTAMP, '9999-12-31 23:59:59')
INSERT INTO AppUser (UserName, created_at, deleted_at) values ('Jack', CURRENT_TIMESTAMP, '9999-12-31 23:59:59')
INSERT INTO AppUser (UserName, created_at, deleted_at) values ('Jill', CURRENT_TIMESTAMP, '9999-12-31 23:59:59')
INSERT INTO AppUser (UserName, created_at, deleted_at) values ('Joe', CURRENT_TIMESTAMP, '9999-12-31 23:59:59')


INSERT INTO DailyNutritionIntake (AppUserId, AppUserDeletedAt, Calories, Protein, Carbohydrates, Fats, created_at, deleted_at)
VALUES(1, '9999-12-31 23:59:59', 3000, 125, 255, 56, CURRENT_TIMESTAMP, '9999-12-31 23:59:59')

INSERT INTO DailyNutritionIntake (AppUserId, AppUserDeletedAt, Calories, Protein, Carbohydrates, Fats, created_at, deleted_at)
VALUES(1, '9999-12-31 23:59:59', 2999, 124, 256, 16, CURRENT_TIMESTAMP, '9999-12-31 23:59:59')

INSERT INTO DailyNutritionIntake (AppUserId, AppUserDeletedAt, Calories, Protein, Carbohydrates, Fats, created_at, deleted_at)
VALUES(2, '9999-12-31 23:59:59', 1923, 221, 255, 99, CURRENT_TIMESTAMP, '9999-12-31 23:59:59')

INSERT INTO DailyNutritionIntake (AppUserId, AppUserDeletedAt, Calories, Protein, Carbohydrates, Fats, created_at, deleted_at)
VALUES(2, '9999-12-31 23:59:59', 3000, 125, 253, 56, CURRENT_TIMESTAMP, '9999-12-31 23:59:59')

INSERT INTO DailyNutritionIntake (AppUserId, AppUserDeletedAt, Calories, Protein, Carbohydrates, Fats, created_at, deleted_at)
VALUES(2, '9999-12-31 23:59:59', 3000, 125, 253, 56, CURRENT_TIMESTAMP, '9999-12-31 23:59:59')

INSERT INTO DailyNutritionIntake (AppUserId, AppUserDeletedAt, Calories, Protein, Carbohydrates, Fats, created_at, deleted_at)
VALUES(3, '9999-12-31 23:59:59', 3000, 125, 253, 56, CURRENT_TIMESTAMP, '9999-12-31 23:59:59')


INSERT INTO UserPhoto (AppUserId, AppUserDeletedAt, PhotoSerialized, created_at, deleted_at)
VALUES (1, '9999-12-31 23:59:59', 'askdjfhasdf', CURRENT_TIMESTAMP, '9999-12-31 23:59:59')
INSERT INTO UserPhoto (AppUserId, AppUserDeletedAt, PhotoSerialized, created_at, deleted_at)
VALUES (2, '9999-12-31 23:59:59', 'ggfdgdfg', CURRENT_TIMESTAMP, '9999-12-31 23:59:59')
INSERT INTO UserPhoto (AppUserId, AppUserDeletedAt, PhotoSerialized, created_at, deleted_at)
VALUES (3, '9999-12-31 23:59:59', 'sdfgdsfgsd', CURRENT_TIMESTAMP, '9999-12-31 23:59:59')
INSERT INTO UserPhoto (AppUserId, AppUserDeletedAt, PhotoSerialized, created_at, deleted_at)
VALUES (4, '9999-12-31 23:59:59', 'hhghdfhghdg', CURRENT_TIMESTAMP, '9999-12-31 23:59:59')

------------------------------------------------------------------------------------------------------------------------

-- Try to insert another photo for a user that already has one, this is expected to fail (true 1:0-1 relationship)
-- Uncomment to test it

--INSERT INTO UserPhoto (AppUserId, AppUserDeletedAt, PhotoSerialized, created_at, deleted_at)
--VALUES (4, '9999-12-31 23:59:59', 'hhghdfhghdg', CURRENT_TIMESTAMP, '9999-12-31 23:59:59')


------------------------------------------------------------------------------------------------------------------------


-- Soft delete an AppUser (does not cascade delete related records in DailyNutritionIntake, this is by choice)

DECLARE @idOfUserToDelete int;
SET @idOfUserToDelete = 1;

UPDATE AppUser SET deleted_at = CURRENT_TIMESTAMP WHERE AppUserId = @idOfUserToDelete;


SELECT * from AppUser;
SELECT * from DailyNutritionIntake;


------------------------------------------------------------------------------------------------------------------------


-- Soft delete a record from DailyNutritionIntake that is related to an AppUser

DECLARE @idOfRecordToDelete int;
SET @idOfRecordToDelete = 5;

UPDATE DailyNutritionIntake SET deleted_at = CURRENT_TIMESTAMP WHERE DailyNutritionIntakeId = @idOfRecordToDelete;

SELECT * from AppUser;
SELECT * from DailyNutritionIntake;


------------------------------------------------------------------------------------------------------------------------

-- Soft update an AppUser

DECLARE @idOfUserToUpdate int;
DECLARE @newUserName VARCHAR(256);
SET @idOfUserToUpdate = 2;
SET @newUserName = 'UpdatedUserName1';

SET IDENTITY_INSERT AppUser ON;

INSERT INTO AppUser (AppUserId, UserName, created_at, deleted_at, comment)
SELECT AppUserId, UserName, created_at, CURRENT_TIMESTAMP, comment
FROM AppUser
WHERE AppUserId = @idOfUserToUpdate
  AND deleted_at > CURRENT_TIMESTAMP;

SET IDENTITY_INSERT AppUser OFF;

UPDATE AppUser
SET UserName = @newUserName, created_at = CURRENT_TIMESTAMP
WHERE AppUserId = @idOfUserToUpdate AND deleted_at > CURRENT_TIMESTAMP;

SELECT * from AppUser;
SELECT * from DailyNutritionIntake;

------------------------------------------------------------------------------------------------------------------------

-- Soft update a record from DailyNutritionIntake

DECLARE @idOfRecordToUpdate int;
DECLARE @newCalories int;
SET @idOfRecordToUpdate = 6;
SET @newCalories = 1;

INSERT INTO DailyNutritionIntake (AppUserId, AppUserDeletedAt, Calories, Protein, Carbohydrates, Fats, created_at, deleted_at, comment)
SELECT AppUserId, AppUserDeletedAt, Calories, Protein, Carbohydrates, Fats, created_at, CURRENT_TIMESTAMP, comment
FROM DailyNutritionIntake
WHERE DailyNutritionIntakeId = @idOfRecordToUpdate

UPDATE DailyNutritionIntake
SET Calories = @newCalories, created_at = CURRENT_TIMESTAMP
WHERE DailyNutritionIntakeId = @idOfRecordToUpdate AND deleted_at > CURRENT_TIMESTAMP;

SELECT * from AppUser;
SELECT * from DailyNutritionIntake;


------------------------------------------------------------------------------------------------------------------------


-- Query all AppUsers that were active in specified time

DECLARE @time DATETIME;
SET @time = '2020-03-09 20:26:58.667';

SELECT * FROM AppUser WHERE @time BETWEEN created_at AND deleted_at; -- Returns all users that were active at given time

SET @time = CURRENT_TIMESTAMP;

SELECT * FROM AppUser WHERE @time BETWEEN created_at AND deleted_at; -- Returns all currently active users


------------------------------------------------------------------------------------------------------------------------

-- Query all AppUsers and their DailyNutritionIntakes that were active in specified time

DECLARE @time2 DATETIME;
SET @time2 = CURRENT_TIMESTAMP;

SELECT * FROM AppUser a, DailyNutritionIntake d
WHERE @time2 BETWEEN a.created_at AND a.deleted_at
  AND @time2 BETWEEN d.created_at AND d.deleted_at
  AND a.AppUserId = d.AppUserId
  AND a.deleted_at = d.AppUserDeletedAt;

SET @time2 = '2020-03-09 20:29:58.592'; -- Set this to somewhere before record was soft updated/deleted to see the effect

SELECT * FROM AppUser a, DailyNutritionIntake d
WHERE @time2 BETWEEN a.created_at AND a.deleted_at
  AND @time2 BETWEEN d.created_at AND d.deleted_at
  AND a.AppUserId = d.AppUserId;

------------------------------------------------------------------------------------------------------------------------

-- Soft delete from UserPhoto (1:0-1 relationship dependent table)

DECLARE @idOfPhotoToDelete int;
SET @idOfPhotoToDelete = 4;

UPDATE UserPhoto SET deleted_at = CURRENT_TIMESTAMP WHERE UserPhotoId = @idOfPhotoToDelete;

SELECT * FROM UserPhoto;


------------------------------------------------------------------------------------------------------------------------

-- Soft update a record from UserPhoto (1:0-1 relationship dependent table)

DECLARE @idOfPhotoToUpdate int;
DECLARE @updatedPhotoSerialized VARCHAR(255);
SET @idOfPhotoToUpdate = 3;
SET @updatedPhotoSerialized = 'a';

INSERT INTO UserPhoto (AppUserId, AppUserDeletedAt, PhotoSerialized, created_at, deleted_at, comment)
SELECT AppUserId, AppUserDeletedAt, PhotoSerialized, created_at, CURRENT_TIMESTAMP, comment FROM UserPhoto
WHERE UserPhotoId = @idOfPhotoToUpdate;

UPDATE UserPhoto SET created_at = CURRENT_TIMESTAMP, PhotoSerialized = @updatedPhotoSerialized
WHERE UserPhotoId = @idOfPhotoToUpdate AND deleted_at > CURRENT_TIMESTAMP;

SELECT * FROM UserPhoto


------------------------------------------------------------------------------------------------------------------------

-- Query all photos that were active at given time (Must be ONE photo per AppUserId)

DECLARE @time4 DATETIME;
SET @time4 = '2020-03-09 20:21:40.123';

SELECT * FROM UserPhoto WHERE @time4 BETWEEN created_at AND deleted_at; -- Returns all photos that were active at given time

SET @time4 = CURRENT_TIMESTAMP;

SELECT * FROM UserPhoto WHERE @time4 BETWEEN created_at AND deleted_at; -- Returns all currently active photos


------------------------------------------------------------------------------------------------------------------------

-- Query all users and their photos (all users must have exactly one photos)

DECLARE @time3 DATETIME;
SET @time3 = CURRENT_TIMESTAMP;

SELECT * FROM AppUser a, UserPhoto p
WHERE @time3 BETWEEN a.created_at AND a.deleted_at AND @time3 BETWEEN p.created_at AND p.deleted_at
  AND a.AppUserId = p.AppUserId AND a.deleted_at = p.AppUserDeletedAt;

SET @time3 = '2020-03-09 20:32:34.407'; -- Set this to somewhere before record was soft updated/deleted to see the effect

SELECT * FROM AppUser a, UserPhoto p
WHERE @time3 BETWEEN a.created_at AND a.deleted_at AND @time3 BETWEEN p.created_at AND p.deleted_at
  AND a.AppUserId = p.AppUserId;

------------------------------------------------------------------------------------------------------------------------

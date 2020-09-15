
USE master;
GO

DROP DATABASE IF EXISTS FourteenersDb;
GO

CREATE DATABASE FourteenersDb;
GO

USE FourteenersDb;
GO


--   P e a k   T a b l e

CREATE TABLE Peak
(
   id          INT          NOT NULL PRIMARY KEY IDENTITY,
   name        NVARCHAR(40) NOT NULL,
   elevation   INT          NOT NULL,
   nearestTown NVARCHAR(40) NULL,
   county      NVARCHAR(20) NOT NULL
);

-- Test Data
INSERT
   INTO Peak
      (name, elevation, nearestTown, county)
   VALUES
      ('Mt. Elbert',    14433, 'Leadville',        'Lake'               ), -- 1
      ('Grays Peak',    14270, 'Keystone',         'Clear Creek, Summit'), -- 2
      ('Handies Peak',  14048, 'Ouray',            'Hinsdale'           ), -- 3
      ('Pikes Peak',    14110, 'Colorado Springs', 'El Paso'            ), -- 4
      ('Quandry Peak',  14265, 'Breckenridge',     'Summit'             ), -- 5
      ('San Luis Peak', 14014, 'Gunnison',         'Saguache'           ); -- 6

SELECT *
   FROM Peak
   ORDER BY elevation DESC;


--   T r a i l   T a b l e

CREATE TABLE Trail
(
   id               INT           NOT NULL PRIMARY KEY IDENTITY,
   name             NVARCHAR(40)  NULL,
   distance         DECIMAL(4, 1) NOT NULL,
   startingAltitude INT           NOT NULL,
   peakId           INT           NOT NULL, -- Foreign Key To Peak

   CONSTRAINT FK_Trail_Peak
      FOREIGN KEY(peakId)
      REFERENCES Peak(id),
);

-- Test Data
INSERT
   INTO Trail
      (name, distance, startingAltitude, peakId)
   VALUES
      ('Northeast Ridge',     9.5,  10040, 1),
      ('East Ridge',         10.5,  10500, 1),
      ('Black Cloud',        11,     9700, 1),
      ('Box Creek Couloirs',  8.5,  10400, 1),
      ('North Slope',         7.5,  10280, 2),
      ('American Basin',      5.5,  11600, 3),
      ('Barr Trail',         24,     6650, 4),
      ('Crags',              14,    10000, 4),
      ('Quandry',             6.75, 10850, 5),
      ('Stewart Creek',      13.5,  10500, 6),
      ('West Willow Creek',  11.25, 10500, 6);

SELECT *, Peak.elevation - Trail.startingAltitude AS altitudeGain
   FROM Trail
      INNER JOIN Peak
         ON Trail.peakId = Peak.id;

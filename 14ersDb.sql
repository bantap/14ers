
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

INSERT
   INTO Trail
      (name, distance, startingAltitude, peakId)
   VALUES
      ('Northeast Ridge',     9.5,  10040, 1), -- 1
      ('East Ridge',         10.5,  10500, 1), -- 2
      ('Black Cloud',        11,     9700, 1), -- 3
      ('Box Creek Couloirs',  8.5,  10400, 1), -- 4
      ('North Slope',         7.5,  10280, 2), -- 5
      ('American Basin',      5.5,  11600, 3), -- 6
      ('Barr Trail',         24,     6650, 4), -- 7
      ('Crags',              14,    10000, 4), -- 8
      ('Quandry',             6.75, 10850, 5), -- 9
      ('Stewart Creek',      13.5,  10500, 6), -- 10
      ('West Willow Creek',  11.25, 10500, 6); -- 11

SELECT *, Peak.elevation - Trail.startingAltitude AS altitudeGain
   FROM Trail
      INNER JOIN Peak
         ON Trail.peakId = Peak.id;


--   H i k e r   T a b l e   ( U s e r s )

CREATE TABLE Hiker
(
   id           INT           NOT NULL PRIMARY KEY IDENTITY,
   emailAddress NVARCHAR(80)  NOT NULL,
   password     NVARCHAR(400) NOT NULL,
   name         NVARCHAR(40)  NOT NULL,
);

INSERT
   INTO Hiker
      (emailAddress, password, name)
   VALUES
      ('PBanta101@GMail.Com', 'Wombat1', 'Paul Banta'), -- 1
      ('PBanta@Example.Com',  'Wombat1', 'Paul Banta'), -- 2
      ('BantaP@ERAU.Edu',     'Wombat1', 'Paul Banta'); -- 3

SELECT *
   FROM Hiker
   ORDER BY emailAddress;


--   H i k e   T a b l e   ( U s e r s )

CREATE TABLE Hike
(
   id             INT            NOT NULL PRIMARY KEY IDENTITY,
   date           DATE           NOT NULL,
   startTime      TIME           NULL,
   summitTime     TIME           NULL,
   endTime        TIME           NULL,
   duration       INT            NULL, -- Computed
   speedGoingUp   DECIMAL        NULL, -- Computed
   speedGoingDown DECIMAL        NULL, -- Computed
   trailCondition NVARCHAR(80)   NULL,
   weather        NVARCHAR(80)   NULL,
   notes          NVARCHAR(1000) NULL,
   share          BIT            NOT NULL DEFAULT 0,
   hikerId        INT            NOT NULL FOREIGN KEY REFERENCES Hiker(id),
   trailId        INT            NOT NULL FOREIGN KEY REFERENCES Trail(id)
);

INSERT
   INTO Hike
      (date, hikerId, trailId)
   VALUES
      ('20200901', 1, 1), -- 1
      ('20200902', 2, 2), -- 2
      ('20200903', 3, 3), -- 3
      ('20200904', 1, 4), -- 4
      ('20200905', 2, 5); -- 5

SELECT *
   FROM Hike
      INNER JOIN Hiker
         ON Hike.hikerId = Hiker.id
      INNER JOIN Trail
         ON Hike.trailId = Trail.id
      INNER JOIN Peak
         ON Trail.peakId = Peak.id;

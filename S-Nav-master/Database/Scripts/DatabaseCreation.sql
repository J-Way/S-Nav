USE tempdb;

DROP DATABASE S_NAV;

CREATE DATABASE S_NAV;

USE S_NAV;

CREATE TABLE CAMPUS (
	CAMPUS_ID INT IDENTITY(1,1) PRIMARY KEY,
	CAMPUS_NAME VARCHAR(50) NOT NULL UNIQUE,
);

CREATE TABLE WING (
	WING_ID INT IDENTITY(1,1) PRIMARY KEY,
	WING_NAME VARCHAR(25) NOT NULL,

	CAMPUS_ID INT FOREIGN KEY (CAMPUS_ID) REFERENCES CAMPUS(CAMPUS_ID)
);

CREATE TABLE FLOOR_LEVEL(
	FLOOR_ID INT IDENTITY(1,1) PRIMARY KEY,
	FLOOR_LEVEL INT NOT NULL,

	WING_ID INT FOREIGN KEY(WING_ID) REFERENCES WING(WING_ID)
);

CREATE TABLE ROOM(
	ROOM_ID INT IDENTITY(1,1) PRIMARY KEY,
	ROOM_NUMBER VARCHAR (10) NOT NULL,
	ROOM_TYPE VARCHAR(100),

	FLOOR_ID INT FOREIGN KEY(FLOOR_ID) REFERENCES FLOOR_LEVEL(FLOOR_ID)
);
-- SQLite
DROP TABLE TEAMS;
--DROP TABLE favorite_beers;

CREATE TABLE TEAMS(ID INTEGER PRIMARY KEY, teamWins INTEGER, teamLosses INTEGER, ptsForSeason INTEGER, ptsAgainstSeason INTEGER, name VARCHAR(50));

INSERT INTO TEAMS (teamWins, teamLosses, ptsForSeason, ptsAgainstSeason, name) VALUES (0,0,0,0,"ATENEO");
INSERT INTO TEAMS (teamWins, teamLosses, ptsForSeason, ptsAgainstSeason, name) VALUES (0,0,0,0,"AGLO");
INSERT INTO TEAMS (teamWins, teamLosses, ptsForSeason, ptsAgainstSeason, name) VALUES (0,0,0,0,"THT");
INSERT INTO TEAMS (teamWins, teamLosses, ptsForSeason, ptsAgainstSeason, name) VALUES (0,0,0,0,"AMERIKA");
INSERT INTO TEAMS (teamWins, teamLosses, ptsForSeason, ptsAgainstSeason, name) VALUES (0,0,0,0,"PROYECTO BASQUET");
INSERT INTO TEAMS (teamWins, teamLosses, ptsForSeason, ptsAgainstSeason, name) VALUES (0,0,0,0,"SHOLEM");
INSERT INTO TEAMS (teamWins, teamLosses, ptsForSeason, ptsAgainstSeason, name) VALUES (0,0,0,0,"TRIGLAV");
INSERT INTO TEAMS (teamWins, teamLosses, ptsForSeason, ptsAgainstSeason, name) VALUES (0,0,0,0,"SAHORES");
INSERT INTO TEAMS (teamWins, teamLosses, ptsForSeason, ptsAgainstSeason, name) VALUES (0,0,0,0,"CABALLITO HEADS");
INSERT INTO TEAMS (teamWins, teamLosses, ptsForSeason, ptsAgainstSeason, name) VALUES (0,0,0,0,"BETAM");

--SELECT * FROM TEAMS;

--REVISAR IDS PARA QUE SEAN AUTOINCREMENTALES
CREATE TABLE PLAYERS (
ID INTEGER PRIMARY KEY,
FIRST_NAME varchar(255) NOT NULL,
LAST_NAME varchar(255) NOT NULL,
AGE INTEGER,
HEIGHT INTEGER,
insideShooting INTEGER,
perimeterShooting INTEGER,
threePointShooting INTEGER,
passing INTEGER,
freeThrow INTEGER,
handling INTEGER,
onBallDefense INTEGER,
insideDefense INTEGER,
stealing INTEGER,
block INTEGER,
offRebounding INTEGER,
defRebounding INTEGER,
totalPoints INTEGER,
TEAM INTEGER,
shootInsideTendencyMax INTEGER,
shootInsideTendencyMin INTEGER,
shootThreeTendencyMax INTEGER,
shootThreeTendencyMin INTEGER,
passBallTendencyMax INTEGER,
passBallTendencyMin INTEGER,
stealTendencyMax INTEGER,
stealTendencyMin INTEGER,
blockTendencyMax INTEGER,
blockTendencyMin INTEGER,
foulTendencyMax INTEGER,
foulTendencyMin INTEGER,
FOREIGN KEY(TEAM) REFERENCES TEAMS(ID));
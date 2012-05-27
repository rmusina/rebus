USE [ReBus];

DELETE FROM StationLine;
DELETE FROM Stations;
DELETE FROM TicketCost;
DELETE FROM SubscriptionCosts;
DELETE FROM Tickets;
DELETE FROM SubscriptionLine;
DELETE FROM Subscriptions;
DELETE FROM Transactions;
DELETE FROM Accounts;
DELETE FROM Buses;
DELETE FROM Lines;

INSERT INTO TicketCost(Cost)
VALUES
 (1.75);

INSERT INTO Lines(Name)
VALUES
 ('4'),
 ('30'),
 ('24b');

 INSERT INTO Lines([GUID], Name)
 VALUES 
 ('b615c93d-9521-4cf4-9c7b-fd9c0e887f50', '24'),
 ('3283560b-1ffe-44d6-b7db-55ea02927a20', '25'),
 ('c59e5f4f-e1bb-42b6-924d-cc790492be11', '6');

INSERT INTO Buses(LineGUID)
SELECT [GUID] FROM Lines;

INSERT INTO Buses(LineGUID)
SELECT [GUID] FROM Lines;

INSERT INTO SubscriptionCosts(Lines, Cost)
VALUES
	(0, 100),
	(1, 50),
	(2, 75);

INSERT INTO Accounts(Username, PasswordHash, FirstName, LastName, Credit, IsTicketController)
VALUES
 ('a', 'a', 'Alexandru', 'Spiridon', 200, 'false'),
 ('b', 'b', 'Rares', 'Musina', 150, 'true'),
 ('c', 'c', 'Razvan', 'Jurca', 100, 'false');


 INSERT INTO Tickets(AccountGUID, BusGUID, Created)
 SELECT a.[GUID], b.[GUID], CURRENT_TIMESTAMP
 FROM Accounts a, Buses b INNER JOIN Lines l on b.LineGUID = l.[GUID]  WHERE a.Username = 'a' AND (l.Name = '4' OR l.Name = '6' OR l.Name = '48')

 
 INSERT INTO Tickets(AccountGUID, BusGUID, Created)
 SELECT a.[GUID], b.[GUID], CURRENT_TIMESTAMP
 FROM Accounts a, Buses b INNER JOIN Lines l on b.LineGUID = l.[GUID]  WHERE a.Username = 'a' AND (l.Name = '6' OR l.Name = '30')

 
 INSERT INTO Tickets(AccountGUID, BusGUID, Created)
 SELECT a.[GUID], b.[GUID], CURRENT_TIMESTAMP
 FROM Accounts a, Buses b INNER JOIN Lines l on b.LineGUID = l.[GUID]  WHERE a.Username = 'a' AND (l.Name = '6' OR l.Name = '30')

 
 INSERT INTO Tickets(AccountGUID, BusGUID, Created)
 SELECT a.[GUID], b.[GUID], CURRENT_TIMESTAMP
 FROM Accounts a, Buses b INNER JOIN Lines l on b.LineGUID = l.[GUID]  WHERE a.Username = 'a' AND (l.Name = '48')


 
 INSERT INTO Tickets(AccountGUID, BusGUID, Created)
 SELECT a.[GUID], b.[GUID], CURRENT_TIMESTAMP
 FROM Accounts a, Buses b INNER JOIN Lines l on b.LineGUID = l.[GUID]  WHERE a.Username = 'b' AND (l.Name = '4' OR l.Name = '6')
 
 INSERT INTO Tickets(AccountGUID, BusGUID, Created)
 SELECT a.[GUID], b.[GUID], CURRENT_TIMESTAMP
 FROM Accounts a, Buses b INNER JOIN Lines l on b.LineGUID = l.[GUID]  WHERE a.Username = 'b' AND (l.Name = '25' OR l.Name = '6')
 
 INSERT INTO Tickets(AccountGUID, BusGUID, Created)
 SELECT a.[GUID], b.[GUID], CURRENT_TIMESTAMP
 FROM Accounts a, Buses b INNER JOIN Lines l on b.LineGUID = l.[GUID]  WHERE a.Username = 'b' AND (l.Name = '24b')

 
 INSERT INTO Tickets(AccountGUID, BusGUID, Created)
 SELECT a.[GUID], b.[GUID], CURRENT_TIMESTAMP
 FROM Accounts a, Buses b INNER JOIN Lines l on b.LineGUID = l.[GUID]  WHERE a.Username = 'c' AND (l.Name = '25' OR l.Name = '48')

 
 INSERT INTO Tickets(AccountGUID, BusGUID, Created)
 SELECT a.[GUID], b.[GUID], CURRENT_TIMESTAMP
 FROM Accounts a, Buses b INNER JOIN Lines l on b.LineGUID = l.[GUID]  WHERE a.Username = 'c' AND (l.Name = '4')


 INSERT INTO Subscriptions([GUID], AccountGUID, Start, [End], Created)
 SELECT '75c8242f-2d20-4f04-a137-1752c48763f6', [GUID], dateadd(day, -10, CURRENT_TIMESTAMP), dateadd(day, 20, CURRENT_TIMESTAMP), dateadd(day, -11, CURRENT_TIMESTAMP)
	FROM Accounts WHERE Username = 'a';

INSERT INTO SubscriptionLine(Lines_GUID, Subscriptions_GUID)
SELECT [GUID], '75c8242f-2d20-4f04-a137-1752c48763f6' FROM Lines WHERE Name = '24';

	
 INSERT INTO Subscriptions(AccountGUID, Start, [End], Created)
 SELECT [GUID], dateadd(day, -50, CURRENT_TIMESTAMP), dateadd(day, -20, CURRENT_TIMESTAMP), dateadd(day, -50, CURRENT_TIMESTAMP)
	FROM Accounts WHERE Username = 'a';


 INSERT INTO Subscriptions([GUID], AccountGUID, Start, [End], Created)
 SELECT '9ad3434b-ac48-4106-9971-a4ef05fc10dc', [GUID], dateadd(day, -5, CURRENT_TIMESTAMP), dateadd(day, 25, CURRENT_TIMESTAMP), dateadd(day, -10, CURRENT_TIMESTAMP)
	FROM Accounts WHERE Username = 'b';
	
INSERT INTO SubscriptionLine(Lines_GUID, Subscriptions_GUID)
SELECT [GUID], '9ad3434b-ac48-4106-9971-a4ef05fc10dc' FROM Lines WHERE Name = '6';
	
 INSERT INTO Subscriptions([GUID], AccountGUID, Start, [End], Created)
 SELECT 'cafa6d8c-b6f4-4def-970c-38dc021c94c1', [GUID], dateadd(day, 10, CURRENT_TIMESTAMP), dateadd(day, 40, CURRENT_TIMESTAMP), CURRENT_TIMESTAMP
	FROM Accounts WHERE Username = 'c';
	
INSERT INTO SubscriptionLine(Lines_GUID, Subscriptions_GUID)
SELECT [GUID], 'cafa6d8c-b6f4-4def-970c-38dc021c94c1' FROM Lines WHERE Name = '25';

INSERT INTO Transactions(AccountGUID, Amount, AssociatedGUID, Created, [Type])
SELECT [GUID], 250, NULL, CURRENT_TIMESTAMP, 0 FROM Accounts WHERE Username = 'a';

INSERT INTO Transactions(AccountGUID, Amount, AssociatedGUID, Created, [Type])
SELECT [GUID], 50, '75c8242f-2d20-4f04-a137-1752c48763f6', CURRENT_TIMESTAMP, 2 FROM Accounts WHERE Username = 'a';


INSERT INTO Stations(Name, Latitude, Longitude)
VALUES
('Memorandumului I', 46.769496, 23.586663),             	-- 1
('Memorandumului II', 46.769571,	 23.587218),			-- 2
('Regionala I',	46.773309	, 23.597306),					-- 3
('Regionala II',	 46.772935	, 23.596968),				-- 4
('Somesului I',	 46.775992	,23.604690),					-- 5
('Somesului II',	 46.775927	, 23.605123),				-- 6
('Piatza Marasti I',	46.777869	, 23.611514),			-- 7
('Piatza Marasti II',	 46.777669	, 23.611641),			-- 8
('Maresal Constantin Prezan',	 46.778334	,23.616046),	-- 9
( 'Arte',	 46.778736,	23.616266),							-- 10
( 'Dorobanti',	 46.777305	, 23.620113),					-- 11
( 'Campus Universitar II',	 46.773951,	 23.621691),		-- 12
( 'Campus Universitar I',	 46.774048	, 23.621961),		-- 13
( 'Iulius Mall II',	 46.771319	, 23.625384),				-- 14
( 'Iulius Mall I',	 46.771387	 ,23.625742),				-- 15
( 'Unirii II',	 46.768899	, 23.629496),					-- 16
('Unirii I',	 46.768574	, 23.630220),					-- 17
( 'Spitalul de copii I',	46.766339	, 23.579967),		-- 18
( 'Spitalul de copii II',	 46.766232	 ,23.580060),		-- 19
( 'Agronomie I',	 46.763804	, 23.573487),				-- 20
( 'Agronomie II',	 46.763725,	 23.573710),				-- 21
( 'Campului I',	 46.760882	, 23.564024),					-- 22
( 'Campului II',	 46.760678	, 23.564429),				-- 23
( 'Peco',	 46.758991	, 23.551528),						-- 24
( 'Peco II',	 46.758584	, 23.550947),					-- 25
( 'Calea Floresti I',	 46.757593	, 23.544685),			-- 26
( 'Calea Floresti II',	 46.757291	, 23.545074),			-- 27
( 'Bucium I',	 46.752637	, 23.543537),					-- 28
( 'Bucium II',	 46.752530	, 23.543994),					-- 29
('Snagov',  46.767981, 23.628343),							-- 30
('Borsec', 46.768313, 23.621856),							-- 31
('Nicolae Titulesc',  46.769212, 23.615664),				-- 32
('Septimiu Albini', 46.769043, 23.607382),					-- 33
('Piata Cipariu', 46.768149,  23.599513),					-- 34
('Piatza Avram Iancu',  46.769857,  23.598420),				-- 35
('Grigore Alexandrescu', 46.756967,  23.556471),			-- 36
('Minerva I',  46.754363,  23.555354),						-- 37
('Bucium I',  46.751578,  23.545635),						-- 38
('Bucium II',  46.751204,  23.545108),						-- 39
('Minerva II',  46.753931,  23.554874),						-- 40
('Izlazului', 46.755062,  23.562482),						-- 41
('Siretului I',  46.780641,  23.627983), 					-- 42
('Siretului II',  46.780457,  23.627462),					-- 43
('Atlas I',  46.781718,  23.636455),						-- 44
('Atlas II',  46.781509,  23.636132);						-- 45


-- 24
INSERT INTO StationLine(Lines_GUID, Stations_Id)
VALUES
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',17),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',15),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',13),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',10),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',7),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',3),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',1),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',18),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',20),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',22),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',24),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',26),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',28),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',29),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',27),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',25),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',23),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',21),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',19),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',2),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',4),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',6),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',8),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',9),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',11),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',12),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',14),
('b615c93d-9521-4cf4-9c7b-fd9c0e887f50',16);

-- 25
INSERT INTO StationLine(Lines_GUID, Stations_Id)
VALUES
('3283560b-1ffe-44d6-b7db-55ea02927a20', 16),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 30),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 31),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 32),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 33),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 34),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 35),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 1),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 18),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 20),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 22),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 36),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 37),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 38),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 39),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 40),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 41),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 23),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 21),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 19),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 2),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 4),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 6),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 8),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 9),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 11),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 12),
('3283560b-1ffe-44d6-b7db-55ea02927a20', 14);

-- 6
INSERT INTO StationLine(Lines_GUID, Stations_Id)
VALUES
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 44),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 42),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 10),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 7),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 5),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 3),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 1),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 18),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 20),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 22),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 36),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 37),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 38),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 39),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 40),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 41),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 23),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 21),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 19),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 2),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 4),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 6),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 8),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 9),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 43),
('c59e5f4f-e1bb-42b6-924d-cc790492be11', 45);
USE [ReBus];

DELETE FROM BusStopLine;
DELETE FROM BusStops;
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
 ('25'),
 ('4'),
 ('6'),
 ('30'),
 ('24b'),
 ('25b');

 INSERT INTO Lines([GUID], Name)
 VALUES ('b615c93d-9521-4cf4-9c7b-fd9c0e887f50', '24');

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
 ('a', 'a', 'Alexandru', 'Spiridon', 200, 'true'),
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


INSERT INTO BusStops(Name, Latitude, Longitude)
VALUES
('Memorandumului I', 46.769496, 23.586663),
('Memorandumului II', 46.769571,	 23.587218),
('Regionala I',	46.773309	, 23.597306),
('Regionala II',	 46.772935	, 23.596968),
('Somesului I',	 46.775992	,23.604690),
('Somesului II',	 46.775927	, 23.605123),
('Piatza Marasti I',	46.777869	, 23.611514),
('Piatza Marasti II',	 46.777669	, 23.611641),
('Maresal Constantin Prezan',	 46.778334	,23.616046),
( 'Arte',	 46.778736,	23.616266),
( 'Dorobanti',	 46.777305	, 23.620113),
( 'Campus Universitar II',	 46.773951,	 23.621691),
( 'Campus Universitar I',	 46.774048	, 23.621961),
( 'Iulius Mall II',	 46.771319	, 23.625384),
( 'Iulius Mall I',	 46.771387	 ,23.625742),
( 'Unirii II',	 46.768899	, 23.629496),
('Unirii I',	 46.768574	, 23.630220),
( 'Spitalul de copii I',	46.766339	, 23.579967),
( 'Spitalul de copii II',	 46.766232	 ,23.580060),
( 'Agronomie I',	 46.763804	, 23.573487),
( 'Agronomie II',	 46.763725,	 23.573710),
( 'Campului I',	 46.760882	, 23.564024),
( 'Campului II',	 46.760678	, 23.564429),
( 'Peco',	 46.758991	, 23.551528),
( 'Peco II',	 46.758584	, 23.550947),
( 'Calea Floresti I',	 46.757593	, 23.544685),
( 'Calea Floresti II',	 46.757291	, 23.545074),
( 'Bucium I',	 46.752637	, 23.543537),
( 'Bucium II',	 46.752530	, 23.543994);

INSERT INTO BusStopLine(Lines_GUID, BusStops_Id)
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

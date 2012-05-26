USE [ReBus];

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
 ('24'),
 ('25'),
 ('4'),
 ('6'),
 ('30'),
 ('24b'),
 ('25b');

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
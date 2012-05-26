USE [ReBus];

DELETE FROM TicketCost;
DELETE FROM Buses;
DELETE FROM Lines;
DELETE FROM SubscriptionCosts;

INSERT INTO TicketCost(Cost)
VALUES
 (1.75);

INSERT INTO Lines(Name)
VALUES
 ('24'),
 ('25'),
 ('4'),
 ('6'),
 ('30')
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


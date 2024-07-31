INSERT INTO [dbo].[Countries] (CountryName, CountryCode)
VALUES
('United States', 'US'),
('Canada', 'CA'),
('China', 'CN'),
('Germany', 'DE'),
('Australia', 'AU');
 

 INSERT INTO [dbo].[Sports] (SportName)
VALUES
('Swimming'),
('Athletics'),
('Gymnastics'),
('Cycling'),
('Boxing');


INSERT INTO [dbo].[Athletes] (Name, CountryID, SportID, Birthdate)
VALUES
('Michael Phelps', 1, 1, '1985-06-30'),
('Usain Bolt', 3, 2, '1986-08-21'),
('Simone Biles', 1, 3, '1997-03-14'),
('Chris Hoy', 2, 4, '1976-03-23'),
('Muhammad Ali', 1, 5, '1942-01-17'),
('Ian Thorpe', 5, 1, '1982-10-13'),
('Donovan Bailey', 2, 2, '1967-12-16'),
('Nadia Comaneci', 3, 3, '1961-11-12'),
('Victoria Pendleton', 2, 4, '1980-09-24'),
('Manny Pacquiao', 4, 5, '1978-12-17'),
('Sun Yang', 3, 1, '1991-12-01'),
('Yohan Blake', 3, 2, '1989-12-26'),
('Aly Raisman', 1, 3, '1994-05-25'),
('Bradley Wiggins', 2, 4, '1980-04-28'),
('Joe Frazier', 4, 5, '1944-01-12'),
('Cameron McEvoy', 5, 1, '1994-05-13'),
('Andre De Grasse', 2, 2, '1994-11-10'),
('Zou Kai', 3, 3, '1988-02-25'),
('Anna Meares', 5, 4, '1983-09-21'),
('Wladimir Klitschko', 4, 5, '1976-03-25');


INSERT INTO [dbo].[Medals] (AthleteID, SportID, MedalType, DateAwarded)
VALUES
(1, 1, 'Gold', '2008-08-12'),
(1, 1, 'Gold', '2012-08-04'),
(2, 2, 'Gold', '2012-08-05'),
(3, 3, 'Gold', '2016-08-11'),
(5, 5, 'Gold', '1960-09-05'),
(7, 2, 'Gold', '1996-07-27'),
(11, 1, 'Gold', '2012-07-30'),
(13, 3, 'Silver', '2016-08-14'),
(16, 1, 'Bronze', '2016-08-10'),
(20, 5, 'Gold', '2000-09-30');

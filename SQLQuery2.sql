INSERT INTO [dbo].[TestData] (NumA, NumB, Expected, Actual)
VALUES 
(2, 4, 6, NULL),
(10, 20, 30, NULL),
(10, -3, 7, NULL),
(50, -50, 0, NULL),

(-5, -8, -13, NULL),
(-100, -200, -300, NULL),

(15, 0, 15, NULL),
(0, 25, 25, NULL),

(2147483647, -2147483648, -1, NULL),
(0, 0, 0, NULL)


CREATE TABLE Member (
	id INT PRIMARY KEY IDENTITY(1,1),
	fn VARCHAR(62),
	mn VARCHAR(62),
	ln VARCHAR(62),
	dn VARCHAR(30),
	dob DATETIME,
	dod DATETIME,
	note VARCHAR(2000),
	crt DATETIME NOT NULL DEFAULT GETDATE(),
	upd DATETIME
)
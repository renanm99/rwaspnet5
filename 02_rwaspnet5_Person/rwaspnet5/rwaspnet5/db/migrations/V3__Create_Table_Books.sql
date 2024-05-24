
CREATE TABLE dbo.books (
  id bigint identity NOT NULL,
  author varchar(100) NOT NULL,
  launch_date datetime NOT NULL,
  price money NOT NULL,
  title varchar(100) NOT NULL
    primary key (id));

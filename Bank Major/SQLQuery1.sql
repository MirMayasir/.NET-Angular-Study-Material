Create database Wiprongadb

use Wiprongadb
create table Student
(
sid int,
sname varchar(20) not null,
age int,
marks float,
result bit
)

insert into student values(101,'ABCD',23,90,1)

alter table Student add primary key(sid)

ALTER TABLE Student
ALTER COLUMN sid int NOT NULL;

ALTER TABLE Student ADD CONSTRAINT PK_Student PRIMARY KEY (sid);

create table courses
(
cid int primary key,
cname varchar(20),
fees float
)
alter table student add courseid int references courses(cid)
insert into courses values(1, 'React', 1000), (2,'.NET',7354), (3,'Nodejs', 2000);
select * from courses
delete from courses where cid = 5; 
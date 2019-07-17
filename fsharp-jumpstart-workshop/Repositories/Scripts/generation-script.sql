sqlite3 fsharpjumpstart.db

create table members (id integer not null primary key, first_name text not null, last_name text not null, email text unique, plan_id text);

insert into members values 
(1, 'John', 'Smith', 'john@email.com', 'plan_1'),
(2, 'Jim', 'Jones', 'jim@email.com', 'plan_1'),
(3, 'Doug', 'West', 'doug@email.com', 'plan_1'),
(4, 'Tim', 'Lama', 'tim@email.com', 'plan_1'),
(5, 'Liam', 'Tony', 'liam@email.com', 'plan_1'),
(6, 'Tommy', 'Villis', 'tommy@email.com', 'plan_1'),
(7, 'Tami', 'Jones', 'tami@email.com', 'plan_1'),
(8, 'Samantha', 'Westbrook', 'samantha@email.com', 'plan_1'),
(9, 'Ginny', 'Lawson', 'ginny@email.com', 'plan_1'),
(10, 'Heather', 'Stonson', 'heather@email.com', 'plan_1')
;
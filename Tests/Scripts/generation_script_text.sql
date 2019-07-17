sqlite3 testingdb.db

create table members (id integer not null primary key, first_name text not null, last_name text not null, email text unique, plan_id text);

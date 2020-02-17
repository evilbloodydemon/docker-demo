create database ddemo;

\c ddemo

create table people
(
    id         serial not null
        constraint people_pkey
            primary key,
    first_name text   not null,
    last_name  text   not null,
    birthdate  date   not null
);

alter table people
    owner to postgres;
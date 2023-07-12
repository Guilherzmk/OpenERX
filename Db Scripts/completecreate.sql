use db_openerx

if(OBJECT_ID('tb_address') is not null)
	drop table tb_address

go

create table tb_address
(
id uniqueidentifier primary key not null,
parent_id uniqueidentifier not null,
parent_type varchar(50) not null,
type_code int,
[type_name] varchar(50),
prefix varchar(150),
street varchar(150) not null,
number varchar(50),
complement varchar(50),
district varchar(150),
city varchar(150),
state varchar(2),
country varchar(150),
zip_code varchar(8),
[index] int,
note varchar(255)
)

go

if(OBJECT_ID('tb_email') is not null)
	drop table tb_email

go

create table tb_email
(
id uniqueidentifier primary key not null,
parent_id uniqueidentifier not null,
parent_type varchar(50) not null,
type_code int,
[type_name] varchar(50),
address varchar(255),
note varchar(8000)
)

go

if(OBJECT_ID('tb_customer') is not null)
	drop table tb_customer

go

create table tb_customer
(
id uniqueidentifier primary key not null,
code int,
type_code int not null,
[type_name] varchar(150),
name varchar(150) not null,
nickname varchar(150) not null,
display varchar(255),
birth_date datetime,
person_type_code int not null,
person_type_name varchar(150),
[identity] varchar(20) not null,
external_code varchar(50),
status_code int not null,
status_name varchar(150),
status_date datetime,
status_color varchar(25),
status_note varchar(255),
origin_id uniqueidentifier not null,
origin_code int not null,
origin_name varchar(250),
note varchar(255),
account_id uniqueidentifier not null,
account_code int not null,
account_name varchar(150),
store_id uniqueidentifier not null,
store_code int not null,
store_name varchar(150),
broker_id uniqueidentifier not null,
broker_code int not null,
broker_name varchar(150),
creation_date datetime not null,
creation_user_id uniqueidentifier not null,
creation_user_name varchar(150),
change_date datetime,
change_user_id uniqueidentifier,
change_user_name varchar(150),
exclusion_date datetime,
exclusion_user_id uniqueidentifier,
exclusion_user_name varchar(150),
record_status_code int not null,
record_status_name varchar(150),
version_id uniqueidentifier,
previous_id uniqueidentifier,
version_date datetime
)

go

if(OBJECT_ID('tb_phone') is not null)
	drop table tb_phone

go

create table tb_phone
(
id uniqueidentifier primary key not null,
parent_id uniqueidentifier not null,
parent_type varchar(50) not null,
type_code int not null,
[type_name] varchar(150),
country_code varchar(10),
number varchar(25),
note varchar(8000)
)	

go

if(OBJECT_ID('tb_site') is not null)
	drop table tb_site

go

create table tb_site
(
id uniqueidentifier primary key,
parent_id uniqueidentifier not null,
parent_type varchar(50) not null,
type_code int not null,
[type_name] varchar(150),
address varchar(150),
note varchar(8000)
)

if(OBJECT_ID('tb_user') is not null)
	drop table tb_user

go

create table tb_user
(
id uniqueidentifier primary key not null,
code int not null,
name varchar(255) not null,
access_key varchar(150) not null,
password varchar(150) not null,
email varchar(255),
phone varchar(20),
type_code int not null,
[type_name] varchar(255),
profile_code int not null,
profile_name varchar(255),
status_code int not null,
status_name varchar(255),
last_access DateTime,
access_count int not null,
enabled int not null,
avatar varchar(8000),
note varchar(8000),
broker_id uniqueidentifier not null,
account_id uniqueidentifier not null,
creation_date DateTime not null,
creation_user_id uniqueidentifier not null,
creation_user_name varchar(150) not null,
change_date DateTime,
change_user_id uniqueidentifier,
change_user_name varchar(150),
exclusion_date DateTime,
exclusion_user_id uniqueidentifier,
exclusion_user_name varchar(150),
record_status int
)
go

if(OBJECT_ID('tb_profile') is not null)
	drop table tb_profile
go

create table tb_profile
(
id uniqueidentifier primary key not null,
code int not null,
parent_id uniqueidentifier not null,
parent_type varchar(50) not null,
name varchar(150),
note varchar(8000)
)
go

if(OBJECT_ID('tb_profile_auths') is not null)
	drop table tb_profile_auths
go

create table tb_profile_auths
(
id uniqueidentifier primary key not null,
code int not null,
parent_id uniqueidentifier not null,
parent_type varchar(150) not null,
name varchar(150),
note varchar(8000)
)





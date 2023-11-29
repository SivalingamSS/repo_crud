use training2023
CREATE TABLE TBM_regiter( R_ID int  primary key identity ,NAME varchar(50),
Age int ,Address varchar(50),PH_number int)


create table TBM_Regiter_STUD( stud_ID int primary key identity, Gender varchar(50),
E_ID varchar(50), R_ID int)

ALTER TABLE TBM_Regiter_STUD
ADD FOREIGN KEY (R_ID) REFERENCES TBM_regiter(R_ID)

select * from TBM_Regiter_STUD
select * from TBM_regiter

drop table TBM_regiter
drop table TBM_Regiter_STUD
alter table TBM_Regiter_STUD
add stud_ID int primary key

Alter PROCEDURE  SPM_Procedures
@R_ID INT , @NAME varchar(50),@Age int ,@Address varchar(50),@PH_number int ,@Gender varchar(50),@E_ID  varchar (50)
AS
begin 
set nocount on ;
insert into TBM_regiter (NAME,Age,Address,PH_number) values (@NAME,@Age,@Address,@PH_number);
DECLARE @ID INT=scope_Identity();
insert into TBM_Regiter_STUD(Gender,E_ID,R_ID) values (@Gender,@E_ID,@ID); 
	
end
GO


 DROP  PROCEDURE SPM_Procedures ;

select * from TBM_Regiter_STUD
select * from TBM_regiter

create procedure SPM_GetProcedure 
AS
begin 
set nocount on ;
select  sp.R_ID,sp.NAME,sp.Age,sp.Address,sp.PH_number,s.E_ID,s.Gender from 
TBM_regiter sp
inner join TBM_Regiter_STUD s on sp.R_ID=s.R_ID
end
exec SPM_GetProcedure

create procedure SPM_Deleteprocedure @R_ID int
as begin 

delete  from TBM_regiter where R_ID=@R_ID
delete  from  TBM_Regiter_STUD where  R_ID= @R_ID
end

exec SPM_Deleteprocedure

create procedure SPM_Puteprocedure @R_ID INT=null , @NAME varchar(50) =null,@Age int=null ,@Address varchar(50)=null,@PH_number int =null,@Gender varchar(50)=null,@E_ID  varchar (50) =null

as begin 
UPDATE TBM_regiter SET  

			NAME = @NAME, 
		    Age = @Age,  
			Address = @Address, 
			PH_number = @PH_number	
			
		WHERE R_ID = @R_ID 
UPDATE TBM_Regiter_STUD SET  
           Gender=@Gender,
		   E_ID=@E_ID
		   WHERE R_ID = @R_ID 
end
drop procedure SPM_Puteprocedure







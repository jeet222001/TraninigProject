alter table [User]
 add constraint df_dt
	Default GETDATE() FOR Date_Reg

	alter table [User] add [Password] VARCHAR(128) 


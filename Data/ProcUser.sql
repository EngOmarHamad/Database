


--GetAllUsers  AddUsers UpdateUsers   DeleteUsersbyId


				create proc GetAllUsers
				as
				begin
				select user_id ,name,surname,username , password,gender,age,email,store_id
				from users
				end

				go

				create proc AddUsers
					@name varchar(50) ,
					@surname varchar(50) ,
					@user_name varchar(50) ,
				    @password int ,
				    @gender int ,
				    @age int ,
				    @email varchar(50) ,
				    @store_id int 	
				as
				begin
				insert into users values(@name,@surname,@user_name,@password,@gender,@age,@email,@store_id)
				end
				go

				create proc UpdateUsers
				@user_id int ,
					@name varchar(50) ,
					@surname varchar(50) ,
					@user_name varchar(50) ,
				    @password int ,
				    @gender int ,
				    @age int ,
				    @email varchar(50) ,
				    @store_id int 	
				as
				begin
				update users 
				set 
				 name=@name ,
				 surname=@surname, 
				 username=@user_name, 
				 password=@password ,
				 gender=@gender ,
				 age=@age ,
				 email=@email, 
				 store_id=@store_id 
				

				where user_id=@user_id
				end

				go

				create proc DeleteUsersbyId
				 @user_id int
				  as
				begin
				
				delete from  users where  user_id=@user_id

				end




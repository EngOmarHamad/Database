
				create proc GetAllDevelopers
				as
				begin
				select developer_id , name,website from developers
				end

				go

				create proc AddDevelopers
				@name  varchar(50),@website varchar(50)
				as
				begin
				insert into developers values(@name,@website)

				end
				go

				create proc UpdateDeveloper
					@developer_id int ,@name  varchar(50),@website varchar(50)
				as
				begin

				update developers 
				set name=@name , website=@website
				where developer_id=@developer_id


				end

				go

				create proc DeleteDevelpor
					@developer_id int
				as
				begin
				
				delete from  developers where developer_id= @developer_id

				end





						

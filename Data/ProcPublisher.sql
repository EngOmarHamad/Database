-- GetAllPublishers   AddPubliser  UpdatePubliser  DeletePubliserbyId




				create proc GetAllPublishers
				as
				begin
				select publisher_id ,name,country,website
				from publishers
				end

				go

				create proc AddPubliser
					@name varchar(50) ,
					@country  varchar(50) ,
					@website  varchar(50) 
					
				as
				begin
				insert into publishers values(@name,@country,@website)
				end
				go

				create proc UpdatePubliser
				   @publisher_id int ,
					@name varchar(50) ,
					@country  varchar(50) ,
					@website  varchar(50) 
				as
				begin
				update publishers 
				set name=@name,
				 country=@country , 
				 website=@website 

				where publisher_id=@publisher_id
				end

				go

				create proc DeletePubliserbyId
				  @publisher_id int 
				  as
				begin
				
				delete from  publishers where publisher_id= @publisher_id

				end





						

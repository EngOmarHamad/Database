--GetAllstores  AddStore UpdateStore   DeleteStorebyId


				create proc GetAllstores
				as
				begin
				select store_id ,country
				from stores
				end

				go

				create proc AddStore
					@country varchar(50) 
					
					
				as
				begin
				insert into stores values(@country)
				end
				go

				create proc UpdateStore
				  @store_id int ,
					@country varchar(50) 
				as
				begin
				update stores 
				set 
				 country=@country 
				

				where store_id=@store_id
				end

				go

				create proc DeleteStorebyId
				 @store_id int
				  as
				begin
				
				delete from  stores where  store_id=@store_id

				end




-- GetAllWishlists  AddWishlists   UpdateWishlists   DeleteWishlistsbyId

create proc GetAllWishlists
				as
				begin
				select wish_id ,user_id,game_id,date 
				from wishlists
				end

				go

				create proc AddWishlists
					@user_id int ,
					@game_id int ,
					@date varchar(50) 
				   
				as
				begin
				insert into wishlists values(@user_id,@game_id,@date)

				end
				go

				create proc UpdateWishlists
				@wish_id int ,
					@user_id int ,
					@game_id int ,
					@date varchar(50) 
				as
				begin
				update wishlists 
				set 
				 user_id=@user_id ,
				 game_id=@game_id, 
				 date=@date
				 
				

				where wish_id=@wish_id
				end

				go

				create proc DeleteWishlistsbyId
				 @wish_id int
				  as
				begin
				
				delete from  wishlists where  wish_id=@wish_id

				end


--GetAllOrders  AddOrder  UpdateOrder  DeleteOrder


				create proc GetAllOrders
				as
				begin
				select order_id ,user_id,game_id,price,payment_id,date 
				from orders
				end

				go

				create proc
				AddOrder
				
					@user_id int ,
					@game_id int ,
					@price int ,
					@payment_id int ,
					@date date 
				as
				begin
				insert into orders values(@user_id,@game_id,@price,@payment_id,@date)

				end
				go

				create proc UpdateOrder
				    @order_id int ,
					@user_id int ,
					@game_id int ,
					@price int ,
					@payment_id int ,
					@date date 
				as
				begin
				update orders 
				set price=@price,
				 user_id=@user_id , payment_id=@payment_id,
				 game_id=@game_id , date=@date

				where order_id=@order_id
				end

				go

				create proc DeleteOrder
					@order_id int
				as
				begin
				
				delete from  orders where order_id= @order_id

				end





						

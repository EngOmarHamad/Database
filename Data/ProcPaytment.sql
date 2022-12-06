-- GetAllPayments AddPayment  UpdatePayment  DeletePayment




				create proc GetAllPayments
				as
				begin
				select payment_id ,user_id,payment_type,card_number,valid
				from payments
				end

				go

				create proc AddPayment
					
					@user_id int ,
					@payment_type varchar(50) ,
					@card_number int ,
					@valid int 
				as
				begin
				insert into payments values(@user_id,@payment_type,@card_number,@valid)

				end
				go

				



				create proc UpdatePayment
				    @payment_id int ,
					@user_id int ,
					@payment_type varchar(50) ,
					@card_number int ,
					@valid int 
			
				as
				begin
				update payments 
				set payment_type=@payment_type,
				 user_id=@user_id , card_number=@card_number,
				 valid=@valid 

				where payment_id=@payment_id
				end

				go

				create proc DeletePayment
					@payment_id int
				as
				begin
				
				delete from  payments where payment_id= @payment_id

				end





						

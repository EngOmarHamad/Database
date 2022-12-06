    alter procedure GetAllGames 
    as 
        begin 
            SELECT [game_id]
                  ,[name]
                  ,[developer]
                  ,[publisher]
                  ,[store_id]
                  ,[genre]
                  ,[price]
                  ,[review]
                  ,[age_limit]
                  ,[release_date]
                  ,[except_country]
                  ,[description]
                  ,[IsObtainable]
              FROM [GameStroeProject].[dbo].[games]
        end

go


 create procedure AddGame 

              
                  @name varchar(33)
                  ,@developer int 
                  ,@publisher int 
                  ,@store_id int 
                  ,@genre varchar(52)
                  ,@price int 
                  ,@review int 
                  ,@age_limit  int 
                  ,@release_date varchar(11)
                  ,@except_country varchar(10)
                  ,@description varchar(763),
                  @IsObtainable varchar(1)

    as 
        begin 
            insert into games
                 

                  values(
             
                  @name
                  ,@developer
                  ,@publisher
                  ,@store_id
                  ,@genre
                  ,@price
                  ,@review
                  ,@age_limit
                  ,@release_date
                  ,@except_country
                  ,@description       ,
                  @IsObtainable 

                  )
        
        
        
        end
        
        
        go

 create procedure UpdateGame 

                   @game_id int 
                  ,@name varchar(33)
                  ,@developer int 
                  ,@publisher int 
                  ,@store_id int 
                  ,@genre varchar(52)
                  ,@price int 
                  ,@review int 
                  ,@age_limit  int 
                  ,@release_date varchar(11)
                  ,@except_country varchar(10)
                  ,@description varchar(763),
                  @IsObtainable varchar(1)

    as 
        begin 
            update games set 
                   name=@name
                  ,developer=@developer
                  ,publisher=@publisher
                  ,store_id=@store_id
                  ,genre=@genre
                  ,price=@price
                  ,review=@review
                  ,age_limit=@age_limit
                  ,release_date=@release_date
                  ,except_country=@except_country
                  ,description=@description
                  ,IsObtainable=@IsObtainable                   
                  where game_id=@game_id

                
        
        
        
        end

                go

                     alter procedure DeleteGamebyId 
                     @game_id int  
                     as 
                        begin 
                            delete from games where game_id=@game_id
                        end

             
             go




                 alter procedure Seacrh
                    @game_id int 
                  ,@name varchar(33)
                  ,@developer int 
                  ,@publisher int 
                  ,@store_id int 
                  ,@genre varchar(52)
                  ,@price int 
                  ,@review int 
                  ,@age_limit  int 
                  ,@release_date varchar(11)
                  ,@except_country varchar(10)
                  ,@description varchar(763),
                  @IsObtainable varchar(1)

                    as 
                        begin 
                            SELECT [game_id]
                                  ,[name]
                                  ,[developer]
                                  ,[publisher]
                                  ,[store_id]
                                  ,[genre]
                                  ,[price]
                                  ,[review]
                                  ,[age_limit]
                                  ,[release_date]
                                  ,[except_country]
                                  ,[description]
                                  ,[IsObtainable]

                              FROM [GameStroeProject].[dbo].[games] where
                              [game_id]=@game_id or
                              [name]=@name or
                              [developer]=@developer or
                              [publisher]=@publisher or
                              [store_id]=@store_id or 
                              [genre]=@genre or 
                              [price]=@price or
                              [review]=@review or 
                              [IsObtainable]=@IsObtainable or 
                              [age_limit]=@age_limit or
                              [release_date]=@release_date or
                              [except_country]=@except_country or
                              [description]=@description 
                      end

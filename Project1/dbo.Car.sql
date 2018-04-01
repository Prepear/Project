CREATE TABLE [dbo].[Car] (
    [car_id]        INT           IDENTITY (1, 1) NOT NULL,
    [car_serial]    NVARCHAR (50) NOT NULL,
    [seat_type]     NVARCHAR (50) NOT NULL,
    [seat_capacity] INT           NOT NULL,
    [train_set_model_id] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([car_id] ASC)
);


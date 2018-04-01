CREATE TABLE [dbo].[OperationCost]
(
	[operation_cost_id] INT NOT NULL PRIMARY KEY, 
    [o_station] NVARCHAR(50) NULL, 
    [d_station] NVARCHAR(50) NOT NULL, 
	 [train_set_model_id] INT NOT NULL,
    [train_set_type] NVARCHAR(50) NOT NULL, 
    [cost] INT NULL, 
    
)

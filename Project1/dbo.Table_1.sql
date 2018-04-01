DROP TABLE [dbo].[Table] (
    [operation_cost_id] INT           NOT NULL,
    [o_station]         NVARCHAR (50) NULL,
    [d_station]         NVARCHAR (50) NULL,
    [train_set_type]    NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([operation_cost_id] ASC)
);


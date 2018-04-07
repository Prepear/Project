select operation_cost_id,a.station_name as origin ,
		b.station_name as destination,
		o_station ,
			d_station ,train_set_model_name,OperationCost.train_set_model_id as train_set_model_id,train_set_type,cost
          FROM OperationCost
		 JOIN  Station a ON  a.station_id = OperationCost.o_station
		 JOIN  Station b ON  b.station_id = OperationCost.d_station
		JOIN TrainSetModel ON TrainSetModel.train_set_model_id = OperationCost.train_set_model_id
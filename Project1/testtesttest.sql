select operation_cost_id,station_name as origin ,station_name as destination,o_station ,
			d_station ,train_set_model_name,OperationCost.train_set_model_id as train_set_model_id,train_set_type,cost
          FROM OperationCost
		INNER JOIN Station
		ON  Station.station_id = OperationCost.o_station
		INNER JOIN 
		Station.station_id = OperationCost.d_station 
		INNER JOIN TrainSetModel
		ON TrainSetModel.train_set_model_id = OperationCost.train_set_model_id

			
									

								   
									
									
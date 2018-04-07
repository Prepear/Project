select station_name as destination,o_station, d_station
from OperationCost
join  Station   on OperationCost.d_station = Station.station_id
order by OperationCost.field<o_station>("destination")

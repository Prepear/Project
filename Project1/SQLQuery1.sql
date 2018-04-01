select station_id,station_name,station_type,line_name,sequence
from Station
inner join Line on Station.line_id = Line.line_id
where station_id = 3
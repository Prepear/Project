select station_id,station_name,station_type,line_name,sequence,Station.line_id as line_id
                                    from Station
                                    inner join Line on Station.line_id = Line.line_id



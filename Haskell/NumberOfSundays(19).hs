is_leap_year year = (rem year 4 == 0) && ((rem year 100 /= 0)  || (rem year 400 == 0))

month_days year | is_leap_year year =  [31,29,31,30,31,30,31,31,30,31,30,31] ++ (month_days (year+1))
				| otherwise = [31,28,31,30,31,30,31,31,30,31,30,31] ++ (month_days (year+1))

day_index =1:zipWith (\x y -> rem (x+y) 7) (month_days 1900) (day_index)

number_of_sundays_1901_to_2000 = length $ filter (==0) $ drop 12 $ take 1212 day_index
check_step num 'D' = (rem num 3) == 0
check_step num 'd' = (rem num 3) == 2
check_step num 'U' = (rem num 3) == 1

apply_step num 'D' = div num 3
apply_step num 'd' = div ((num * 2)-1) 3
apply_step num 'U' = div ((num * 4)+2) 3

reverse_step num 'D' = num *3 
reverse_step num 'd' = div ((num *3)+1) 2  
reverse_step num 'U' = div ((num *3)-2) 4

check_reverse_step num 'D' = True 
check_reverse_step num 'd' = (rem ((num*3)+1) 2)==0 
check_reverse_step num 'U' = (rem ((num*3)-2) 4)==0 

check_collatz [] _ = True
check_collatz (x:xs) num | (check_step num x) = check_collatz xs (apply_step num x)
		         | otherwise = False

first_collatz = head $ filter (check_collatz "UDDDUdddDDUDDddDdDddDDUDDdUUDd") [(10^15)..] 


generate_collatz_num [] num = num
generate_collatz_num (x:xs) num | (check_reverse_step num x) = generate_collatz_num xs (reverse_step num x)
				| otherwise = 0  

first_collatz_from_reverse = head $ filter ((>15).length.show) $ map (generate_collatz_num (reverse "UDDDUdddDDUDDddDdDddDDUDDdUUDd")) [22*(10^6)..23*(10^6)] 

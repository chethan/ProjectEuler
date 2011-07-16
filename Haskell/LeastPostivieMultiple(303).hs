least_multiple 9 = 1358
least_multiple 99 = 11335578
least_multiple 999 = 111333555778
least_multiple 9999 = 1111333355557778
least_multiple n = fst$head $ filter (is_binary.snd) $map (\a->(a,a*n))[1..] where is_binary num = all (\x-> x=='0'||x=='1' || x=='2')$show num

sum_of_multiples = sum$map least_multiple [1..10000]

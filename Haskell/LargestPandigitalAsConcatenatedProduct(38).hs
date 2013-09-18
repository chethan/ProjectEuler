import Data.List(sort)
import Data.Char(intToDigit)

is_pandigital num = (sort$temp)==['1'..intToDigit(length temp)] where temp = show num
get_pandigital start acc num| acc > (10^9) = 0
			    | acc > (10^8) = acc
			    | otherwise = get_pandigital (start+1) (read (show acc++show(num*start))::Int) num

maximum_pandigital=maximum$filter is_pandigital$map (\x->get_pandigital 2 x x) [1..10000]

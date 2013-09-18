import Data.Char(digitToInt)

is_reversible num = ((rem num 10)/=0) && (all (odd.digitToInt) $ show (num + read (reverse $ show num)::Int))

reversible_count_brute_force = length $ filter is_reversible [1..10^8]

reversible_count= 0 + 20*30^0 + 100*500^0 + 20*30^1 + 0 + 20*30^2 + 100*500^1 + 20*30^3 + 0

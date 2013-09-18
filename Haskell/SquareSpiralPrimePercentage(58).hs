import Data.Numbers.Primes(isPrime)
import Data.MemoTrie(memo)

diag = 1:3:5:7:zipWith (+) diag [8,10..]

prime_count n = length $filter isPrime$drop ((n-1)*4 +1)$take ((n*4)+1)$diag 

spiral_length = let temp n p |(div (p*100)((n*4)+1)) < 10 = n*2 + 1
		   	     |otherwise = temp (n+1) (p+(prime_count (n+1)))
	      in temp 1 3  

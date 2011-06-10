import Data.Numbers.Primes(isPrime)

expression_value n a b = (n*n) + (a*n)+b 

prime_seq_length a b = length $ takeWhile (isPrime.abs) $ map (\n->expression_value n a b) [0..]  

prime_seq_lengths =maximum$map (\b->maximum$(map (\a-> ((prime_seq_length a b),(a,b))) [-999,-997..999])) (filter isPrime [1..1000])

coeff_product = snd $ prime_seq_lengths

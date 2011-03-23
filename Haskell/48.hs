lastTenDigits (x:xs) = let temp (x:xs) acc =   temp xs (acc + mod (x ^ x) (100000000000))
                           temp [] acc =   acc
                       in temp (x:xs) 0
                        
lastTenDigits1 = sum ([n^n| n <- [1..1000]]) `mod` 10^10

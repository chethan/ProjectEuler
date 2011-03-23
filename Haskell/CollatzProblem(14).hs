import Data.List

collatzSequence startNum = let  nextNum n | even n = div n 2
                                          | otherwise = (3*n+1)
                                temp (xs) 1 = xs
                                temp (xs) num = temp (xs ++ [nextNum num]) (nextNum num)
                           in temp [startNum] startNum

largest xs startNum (len,num)   | (length xs) > len = (length xs,startNum)
                                | otherwise = (len,num)

final = let temp startNum (largeLen,largeStartNum) | startNum == 1000001 = (largeLen,largeStartNum)
                                                   | otherwise = temp (startNum+1) (largest (collatzSequence startNum) startNum (largeLen,largeStartNum))
        in temp 1 (0,1)




collatz_chain 1 = [1]
collatz_chain n | even n =    n : (collatz_chain $ div n 2)
                 | otherwise = n : (collatz_chain $ 3 * n + 1)

collatzip = zip [10..1000000] (map length $ map collatz_chain [10..1000000])

final1 = maximumBy (\a b -> compare (snd a) (snd b)) collatzip

    

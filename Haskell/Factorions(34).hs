import Data.Char (digitToInt)
 
isFactorion :: Int -> Bool
isFactorion n = (sum $ map ((\x -> product [1..x]) . digitToInt) $ show n) == n
 
factorions :: [Int]
factorions = filter isFactorion [1..2540160]
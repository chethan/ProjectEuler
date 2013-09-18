ackermann_function 0 n = n+1
ackermann_function m 0 = ackermann_function (m-1) 1
ackermann_function m n = ackermann_function (m-1) (ackermann_function m (n-1)) 
 
